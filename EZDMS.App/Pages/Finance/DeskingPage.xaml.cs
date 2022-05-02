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
using EZDMS.App.Core;

namespace EZDMS.App
{
    /// <summary>
    /// Interaction logic for DeskingPage.xaml
    /// </summary>
    public partial class DeskingPage : BasePage<DeskingInfoViewModel>
    {
        public DeskingPage() : base()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific view model to use for this page</param>
        public DeskingPage(DeskingInfoViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

    }
}
