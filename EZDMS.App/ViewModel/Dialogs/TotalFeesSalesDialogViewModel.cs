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
    /// The view model for the <see cref="DialogTotalFeesSales"/>
    /// <summary>
    public class TotalFeesSalesDialogViewModel:BaseDialogViewModel
    {

        #region Public Properties

        /// <summary>
        /// The list of all the product providers
        /// </summary>
        public SystemLicensingFeesDataModel SystemLicensing { get; set; }

        /// <summary>
        /// The list of all the product plans
        /// </summary>
        public SystemLocalFeesDataModel SystemLocalFees { get; set; }

        /// <summary>
        /// The list of all the product plans
        /// </summary>
        public SystemBankFeesDataModel SystemBankFees { get; set; }

        /// <summary>
        /// The view model for the service contract 
        /// </summary>
        public SalesLicensingFeesDataModel CurrentSalesLicensing { get; set; }
        
        /// <summary>
        /// The view model for the warranty
        /// </summary>
        public SalesLocalFeesDataModel CurrentSalesLocalFees { get; set; }

        /// <summary>
        /// The view model for the current sales bank fees
        /// </summary>
        public SalesBankFeesDataModel CurrentSalesBankFees { get; set; }        

        /// <summary>
        /// The view model for the sales licensing control
        /// </summary>
        public SalesLicensingViewModel SalesLicensing { get; set; }

        /// <summary>
        /// The view model for the sales local fees control
        /// </summary>
        public SalesLocalFeesViewModel SalesLocalFees { get; set; }

        /// <summary>
        /// The view model for the sales local fees control
        /// </summary>
        public SalesBankFeesViewModel SalesBankFees { get; set; }





        /// <summary>
        /// The text for the total retail 
        /// </summary>
        public DecimalInputViewModel TotalFees { get; set; }

        /// <summary>
        /// Indicates if there is a save action
        /// </summary>
        public bool Saving { get; set; }

        /// <summary>
        /// Indicates if the dialog has loaded
        /// </summary>
        public bool FeesLoading { get; set; }

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
        public TotalFeesSalesDialogViewModel()
        {
            // Create commands
            SaveCommand = new RelayCommand(async () => await SaveFeesAsync());
                
            Task.Run(LoadFeesAsync);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Initialize products view models and controls 
        /// </summary>
        /// <returns></returns>
        public async Task LoadFeesAsync()
        {
            await RunCommandAsync(() => FeesLoading, async () =>
            {
                
                //// Get the default settings for the licensing fees
                //SystemLicensing = await ClientDataStore.GetSystemLicensingAsync("STORE01");

                //// Get the default settings for the local fees
                //SystemLocalFees = await ClientDataStore.GetSystemLocalFeesAsync("STORE01");

                //// Get the current sales licensing fees
                //CurrentSalesLicensing = await ClientDataStore.GetSalesLicensingAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

                //// Get the current sales local fees
                //CurrentSalesLocalFees = await ClientDataStore.GetSalesLocalFeesAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

                //// Get the current sales licensing fees
                //CurrentSalesLicensing = await ClientDataStore.GetSalesLicensingAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

                // Get the current sales bank fees
                //CurrentSalesBankFees = await ClientDataStore.GetSalesBankFeesAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

                // Update sales licensing vm


                //if (CurrentSalesLicensing != null)
                    // Update service view model
                    UpdateLicensingVM(CurrentSalesLicensing);

                //if (CurrentSalesLocalFees != null)
                    // Update service view model
                    UpdateLocalFeesVM(CurrentSalesLocalFees);


                await Task.Delay(1);


            });


        }

        public async Task SaveFeesAsync()
        {
            await RunCommandAsync(() => Saving, async () =>
            {

                // Get the current sales licensing fees
                CurrentSalesLicensing = await ClientDataStore.GetSalesLicensingAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

               
                    // Check if record exists
                    if (CurrentSalesLicensing == null)
                    {
                    CurrentSalesLicensing = new SalesLicensingFeesDataModel
                        {
                            DealNumber = ViewModelSalesFinance.SalesFinanceDeal.DealNumber,

                        };

                        await ClientDataStore.AddNewSalesRecordAsync(CurrentSalesLicensing, DbTableNames.SalesLicensing);

                    }
                    //// Update data model
                    //await Task.Run(UpdateServiceDM);

                    //// Save to the data store                    
                    //await ClientDataStore.SaveSalesRecordAsync(SalesService, DbTableNames.SalesService);

                    //// Update Sales finance deal view model
                    //ViewModelSalesFinance.SalesFinanceDeal.ServiceContract = SalesService.Retail;
                

                // Get the stored record
                CurrentSalesLocalFees = await ClientDataStore.GetSalesLocalFeesAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);


                // Check if record exists
                if (CurrentSalesLocalFees == null)
                {
                    CurrentSalesLocalFees = new SalesLocalFeesDataModel
                    {
                        DealNumber = ViewModelSalesFinance.SalesFinanceDeal.DealNumber,

                    };

                    await ClientDataStore.AddNewSalesRecordAsync(CurrentSalesLocalFees, DbTableNames.SalesLocalFees);

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

       
        private void UpdateLicensingVM(SalesLicensingFeesDataModel salesLicensing)
        {

            SalesLicensing = new SalesLicensingViewModel 
            
            {
            FeesInPayment = true,

            LicenseFee = new DecimalInputViewModel { Label = "License", Amount = 3400 },

            TitleFee = new DecimalInputViewModel { Label = "Title", Amount = 6500 },

            PlateFee = new DecimalInputViewModel { Label = "Plates", Amount = 6500 },

            TempTagFee = new DecimalInputViewModel { Label = "Temp Tag", Amount = 1325 },

            RegistrationFee = new DecimalInputViewModel { Label = "Registration", Amount = 24639 },

            TransferFee = new DecimalInputViewModel { Label = "Transfer", Amount = 1200 },

            NotaryFee = new DecimalInputViewModel { Label = "Notary", Amount = 1400 },

            FilingFee = new DecimalInputViewModel { Label = "Filing", Amount = 5000 },

            Total = new DecimalInputViewModel { Label = "Total", Amount = 49964 },

        };
            


        }


        private void UpdateLocalFeesVM(SalesLocalFeesDataModel salesLocalFees)
        {
            SalesLocalFees = new SalesLocalFeesViewModel 
            {
            DocumentationFee = new LocalFeeViewModel { Label = "Document", Amount = 12900, },
            TireFee = new LocalFeeViewModel { Label = "Tire", Amount = 1300 },
            InspectionFee = new LocalFeeViewModel { Label = "Inspection", Amount = 6500 },
            BatteryFee = new LocalFeeViewModel { Label = "Battery", Amount = 1825 },
            SmogStateFee = new LocalFeeViewModel { Label = "Smog", Amount = 3500 },
            ElectronicFilingFee = new LocalFeeViewModel { Label = "Electronic Filing", Amount = 6500 },
            LocalFee1 = new LocalFeeViewModel { Label = "Misc", Amount = 1400 },
            Total = new DecimalInputViewModel { Label = "Total", Amount = 49964 },


        };
          

        }




        private void UpdateTotalRetail()
        {

            TotalFees = new DecimalInputViewModel
            {
                Label = "Total Fees",

                Amount = SalesLocalFees.Total.Amount + SalesLicensing.Total.Amount 
            };

        }


    #endregion
}
}
