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

        /// <summary>
        /// The service contract data model 
        /// </summary>
        private SalesServiceDataModel mSalesService;

        /// <summary>
        /// The warranty data model 
        /// </summary>
        private SalesWarrantyDataModel mSalesWarranty;

        /// <summary>
        /// The maintenance data model 
        /// </summary>
        private SalesMaintenanceDataModel mSalesMaintenance;

        /// <summary>
        /// The gap data model 
        /// </summary>
        private SalesGapDataModel mSalesGap;


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

                // Update service provider list
                ServiceProviders = new ObservableCollection<CoverageProviderDataModel>(
                mProviders.Where(item => item.IsService == true));
                // Update view model
                Service.Providers = ServiceProviders;

                // Update warranty provider list
                WarrantyProviders = new ObservableCollection<CoverageProviderDataModel>(
                mProviders.Where(item => item.IsWarranty == true));
                // Update view model
                Warranty.Providers = WarrantyProviders;

                // Update maintenance provider list
                MaintenanceProviders = new ObservableCollection<CoverageProviderDataModel>(
                mProviders.Where(item => item.IsMaintenance == true));
                // Update view model
                Maintenance.Providers = MaintenanceProviders;

                // Update gap provider list
                GapProviders = new ObservableCollection<CoverageProviderDataModel>(
                mProviders.Where(item => item.IsGap == true));
                // Update view model
                Gap.Providers = GapProviders;

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

                // Update service plan list
                ServicePlans = new ObservableCollection<CoveragePlanDataModel>(
                mPlans.Where(item => item.Type.ToLower().Contains("service")));
                // Update view model
                Service.Plans = ServicePlans;

                // Update service plan list
                WarrantyPlans = new ObservableCollection<CoveragePlanDataModel>(
                mPlans.Where(item => item.Type.ToLower().Contains("warranty")));
                // Update view model
                Warranty.Plans = WarrantyPlans;

                // Update service plan list
                MaintenancePlans = new ObservableCollection<CoveragePlanDataModel>(
                mPlans.Where(item => item.Type.ToLower().Contains("maintenance")));
                // Update view model
                Maintenance.Plans = MaintenancePlans;


                // Update gap plan list
                GapPlans = new ObservableCollection<CoveragePlanDataModel>(
                mPlans.Where(item => item.Type.ToLower().Contains("gap")));
                // Update view model
                Gap.Plans = GapPlans;

            }
        }

        /// <summary>
        /// The plan items for the list that include any filtering
        /// </summary>
        public ObservableCollection<CoveragePlanDataModel> FilteredPlans { get; set; }

        /// <summary>
        /// The service plan items for the list
        /// </summary>
        public ObservableCollection<CoveragePlanDataModel> ServicePlans { get; set; }

        /// <summary>
        /// The warranty plan items for the list
        /// </summary>
        public ObservableCollection<CoveragePlanDataModel> WarrantyPlans { get; set; }

        /// <summary>
        /// The maintenance plan items for the list
        /// </summary>
        public ObservableCollection<CoveragePlanDataModel> MaintenancePlans { get; set; }

        /// <summary>
        /// The gap plan items for the list
        /// </summary>
        public ObservableCollection<CoveragePlanDataModel> GapPlans { get; set; }

        /// <summary>
        /// The service provider items for the list
        /// </summary>
        public ObservableCollection<CoverageProviderDataModel> ServiceProviders { get; set; }

        /// <summary>
        /// The warranty provider items for the list
        /// </summary>
        public ObservableCollection<CoverageProviderDataModel> WarrantyProviders { get; set; }

        /// <summary>
        /// The maintenance provider items for the list
        /// </summary>
        public ObservableCollection<CoverageProviderDataModel> MaintenanceProviders { get; set; }

        /// <summary>
        /// The gap provider items for the list
        /// </summary>
        public ObservableCollection<CoverageProviderDataModel> GapProviders { get; set; }
                
        /// <summary>
        /// The sales maintenance data model
        /// </summary>
        public SalesMaintenanceDataModel SalesMaintenance
        { 
            get => mSalesMaintenance;
                
            set
            {

                // Make sure data model has changed
                if (mSalesMaintenance == value)
                    return;

                // Update value
                mSalesMaintenance = value;

                if (value != null && ProductsLoading)

                    // Update view model
                    UpdateMaintenanceVM(mSalesMaintenance);

            }
        
        }

        /// <summary>
        /// The sales service data model
        /// </summary>
        public SalesServiceDataModel SalesService
        {
            get => mSalesService;

            set
            {

                // Make sure data model has changed
                if (mSalesService == value)
                    return;

                // Update value
                mSalesService = value;

                //if (value != null && ProductsLoading)
                //    // Update view model
                //    UpdateServiceVM(mSalesService);

            }

        }

        /// <summary>
        /// The sales warranty data model
        /// </summary>
        public SalesWarrantyDataModel SalesWarranty
        {
            get => mSalesWarranty;

            set
            {

                // Make sure data model has changed
                if (mSalesWarranty == value)
                    return;

                // Update value
                mSalesWarranty = value;

                if (value != null && ProductsLoading)
                    // Update view model
                    UpdateWarrantyVM(mSalesWarranty);

            }

        }

        /// <summary>
        /// The sales gap data model
        /// </summary>
        public SalesGapDataModel SalesGap
        {
            get => mSalesGap;

            set
            {

                // Make sure data model has changed
                if (mSalesGap == value)
                    return;

                // Update value
                mSalesGap = value;

                if (value != null && ProductsLoading)
                    // Update view model
                    UpdateGapVM(mSalesGap);

            }

        }

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
                               
                SetProductItems();

                Providers = await ClientDataStore.GetCoverageProvidersAsync();
                Plans = await ClientDataStore.GetCoveragePlansAsync();

                //SalesService = await ClientDataStore.GetSalesServiceAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);
                //SalesMaintenance = await ClientDataStore.GetSalesMaintenanceAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);
                //SalesWarranty = await ClientDataStore.GetSalesWarrantyAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);
                //SalesGap = await ClientDataStore.GetSalesGapAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

            });


        }




        public async Task SaveProductsAsync()
        {
            await RunCommandAsync(() => Saving, async () =>
            {
                // Check if plan was selected
                if (Service.SelectedPlan !=null)
                {
                    // Get the service record
                    SalesService = await ClientDataStore.GetSalesServiceAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

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

                }

                // Check if plan was selected
                if (Maintenance.SelectedPlan != null)
                {
                    // Get the stored record
                    SalesMaintenance = await ClientDataStore.GetSalesMaintenanceAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

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

                }

                // Check if plan was selected
                if (Warranty.SelectedPlan != null)
                {
                    // Get the stored  record
                    SalesWarranty = await ClientDataStore.GetSalesWarrantyAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

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

                }

                // Check if plan was selected
                if (Gap.SelectedPlan != null)
                {
                    // Get the stored record
                    SalesGap = await ClientDataStore.GetSalesGapAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

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
            Maintenance.SelectedPlan.ProviderName = salesMaintenance.ProviderName;
            Maintenance.SelectedPlan.Name = salesMaintenance.Plan;
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
            Service.SelectedPlan.ProviderName = salesService.ProviderName;
            Service.SelectedPlan.Name = salesService.Plan;
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
            Warranty.SelectedPlan.ProviderName = salesWarranty.ProviderName;
            Warranty.SelectedPlan.Name = salesWarranty.Plan;
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
            Gap.SelectedPlan.ProviderName = salesGap.ProviderName;
            Gap.SelectedPlan.Name = salesGap.Plan;
            Gap.InPayment = salesGap.InPayment;
            Gap.Taxable = salesGap.IsTaxable;
            Gap.ContractNumber.Text = salesGap.ContractNumber;           
            Gap.Retail = salesGap.Retail;
            Gap.Cost.Amount = salesGap.Cost;
           
        }

        private void UpdateMaintenanceDM()
        {
            
            SalesMaintenance.Plan = Maintenance.SelectedPlan.Name;
            SalesMaintenance.PlanID = Maintenance.SelectedPlan.ID;
            SalesMaintenance.InPayment = Maintenance.InPayment;
            SalesMaintenance.Cost = Maintenance.Cost.Amount == 0 ? Maintenance.SelectedPlan.Cost : Maintenance.Cost.Amount;
            SalesMaintenance.Retail = Maintenance.Retail == 0 ? Maintenance.SelectedPlan.Retail : Maintenance.Retail;
            SalesMaintenance.Profit = SalesMaintenance.Retail - SalesMaintenance.Cost;
            SalesMaintenance.Deductible = Maintenance.Deductible.Amount == 0 ? Maintenance.SelectedPlan.Deductible : Maintenance.Deductible.Amount;
            SalesMaintenance.IsDisappearingDeductible = Maintenance.IsDisappearingDeductible;
            SalesMaintenance.ProviderNumber = Maintenance.SelectedPlan.ProviderNumber;
            SalesMaintenance.ProviderName = Maintenance.SelectedPlan.ProviderName;
            SalesMaintenance.Term = Maintenance.Term.Text == null ? Maintenance.SelectedPlan.Term : Convert.ToInt32(Maintenance.Term.Text);
            SalesMaintenance.Miles = Maintenance.Miles.Text == null ? Maintenance.SelectedPlan.Miles : Convert.ToInt32(Maintenance.Miles.Text);
            SalesMaintenance.DealerNumber = Maintenance.SelectedProvider?.DealerNumber;

        }

        private void UpdateServiceDM()
        {

            SalesService.Plan = Service.SelectedPlan.Name;            
            SalesService.PlanID = Service.SelectedPlan.ID;
            SalesService.InPayment = Service.InPayment;
            SalesService.Cost = Service.Cost.Amount == 0 ? Service.SelectedPlan.Cost : Service.Cost.Amount;
            SalesService.Retail = Service.Retail == 0 ? Service.SelectedPlan.Retail : Service.Retail;
            SalesService.Profit = SalesService.Retail - SalesService.Cost;
            SalesService.Deductible = Service.Deductible.Amount == 0 ? Service.SelectedPlan.Deductible : Service.Deductible.Amount;
            SalesService.IsDisappearingDeductible = Service.IsDisappearingDeductible;
            SalesService.ProviderNumber = Service.SelectedPlan.ProviderNumber;
            SalesService.ProviderName = Service.SelectedPlan.ProviderName;
            SalesService.Term = Service.Term.Text== null ? Service.SelectedPlan.Term : Convert.ToInt32(Service.Term.Text);
            SalesService.Miles = Service.Miles.Text == null ? Service.SelectedPlan.Miles : Convert.ToInt32(Service.Miles.Text);
            SalesService.DealerNumber = Service.SelectedProvider?.DealerNumber;

        }

        private void UpdateWarrantyDM()
        {

            SalesWarranty.Plan = Warranty.SelectedPlan.Name;
            SalesWarranty.PlanID = Warranty.SelectedPlan.ID;
            SalesWarranty.InPayment = Warranty.InPayment;
            SalesWarranty.Cost = Warranty.Cost.Amount == 0 ? Warranty.SelectedPlan.Cost : Warranty.Cost.Amount;
            SalesWarranty.Retail = Warranty.Retail == 0 ? Warranty.SelectedPlan.Retail : Warranty.Retail;
            SalesWarranty.Profit = SalesWarranty.Retail - SalesWarranty.Cost;
            SalesWarranty.Deductible = Warranty.Deductible.Amount == 0 ? Warranty.SelectedPlan.Deductible : Warranty.Deductible.Amount;
            SalesWarranty.IsDisappearingDeductible = Warranty.IsDisappearingDeductible;
            SalesWarranty.ProviderNumber = Warranty.SelectedPlan.ProviderNumber;
            SalesWarranty.ProviderName = Warranty.SelectedPlan.ProviderName;
            SalesWarranty.Term = Warranty.Term.Text == null ? Warranty.SelectedPlan.Term : Convert.ToInt32(Warranty.Term.Text);
            SalesWarranty.Miles = Warranty.Miles.Text == null ? Warranty.SelectedPlan.Miles : Convert.ToInt32(Warranty.Miles.Text);
            SalesWarranty.DealerNumber = Warranty.SelectedProvider?.DealerNumber;

        }

        private void UpdateGapDM()
        {

            SalesGap.Plan = Gap.SelectedPlan.Name;
            SalesGap.PlanID = Gap.SelectedPlan.ID;
            SalesGap.InPayment = Gap.InPayment;
            SalesGap.Cost = Gap.Cost.Amount == 0 ? Gap.SelectedPlan.Cost : Gap.Cost.Amount;
            SalesGap.Retail = Gap.Retail == 0 ? Gap.SelectedPlan.Retail : Gap.Retail;
            SalesGap.Profit = SalesGap.Retail - SalesGap.Cost;
            SalesGap.ProviderNumber = Gap.SelectedPlan.ProviderNumber;
            SalesGap.ProviderName = Gap.SelectedPlan.ProviderName;
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
                Type = new TextInputViewModel { Label = "Product", Text = "Service", Editable = false },
                Retail = SalesService != null ? SalesService.Retail : 0,
                Cost = new DecimalInputViewModel { Label = "Cost", Amount = SalesService != null ? SalesService.Cost : 0, Editable = true },
                Deductible = new DecimalInputViewModel { Label = "Deductible", Amount = SalesService != null ? SalesService.Deductible : 0, Editable = true },
                Term = new TextInputViewModel { Label = "Term", Text = SalesService != null ? SalesService.Term.ToString() : "" },
                Miles = new TextInputViewModel { Label = "Mileage", Text = SalesService != null ? SalesService.Miles.ToString() : ""},
                ContractNumber = new TextInputViewModel { Label = "Contract No", Text = SalesService != null ? SalesService.ContractNumber : "" },
                InPayment = SalesService != null ? SalesService.InPayment : true,
                IsDisappearingDeductible = SalesService != null ? SalesService.IsDisappearingDeductible : false,
                Taxable = SalesService != null ? SalesService.IsTaxable : false,
                Providers = new ObservableCollection<CoverageProviderDataModel>(),
                Plans = new ObservableCollection<CoveragePlanDataModel>(),
                SelectedProvider = new CoverageProviderDataModel {Number = SalesService != null ? SalesService.ProviderNumber : "" },
                SelectedPlan = new CoveragePlanDataModel { Name = SalesService != null ? SalesService.Plan : "" },

                UpdateAction = UpdateTotalRetailAsync,
                
            };

            Warranty = new ProductItemViewModel
            {
                Type = new TextInputViewModel { Label = "Product", Text = "Warranty", Editable = false },
                Retail = 0,
                Cost = new DecimalInputViewModel { Label = "Cost", Amount = 0, Editable = true },
                Deductible = new DecimalInputViewModel { Label = "Deductible", Amount = 0, Editable = true },
                Term = new TextInputViewModel { Label = "Term", Text = "" },
                Miles = new TextInputViewModel { Label = "Mileage", Text = "" },
                ContractNumber = new TextInputViewModel { Label = "Contract No", Text = "" },
                InPayment = true,
                IsDisappearingDeductible = false,
                Taxable = true,
                Providers = new ObservableCollection<CoverageProviderDataModel>(),
                Plans = new ObservableCollection<CoveragePlanDataModel>(),
                UpdateAction = UpdateTotalRetailAsync,

            };

            Maintenance = new ProductItemViewModel
            {
                Type = new TextInputViewModel { Label = "Product", Text = "Maintenance", Editable = false },
                Retail = 0,
                Cost = new DecimalInputViewModel { Label = "Cost", Amount = 0, Editable = true },
                Deductible = new DecimalInputViewModel { Label = "Deductible", Amount = 0, Editable = true },
                Term = new TextInputViewModel { Label = "Term", Text = "" },
                Miles = new TextInputViewModel { Label = "Mileage", Text = "" },
                ContractNumber = new TextInputViewModel { Label = "Contract No", Text = "" },
                InPayment = true,
                IsDisappearingDeductible = false,
                Taxable = true,
                Providers = new ObservableCollection<CoverageProviderDataModel>(),
                Plans = new ObservableCollection<CoveragePlanDataModel>(),
                UpdateAction = UpdateTotalRetailAsync,

            };

            Gap = new ProductItemViewModel
            {
                Type = new TextInputViewModel { Label = "Product", Text = "Gap", Editable = false },
                Retail = 0,
                Cost = new DecimalInputViewModel { Label = "Cost", Amount = 0, Editable = true },
                Deductible = new DecimalInputViewModel { Label = "Deductible", Amount = 0, Editable = true },
                Term = new TextInputViewModel { Label = "Term", Text = "" },
                Miles = new TextInputViewModel { Label = "Mileage", Text = "" },
                ContractNumber = new TextInputViewModel { Label = "Contract No", Text = "" },
                InPayment = true,
                IsDisappearingDeductible = false,
                Taxable = true,
                Providers = new ObservableCollection<CoverageProviderDataModel>(),
                Plans = new ObservableCollection<CoveragePlanDataModel>(),
                UpdateAction = UpdateTotalRetailAsync,

            };


        }


    #endregion
}
}
