
namespace EZDMS.App
{
    /// <summary>
    /// The view model for the <see cref="DialogCustomerSelect"/>
    /// <summary>
    public class CustomerSelectDialogViewModel:BaseDialogViewModel
    {

        #region Private Members

        protected CustomersListViewModel mCustomer;

        #endregion

        #region Public Properties

        /// <summary>
        /// The view model for the customer list
        /// </summary>
        public CustomersListViewModel Customer
        {
            get => mCustomer;
            set
            {
                // If datamodel has not changed...
                if (mCustomer == value)
                    // Ignore
                    return;

                // Set the backing datamodel
                mCustomer = value;

                //if (value != null)
                //    // Reload sales deal view model
                //    UpdateValuesOfSalesDealCard(SalesDealsItem);
            }
        }

        #endregion

            #region Constructor

            /// <summary>
            /// Default constructor
            /// </summary>
        public CustomerSelectDialogViewModel()
        {
            
        }

        #endregion
    }
}
