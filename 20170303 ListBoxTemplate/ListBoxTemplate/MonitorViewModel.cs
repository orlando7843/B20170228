using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DevExpress.Mvvm.Native;
using Microsoft.Win32;
using System.Windows.Controls;

namespace ListBoxTemplate
{
    public class MonitorViewModel : INotifyPropertyChanged
    {
        //Field
        private ObservableCollection<TodoModel> _myItems;//Collection
        private string _title;//視窗Title

        //Constructor
        public MonitorViewModel()
        {
            _myItems = new ObservableCollection<TodoModel>();//實體化 field
            _myItems.Add(new TodoModel() { Title = "Complete this WPF tutorial", Completion = 45 });
            _myItems.Add(new TodoModel() { Title = "Learn C#", Completion = 80 });
            _myItems.Add(new TodoModel() { Title = "Wash the car", Completion = 0 });
            //field 指派 給Property
            //MyItems = _myItems;

        }

        //Property              
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public ObservableCollection<TodoModel> MyItems
        {
            get { return _myItems; }
            set { _myItems = value; OnNotifyPropertyChanged("MyItems"); }
        }

        private void OnNotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private ICommand _showSelectedCommand;
        public ICommand ShowSelectedCommand
        {
            //綁方法名稱
            get { return _showSelectedCommand ?? (_showSelectedCommand = DelegateCommandFactory.Create<ListBox>(OnBrowse)); }//加入組件DevExpress.Mvvm.Native
        }

        private void OnBrowse(ListBox m_listbox)
        {
            // CommandParameter 為 ElementName 由 m_listbox 接收            
            if (m_listbox.SelectedItem != null)
            {
                _title = (m_listbox.SelectedItem as TodoModel).Title;
                System.Windows.MessageBox.Show(_title);
            }
            //if (lbTodoList.SelectedItem != null)
            //    this.Title = (lbTodoList.SelectedItem as TodoItem).Title;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
