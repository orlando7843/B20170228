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
using System.Windows.Shapes;

namespace ListBoxTemplate
{
    /// <summary>
    /// Window1.xaml 的互動邏輯
    /// </summary>
    public partial class Window1 : Window
    {
        //Field
        private MonitorViewModel _viewModel;
        
        public Window1()
        {
            InitializeComponent();

            _viewModel = new MonitorViewModel();
            base.DataContext = _viewModel;// view 參考 viewModel

        }

        private void lbTodoList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var m_listbox = sender as ListBox;
            if (m_listbox.SelectedItem != null)
            { 
                this.Title = (m_listbox.SelectedItem as TodoModel).Title;
            }
            //if (lbTodoList.SelectedItem != null)
            //    this.Title = (lbTodoList.SelectedItem as TodoItem).Title;
        }

        //private void btnShowSelectedItem_Click(object sender, RoutedEventArgs e)
        //{
        //    foreach (object o in lbTodoList.SelectedItems)
        //        MessageBox.Show((o as TodoModel).Title);
        //}

        private void btnSelectLast_Click(object sender, RoutedEventArgs e)
        {
            //lbTodoList.SelectedIndex = lbTodoList.Items.Count - 1;
            lbTodoList.SelectedIndex = _viewModel.MyItems.Count - 1;//對控件名稱操作 <ListBox x:Name="lbTodoList"/>

        }

        private void btnSelectNext_Click(object sender, RoutedEventArgs e)
        {
            int nextIndex = 0;
            if ((lbTodoList.SelectedIndex >= 0) && (lbTodoList.SelectedIndex < (_viewModel.MyItems.Count - 1)))
                nextIndex = lbTodoList.SelectedIndex + 1;
            lbTodoList.SelectedIndex = nextIndex;
        }

        private void btnSelectCSharp_Click(object sender, RoutedEventArgs e)
        {
            foreach (object o in lbTodoList.Items)
            {
                if ((o is TodoModel) && ((o as TodoModel).Title.Contains("C#")))
                {
                    lbTodoList.SelectedItem = o;
                    break;
                }
            }
        }

        private void btnSelectAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (object o in lbTodoList.Items)
                lbTodoList.SelectedItems.Add(o);
        }

    }
}
