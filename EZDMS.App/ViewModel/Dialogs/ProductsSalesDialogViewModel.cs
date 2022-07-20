using Dna;
using EZDMS.App.Core;
using System.Windows.Input;
using static EZDMS.App.DI;
using static Dna.FrameworkDI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
        protected List<CoverageProviderDataModel> mProviders;

        /// <summary>
        /// The list of all the product plans
        /// </summary>
        protected List<CoveragePlanDataModel> mPlans;

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

                // Update service plan list
                WarrantyPlans = new ObservableCollection<CoveragePlanDataModel>(
                mPlans.Where(item => item.Type.ToLower().Contains("warranty")));

                // Update service plan list
                MaintenancePlans = new ObservableCollection<CoveragePlanDataModel>(
                mPlans.Where(item => item.Type.ToLower().Contains("maintenance")));
                                
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
                DisappearingDeductible = false,
                Taxable = true,
                Providers = new ObservableCollection<CoverageProviderDataModel>(),
                Plans = new ObservableCollection<CoveragePlanDataModel>()
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
                DisappearingDeductible = false,
                Taxable = true,
                Providers = new ObservableCollection<CoverageProviderDataModel>(),
                Plans = new ObservableCollection<CoveragePlanDataModel>()

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
                DisappearingDeductible = false,
                Taxable = true,
                Providers = new ObservableCollection<CoverageProviderDataModel>(),
                Plans = new ObservableCollection<CoveragePlanDataModel>()

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
                Plans = new ObservableCollection<CoveragePlanDataModel>()
            };
        }

        #endregion
    }
}
