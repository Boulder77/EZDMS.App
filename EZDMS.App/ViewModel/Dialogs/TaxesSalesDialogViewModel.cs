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
    /// The view model for the <see cref="DialogTotalTaxesSales"/>
    /// <summary>
    public class TaxesSalesDialogViewModel:BaseDialogViewModel
    {

        private TaxItemViewModel mStateTax;


        #region Public Properties

        /// <summary>
        /// The list of all the product providers
        /// </summary>
        public SystemTaxesDataModel SystemTaxes { get; set; }

        /// <summary>
        /// The list of all the product plans
        /// </summary>
        public SalesTaxesDataModel SalesTaxes { get; set; }


        /// <summary>
        /// The SalesTaxes taxes in payment
        /// <summary>
        public bool TaxesInPayment { get; set; }

        /// <summary>
        /// The state tax view model
        /// <summary>
        public TaxItemViewModel StateTax { get; set; }

        /// <summary>
        /// The county tax view model
        /// <summary>
        public TaxItemViewModel CountyTax { get; set; }

        /// <summary>
        /// The local tax view model
        /// <summary>
        public TaxItemViewModel CityTax { get; set; }

        /// <summary>
        /// The other tax view model
        /// <summary>
        public TaxItemViewModel OtherTax { get; set; }

        /// <summary>
        /// The total tax amount
        /// </summary>
        public DecimalInputViewModel Total { get; set; }                

        /// <summary>
        /// Indicates if there is a save action
        /// </summary>
        public bool Saving { get; set; }

        /// <summary>
        /// Indicates if the dialog has loaded
        /// </summary>
        public bool Loading { get; set; }

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
        public TaxesSalesDialogViewModel()
        {
            // Create commands
            SaveCommand = new RelayCommand(async () => await SaveAsync());
                
            Task.Run(LoadAsync);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Initialize products view models and controls 
        /// </summary>
        /// <returns></returns>
        public async Task LoadAsync()
        {
            await RunCommandAsync(() => Loading, async () =>
            {

                // Get active local fees
                SystemTaxes = await ClientDataStore.GetSystemTaxesAsync("STORE01");


                //Get the current sales licensing fees
                SalesTaxes = await ClientDataStore.GetSalesTaxesAsync(ViewModelSalesFinance.SalesFinanceDeal.DealNumber);

                // if does not exist
                if (SalesTaxes == null)
                    // exit
                    return;
                
                // Update the taxes VM
                SetTaxesVM();
                CalculateSalesTaxes();

            });


        }

        public async Task SaveAsync()
        {
            await RunCommandAsync(() => Saving, async () =>

            {

                await Task.Run(UpdateSalexTaxDM);                               
                
                // save the sales taxes to db store
                await ClientDataStore.SaveSalesRecordAsync(SalesTaxes, DbTableNames.SalesTaxes);               


            });

            // exit dialog
            CloseAction();

        }

        #endregion

        public async Task<bool> UpdateTaxesAsync()
        {

            CalculateSalesTaxes();

            // Lock this command to ignore any other requests while processing
            await Task.Delay(1);
            return true;
            
        }

        #region Private Helper Methods

       
        private void SetTaxesVM()
        {

            StateTax = new TaxItemViewModel { Name = SalesTaxes.StateTaxName, Active = SystemTaxes.StateTaxActive, Base = SalesTaxes.StateTaxBase, Rate = SalesTaxes.StateTaxRate,SaveAction=UpdateTaxesAsync };
            CountyTax = new TaxItemViewModel { Name = SalesTaxes.CountyTaxName, Active = SystemTaxes.CountyTaxActive, Base = SalesTaxes.CountyTaxBase, Rate = SalesTaxes.CountyTaxRate };
            CityTax = new TaxItemViewModel { Name = SalesTaxes.CityTaxName, Active = SystemTaxes.CityTaxActive, Base = SalesTaxes.CityTaxBase, Rate = SalesTaxes.CityTaxRate };
            OtherTax = new TaxItemViewModel { Name = SalesTaxes.OtherTaxName, Active = SystemTaxes.OtherTaxActive, Base = SalesTaxes.OtherTaxBase, Rate = SalesTaxes.OtherTaxRate };
            Total = new DecimalInputViewModel { Label = "Total", Amount = SalesTaxes.OtherTaxAmount + SalesTaxes.StateTaxAmount + SalesTaxes.CountyTaxAmount + SalesTaxes.CityTaxAmount };

        }

        /// <summary>
        /// Update sales tax data model
        /// </summary>
        private void UpdateSalexTaxDM()
        {

             if (SalesTaxes==null) return;

            SalesTaxes.CityTaxActive = CityTax.Active;
            SalesTaxes.CityTaxAmount=CityTax.Amount;
            SalesTaxes.CityTaxBase = CityTax.Base;
            SalesTaxes.CityTaxName = CityTax.Name;
            SalesTaxes.CityTaxRate = CityTax.Rate;
            SalesTaxes.CountyTaxActive = CountyTax.Active;
            SalesTaxes.CountyTaxAmount = CountyTax.Amount;
            SalesTaxes.CountyTaxBase = CountyTax.Base;
            SalesTaxes.CountyTaxName = CountyTax.Name;
            SalesTaxes.CountyTaxRate = CountyTax.Rate;
            SalesTaxes.StateTaxActive = StateTax.Active;
            SalesTaxes.StateTaxAmount = StateTax.Amount;
            SalesTaxes.StateTaxBase = StateTax.Base;
            SalesTaxes.StateTaxName = StateTax.Name;
            SalesTaxes.StateTaxRate = StateTax.Rate;
            SalesTaxes.OtherTaxActive = OtherTax.Active;
            SalesTaxes.OtherTaxAmount = OtherTax.Amount;
            SalesTaxes.OtherTaxBase = OtherTax.Base;
            SalesTaxes.OtherTaxName = OtherTax.Name;
            SalesTaxes.OtherTaxRate = OtherTax.Rate;

        }

        private void CalculateSalesTaxes()
        {

           

            // Update State Tax amount
            if (SystemTaxes.StateTaxActive == true)
            {
                                
                StateTax.Amount = (StateTax.Base * StateTax.Rate) / 100;

            }

            // Update County Tax amount
            if (SystemTaxes.CountyTaxActive == true)
            {

                CountyTax.Amount = (CountyTax.Base * CountyTax.Rate) / 100;

            }

            // Update City Tax amount
            if (SystemTaxes.CityTaxActive == true)
            {

                CityTax.Amount = (CityTax.Base * CityTax.Rate) / 100;

            }

            // Update Other Tax amount
            if (SystemTaxes.OtherTaxActive == true)
            {

                OtherTax.Amount = (OtherTax.Base * OtherTax.Rate) / 100;

            }            

            Total.Amount = StateTax.Amount + CityTax.Amount + OtherTax.Amount+ CountyTax.Amount;

        }




        #endregion
    }
}
