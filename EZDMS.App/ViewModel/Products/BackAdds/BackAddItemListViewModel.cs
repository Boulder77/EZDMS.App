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
using Prism.Commands;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for the overview back add list
    /// <summary>
    public class BackAddItemListViewModel : BaseViewModel
    {

        #region Protected Members

        /// <summary>
        /// The front add items for the list
        /// </summary>
        protected ObservableCollection<BackAddItemViewModel> mItems;

        /// <summary>
        /// The front add datamodel list
        /// </summary>
        protected List<SystemBackAddsDataModel> mAddList;


        private BackAddItemViewModel mSelectedItem;

        

        #endregion

        #region Public Properties

        /// <summary>
        /// The front add items list
        /// </summary>
        public ObservableCollection<BackAddItemViewModel> Items
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
        public List<SystemBackAddsDataModel> AddList
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
                    CurrentAddList = new List<SystemBackAddsDataModel>(mAddList);
            }
        }

        /// <summary>
        /// The chat thread items for the list that include any search filtering
        /// </summary>
        public List<SystemBackAddsDataModel> CurrentAddList { get; set; }

        /// <summary>
        /// The selected front add from the list
        /// </summary>
        public BackAddItemViewModel SelectedItem
        {

            get => mSelectedItem;

            set
            {
                // Make sure list has changed
                if (mSelectedItem == value)
                    return;

                if (value != null)
                // Update value
                    mSelectedItem = value;

            }
        }


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


        public DelegateCommand<object> DeleteCommand { get; set; }



        #region Constructor

        public BackAddItemListViewModel()
        {
            DeleteCommand = new DelegateCommand<object>(argument =>
            {
                var item = argument as BackAddItemViewModel;

                CurrentAddList.Add(item.SelectedItem);

                Items.Remove(item);

                // Set last item flag
                if (Items.Count < 10)
                    Items.Last().LastItem = true;

                // Update the total
                UpdateTotalRetail();

            });

            LoadAddsAsync();

        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Add new back add item to the item list
        /// </summary>
        public void Add()
        {

            // Check to make sure list is not null
            if (Items == null)
                Items = new ObservableCollection<BackAddItemViewModel>();

            // New Back Add
            var backAdd = new BackAddItemViewModel
            {
                Items = new ObservableCollection<SystemBackAddsDataModel>(CurrentAddList),
                UpdateAction = UpdateTotalRetailAsync,
                AddCommand = new RelayCommand(Add),
                DeleteCommand = DeleteCommand,
               
                LastItem = Items.Count >= 9 ? false : true,
               
            };


            //Items.Where(c => c.LastItem).ToList().Select(c => { c.LastItem = false; return c; });
            Items.Where(c => c.LastItem).ToList().SetValue(c => c.LastItem = false);

            // Add item to both lists
            Items.Add(backAdd);            

        }

        /// <summary>
        /// Delete new front add item to the item list
        /// </summary>
        public void Delete()
        {
                        

            // Set last item flag
            if (Items.Count < 10)
                Items.Last().LastItem = true;

            // Update the total
            UpdateTotalRetail();

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
            AddList = await ClientDataStore.GetSystemBackAddsAsync();
                           
            // Get the deal front adds items
            var salesBackAdds = await ClientDataStore.GetSalesBackAddsAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

            // Load adds to items collection
            if (salesBackAdds == null)
                Add();
            else
                LoadSavedAdds(salesBackAdds);

            await Task.Delay(1);

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

                var newSalesAdds = CreateSalesBackAdds(Items.ToList());

                // Update the data store
                if (salesAdds == null)
                    await ClientDataStore.AddNewSalesRecordAsync(newSalesAdds, DbTableNames.SalesBackAdds);
                else
                    await ClientDataStore.SaveSalesRecordAsync(newSalesAdds, DbTableNames.SalesBackAdds);

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
        /// <param name="salesBackAdds"></param>
        /// <returns></returns>
       private void LoadSavedAdds(SalesBackAddsDataModel salesAdds)
        {

            if (Items == null)
                Items = new ObservableCollection<BackAddItemViewModel>();


            var i = 0;
            var done = false;


            do
            {
                i++;
                if (salesAdds.GetValObjDy($"BackAdd{i.ToString()}ID") != null)
                {
                    var add = new BackAddItemViewModel
                    {
                        Items = new ObservableCollection<SystemBackAddsDataModel>(AddList),
                        SelectedItem = CurrentAddList.FirstOrDefault(item => item.Id == salesAdds.GetValObjDy($"BackAdd{i.ToString()}ID").ToString()),

                        Retail = (decimal)salesAdds.GetValObjDy($"BackAdd{i.ToString()}Retail"),
                        Cost = (decimal)salesAdds.GetValObjDy($"BackAdd{i.ToString()}Cost"),
                        InPayment = (bool)salesAdds.GetValObjDy($"BackAdd{i.ToString()}InPayment"),
                        Taxable = (bool)salesAdds.GetValObjDy($"BackAdd{i.ToString()}InPayment"),
                        UpdateAction = UpdateTotalRetailAsync,
                        AddCommand = new RelayCommand(Add),
                        


                    };
                    Items.Add(add);
                    CurrentAddList.Remove(add.SelectedItem);
                }
                else
                    done = true;

               

            } while (done == false);

            // Set last item flag
            if (Items.Count <10)           
                Items.Last().LastItem=true;

            // Update the total
            UpdateTotalRetail();

        }
                       
        

        /// <summary>
        /// Create a sales back add data model
        /// </summary>
        /// <param name="adds"></param>
        /// <returns>SalesBackAddsDataModel</returns>
        private SalesBackAddsDataModel CreateSalesBackAdds(List<BackAddItemViewModel> adds)
        {

            // check null
            if (adds == null)
                return null;

            var salesBackAdds = new SalesBackAddsDataModel
            {
                DealNumber = ViewModelSalesFinance.SalesFinanceDeal.DealNumber,

            };

            // Loop thru the sales adds and update datamodel
            var i = 0;
            foreach (var add in adds)
            {
                
                i++;

                salesBackAdds.SetValObjDy($"BackAdd{i.ToString()}ID", add.SelectedItem.Id);
                salesBackAdds.SetValObjDy($"BackAdd{i.ToString()}Description", add?.SelectedItem.Name);
                salesBackAdds.SetValObjDy($"BackAdd{i.ToString()}Retail", add.Retail);
                salesBackAdds.SetValObjDy($"BackAdd{i.ToString()}Cost", add.Cost);
                salesBackAdds.SetValObjDy($"BackAdd{i.ToString()}InPayment", add.InPayment);
                salesBackAdds.SetValObjDy($"BackAdd{i.ToString()}IsTaxable1", add.Taxable);

            }

            return salesBackAdds;
                        
         }

    }


        #endregion

   
}
