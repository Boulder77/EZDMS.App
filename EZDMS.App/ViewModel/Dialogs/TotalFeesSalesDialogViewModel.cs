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
using System.Numerics;


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


                await Task.Run(UpdateTotalRetailAsync);

            });


        }

        public async Task SaveFeesAsync()
        {
            await RunCommandAsync(() => Saving, async () =>
            {

                // Update the licensing fees dm
                UpdateLicensingDM();

                // save the sales licensing fees to db store
                await ClientDataStore.SaveSalesRecordAsync(CurrentSalesLicensing, DbTableNames.SalesLicensing);

                // Update the local fees dm
                UpdateLocalFeesDM();

                // Save the sales local fees to db store
                await ClientDataStore.SaveSalesRecordAsync(CurrentSalesLocalFees, DbTableNames.SalesLocalFees);

                // Update the totals
                await Task.Run(UpdateTotalRetailAsync);

                // Update Sales finance deal view model
                ViewModelSalesFinance.SalesFinanceDeal.TotalDealerFees = SalesLocalFees.Total.Amount;
                ViewModelSalesFinance.SalesFinanceDeal.TotalOfficialFees = SalesLicensing.Total.Amount;


            });

            // exit dialog
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

            LicenseFee = new DecimalInputViewModel { Label = "License", Amount = salesLicensing.LicenseFee, CommitAction=UpdateTotalRetailAsync },
            
            TitleFee = new DecimalInputViewModel { Label = "Title", Amount = salesLicensing.TitleFee, CommitAction = UpdateTotalRetailAsync },

            PlateFee = new DecimalInputViewModel { Label = "Plates", Amount = salesLicensing.PlateFee, CommitAction = UpdateTotalRetailAsync },

            TempTagFee = new DecimalInputViewModel { Label = "Temp Tag", Amount = salesLicensing.TempTagFee, CommitAction = UpdateTotalRetailAsync },

            RegistrationFee = new DecimalInputViewModel { Label = "Registration", Amount = salesLicensing.RegistrationFee, CommitAction = UpdateTotalRetailAsync },

            TransferFee = new DecimalInputViewModel { Label = "Transfer", Amount = salesLicensing.TransferFee, CommitAction = UpdateTotalRetailAsync },

            NotaryFee = new DecimalInputViewModel { Label = "Notary", Amount = salesLicensing.NotaryFee, CommitAction = UpdateTotalRetailAsync },

            FilingFee = new DecimalInputViewModel { Label = "Filing", Amount = salesLicensing.FilingFee, CommitAction = UpdateTotalRetailAsync },

            Total = new DecimalInputViewModel { Label = "Total", Amount = salesLicensing.LicenseFee + salesLicensing.TitleFee + salesLicensing.PlateFee
            + salesLicensing.NotaryFee + salesLicensing.TransferFee + salesLicensing.TempTagFee + salesLicensing.RegistrationFee + salesLicensing.FilingFee },

        };
            


        }

        private void UpdateLicensingDM()
        {

            /// Create new sales licensing fees
            CurrentSalesLicensing = new SalesLicensingFeesDataModel
            {
                DealNumber = ViewModelSalesFinance.SalesFinanceDeal.DealNumber,
                FeesInPayment = SalesLicensing.FeesInPayment,
                LicenseFee = SalesLicensing.LicenseFee.Amount,
                TitleFee = SalesLicensing.TitleFee.Amount,
                PlateFee = SalesLicensing.PlateFee.Amount,
                TempTagFee = SalesLicensing.TempTagFee.Amount,
                RegistrationFee = SalesLicensing.RegistrationFee.Amount,
                TransferFee = SalesLicensing.TransferFee.Amount,
                NotaryFee = SalesLicensing.NotaryFee.Amount,
                FilingFee = SalesLicensing.FilingFee.Amount,
            };

        }

        private void UpdateLocalFeesDM()
        {

            /// Create new sales licensing fees
            CurrentSalesLocalFees = new SalesLocalFeesDataModel
            {
               DealNumber = ViewModelSalesFinance.SalesFinanceDeal.DealNumber,
               DocumentationFeeInPayment = SalesLocalFees.DocumentationFee.InPayment,
               DocumentationFeeTaxable = SalesLocalFees.DocumentationFee.Taxable,
               DocumentationFee = SalesLocalFees.DocumentationFee.Amount,
               TireFeeInPayment = SalesLocalFees.TireFee.InPayment,
               TireFeeTaxable = SalesLocalFees.TireFee.Taxable,
               TireFee = SalesLocalFees.TireFee.Amount,
               InspectionFeeInPayment = SalesLocalFees.InspectionFee.InPayment,
               InspectionFeeTaxable = SalesLocalFees.InspectionFee.Taxable,
               InspectionFee = SalesLocalFees.InspectionFee.Amount,
               MessengerFeeInPayment = SalesLocalFees.MessengerFee.InPayment,
               MessengerFeeTaxable = SalesLocalFees.MessengerFee.Taxable,
               MessengerFee = SalesLocalFees.MessengerFee.Amount,
               BatteryFeeInPayment = SalesLocalFees.BatteryFee.InPayment,
               BatteryFeeTaxable = SalesLocalFees.BatteryFee.Taxable,
               BatteryFee = SalesLocalFees.BatteryFee.Amount,
               SmogAbatementFeeInPayment = SalesLocalFees.SmogAbatementFee.InPayment,
               SmogAbatementFeeTaxable = SalesLocalFees.SmogAbatementFee.Taxable,
               SmogAbatementFee = SalesLocalFees.SmogAbatementFee.Amount,
               SmogStateFeeInPayment = SalesLocalFees.SmogStateFee.InPayment,
               SmogStateFeeTaxable = SalesLocalFees.SmogStateFee.Taxable,
               SmogStateFee = SalesLocalFees.SmogStateFee.Amount,
               SmogToSellerFeeInPayment = SalesLocalFees.SmogToSellerFee.InPayment,
               SmogToSellerFeeTaxable = SalesLocalFees.SmogToSellerFee.Taxable,
               SmogToSellerFee = SalesLocalFees.SmogToSellerFee.Amount,
               DocStampsFeeInPayment = SalesLocalFees.DocStampsFee.InPayment,
               DocStampsFeeTaxable = SalesLocalFees.DocStampsFee.Taxable,
               DocStampsFee = SalesLocalFees.DocStampsFee.Amount,
               ElectronicFilingFeeInPayment = SalesLocalFees.ElectronicFilingFee.InPayment,
               ElectronicFilingFeeTaxable = SalesLocalFees.ElectronicFilingFee.Taxable,
               ElectronicFilingFee = SalesLocalFees.ElectronicFilingFee.Amount,
               EmissionsFeeInPayment = SalesLocalFees.EmissionsFee.InPayment,
               EmissionsFeeTaxable = SalesLocalFees.EmissionsFee.Taxable,
               EmissionsFee = SalesLocalFees.EmissionsFee.Amount,
               EVChargingFeeInPayment = SalesLocalFees.EVChargingFee.InPayment,
               EVChargingFeeTaxable = SalesLocalFees.EVChargingFee.Taxable,
               EVChargingFee = SalesLocalFees.EVChargingFee.Amount,
               StateInspectionFeeInPayment = SalesLocalFees.StateInspectionFee.InPayment,
               StateInspectionFeeTaxable = SalesLocalFees.StateInspectionFee.Taxable,
               StateInspectionFee = SalesLocalFees.StateInspectionFee.Amount,
               LocalFee1Name = SalesLocalFees.LocalFee1.Label,
               LocalFee1 = SalesLocalFees.LocalFee1.Amount,
               LocalFee1InPayment = SalesLocalFees.LocalFee1.InPayment,
               LocalFee1Taxable = SalesLocalFees.LocalFee1.Taxable,
               LocalFee2Name = SalesLocalFees.LocalFee2.Label,
               LocalFee2 = SalesLocalFees.LocalFee2.Amount,
               LocalFee2InPayment = SalesLocalFees.LocalFee2.InPayment,
               LocalFee2Taxable = SalesLocalFees.LocalFee2.Taxable,
               LocalFee3Name = SalesLocalFees.LocalFee3.Label,
               LocalFee3 = SalesLocalFees.LocalFee3.Amount,
               LocalFee3InPayment = SalesLocalFees.LocalFee3.InPayment,
               LocalFee3Taxable = SalesLocalFees.LocalFee3.Taxable,
               LocalFee4Name = SalesLocalFees.LocalFee4.Label,
               LocalFee4 = SalesLocalFees.LocalFee4.Amount,
               LocalFee4InPayment = SalesLocalFees.LocalFee4.InPayment,
               LocalFee4Taxable = SalesLocalFees.LocalFee4.Taxable,
               LocalFee5Name = SalesLocalFees.LocalFee5.Label,
               LocalFee5 = SalesLocalFees.LocalFee5.Amount,
               LocalFee5InPayment = SalesLocalFees.LocalFee5.InPayment,
               LocalFee5Taxable = SalesLocalFees.LocalFee5.Taxable,
               LocalFee6Name = SalesLocalFees.LocalFee6.Label,
               LocalFee6 = SalesLocalFees.LocalFee6.Amount,
               LocalFee6InPayment = SalesLocalFees.LocalFee6.InPayment,
               LocalFee6Taxable = SalesLocalFees.LocalFee6.Taxable,
               LocalFee7Name = SalesLocalFees.LocalFee7.Label,
               LocalFee7 = SalesLocalFees.LocalFee7.Amount,
               LocalFee7InPayment = SalesLocalFees.LocalFee7.InPayment,
               LocalFee7Taxable = SalesLocalFees.LocalFee7.Taxable,
               LocalFee8Name = SalesLocalFees.LocalFee8.Label,
               LocalFee8 = SalesLocalFees.LocalFee8.Amount,
               LocalFee8InPayment = SalesLocalFees.LocalFee8.InPayment,
               LocalFee8Taxable = SalesLocalFees.LocalFee8.Taxable,
               LocalFee9Name = SalesLocalFees.LocalFee9.Label,
               LocalFee9 = SalesLocalFees.LocalFee9.Amount,
               LocalFee9InPayment = SalesLocalFees.LocalFee9.InPayment,
               LocalFee9Taxable = SalesLocalFees.LocalFee9.Taxable,
               LocalFee10Name = SalesLocalFees.LocalFee10.Label,
               LocalFee10 = SalesLocalFees.LocalFee10.Amount,
               LocalFee10InPayment = SalesLocalFees.LocalFee10.InPayment,
               LocalFee10Taxable = SalesLocalFees.LocalFee10.Taxable,

            };

        }


        private void SetLocalFeesVM(SalesLocalFeesDataModel salesLocalFees)
        {

            SalesLocalFees = new SalesLocalFeesViewModel 
            {
                
                DocumentationFee = new LocalFeeViewModel { Label = "Document", Amount = salesLocalFees.DocumentationFee, InPayment=salesLocalFees.DocumentationFeeInPayment, Taxable=salesLocalFees.DocumentationFeeTaxable, Active=SystemLocalFees.DocumentationFeeActive, SaveAction=UpdateTotalRetailAsync},
                TireFee = new LocalFeeViewModel { Label = "Tire", Amount = salesLocalFees.TireFee, InPayment = salesLocalFees.TireFeeInPayment, Taxable = salesLocalFees.TireFeeTaxable, Active = SystemLocalFees.TireFeeActive, SaveAction = UpdateTotalRetailAsync },
                InspectionFee = new LocalFeeViewModel { Label = "Inspection", Amount = salesLocalFees.InspectionFee, InPayment = salesLocalFees.InspectionFeeInPayment, Taxable = salesLocalFees.InspectionFeeTaxable, Active = SystemLocalFees.InspectionFeeActive, SaveAction = UpdateTotalRetailAsync },
                MessengerFee = new LocalFeeViewModel { Label = "Messenger", Amount = salesLocalFees.MessengerFee, InPayment = salesLocalFees.MessengerFeeInPayment, Taxable = salesLocalFees.MessengerFeeTaxable, Active = SystemLocalFees.MessengerFeeActive, SaveAction = UpdateTotalRetailAsync },
                BatteryFee = new LocalFeeViewModel { Label = "Battery", Amount = salesLocalFees.BatteryFee, InPayment = salesLocalFees.BatteryFeeInPayment, Taxable = salesLocalFees.BatteryFeeTaxable, Active = SystemLocalFees.BatteryFeeActive, SaveAction = UpdateTotalRetailAsync },
                SmogStateFee = new LocalFeeViewModel { Label = "Smog", Amount = salesLocalFees.SmogStateFee, InPayment = salesLocalFees.SmogStateFeeInPayment, Taxable = salesLocalFees.SmogStateFeeTaxable, Active = SystemLocalFees.SmogStateFeeActive, SaveAction = UpdateTotalRetailAsync },
                SmogToSellerFee = new LocalFeeViewModel { Label = "SmogToSeller", Amount = salesLocalFees.SmogToSellerFee, InPayment = salesLocalFees.SmogToSellerFeeInPayment, Taxable = salesLocalFees.SmogToSellerFeeTaxable, Active = SystemLocalFees.SmogToSellerFeeActive, SaveAction = UpdateTotalRetailAsync },
                SmogAbatementFee = new LocalFeeViewModel { Label = "Smog", Amount = salesLocalFees.SmogAbatementFee, InPayment = salesLocalFees.SmogAbatementFeeInPayment, Taxable = salesLocalFees.SmogAbatementFeeTaxable, Active = SystemLocalFees.SmogAbatementFeeActive, SaveAction = UpdateTotalRetailAsync },
                DocStampsFee = new LocalFeeViewModel { Label = "DocStamps", Amount = salesLocalFees.DocStampsFee, InPayment = salesLocalFees.DocStampsFeeInPayment, Taxable = salesLocalFees.DocStampsFeeTaxable, Active = SystemLocalFees.DocStampsFeeActive, SaveAction = UpdateTotalRetailAsync },
                ElectronicFilingFee = new LocalFeeViewModel { Label = "Electronic Filing", Amount = salesLocalFees.ElectronicFilingFee, InPayment = salesLocalFees.ElectronicFilingFeeInPayment, Taxable = salesLocalFees.ElectronicFilingFeeTaxable, Active = SystemLocalFees.ElectronicFilingFeeActive, SaveAction = UpdateTotalRetailAsync },
                EVChargingFee = new LocalFeeViewModel { Label = "EVCharging", Amount = salesLocalFees.EVChargingFee, InPayment = salesLocalFees.EVChargingFeeInPayment, Taxable = salesLocalFees.EVChargingFeeTaxable, Active = SystemLocalFees.EVChargingFeeActive, SaveAction = UpdateTotalRetailAsync },
                StateInspectionFee = new LocalFeeViewModel { Label = "StateInspection", Amount = salesLocalFees.StateInspectionFee, InPayment = salesLocalFees.StateInspectionFeeInPayment, Taxable = salesLocalFees.StateInspectionFeeTaxable, Active = SystemLocalFees.StateInspectionFeeActive, SaveAction = UpdateTotalRetailAsync },
                EmissionsFee = new LocalFeeViewModel { Label = "Smog", Amount = salesLocalFees.EmissionsFee, InPayment = salesLocalFees.EmissionsFeeInPayment, Taxable = salesLocalFees.EmissionsFeeTaxable, Active = SystemLocalFees.EmissionsFeeActive, SaveAction = UpdateTotalRetailAsync },
                LocalFee1 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee1Name, Amount = salesLocalFees.LocalFee1, InPayment = salesLocalFees.LocalFee1InPayment, Taxable = salesLocalFees.LocalFee1Taxable, Active = SystemLocalFees.LocalFee1Active, SaveAction = UpdateTotalRetailAsync },
                LocalFee2 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee2Name, Amount = salesLocalFees.LocalFee2, InPayment = salesLocalFees.LocalFee2InPayment, Taxable = salesLocalFees.LocalFee2Taxable, Active = SystemLocalFees.LocalFee2Active, SaveAction = UpdateTotalRetailAsync },
                LocalFee3 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee3Name, Amount = salesLocalFees.LocalFee3, InPayment = salesLocalFees.LocalFee3InPayment, Taxable = salesLocalFees.LocalFee3Taxable, Active = SystemLocalFees.LocalFee3Active, SaveAction = UpdateTotalRetailAsync },
                LocalFee4 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee4Name, Amount = salesLocalFees.LocalFee4, InPayment = salesLocalFees.LocalFee4InPayment, Taxable = salesLocalFees.LocalFee4Taxable, Active = SystemLocalFees.LocalFee4Active, SaveAction = UpdateTotalRetailAsync },
                LocalFee5 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee5Name, Amount = salesLocalFees.LocalFee5, InPayment = salesLocalFees.LocalFee5InPayment, Taxable = salesLocalFees.LocalFee5Taxable, Active = SystemLocalFees.LocalFee5Active, SaveAction = UpdateTotalRetailAsync },
                LocalFee6 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee6Name, Amount = salesLocalFees.LocalFee6, InPayment = salesLocalFees.LocalFee6InPayment, Taxable = salesLocalFees.LocalFee6Taxable, Active = SystemLocalFees.LocalFee6Active, SaveAction = UpdateTotalRetailAsync },
                LocalFee7 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee7Name, Amount = salesLocalFees.LocalFee7, InPayment = salesLocalFees.LocalFee7InPayment, Taxable = salesLocalFees.LocalFee7Taxable, Active = SystemLocalFees.LocalFee7Active, SaveAction = UpdateTotalRetailAsync },
                LocalFee8 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee8Name, Amount = salesLocalFees.LocalFee8, InPayment = salesLocalFees.LocalFee8InPayment, Taxable = salesLocalFees.LocalFee8Taxable, Active = SystemLocalFees.LocalFee8Active, SaveAction = UpdateTotalRetailAsync },
                LocalFee9 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee9Name, Amount = salesLocalFees.LocalFee9, InPayment = salesLocalFees.LocalFee9InPayment, Taxable = salesLocalFees.LocalFee9Taxable, Active = SystemLocalFees.LocalFee9Active, SaveAction = UpdateTotalRetailAsync },
                LocalFee10 = new LocalFeeViewModel { Label = salesLocalFees.LocalFee10Name, Amount = salesLocalFees.LocalFee10, InPayment = salesLocalFees.LocalFee10InPayment, Taxable = salesLocalFees.LocalFee10Taxable, Active = SystemLocalFees.LocalFee10Active, SaveAction = UpdateTotalRetailAsync },
                Total = new DecimalInputViewModel {  Label = "TOTAL", Amount = 0}

            };
          

        }




        private void UpdateTotalRetail()
        {
            SalesLicensing.Total.Amount = SalesLicensing.LicenseFee.Amount + SalesLicensing.TitleFee.Amount + SalesLicensing.PlateFee.Amount + SalesLicensing.NotaryFee.Amount + SalesLicensing.TransferFee.Amount + SalesLicensing.TempTagFee.Amount + SalesLicensing.RegistrationFee.Amount + SalesLicensing.FilingFee.Amount;
            SalesLocalFees.Total.Amount = SalesLocalFees.DocumentationFee.Amount + SalesLocalFees.TireFee.Amount + SalesLocalFees.InspectionFee.Amount + SalesLocalFees.MessengerFee.Amount + SalesLocalFees.BatteryFee.Amount + SalesLocalFees.SmogToSellerFee.Amount + SalesLocalFees.DocStampsFee.Amount + SalesLocalFees.EVChargingFee.Amount + SalesLocalFees.StateInspectionFee.Amount + SalesLocalFees.SmogStateFee.Amount + SalesLocalFees.SmogAbatementFee.Amount + SalesLocalFees.EmissionsFee.Amount + SalesLocalFees.ElectronicFilingFee.Amount + SalesLocalFees.LocalFee1.Amount + SalesLocalFees.LocalFee2.Amount + SalesLocalFees.LocalFee3.Amount + SalesLocalFees.LocalFee4.Amount + SalesLocalFees.LocalFee5.Amount + SalesLocalFees.LocalFee6.Amount + SalesLocalFees.LocalFee7.Amount + SalesLocalFees.LocalFee8.Amount + SalesLocalFees.LocalFee9.Amount + SalesLocalFees.LocalFee10.Amount;



            TotalFees = new DecimalInputViewModel
            {
                Label = "Total Fees",
                

                Amount = SalesLocalFees.Total.Amount + SalesLicensing.Total.Amount 
            };

        }


    #endregion
}
}
