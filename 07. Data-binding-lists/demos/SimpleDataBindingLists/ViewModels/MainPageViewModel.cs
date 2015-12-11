namespace SimpleDataBindingLists.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Extensions;

    public class MainPageViewModel
    {
        private ObservableCollection<string> names;

        public IEnumerable<string> Names
        {
            get
            {
                if (this.names == null)
                {
                    this.names = new ObservableCollection<string>();
                }

                return this.names;
            }
            set
            {
                if (this.names == null)
                {
                    this.names = new ObservableCollection<string>();
                }
                this.names.Clear();

                value.ForEach(this.names.Add);
            }
        }

        public void AddName(string name)
        {
            this.names.Add(name);
        }

        public void DeleteName(string name)
        {
            this.names.Remove(name);
        }
    }
}
