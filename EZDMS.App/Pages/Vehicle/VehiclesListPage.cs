﻿using System;
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
    /// Interaction logic for VehiclesListPage.xaml
    /// </summary>
    public partial class VehiclesListPage : BasePage<VehiclesListViewModel>
    {
        public VehiclesListPage()
        {
            InitializeComponent();
            
        }

        public VehiclesListPage(VehiclesListViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

    }
}
