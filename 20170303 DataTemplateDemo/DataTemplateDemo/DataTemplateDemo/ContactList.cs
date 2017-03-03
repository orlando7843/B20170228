using DevExpress.Mvvm.Native;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DataTemplateDemo
{
    public class ContactList : INotifyPropertyChanged
    {
        //filed
        private ContactDetails _editableContact;

        //constructor
        public ContactList()
        {
            Contacts = new ObservableCollection<ContactDetails>();
            EditableContact = new ContactDetails();
       }

        //property
        public ObservableCollection<ContactDetails> Contacts { get; set; }

        public ContactDetails EditableContact
        {
            get { return _editableContact; }
            set
            {
                _editableContact = value;
                OnNotifyPropertyChanged("EditableContact");
            }
        }

        public ICommand AddEditableContact
        {
            get
            {
                return new RelayCommand(AddEditableContactExecute, CanAddEditableContactExecute);
            }
        }

        private void OnNotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void AddEditableContactExecute()
        {
            Contacts.Add(EditableContact);
            EditableContact = new ContactDetails();
        }

        bool CanAddEditableContactExecute()
        {
            return true;
        }

        //使用third party 較簡潔
        private ICommand _addCommand;
        public ICommand AddCommand
        {
            //綁方法名稱
            get { return _addCommand ?? (_addCommand = DelegateCommandFactory.Create(AddEditableContactExecute)); }//加入組件DevExpress.Mvvm.Native
        }
    }
}