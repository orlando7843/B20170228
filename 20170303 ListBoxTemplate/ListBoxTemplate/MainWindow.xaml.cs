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

namespace ListBoxTemplate
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<TodoModel> items = new List<TodoModel>();
            items.Add(new TodoModel() { Title = "Complete this WPF tutorial", Completion = 45 });
            items.Add(new TodoModel() { Title = "Learn C#", Completion = 80 });
            items.Add(new TodoModel() { Title = "Wash the car", Completion = 0 });

            //直接對控件名稱操作
            lbTodoList.ItemsSource = items;
        }
    }


}
