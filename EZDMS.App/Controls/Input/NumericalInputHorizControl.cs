﻿using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace EZDMS.App
{
    /// <summary>
    /// Interaction logic for NumericalInputHorizControl.xaml
    /// </summary>
    public partial class NumericalInputHorizControl : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// The label width of the control
        /// </summary>
        public GridLength LabelWidth
        {
            get => (GridLength)GetValue(LabelWidthProperty);
            set => SetValue(LabelWidthProperty, value);
        }

        // Using a DependencyProperty as the backing store for LabelWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(GridLength), typeof(NumericalInputHorizControl), new PropertyMetadata(GridLength.Auto, LabelWidthChangedCallback));

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public NumericalInputHorizControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Dependency Callbacks

        /// <summary>
        /// Called when the label width has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        public static void LabelWidthChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                // Set the column definition width to the new value
                (d as NumericalInputHorizControl).LabelColumnDefinition.Width = (GridLength)e.NewValue;
            }

// Making ex available for developer on break
#pragma warning disable CS0168
            catch (Exception ex)
#pragma warning restore CS0168
            {
                // Make developer aware of potential issue
                Debugger.Break();

                (d as NumericalInputHorizControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }

        #endregion
    }
}
