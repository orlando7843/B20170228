using System.ComponentModel;

namespace DataTemplateDemo
{
    public class ContactDetails : INotifyPropertyChanged
    {
        string _name;
        string _telephone;
        string _email;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnNotifyPropertyChanged("Name");
            }
        }

        public string Telephone
        {
            get { return _telephone; }
            set
            {
                _telephone = value;
                OnNotifyPropertyChanged("Telephone");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnNotifyPropertyChanged("Email");
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
    }
}