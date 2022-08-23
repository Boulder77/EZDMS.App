using Dna;
using EZDMS.App.Core;
using static EZDMS.App.Core.CoreDI;
using static EZDMS.App.DI;
using static Dna.FrameworkDI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Windows.Input;


namespace EZDMS.App
{
    /// <summary>
    /// The view model for the <see cref="DialogProductsSales"/>
    /// <summary>
    public class ProductsSalesDialogViewModel:BaseDialogViewModel
    {

        #region Private Members

        /// <summary>
        /// The list of all the product providers
        /// </summary>
        private List<CoverageProviderDataModel> mProviders;

        /// <summary>
        /// The list of all the product plans
        /// </summary>
        private List<CoveragePlanDataModel> mPlans;
               

        #endregion

        #region Public Properties

        /// <summary>
        /// The list of all the product providers
        /// </summary>
        public List<CoverageProviderDataModel> Providers
        {

            get => mProviders;

            set
            {
                // Make sure list has changed
                if (mProviders == value)
                    return;

                // Update value
                mProviders = value;

            }
        }
               
        /// <summary>
        /// The list of all the product plans
        /// </summary>
        public List<CoveragePlanDataModel> Plans
        {

            get => mPlans;

            set
            {
                // Make sure list has changed
                if (mPlans == value)
                    return;

                // Update value
                mPlans = value;

            }
        }

        /// <summary>
        /// The sales maintenance data model
        /// </summary>
        public SalesMaintenanceDataModel SalesMaintenance { get; set; }
        
        /// <summary>
        /// The sales service data model
        /// </summary>
        public SalesServiceDataModel SalesService { get; set; }
        
        /// <summary>
        /// The sales warranty data model
        /// </summary>
        public SalesWarrantyDataModel SalesWarranty { get; set; }
        
        /// <summary>
        /// The sales gap data model
        /// </summary>
        public SalesGapDataModel SalesGap { get; set; }
        
        /// <summary>
        /// The view model for the service contract 
        /// </summary>
        public ProductItemViewModel Service { get; set; }
        
        /// <summary>
        /// The view model for the warranty
        /// </summary>
        public ProductItemViewModel Warranty { get; set; }

        /// <summary>
        /// The view model for the maintenance
        /// </summary>
        public ProductItemViewModel Maintenance { get; set; }

        /// <summary>
        /// The view model for Gap
        /// </summary>
        public ProductItemViewModel Gap { get; set; }

        /// <summary>
        /// The text for the total retail 
        /// </summary>
        public DecimalInputViewModel TotalRetail { get; set; }

        /// <summary>
        /// Indicates if there is a save action
        /// </summary>
        public bool Saving { get; set; }

        /// <summary>
        /// Indicates if the dialog has loaded
        /// </summary>
        public bool ProductsLoading { get; set; }

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
        public ProductsSalesDialogViewModel()
        {
            // Create commands
            SaveCommand = new RelayCommand(async () => await SaveProductsAsync());
                
            Task.Run(LoadProductsAsync);
        }

        #endregion

        #region Public Commands

        /// <summary>
        /// Initialize products view models and controls 
        /// </summary>
        /// <returns></returns>
        public async Task LoadProductsAsync()
        {
            await RunCommandAsync(() => ProductsLoading, async () =>
            {
                // Get provider list from data store
                Providers = await ClientDataStore.GetCoverageProvidersAsync();

                // Get plan list from data store
                Plans = await ClientDataStore.GetCoveragePlansAsync();

                // Set product items view model default
                SetProductItems();
                
                // Get service contract from data store
                SalesService = await ClientDataStore.GetSalesServiceAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);
                
                if (SalesService != null)
                    // Update service view model
                    UpdateServiceVM(SalesService);

                // Get the maintenance contract from data store
                SalesMaintenance = await ClientDataStore.GetSalesMaintenanceAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);
                
                if (SalesMaintenance != null)
                    // Update maintenance view model
                    UpdateMaintenanceVM(SalesMaintenance);

                // Get the warranty contract from data store
                SalesWarranty = await ClientDataStore.GetSalesWarrantyAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

                if (SalesWarranty != null)
                    // Update warranty view model
                    UpdateWarrantyVM(SalesWarranty);

                // Get the gap contract from data store
                SalesGap = await ClientDataStore.GetSalesGapAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

                if (SalesGap != null)
                    // Update gap view model
                    UpdateGapVM(SalesGap);

            });


        }

        public async Task SaveProductsAsync()
        {
            await RunCommandAsync(() => Saving, async () =>
            {

                // Get the service record
                SalesService = await ClientDataStore.GetSalesServiceAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

                // Check if plan was selected
                if (Service.SelectedPlan !=null || SalesService != null)
                {
                
                    // Check if record exists
                    if (SalesService == null)
                    {
                        SalesService = new SalesServiceDataModel
                        {
                            DealNumber = ViewModelSalesFinance.SalesFinanceDeal.DealNumber,

                        };

                        await ClientDataStore.AddNewSalesRecordAsync(SalesService, DbTableNames.SalesService);

                    }
                    // Update data model
                    await Task.Run(UpdateServiceDM);

                    // Save to the data store                    
                    await ClientDataStore.SaveSalesRecordAsync(SalesService, DbTableNames.SalesService);

                    // Update Sales finance deal view model
                    ViewModelSalesFinance.SalesFinanceDeal.ServiceContract = SalesService.Retail;
                }

                // Get the stored record
                SalesMaintenance = await ClientDataStore.GetSalesMaintenanceAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);


                // Check if plan was selected
                if (Maintenance.SelectedPlan != null || SalesMaintenance !=null)
                {
                
                    // Check if record exists
                    if (SalesMaintenance == null)
                    {
                        SalesMaintenance = new SalesMaintenanceDataModel
                        {
                            DealNumber = ViewModelSalesFinance.SalesFinanceDeal.DealNumber,

                        };

                        await ClientDataStore.AddNewSalesRecordAsync(SalesMaintenance, DbTableNames.SalesMaintenance);

                    }
                    // Update data model
                    await Task.Run(UpdateMaintenanceDM);

                    // Save to the data store                    
                    await ClientDataStore.SaveSalesRecordAsync(SalesMaintenance, DbTableNames.SalesMaintenance);

                    // Update Sales finance deal view model
                    ViewModelSalesFinance.SalesFinanceDeal.Maintenance = SalesMaintenance.Retail;

                }

                // Get the stored  record
                SalesWarranty = await ClientDataStore.GetSalesWarrantyAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

                // Check if plan was selected
                if (Warranty.SelectedPlan != null || SalesWarranty != null)
                {
                    
                    // Check if record exists
                    if (SalesWarranty == null)
                    {
                        SalesWarranty = new SalesWarrantyDataModel
                        {
                            DealNumber = ViewModelSalesFinance.SalesFinanceDeal.DealNumber,

                        };

                        await ClientDataStore.AddNewSalesRecordAsync(SalesWarranty, DbTableNames.SalesWarranty);

                    }
                    // Update data model
                    await Task.Run(UpdateWarrantyDM);

                    // Save to the data store                    
                    await ClientDataStore.SaveSalesRecordAsync(SalesWarranty, DbTableNames.SalesWarranty);

                    // Update Sales finance deal view model
                    ViewModelSalesFinance.SalesFinanceDeal.Warranty = SalesWarranty.Retail;

                }

                // Get the stored record
                SalesGap = await ClientDataStore.GetSalesGapAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

                // Check if plan was selected
                if (Gap.SelectedPlan != null || SalesGap != null)
                {
                    
                    // Check if record exists
                    if (SalesGap == null)
                    {
                        SalesGap = new SalesGapDataModel
                        {
                            DealNumber = ViewModelSalesFinance.SalesFinanceDeal.DealNumber,

                        };

                        await ClientDataStore.AddNewSalesRecordAsync(SalesGap, DbTableNames.SalesGap);

                    }
                    // Update data model
                    await Task.Run(UpdateGapDM);

                    // Save to the data store                    
                    await ClientDataStore.SaveSalesRecordAsync(SalesGap, DbTableNames.SalesGap);

                    // Update Sales finance deal view model
                    ViewModelSalesFinance.SalesFinanceDeal.Gap = SalesGap.Retail;

                }


            });

            CloseAction();

        }

        #endregion

        public async Task<bool> UpdateTotalRetailAsync()
        {

            UpdateTotalRetail();

            // Lock this command to ignore any other requests while processing
            await Task.Delay(1);
            return true;
            
        }

        #region Private Helper Methods

        private void UpdateMaintenanceVM(SalesMaintenanceDataModel salesMaintenance)
        {

            // Update the view model
            Maintenance.SelectedProvider = Providers.FirstOrDefault(item => item.Number == salesMaintenance.ProviderNumber);
            Maintenance.SelectedPlan = Plans.FirstOrDefault(item => item.ID == salesMaintenance.PlanID);
            Maintenance.InPayment = salesMaintenance.InPayment;
            Maintenance.Taxable = salesMaintenance.IsTaxable;
            Maintenance.ContractNumber.Text = salesMaintenance.ContractNumber;
            Maintenance.Term.Text = salesMaintenance.Term.ToString();
            Maintenance.Miles.Text = salesMaintenance.Miles.ToString();
            Maintenance.Retail = salesMaintenance.Retail;
            Maintenance.Cost.Amount = salesMaintenance.Cost;
            Maintenance.Deductible.Amount = salesMaintenance.Deductible;
            Maintenance.IsDisappearingDeductible = salesMaintenance.IsDisappearingDeductible;
                        
        }

        private void UpdateServiceVM(SalesServiceDataModel salesService)
        {

            // Update the view model
            Service.SelectedProvider = Providers.FirstOrDefault(item => item.Number == salesService.ProviderNumber);
            Service.SelectedPlan = Plans.FirstOrDefault(item => item.ID == salesService.PlanID);           
            Service.InPayment = salesService.InPayment;
            Service.Taxable = salesService.IsTaxable;
            Service.ContractNumber.Text = salesService.ContractNumber;
            Service.Term.Text = salesService.Term.ToString();
            Service.Miles.Text = salesService.Miles.ToString();
            Service.Retail = salesService.Retail;
            Service.Cost.Amount = salesService.Cost;
            Service.Deductible.Amount = salesService.Deductible;
            Service.IsDisappearingDeductible = salesService.IsDisappearingDeductible;

        }

        private void UpdateWarrantyVM(SalesWarrantyDataModel salesWarranty)
        {

            // Update the view model
            Warranty.SelectedProvider = Providers.FirstOrDefault(item => item.Number == salesWarranty.ProviderNumber);
            Warranty.SelectedPlan = Plans.FirstOrDefault(item => item.ID == salesWarranty.PlanID);
            Warranty.InPayment = salesWarranty.InPayment;
            Warranty.Taxable = salesWarranty.IsTaxable;
            Warranty.ContractNumber.Text = salesWarranty.ContractNumber;
            Warranty.Term.Text = salesWarranty.Term.ToString();
            Warranty.Miles.Text = salesWarranty.Miles.ToString();
            Warranty.Retail = salesWarranty.Retail;
            Warranty.Cost.Amount = salesWarranty.Cost;
            Warranty.Deductible.Amount = salesWarranty.Deductible;
            Warranty.IsDisappearingDeductible = salesWarranty.IsDisappearingDeductible;

        }

        private void UpdateGapVM(SalesGapDataModel salesGap)
        {

            // Update the view model
            Gap.SelectedProvider = Providers.FirstOrDefault(item => item.Number == salesGap.ProviderNumber);
            Gap.SelectedPlan = Plans.FirstOrDefault(item => item.ID == salesGap.PlanID);
            Gap.InPayment = salesGap.InPayment;
            Gap.Taxable = salesGap.IsTaxable;
            Gap.ContractNumber.Text = salesGap.ContractNumber;           
            Gap.Retail = salesGap.Retail;
            Gap.Cost.Amount = salesGap.Cost;
           
        }

        private void UpdateMaintenanceDM()
        {
            
            SalesMaintenance.Plan = Maintenance.SelectedPlan?.Name;
            SalesMaintenance.PlanID = Maintenance.SelectedPlan == null ? 0 : Maintenance.SelectedPlan.ID;
            SalesMaintenance.InPayment = Maintenance.InPayment;
            SalesMaintenance.Cost = Maintenance.Cost.Amount;
            SalesMaintenance.Retail = Maintenance.Retail;
            SalesMaintenance.Profit = SalesMaintenance.Retail - SalesMaintenance.Cost;
            SalesMaintenance.Deductible = Maintenance.Deductible.Amount;
            SalesMaintenance.IsDisappearingDeductible = Maintenance.IsDisappearingDeductible;
            SalesMaintenance.ProviderNumber = Maintenance.SelectedPlan?.ProviderNumber;
            SalesMaintenance.ProviderName = Maintenance.SelectedPlan?.ProviderName;
            int.TryParse(Maintenance.Term.Text, out var result);
            SalesMaintenance.Term = result;
            int.TryParse(Maintenance.Miles.Text, out result);
            SalesMaintenance.Miles = result;
            SalesMaintenance.DealerNumber = Maintenance.SelectedProvider?.DealerNumber;

        }

        private void UpdateServiceDM()
        {
            
            SalesService.Plan = Service.SelectedPlan?.Name;
            SalesService.PlanID = Service.SelectedPlan == null ? 0 : Service.SelectedPlan.ID;
            SalesService.InPayment = Service.InPayment;
            SalesService.Cost = Service.Cost.Amount;
            SalesService.Retail = Service.Retail;
            SalesService.Profit = SalesService.Retail - SalesService.Cost;
            SalesService.Deductible = Service.Deductible.Amount;
            SalesService.IsDisappearingDeductible = Service.IsDisappearingDeductible;
            SalesService.ProviderNumber = Service.SelectedPlan?.ProviderNumber;
            SalesService.ProviderName = Service.SelectedPlan?.ProviderName;
            int.TryParse(Service.Term.Text, out var result);
            SalesService.Term = result;
            int.TryParse(Service.Miles.Text, out result);
            SalesService.Miles = result;            
            SalesService.DealerNumber = Service.SelectedProvider?.DealerNumber;

        }

        private void UpdateWarrantyDM()
        {

            SalesWarranty.Plan = Warranty.SelectedPlan?.Name;
            SalesWarranty.PlanID = Warranty.SelectedPlan == null ? 0 : Warranty.SelectedPlan.ID;
            SalesWarranty.InPayment = Warranty.InPayment;
            SalesWarranty.Cost = Warranty.Cost.Amount;
            SalesWarranty.Retail = Warranty.Retail;
            SalesWarranty.Profit = SalesWarranty.Retail - SalesWarranty.Cost;
            SalesWarranty.Deductible = Warranty.Deductible.Amount;
            SalesWarranty.IsDisappearingDeductible = Warranty.IsDisappearingDeductible;
            SalesWarranty.ProviderNumber = Warranty.SelectedPlan?.ProviderNumber;
            SalesWarranty.ProviderName = Warranty.SelectedPlan?.ProviderName;
            int.TryParse(Warranty.Term.Text, out var result);
            SalesWarranty.Term = result;
            int.TryParse(Warranty.Miles.Text, out result);
            SalesWarranty.Miles = result;
            SalesWarranty.DealerNumber = Warranty.SelectedProvider?.DealerNumber;

        }

        private void UpdateGapDM()
        {

            SalesGap.Plan = Gap.SelectedPlan?.Name;
            SalesGap.PlanID = Gap.SelectedPlan == null ? 0 : Gap.SelectedPlan.ID;
            SalesGap.InPayment = Gap.InPayment;
            SalesGap.Cost = Gap.Cost.Amount;
            SalesGap.Retail = Gap.Retail;
            SalesGap.Profit = SalesGap.Retail - SalesGap.Cost;
            SalesGap.ProviderNumber = Gap.SelectedPlan?.ProviderNumber;
            SalesGap.ProviderName = Gap.SelectedPlan?.ProviderName;
            SalesGap.DealerNumber = Gap.SelectedProvider?.DealerNumber;

        }

        private void UpdateTotalRetail()
        {

            TotalRetail = new DecimalInputViewModel
            {
                Label = "Total Retail",

                Amount = (Service == null ? 0 : Service.Retail) +
                             (Maintenance == null ? 0 : Maintenance.Retail) +
                             (Warranty == null ? 0 : Warranty.Retail) +
                             (Gap == null ? 0 : Gap.Retail)

            };

        }

        private void SetProductItems()
        {

            Service = new ProductItemViewModel
            {

                Type = new TextInputViewModel { Label = "Product", Text = "Service" },
                Retail = 0,
                Cost = new DecimalInputViewModel { Label = "Cost", Amount = 0, Editable = true },
                Deductible = new DecimalInputViewModel { Label = "Deductible", Amount = 0, Editable = true },
                Term = new TextInputViewModel { Label = "Term", Text = "" },
                Miles = new TextInputViewModel { Label = "Mileage", Text = "" },
                ContractNumber = new TextInputViewModel { Label = "Contract No", Text = "" },
                InPayment = true,
                IsDisappearingDeductible = false,
                Taxable = false,
                Providers = new ObservableCollection<CoverageProviderDataModel>(
                mProviders.Where(item => item.IsService == true)),
                Plans = new ObservableCollection<CoveragePlanDataModel>(
                mPlans.Where(item => item.Type.ToLower().Contains("service"))),
                UpdateAction = UpdateTotalRetailAsync,
                SelectedProvider = new CoverageProviderDataModel(),
                SelectedPlan = new CoveragePlanDataModel(),
                //Type = new TextInputViewModel { Label = "Product", Text = "Service", Editable = false },
                //Retail = SalesService != null ? SalesService.Retail : 0,
                //Cost = new DecimalInputViewModel { Label = "Cost", Amount = SalesService != null ? SalesService.Cost : 0, Editable = true },
                //Deductible = new DecimalInputViewModel { Label = "Deductible", Amount = SalesService != null ? SalesService.Deductible : 0, Editable = true },
                //Term = new TextInputViewModel { Label = "Term", Text = SalesService != null ? SalesService.Term.ToString() : "" },
                //Miles = new TextInputViewModel { Label = "Mileage", Text = SalesService != null ? SalesService.Miles.ToString() : ""},
                //ContractNumber = new TextInputViewModel { Label = "Contract No", Text = SalesService != null ? SalesService.ContractNumber : "" },
                //InPayment = SalesService != null ? SalesService.InPayment : true,
                //IsDisappearingDeductible = SalesService != null ? SalesService.IsDisappearingDeductible : false,
                //Taxable = SalesService != null ? SalesService.IsTaxable : false,
                //Providers = new ObservableCollection<CoverageProviderDataModel>(),
                //Plans = new ObservableCollection<CoveragePlanDataModel>(
                //mPlans.Where(item => item.Type.ToLower().Contains("service"))),

                //UpdateAction = UpdateTotalRetailAsync,

            };

            Warranty = new ProductItemViewModel
            {
                Type = new TextInputViewModel { Label = "Product", Text = "Warranty" },
                Retail = 0,
                Cost = new DecimalInputViewModel { Label = "Cost", Amount = 0, Editable = true },
                Deductible = new DecimalInputViewModel { Label = "Deductible", Amount = 0, Editable = true },
                Term = new TextInputViewModel { Label = "Term", Text = "" },
                Miles = new TextInputViewModel { Label = "Mileage", Text = "" },
                ContractNumber = new TextInputViewModel { Label = "Contract No", Text = "" },
                InPayment = true,
                IsDisappearingDeductible = false,
                Taxable = false,
                Providers = new ObservableCollection<CoverageProviderDataModel>(
                mProviders.Where(item => item.IsWarranty == true)),
                Plans = new ObservableCollection<CoveragePlanDataModel>(
                mPlans.Where(item => item.Type.ToLower().Contains("warranty"))),
                UpdateAction = UpdateTotalRetailAsync,

            };

            Maintenance = new ProductItemViewModel
            {
                Type = new TextInputViewModel { Label = "Product", Text = "Maintenance" },
                Retail = 0,
                Cost = new DecimalInputViewModel { Label = "Cost", Amount = 0, Editable = true },
                Deductible = new DecimalInputViewModel { Label = "Deductible", Amount = 0, Editable = true },
                Term = new TextInputViewModel { Label = "Term", Text = "" },
                Miles = new TextInputViewModel { Label = "Mileage", Text = "" },
                ContractNumber = new TextInputViewModel { Label = "Contract No", Text = "" },
                InPayment = true,
                IsDisappearingDeductible = false,
                Taxable = false,
                Providers = new ObservableCollection<CoverageProviderDataModel>(
                mProviders.Where(item => item.IsMaintenance == true)),
                Plans = new ObservableCollection<CoveragePlanDataModel>(
                mPlans.Where(item => item.Type.ToLower().Contains("maintenance"))),
                UpdateAction = UpdateTotalRetailAsync,

            };

            Gap = new ProductItemViewModel
            {
                Type = new TextInputViewModel { Label = "Product", Text = "Gap" },
                Retail = 0,
                Cost = new DecimalInputViewModel { Label = "Cost", Amount = 0, Editable = true },
                Deductible = new DecimalInputViewModel { Label = "Deductible", Amount = 0, Editable = true },
                Term = new TextInputViewModel { Label = "Term", Text = "" },
                Miles = new TextInputViewModel { Label = "Mileage", Text = "" },
                ContractNumber = new TextInputViewModel { Label = "Contract No", Text = "" },
                InPayment = true,
                IsDisappearingDeductible = false,
                Taxable = false,
                Providers = new ObservableCollection<CoverageProviderDataModel>(
                mProviders.Where(item => item.IsGap == true)),
                Plans = new ObservableCollection<CoveragePlanDataModel>(
                mPlans.Where(item => item.Type.ToLower().Contains("gap"))),
                UpdateAction = UpdateTotalRetailAsync,

            };

        }




    #endregion
}
}
