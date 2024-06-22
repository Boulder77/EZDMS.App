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

                // Get active local fees
                SystemLocalFees = await ClientDataStore.GetSystemLocalFeesAsync("STORE01");


                //Get the current sales licensing fees
                CurrentSalesLicensing = await ClientDataStore.GetSalesLicensingAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

                // if does not exist
                if (CurrentSalesLicensing == null)
                    // exit
                    return;
                
                // Update licensing VM
                SetLicensingVM(CurrentSalesLicensing);
                
                // Get the current sales local fees
                CurrentSalesLocalFees = await ClientDataStore.GetSalesLocalFeesAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

                // if local fees does not exist
                if (CurrentSalesLocalFees == null)
                    // exit
                    return;                                

                // Set the local fees control view model
                SetLocalFeesVM(CurrentSalesLocalFees);

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

       
        private void SetLicensingVM(SalesLicensingFeesDataModel salesLicensing)
        {



            SalesLicensing = new SalesLicensingViewModel 
            
            {
            FeesInPayment = salesLicensing.FeesInPayment,

            LicenseFee = new DecimalInputViewModel { Label = "License", Amount = salesLicensing.LicenseFee },
            
            TitleFee = new DecimalInputViewModel { Label = "Title", Amount = salesLicensing.TitleFee },

            PlateFee = new DecimalInputViewModel { Label = "Plates", Amount = salesLicensing.PlateFee },

            TempTagFee = new DecimalInputViewModel { Label = "Temp Tag", Amount = salesLicensing.TempTagFee },

            RegistrationFee = new DecimalInputViewModel { Label = "Registration", Amount = salesLicensing.RegistrationFee },

            TransferFee = new DecimalInputViewModel { Label = "Transfer", Amount = salesLicensing.TransferFee },

            NotaryFee = new DecimalInputViewModel { Label = "Notary", Amount = salesLicensing.NotaryFee },

            FilingFee = new DecimalInputViewModel { Label = "Filing", Amount = salesLicensing.FilingFee },

            Total = new DecimalInputViewModel { Label = "Total", Amount = salesLicensing.LicenseFee + salesLicensing.TitleFee + salesLicensing.PlateFee
            + salesLicensing.NotaryFee + salesLicensing.TransferFee + salesLicensing.TempTagFee + salesLicensing.RegistrationFee + salesLicensing.FilingFee },

        };
            


        }


        private void SetLocalFeesVM(SalesLocalFeesDataModel salesLocalFees)
        {

            SalesLocalFees = new SalesLocalFeesViewModel 
            {
                
                DocumentationFee = new LocalFeeViewModel { Label = "Document", Amount = salesLocalFees.DocumentationFee, InPayment=salesLocalFees.DocumentationFeeInPayment, Taxable=salesLocalFees.DocumentationFeeTaxable, Active=SystemLocalFees.DocumentationFeeActive},
                TireFee = new LocalFeeViewModel { Label = "Tire", Amount = salesLocalFees.TireFee, InPayment = salesLocalFees.TireFeeInPayment, Taxable = salesLocalFees.TireFeeTaxable, Active = SystemLocalFees.TireFeeActive },
                InspectionFee = new LocalFeeViewModel { Label = "Inspection", Amount = salesLocalFees.InspectionFee, InPayment = salesLocalFees.InspectionFeeInPayment, Taxable = salesLocalFees.InspectionFeeTaxable, Active = SystemLocalFees.InspectionFeeActive },
                MessengerFee = new LocalFeeViewModel {Label = "Messenger", Amount = salesLocalFees.MessengerFee, InPayment = salesLocalFees.MessengerFeeInPayment, Taxable = salesLocalFees.MessengerFeeTaxable, Active = SystemLocalFees.MessengerFeeActive },
                BatteryFee = new LocalFeeViewModel {Label = "Battery", Amount = salesLocalFees.BatteryFee, InPayment = salesLocalFees.BatteryFeeInPayment, Taxable = salesLocalFees.BatteryFeeTaxable, Active = SystemLocalFees.BatteryFeeActive },
                SmogStateFee = new LocalFeeViewModel {Label = "Smog", Amount = salesLocalFees.SmogStateFee, InPayment = salesLocalFees.SmogStateFeeInPayment, Taxable = salesLocalFees.SmogStateFeeTaxable, Active = SystemLocalFees.SmogStateFeeActive },
                SmogToSellerFee = new LocalFeeViewModel {Label = "SmogToSeller", Amount = salesLocalFees.SmogToSellerFee, InPayment = salesLocalFees.SmogToSellerFeeInPayment, Taxable = salesLocalFees.SmogToSellerFeeTaxable, Active = SystemLocalFees.SmogToSellerFeeActive },
                SmogAbatementFee = new LocalFeeViewModel {Label = "Smog", Amount = salesLocalFees.SmogAbatementFee, InPayment = salesLocalFees.SmogAbatementFeeInPayment, Taxable = salesLocalFees.SmogAbatementFeeTaxable, Active = SystemLocalFees.SmogAbatementFeeActive },
                DocStampsFee = new LocalFeeViewModel {Label = "DocStamps", Amount = salesLocalFees.DocStampsFee, InPayment = salesLocalFees.DocStampsFeeInPayment, Taxable = salesLocalFees.DocStampsFeeTaxable, Active = SystemLocalFees.DocStampsFeeActive },
                ElectronicFilingFee = new LocalFeeViewModel {Label = "Electronic Filing", Amount = salesLocalFees.ElectronicFilingFee, InPayment = salesLocalFees.ElectronicFilingFeeInPayment, Taxable = salesLocalFees.ElectronicFilingFeeTaxable, Active = SystemLocalFees.ElectronicFilingFeeActive },
                EVChargingFee = new LocalFeeViewModel {Label = "EVCharging", Amount = salesLocalFees.EVChargingFee, InPayment = salesLocalFees.EVChargingFeeInPayment, Taxable = salesLocalFees.EVChargingFeeTaxable, Active = SystemLocalFees.EVChargingFeeActive },
                StateInspectionFee = new LocalFeeViewModel {Label = "StateInspection", Amount = salesLocalFees.StateInspectionFee, InPayment = salesLocalFees.StateInspectionFeeInPayment, Taxable = salesLocalFees.StateInspectionFeeTaxable, Active = SystemLocalFees.StateInspectionFeeActive },
                EmissionsFee = new LocalFeeViewModel {Label = "Smog", Amount = salesLocalFees.EmissionsFee, InPayment = salesLocalFees.EmissionsFeeInPayment, Taxable = salesLocalFees.EmissionsFeeTaxable, Active = SystemLocalFees.EmissionsFeeActive },
                LocalFee1 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee1Name, Amount = salesLocalFees.LocalFee1, InPayment = salesLocalFees.LocalFee1InPayment, Taxable = salesLocalFees.LocalFee1Taxable, Active = SystemLocalFees.LocalFee1Active },
                LocalFee2 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee2Name, Amount = salesLocalFees.LocalFee2, InPayment = salesLocalFees.LocalFee2InPayment, Taxable = salesLocalFees.LocalFee2Taxable, Active = SystemLocalFees.LocalFee2Active },
                LocalFee3 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee3Name, Amount = salesLocalFees.LocalFee3, InPayment = salesLocalFees.LocalFee3InPayment, Taxable = salesLocalFees.LocalFee3Taxable, Active = SystemLocalFees.LocalFee3Active },
                LocalFee4 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee4Name, Amount = salesLocalFees.LocalFee4, InPayment = salesLocalFees.LocalFee4InPayment, Taxable = salesLocalFees.LocalFee4Taxable, Active = SystemLocalFees.LocalFee4Active },
                LocalFee5 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee5Name, Amount = salesLocalFees.LocalFee5, InPayment = salesLocalFees.LocalFee5InPayment, Taxable = salesLocalFees.LocalFee5Taxable, Active = SystemLocalFees.LocalFee5Active },
                LocalFee6 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee6Name, Amount = salesLocalFees.LocalFee6, InPayment = salesLocalFees.LocalFee6InPayment, Taxable = salesLocalFees.LocalFee6Taxable, Active = SystemLocalFees.LocalFee6Active },
                LocalFee7 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee7Name, Amount = salesLocalFees.LocalFee7, InPayment = salesLocalFees.LocalFee7InPayment, Taxable = salesLocalFees.LocalFee7Taxable, Active = SystemLocalFees.LocalFee7Active },
                LocalFee8 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee8Name, Amount = salesLocalFees.LocalFee8, InPayment = salesLocalFees.LocalFee8InPayment, Taxable = salesLocalFees.LocalFee8Taxable, Active = SystemLocalFees.LocalFee8Active },
                LocalFee9 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee9Name, Amount = salesLocalFees.LocalFee9, InPayment = salesLocalFees.LocalFee9InPayment, Taxable = salesLocalFees.LocalFee9Taxable, Active = SystemLocalFees.LocalFee9Active },
                LocalFee10 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee10Name, Amount = salesLocalFees.LocalFee10, InPayment = salesLocalFees.LocalFee10InPayment, Taxable = salesLocalFees.LocalFee10Taxable, Active = SystemLocalFees.LocalFee10Active },
            };
          

        }




        private void UpdateTotalRetail()
        {

            SalesLicensing.Total.Amount = CurrentSalesLicensing.LicenseFee + CurrentSalesLicensing.TitleFee + CurrentSalesLicensing.PlateFee +CurrentSalesLicensing.NotaryFee + CurrentSalesLicensing.TransferFee + CurrentSalesLicensing.TempTagFee + CurrentSalesLicensing.RegistrationFee + CurrentSalesLicensing.FilingFee;
            SalesLocalFees.Total.Amount = CurrentSalesLocalFees.DocumentationFee + CurrentSalesLocalFees.TireFee + CurrentSalesLocalFees.InspectionFee + CurrentSalesLocalFees.MessengerFee + CurrentSalesLocalFees.BatteryFee + CurrentSalesLocalFees.SmogToSellerFee + CurrentSalesLocalFees.DocStampsFee + CurrentSalesLocalFees.EVChargingFee + CurrentSalesLocalFees.StateInspectionFee + CurrentSalesLocalFees.SmogStateFee + CurrentSalesLocalFees.SmogAbatementFee + CurrentSalesLocalFees.EmissionsFee + CurrentSalesLocalFees.ElectronicFilingFee + CurrentSalesLocalFees.LocalFee1 + CurrentSalesLocalFees.LocalFee2 + CurrentSalesLocalFees.LocalFee3 + CurrentSalesLocalFees.LocalFee4 + CurrentSalesLocalFees.LocalFee5 + CurrentSalesLocalFees.LocalFee6 + CurrentSalesLocalFees.LocalFee7 + CurrentSalesLocalFees.LocalFee8 + CurrentSalesLocalFees.LocalFee9 + CurrentSalesLocalFees.LocalFee10;



            TotalFees = new DecimalInputViewModel
            {
                Label = "Total Fees",
                

                Amount = SalesLocalFees.Total.Amount + SalesLicensing.Total.Amount 
            };

        }


    #endregion
}
}
