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
using System.Windows.Shapes;
using Tema3_MVP.Models.EntityLayer;
using Tema3_MVP.ViewModels;

namespace Tema3_MVP.Views
{
    /// <summary>
    /// Interaction logic for AddAbsenceView.xaml
    /// </summary>
    public partial class AddAbsenceView : Window
    {
        public AddAbsenceView(Teacher teacher)
        {
            InitializeComponent();
            DataContext = new AddAbsenceVM(teacher);   
        }
    }
}
