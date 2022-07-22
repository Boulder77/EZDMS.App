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
        /// The provider items for the list that include any filtering
        /// </summary>
        public ObservableCollection<CoverageProviderDataModel> FilteredProviders { get; set; }

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
        public NumericalEntryViewModel TotalRetail { get; set; }

        /// <summary>
        /// The total of all the retail prices
        /// </summary>
        public decimal TotalRetailAmount { get; set; }

        /// <summary>
        /// Indicates if there is a save action
        /// </summary>
        public bool Saving { get; set; }

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



            Service = new ProductItemViewModel
            {
                Type = new TextDisplayViewModel { Label = "Product", DisplayText = "Service" },
                Retail = new NumericalEntryViewModel { Label = "Retail", OriginalAmount = 0, Editable = true },
                Cost = new NumericalEntryViewModel { Label = "Cost", OriginalAmount = 0, Editable = true },
                Deductible = new NumericalEntryViewModel { Label = "Deductible", OriginalAmount = 0, Editable = true },
                Term = new TextEntryViewModel { Label = "Term", OriginalText = "" },
                Mileage = new TextEntryViewModel { Label = "Mileage", OriginalText = "" },
                ContractNumber = new TextEntryViewModel { Label = "Contract No", OriginalText = "" },
                InPayment = true,
                IsDisappearingDeductible = false,
                Taxable = false,
                Providers = new ObservableCollection<CoverageProviderDataModel>(),
                Plans = new ObservableCollection<CoveragePlanDataModel>(),
                //SelectedProvider = new CoverageProviderDataModel(),
                //SelectedPlan = new CoveragePlanDataModel(),
            };

            Warranty = new ProductItemViewModel
            {
                Type = new TextDisplayViewModel { Label = "Product", DisplayText = "Warranty" },
                Retail = new NumericalEntryViewModel { Label = "Retail", OriginalAmount = 0, Editable = true },
                Cost = new NumericalEntryViewModel { Label = "Cost", OriginalAmount = 0, Editable = true },
                Deductible = new NumericalEntryViewModel { Label = "Deductible", OriginalAmount = 0, Editable = true },
                Term = new TextEntryViewModel { Label = "Term", OriginalText = "" },
                Mileage = new TextEntryViewModel { Label = "Mileage", OriginalText = "" },
                ContractNumber = new TextEntryViewModel { Label = "Contract No", OriginalText = "" },
                InPayment = true,
                IsDisappearingDeductible = false,
                Taxable = true,
                Providers = new ObservableCollection<CoverageProviderDataModel>(),
                Plans = new ObservableCollection<CoveragePlanDataModel>(),
                
            };

            Maintenance = new ProductItemViewModel
            {
                Type = new TextDisplayViewModel { Label = "Product", DisplayText = "Maintenance" },
                Retail = new NumericalEntryViewModel { Label = "Retail", OriginalAmount = 0, Editable = true },
                Cost = new NumericalEntryViewModel { Label = "Cost", OriginalAmount = 0, Editable = true },
                Deductible = new NumericalEntryViewModel { Label = "Deductible", OriginalAmount = 0, Editable = true },
                Term = new TextEntryViewModel { Label = "Term", OriginalText = "" },
                Mileage = new TextEntryViewModel { Label = "Mileage", OriginalText = "" },
                ContractNumber = new TextEntryViewModel { Label = "Contract No", OriginalText = "" },
                InPayment = true,
                IsDisappearingDeductible = false,
                Taxable = true,
                Providers = new ObservableCollection<CoverageProviderDataModel>(),
                Plans = new ObservableCollection<CoveragePlanDataModel>(),
                
            };

            Gap = new ProductItemViewModel
            {
                Type = new TextDisplayViewModel { Label = "Product", DisplayText = "Gap" },
                Retail = new NumericalEntryViewModel { Label = "Retail", OriginalAmount = 0, Editable = true },
                Cost = new NumericalEntryViewModel { Label = "Cost", OriginalAmount = 0, Editable = true },
                //Deductible = new NumericalEntryViewModel { Label = "Deductible", OriginalAmount = 0, Editable = true },
                //Term = new TextEntryViewModel { Label = "Term", OriginalText = "" },
                //Mileage = new TextEntryViewModel { Label = "Mileage", OriginalText = "" },
                ContractNumber = new TextEntryViewModel { Label = "Contract No", OriginalText = "" },
                InPayment = true,
                //DisappearingDeductible = false,
                Taxable = true,
                Providers = new ObservableCollection<CoverageProviderDataModel>(),
                Plans = new ObservableCollection<CoveragePlanDataModel>(),
                
            };
        }

        #endregion

        #region Public Commands

        public async Task SaveProductsAsync()
        {
            await RunCommandAsync(() => Saving, async () =>
            {
                // Check if service plan was selected
                if (Service.SelectedPlan !=null)
                {
                    // Get the stored service record
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

                // Check if maintenance plan was selected
                if (Maintenance.SelectedPlan != null)
                {
                    // Get the stored maintenance record
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

                // Check if warranty plan was selected
                if (Warranty.SelectedPlan != null)
                {
                    // Get the stored warranty record
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

                // Check if gap plan was selected
                if (Gap.SelectedPlan != null)
                {
                    // Get the stored warranty record
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



        #region Private Helper Methods

        private void UpdateMaintenanceDM()
        {
            
            SalesMaintenance.Plan = Maintenance.SelectedPlan.Name;
            SalesMaintenance.PlanID = Maintenance.SelectedPlan.ID;
            SalesMaintenance.InPayment = Maintenance.InPayment;
            SalesMaintenance.Cost = Maintenance.Cost.EditedAmount == 0 ? Maintenance.SelectedPlan.Cost : Maintenance.Cost.EditedAmount;
            SalesMaintenance.Retail = Maintenance.Retail.EditedAmount == 0 ? Maintenance.SelectedPlan.Retail : Maintenance.Retail.EditedAmount;
            SalesMaintenance.Profit = SalesMaintenance.Retail - SalesMaintenance.Cost;
            SalesMaintenance.Deductible = Maintenance.Deductible.EditedAmount == 0 ? Maintenance.SelectedPlan.Deductible : Maintenance.Deductible.EditedAmount;
            SalesMaintenance.IsDisappearingDeductible = Maintenance.IsDisappearingDeductible;
            SalesMaintenance.ProviderNumber = Maintenance.SelectedPlan.ProviderNumber;
            SalesMaintenance.Term = Maintenance.Term.EditedText == null ? Maintenance.SelectedPlan.Term : Convert.ToInt32(Maintenance.Term.EditedText);
            SalesMaintenance.Mileage = Maintenance.Mileage.EditedText == null ? Maintenance.SelectedPlan.Mileage : Convert.ToInt32(Maintenance.Mileage.EditedText);
            SalesMaintenance.DealerNumber = Maintenance.SelectedProvider?.DealerNumber;

        }

        private void UpdateServiceDM()
        {

            SalesService.Plan = Service.SelectedPlan.Name;
            SalesService.PlanID = Service.SelectedPlan.ID;
            SalesService.InPayment = Service.InPayment;
            SalesService.Cost = Service.Cost.EditedAmount == 0 ? Service.SelectedPlan.Cost : Service.Cost.EditedAmount;
            SalesService.Retail = Service.Retail.EditedAmount == 0 ? Service.SelectedPlan.Retail : Service.Retail.EditedAmount;
            SalesService.Profit = SalesService.Retail - SalesService.Cost;
            SalesService.Deductible = Service.Deductible.EditedAmount == 0 ? Service.SelectedPlan.Deductible : Service.Deductible.EditedAmount;
            SalesService.IsDisappearingDeductible = Service.IsDisappearingDeductible;
            SalesService.ProviderNumber = Service.SelectedPlan.ProviderNumber;
            SalesService.Term = Service.Term.EditedText==null ? Service.SelectedPlan.Term : Convert.ToInt32(Service.Term.EditedText);
            SalesService.Mileage = Service.Mileage.EditedText == null ? Service.SelectedPlan.Mileage : Convert.ToInt32(Service.Mileage.EditedText);
            SalesService.DealerNumber = Service.SelectedProvider?.DealerNumber;

        }

        private void UpdateWarrantyDM()
        {

            SalesWarranty.Plan = Warranty.SelectedPlan.Name;
            SalesWarranty.PlanID = Warranty.SelectedPlan.ID;
            SalesWarranty.InPayment = Warranty.InPayment;
            SalesWarranty.Cost = Warranty.Cost.EditedAmount == 0 ? Warranty.SelectedPlan.Cost : Warranty.Cost.EditedAmount;
            SalesWarranty.Retail = Warranty.Retail.EditedAmount == 0 ? Warranty.SelectedPlan.Retail : Warranty.Retail.EditedAmount;
            SalesWarranty.Profit = SalesWarranty.Retail - SalesWarranty.Cost;
            SalesWarranty.Deductible = Warranty.Deductible.EditedAmount == 0 ? Warranty.SelectedPlan.Deductible : Warranty.Deductible.EditedAmount;
            SalesWarranty.IsDisappearingDeductible = Warranty.IsDisappearingDeductible;
            SalesWarranty.ProviderNumber = Warranty.SelectedPlan.ProviderNumber;
            SalesWarranty.Term = Warranty.Term.EditedText == null ? Warranty.SelectedPlan.Term : Convert.ToInt32(Warranty.Term.EditedText);
            SalesWarranty.Mileage = Warranty.Mileage.EditedText == null ? Warranty.SelectedPlan.Mileage : Convert.ToInt32(Warranty.Mileage.EditedText);
            SalesWarranty.DealerNumber = Warranty.SelectedProvider?.DealerNumber;

        }

        private void UpdateGapDM()
        {

            SalesGap.Plan = Gap.SelectedPlan.Name;
            SalesGap.PlanID = Gap.SelectedPlan.ID;
            SalesGap.InPayment = Gap.InPayment;
            SalesGap.Cost = Gap.Cost.EditedAmount == 0 ? Gap.SelectedPlan.Cost : Gap.Cost.EditedAmount;
            SalesGap.Retail = Gap.Retail.EditedAmount == 0 ? Gap.SelectedPlan.Retail : Gap.Retail.EditedAmount;
            SalesGap.Profit = SalesGap.Retail - SalesGap.Cost;
            SalesGap.ProviderNumber = Gap.SelectedPlan.ProviderNumber;
            SalesGap.DealerNumber = Gap.SelectedProvider?.DealerNumber;

        }


        #endregion
    }
}
