namespace PopupMenu.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using PopupMenu.Models;

    public class PhonesViewModel
    {
        private ObservableCollection<Phone> phones;

        public IEnumerable<Phone> Phones
        {
            get
            {
                if (this.phones == null)
                {
                    this.Phones = this.GetGeneratedPhones();
                }

                return this.phones;
            }

            set
            {
                if (this.phones != value)
                {
                    if (this.phones == null)
                    {
                        this.phones = new ObservableCollection<Phone>();
                    }

                    this.phones.Clear();
                    foreach (var item in value)
                    {
                        this.phones.Add(item);
                    }
                }
            }
        }

        private IEnumerable<Phone> GetGeneratedPhones()
        {
            Phone[] phonesList =
                {
                    new Phone { Vendor = "Samsung", Model = "Galaxy S4", },
                    new Phone { Vendor = "Apple", Model = "iPhone 4", },
                    new Phone { Vendor = "HTC", Model = "One", },
                    new Phone { Vendor = "Nokia", Model = "Lumia 920", },
                };

            return phonesList;
        }
    }
}
