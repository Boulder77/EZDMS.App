using Dna;
using EZDMS.App.Core;
using static EZDMS.App.Core.CoreDI;
using static EZDMS.App.DI;
using static Dna.FrameworkDI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for the overview front add list
    /// <summary>
    public class FrontAddListViewModel : BaseViewModel
    {

        #region Protected Members

        /// <summary>
        /// The front add items for the list
        /// </summary>
        protected ObservableCollection<FrontAddItemViewModel> mItems;

        /// <summary>
        /// The front add datamodel list
        /// </summary>
        protected List<FrontAddsDataModel> mAddList;

        

        #endregion

        #region Public Properties

        /// <summary>
        /// The front add items list
        /// </summary>
        public ObservableCollection<FrontAddItemViewModel> Items
        {

            get => mItems;

            set
            {
                // Make sure list has changed
                if (mItems == value)
                    return;

                // Update value
                mItems = value;

            }
        }

        /// <summary>
        /// The front add datamodel list
        /// </summary>
        public List<FrontAddsDataModel> AddList
        {
            get => mAddList;
            set
            {
                // Make sure list has changed
                if (mAddList == value)
                    return;

                // Update value
                mAddList = value;

                if (mAddList != null)
                    // Update filtered list to match
                    CurrentAddList = new List<FrontAddsDataModel>(mAddList);
            }
        }

        /// <summary>
        /// The chat thread items for the list that include any search filtering
        /// </summary>
        public List<FrontAddsDataModel> CurrentAddList { get; set; }



        /// <summary>
        /// The total retail of all front adds 
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// The flag indicating that the items are loading
        /// </summary>
        public bool Loading { get; set; }


        /// <summary>
        /// The flag indicating that the items are saving
        /// </summary>
        public bool Saving { get; set; }


        #endregion

        #region Constructor

        public FrontAddListViewModel()
        {

            LoadAddsAsync();

        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Add new front add item to the item list
        /// </summary>
        public void Add()
        {

            // Check to make sure list is not null
            if (Items == null)
                Items = new ObservableCollection<FrontAddItemViewModel>();

            // New Front Add
            var frontadd = new FrontAddItemViewModel
            {
                Items = new ObservableCollection<FrontAddsDataModel>(CurrentAddList),
                UpdateAction = UpdateTotalRetailAsync,
                AddCommand = new RelayCommand(Add),
                LastItem = Items.Count >= 9 ? false : true,
               
            };


            //Items.Where(c => c.LastItem).ToList().Select(c => { c.LastItem = false; return c; });
            Items.Where(c => c.LastItem).ToList().SetValue(c => c.LastItem = false);

            // Add item to both lists
            Items.Add(frontadd);            

        }

        /// <summary>
        /// Add new front add item to the item list
        /// </summary>
        public void Delete()
        {

            // Ensure the item lists are not null
            if (Items == null)
                Items = new ObservableCollection<FrontAddItemViewModel>();

           

            // New Front Add
            var frontadd = new FrontAddItemViewModel
            {
                Items = new ObservableCollection<FrontAddsDataModel>(CurrentAddList),

            };

            // Add item to both lists
            Items.Add(frontadd);
           
        }

        #endregion

        #region Helper Tasks


        /// <summary>
        /// Initialize products view models and controls 
        /// </summary>
        /// <returns></returns>
        public async void LoadAddsAsync()
        {
            
            // Get all the front adds for the list
            AddList = await ClientDataStore.GetFrontAddsAsync();
                           
            // Get the deal front adds items
            var salesFrontAdds = await ClientDataStore.GetSalesFrontAddsAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

            // 
            if (salesFrontAdds == null)
                Add();
            else
                LoadSavedAdds(salesFrontAdds);

           
            
        }

        /// <summary>
        /// Initialize products view models and controls 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAddsAsync()
        {

            // Store the result of a commit call
            var result = default(bool);

           return result = await RunCommandAsync(() => Saving, async () =>
            {

                // Get the deal front adds items
                var salesAdds = await ClientDataStore.GetSalesFrontAddsAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

                var newSalesAdds = CreateSalesFrontAdds(Items.ToList());

                // Update the data store
                if (salesAdds == null)
                    await ClientDataStore.AddNewSalesRecordAsync(newSalesAdds, DbTableNames.SalesFrontAdds);
                else
                    await ClientDataStore.SaveSalesRecordAsync(newSalesAdds, DbTableNames.SalesFrontAdds);

                return true;
            
            });

           
            
        }



        public async Task<bool> UpdateTotalRetailAsync()
        {

            UpdateTotalRetail();

            await Task.Delay(1);
            return true;

        }



        /// <summary>
        /// Update the total retail price
        /// </summary>
        private void UpdateTotalRetail()
        {

            Total = Items.Sum(item => item.Retail);
        }

        /// <summary>
        /// Returns a list of a saved front add items
        /// </summary>
        /// <param name="salesFrontAdds"></param>
        /// <returns></returns>
       private void LoadSavedAdds(SalesFrontAddsDataModel salesAdds)
        {

            if (Items == null)
                Items = new ObservableCollection<FrontAddItemViewModel>();


            var i = 0;
            var done = false;


            do
            {
                i++;
                if (salesAdds.GetValObjDy($"FrontAdd{i.ToString()}ID") != null)
                {
                    var add = new FrontAddItemViewModel
                    {
                        Items = new ObservableCollection<FrontAddsDataModel>(AddList),
                        SelectedItem = CurrentAddList.FirstOrDefault(item => item.Id == salesAdds.GetValObjDy($"FrontAdd{i.ToString()}ID").ToString()),

                        Retail = (decimal)salesAdds.GetValObjDy($"FrontAdd{i.ToString()}Retail"),
                        Cost = (decimal)salesAdds.GetValObjDy($"FrontAdd{i.ToString()}Cost"),
                        InPayment = (bool)salesAdds.GetValObjDy($"FrontAdd{i.ToString()}InPayment"),
                        Taxable = (bool)salesAdds.GetValObjDy($"FrontAdd{i.ToString()}InPayment"),
                        UpdateAction = UpdateTotalRetailAsync
                    };
                    Items.Add(add);
                    CurrentAddList.Remove(add.SelectedItem);
                }
                else
                    done = true;

               

            } while (done == false);


        }
                       
        

        /// <summary>
        /// Create a sales front add data model
        /// </summary>
        /// <param name="adds"></param>
        /// <returns>SalesFrontAddsDataModel</returns>
        private SalesFrontAddsDataModel CreateSalesFrontAdds(List<FrontAddItemViewModel> adds)
        {

            // check null
            if (adds == null)
                return null;

            var salesFrontAdds = new SalesFrontAddsDataModel
            {
                DealNumber = ViewModelSalesFinance.SalesFinanceDeal.DealNumber,

            };

            var i = 1;
            foreach (var add in adds)
            {
                
                salesFrontAdds.SetValObjDy($"FrontAdd{i.ToString()}ID", add.SelectedItem.Id);
                salesFrontAdds.SetValObjDy($"FrontAdd{i.ToString()}Description", add?.SelectedItem.Name);
                salesFrontAdds.SetValObjDy($"FrontAdd{i.ToString()}Retail", add.Retail);
                salesFrontAdds.SetValObjDy($"FrontAdd{i.ToString()}Cost", add.Cost);
                salesFrontAdds.SetValObjDy($"FrontAdd{i.ToString()}InPayment", add.InPayment);
                salesFrontAdds.SetValObjDy($"FrontAdd{i.ToString()}IsTaxable1", add.Taxable);

                i++;

            }

            return salesFrontAdds;
                        
         }

    }


        #endregion

   
}
