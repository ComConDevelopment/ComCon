﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComCon.Client.Modules.Menu
{
    /// <summary>
    /// Interaktionslogik für Menu.xaml
    /// </summary>
    [Export]
    public partial class Menu : UserControl
    {

        public Menu()
        {
           
            this.DataContext = this;
            InitializeComponent();
        }
    }
}
