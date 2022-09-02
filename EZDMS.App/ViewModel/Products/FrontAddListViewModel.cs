
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
        protected List<FrontAddsDataModel> mFrontAddList;

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

                if (value != null)
                    // Add a new blank front add
                   LoadAddsAsync();

            }
        }

        /// <summary>
        /// The front add datamodel list
        /// </summary>
        public List<FrontAddsDataModel> FrontAddList
        {
            get => mFrontAddList;
            set
            {
                // Make sure list has changed
                if (mFrontAddList == value)
                    return;

                // Update value
                mFrontAddList = value;

                if (mFrontAddList != null)
                    // Update filtered list to match
                    FilteredFrontAddList = new List<FrontAddsDataModel>(mFrontAddList);
            }
        }

        /// <summary>
        /// The chat thread items for the list that include any search filtering
        /// </summary>
        public List<FrontAddsDataModel> FilteredFrontAddList { get; set; }



        /// <summary>
        /// The total retail of all front adds 
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// The flag indicating that the items are loading
        /// </summary>
        public bool Loading { get; set; }


        #endregion

        #region Constructor

        public FrontAddListViewModel()
        {


            


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
                Items = new ObservableCollection<FrontAddsDataModel>(FilteredFrontAddList),
                UpdateAction = UpdateTotalRetailAsync,
               
            };

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
                Items = new ObservableCollection<FrontAddsDataModel>(FilteredFrontAddList),

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
            FrontAddList = await ClientDataStore.GetFrontAddsAsync();
                           
            // Get the deal front adds items
            var salesFrontAdds = await ClientDataStore.GetSalesFrontAddsAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

            if (salesFrontAdds == null)
                Add();
            else
                LoadSavedAdds(salesFrontAdds);

           
            
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
       private void LoadSavedAdds(SalesFrontAddsDataModel salesFrontAdds)
        {
           
            if (salesFrontAdds.FrontAdd1Retail > 0)
            {
                var frontAdd = new FrontAddItemViewModel
                {
                    Items = new ObservableCollection<FrontAddsDataModel>(FrontAddList),
                    SelectedItem = FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd1ID),
                    Retail = salesFrontAdds.FrontAdd1Retail,
                    Cost = salesFrontAdds.FrontAdd1Cost,
                    InPayment = salesFrontAdds.FrontAdd1InPayment,
                    Taxable = salesFrontAdds.FrontAdd1IsTaxable1,
                    UpdateAction = UpdateTotalRetailAsync
                };

                Items.Add(frontAdd);
                FrontAddList.Remove(frontAdd.SelectedItem);

            }

            if (salesFrontAdds.FrontAdd2Retail > 0)
            {
                var frontAdd = new FrontAddItemViewModel
                {
                    Items = new ObservableCollection<FrontAddsDataModel>(FrontAddList),
                    SelectedItem = FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd2ID),
                    Retail = salesFrontAdds.FrontAdd2Retail,
                    Cost = salesFrontAdds.FrontAdd2Cost,
                    InPayment = salesFrontAdds.FrontAdd2InPayment,
                    Taxable = salesFrontAdds.FrontAdd2IsTaxable1,
                    UpdateAction = UpdateTotalRetailAsync
                };

                Items.Add(frontAdd);
                FrontAddList.Remove(frontAdd.SelectedItem);

            }

            if (salesFrontAdds.FrontAdd3Retail > 0)
            {
                var frontAdd = new FrontAddItemViewModel
                {
                    Items = new ObservableCollection<FrontAddsDataModel>(FrontAddList),
                    SelectedItem = FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd3ID),
                    Retail = salesFrontAdds.FrontAdd3Retail,
                    Cost = salesFrontAdds.FrontAdd3Cost,
                    InPayment = salesFrontAdds.FrontAdd3InPayment,
                    Taxable = salesFrontAdds.FrontAdd3IsTaxable1,
                    UpdateAction = UpdateTotalRetailAsync
                };

                Items.Add(frontAdd);
                FrontAddList.Remove(frontAdd.SelectedItem);

            }

            if (salesFrontAdds.FrontAdd4Retail > 0)
            {
                var frontAdd = new FrontAddItemViewModel
                {
                    Items = new ObservableCollection<FrontAddsDataModel>(FrontAddList),
                    SelectedItem = FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd4ID),
                    Retail = salesFrontAdds.FrontAdd4Retail,
                    Cost = salesFrontAdds.FrontAdd4Cost,
                    InPayment = salesFrontAdds.FrontAdd4InPayment,
                    Taxable = salesFrontAdds.FrontAdd4IsTaxable1,
                    UpdateAction = UpdateTotalRetailAsync
                };

                Items.Add(frontAdd);
                FrontAddList.Remove(frontAdd.SelectedItem);

            }

            if (salesFrontAdds.FrontAdd5Retail > 0)
            {
                var frontAdd = new FrontAddItemViewModel
                {
                    Items = new ObservableCollection<FrontAddsDataModel>(FrontAddList),
                    SelectedItem = FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd5ID),
                    Retail = salesFrontAdds.FrontAdd5Retail,
                    Cost = salesFrontAdds.FrontAdd5Cost,
                    InPayment = salesFrontAdds.FrontAdd5InPayment,
                    Taxable = salesFrontAdds.FrontAdd5IsTaxable1,
                    UpdateAction = UpdateTotalRetailAsync
                };

                Items.Add(frontAdd);
                FrontAddList.Remove(frontAdd.SelectedItem);

            }


            if (salesFrontAdds.FrontAdd6Retail > 0)
            {
                var frontAdd = new FrontAddItemViewModel
                {
                    Items = new ObservableCollection<FrontAddsDataModel>(FrontAddList),
                    SelectedItem = FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd6ID),
                    Retail = salesFrontAdds.FrontAdd6Retail,
                    Cost = salesFrontAdds.FrontAdd6Cost,
                    InPayment = salesFrontAdds.FrontAdd6InPayment,
                    Taxable = salesFrontAdds.FrontAdd6IsTaxable1,
                    UpdateAction = UpdateTotalRetailAsync
                };

                Items.Add(frontAdd);
                FrontAddList.Remove(frontAdd.SelectedItem);

            }

            if (salesFrontAdds.FrontAdd7Retail > 0)
            {
                var frontAdd = new FrontAddItemViewModel
                {
                    Items = new ObservableCollection<FrontAddsDataModel>(FrontAddList),
                    SelectedItem = FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd7ID),
                    Retail = salesFrontAdds.FrontAdd7Retail,
                    Cost = salesFrontAdds.FrontAdd7Cost,
                    InPayment = salesFrontAdds.FrontAdd7InPayment,
                    Taxable = salesFrontAdds.FrontAdd7IsTaxable1,
                    UpdateAction = UpdateTotalRetailAsync
                };

                Items.Add(frontAdd);
                FrontAddList.Remove(frontAdd.SelectedItem);

            }

            if (salesFrontAdds.FrontAdd8Retail > 0)
            {
                var frontAdd = new FrontAddItemViewModel
                {
                    Items = new ObservableCollection<FrontAddsDataModel>(FrontAddList),
                    SelectedItem = FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd8ID),
                    Retail = salesFrontAdds.FrontAdd8Retail,
                    Cost = salesFrontAdds.FrontAdd8Cost,
                    InPayment = salesFrontAdds.FrontAdd8InPayment,
                    Taxable = salesFrontAdds.FrontAdd8IsTaxable1,
                    UpdateAction = UpdateTotalRetailAsync
                };

                Items.Add(frontAdd);
                FrontAddList.Remove(frontAdd.SelectedItem);

            }

            if (salesFrontAdds.FrontAdd9Retail > 0)
            {
                var frontAdd = new FrontAddItemViewModel
                {
                    Items = new ObservableCollection<FrontAddsDataModel>(FrontAddList),
                    SelectedItem = FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd9ID),
                    Retail = salesFrontAdds.FrontAdd9Retail,
                    Cost = salesFrontAdds.FrontAdd9Cost,
                    InPayment = salesFrontAdds.FrontAdd9InPayment,
                    Taxable = salesFrontAdds.FrontAdd9IsTaxable1,
                    UpdateAction = UpdateTotalRetailAsync
                };

                Items.Add(frontAdd);
                FrontAddList.Remove(frontAdd.SelectedItem);

            }

            if (salesFrontAdds.FrontAdd10Retail > 0)
            {
                var frontAdd = new FrontAddItemViewModel
                {
                    Items = new ObservableCollection<FrontAddsDataModel>(FrontAddList),
                    SelectedItem = FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd10ID),
                    Retail = salesFrontAdds.FrontAdd10Retail,
                    Cost = salesFrontAdds.FrontAdd10Cost,
                    InPayment = salesFrontAdds.FrontAdd10InPayment,
                    Taxable = salesFrontAdds.FrontAdd10IsTaxable1,
                    UpdateAction = UpdateTotalRetailAsync
                };

                Items.Add(frontAdd);
                FrontAddList.Remove(frontAdd.SelectedItem);

            }
                       
        }


        #endregion

    }
}
