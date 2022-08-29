using Dna;
using EZDMS.App.Core;
using static EZDMS.App.Core.CoreDI;
using System.Windows.Input;
using static EZDMS.App.DI;
using static Dna.FrameworkDI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace EZDMS.App
{
    /// <summary>
    /// The view model for the <see cref="DialogFrontBackAdds"/>
    /// <summary>
    public class FrontBackAddsDialogViewModel:BaseDialogViewModel
    {
                
        #region Public Properties

        /// <summary>
        /// The sales maintenance data model
        /// </summary>
        public FrontAddListViewModel FrontAdds { get; set; }

        /// <summary>
        /// The text for the total front adds 
        /// </summary>
        public decimal TotalFrontAdds { get; set; }

        /// <summary>
        /// The text for the total back adds 
        /// </summary>
        public decimal TotalBackAdds { get; set; }

        /// <summary>
        /// Indicates if there is a save action
        /// </summary>
        public bool Saving { get; set; }

        /// <summary>
        /// Indicates if the dialog has loaded
        /// </summary>
        public bool AddsLoading { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command to save the info
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        /// The command to cancel the dialog
        /// </summary>
        public ICommand CancelCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FrontBackAddsDialogViewModel()
        {
            // Create commands
            //SaveCommand = new RelayCommand(async () => await SaveProductsAsync());
                
            Task.Run(LoadSalesFrontAddsAsync);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Add new front add item to the item list
        /// </summary>
        public async Task AddFrontAddAsync()
        {

            // Ensure the item lists are not null
            if (FrontAdds.FrontAddItems == null)
                FrontAdds.FrontAddItems = new ObservableCollection<FrontAddItemViewModel>();

            // New Front Add
            var frontadd = new FrontAddItemViewModel
            {
                Items = new ObservableCollection<FrontAddsDataModel>(FrontAdds.FilteredFrontAddList),
                UpdateAction = FrontAdds.UpdateTotalRetailAsync
            };

            // Add item to both lists
            FrontAdds.FrontAddItems.Add(frontadd);

            //FrontAdds.Add();


            await Task.Delay(1);

        }

        /// <summary>
        /// Add new front add item to the item list
        /// </summary>
        public void DeleteFrontAdd()
        {

            
        }





        /// <summary>
        /// Initialize products view models and controls 
        /// </summary>
        /// <returns></returns>
        public async Task LoadSalesFrontAddsAsync()
        {
            await RunCommandAsync(() => AddsLoading, async () =>
            {
                FrontAdds = new FrontAddListViewModel
                {

                    FrontAddList = await ClientDataStore.GetFrontAddsAsync(),
                    FrontAddItems = new ObservableCollection<FrontAddItemViewModel>(),


            };

                //await FrontAdds.LoadAddsAsync();



                // Get the deal front adds items
                var salesFrontAdds = await ClientDataStore.GetSalesFrontAddsAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

                // Check for stored sales front add items
                if (salesFrontAdds == null)
                {
                    // Add a blank front add item
                    await AddFrontAddAsync();
                    await Task.Delay(1);
                    return;

                }

                if (salesFrontAdds.FrontAdd1Retail > 0)
                {
                    var frontAdd = new FrontAddItemViewModel
                    {
                        Items = new ObservableCollection<FrontAddsDataModel>(FrontAdds.FrontAddList),
                        SelectedItem = FrontAdds.FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd1ID),
                        Retail = salesFrontAdds.FrontAdd1Retail,
                        Cost = salesFrontAdds.FrontAdd1Cost,
                        InPayment = salesFrontAdds.FrontAdd1InPayment,
                        Taxable = salesFrontAdds.FrontAdd1IsTaxable1,
                        UpdateAction = FrontAdds.UpdateTotalRetailAsync
                    };

                    FrontAdds.FrontAddItems.Add(frontAdd);
                    FrontAdds.FrontAddList.Remove(frontAdd.SelectedItem);

                }

                if (salesFrontAdds.FrontAdd2Retail > 0)
                {
                    var frontAdd = new FrontAddItemViewModel
                    {
                        Items = new ObservableCollection<FrontAddsDataModel>(FrontAdds.FrontAddList),
                        SelectedItem = FrontAdds.FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd2ID),
                        Retail = salesFrontAdds.FrontAdd2Retail,
                        Cost = salesFrontAdds.FrontAdd2Cost,
                        InPayment = salesFrontAdds.FrontAdd2InPayment,
                        Taxable = salesFrontAdds.FrontAdd2IsTaxable1,
                        UpdateAction = FrontAdds.UpdateTotalRetailAsync
                    };

                    FrontAdds.FrontAddItems.Add(frontAdd);
                    FrontAdds.FrontAddList.Remove(frontAdd.SelectedItem);

                }

                if (salesFrontAdds.FrontAdd3Retail > 0)
                {
                    var frontAdd = new FrontAddItemViewModel
                    {
                        Items = new ObservableCollection<FrontAddsDataModel>(FrontAdds.FrontAddList),
                        SelectedItem = FrontAdds.FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd3ID),
                        Retail = salesFrontAdds.FrontAdd3Retail,
                        Cost = salesFrontAdds.FrontAdd3Cost,
                        InPayment = salesFrontAdds.FrontAdd3InPayment,
                        Taxable = salesFrontAdds.FrontAdd3IsTaxable1,
                        UpdateAction = FrontAdds.UpdateTotalRetailAsync
                    };

                    FrontAdds.FrontAddItems.Add(frontAdd);
                    FrontAdds.FrontAddList.Remove(frontAdd.SelectedItem);

                }

                if (salesFrontAdds.FrontAdd4Retail > 0)
                {
                    var frontAdd = new FrontAddItemViewModel
                    {
                        Items = new ObservableCollection<FrontAddsDataModel>(FrontAdds.FrontAddList),
                        SelectedItem = FrontAdds.FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd4ID),
                        Retail = salesFrontAdds.FrontAdd4Retail,
                        Cost = salesFrontAdds.FrontAdd4Cost,
                        InPayment = salesFrontAdds.FrontAdd4InPayment,
                        Taxable = salesFrontAdds.FrontAdd4IsTaxable1,
                        UpdateAction = FrontAdds.UpdateTotalRetailAsync
                    };

                    FrontAdds.FrontAddItems.Add(frontAdd);
                    FrontAdds.FrontAddList.Remove(frontAdd.SelectedItem);

                }

                if (salesFrontAdds.FrontAdd5Retail > 0)
                {
                    var frontAdd = new FrontAddItemViewModel
                    {
                        Items = new ObservableCollection<FrontAddsDataModel>(FrontAdds.FrontAddList),
                        SelectedItem = FrontAdds.FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd5ID),
                        Retail = salesFrontAdds.FrontAdd5Retail,
                        Cost = salesFrontAdds.FrontAdd5Cost,
                        InPayment = salesFrontAdds.FrontAdd5InPayment,
                        Taxable = salesFrontAdds.FrontAdd5IsTaxable1,
                        UpdateAction = FrontAdds.UpdateTotalRetailAsync
                    };

                    FrontAdds.FrontAddItems.Add(frontAdd);
                    FrontAdds.FrontAddList.Remove(frontAdd.SelectedItem);

                }


                if (salesFrontAdds.FrontAdd6Retail > 0)
                {
                    var frontAdd = new FrontAddItemViewModel
                    {
                        Items = new ObservableCollection<FrontAddsDataModel>(FrontAdds.FrontAddList),
                        SelectedItem = FrontAdds.FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd6ID),
                        Retail = salesFrontAdds.FrontAdd6Retail,
                        Cost = salesFrontAdds.FrontAdd6Cost,
                        InPayment = salesFrontAdds.FrontAdd6InPayment,
                        Taxable = salesFrontAdds.FrontAdd6IsTaxable1,
                        UpdateAction = FrontAdds.UpdateTotalRetailAsync
                    };

                    FrontAdds.FrontAddItems.Add(frontAdd);
                    FrontAdds.FrontAddList.Remove(frontAdd.SelectedItem);

                }

                if (salesFrontAdds.FrontAdd7Retail > 0)
                {
                    var frontAdd = new FrontAddItemViewModel
                    {
                        Items = new ObservableCollection<FrontAddsDataModel>(FrontAdds.FrontAddList),
                        SelectedItem = FrontAdds.FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd7ID),
                        Retail = salesFrontAdds.FrontAdd7Retail,
                        Cost = salesFrontAdds.FrontAdd7Cost,
                        InPayment = salesFrontAdds.FrontAdd7InPayment,
                        Taxable = salesFrontAdds.FrontAdd7IsTaxable1,
                        UpdateAction = FrontAdds.UpdateTotalRetailAsync
                    };

                    FrontAdds.FrontAddItems.Add(frontAdd);
                    FrontAdds.FrontAddList.Remove(frontAdd.SelectedItem);

                }

                if (salesFrontAdds.FrontAdd8Retail > 0)
                {
                    var frontAdd = new FrontAddItemViewModel
                    {
                        Items = new ObservableCollection<FrontAddsDataModel>(FrontAdds.FrontAddList),
                        SelectedItem = FrontAdds.FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd8ID),
                        Retail = salesFrontAdds.FrontAdd8Retail,
                        Cost = salesFrontAdds.FrontAdd8Cost,
                        InPayment = salesFrontAdds.FrontAdd8InPayment,
                        Taxable = salesFrontAdds.FrontAdd8IsTaxable1,
                        UpdateAction = FrontAdds.UpdateTotalRetailAsync
                    };

                    FrontAdds.FrontAddItems.Add(frontAdd);
                    FrontAdds.FrontAddList.Remove(frontAdd.SelectedItem);

                }

                if (salesFrontAdds.FrontAdd9Retail > 0)
                {
                    var frontAdd = new FrontAddItemViewModel
                    {
                        Items = new ObservableCollection<FrontAddsDataModel>(FrontAdds.FrontAddList),
                        SelectedItem = FrontAdds.FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd9ID),
                        Retail = salesFrontAdds.FrontAdd9Retail,
                        Cost = salesFrontAdds.FrontAdd9Cost,
                        InPayment = salesFrontAdds.FrontAdd9InPayment,
                        Taxable = salesFrontAdds.FrontAdd9IsTaxable1,
                        UpdateAction = FrontAdds.UpdateTotalRetailAsync
                    };

                    FrontAdds.FrontAddItems.Add(frontAdd);
                    FrontAdds.FrontAddList.Remove(frontAdd.SelectedItem);

                }

                if (salesFrontAdds.FrontAdd10Retail > 0)
                {
                    var frontAdd = new FrontAddItemViewModel
                    {
                        Items = new ObservableCollection<FrontAddsDataModel>(FrontAdds.FrontAddList),
                        SelectedItem = FrontAdds.FilteredFrontAddList.FirstOrDefault(item => item.Id == salesFrontAdds.FrontAdd10ID),
                        Retail = salesFrontAdds.FrontAdd10Retail,
                        Cost = salesFrontAdds.FrontAdd10Cost,
                        InPayment = salesFrontAdds.FrontAdd10InPayment,
                        Taxable = salesFrontAdds.FrontAdd10IsTaxable1,
                        UpdateAction = FrontAdds.UpdateTotalRetailAsync
                    };

                    FrontAdds.FrontAddItems.Add(frontAdd);
                    FrontAdds.FrontAddList.Remove(frontAdd.SelectedItem);

                }

        });


    }

        #endregion


    public async Task<bool> UpdateTotalFrontAddsRetailAsync()
    {

        UpdateTotalFrontAddsRetail();

        // Lock this command to ignore any other requests while processing
        await Task.Delay(1);
        return true;

    }



        /// <summary>
        /// Update the total retail price
        /// </summary>
        private void UpdateTotalFrontAddsRetail()
        {

            TotalFrontAdds = FrontAdds.FrontAddItems.Sum(item => item.Retail);
        }


    }
}
