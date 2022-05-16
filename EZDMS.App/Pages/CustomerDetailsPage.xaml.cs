using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EZDMS.App

{
    /// <summary>
    /// Interaction logic for BuyerDetailsPage.xaml
    /// </summary>
    public partial class CustomerDetailsPage : BasePage<CustomerViewModel>

    {

        public CustomerDetailsPage() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use for this page</param>
        public CustomerDetailsPage(CustomerViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }


    }

}
