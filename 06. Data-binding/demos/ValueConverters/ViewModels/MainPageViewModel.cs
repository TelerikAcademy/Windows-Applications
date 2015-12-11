namespace ValueConverters.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;


    public class MainPageViewModel : INotifyPropertyChanged
    {
        public bool IsImageVisible
        {
            get
            {
                return this.isImageVisible;
            }
            set
            {
                if (this.isImageVisible == value)
                {
                    return;
                }
                this.isImageVisible = value;
                this.RaisePropertyChanged("IsImageVisible");
            }
        }

        public string Title { get; set; }
        public string ImgSrc { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private bool isImageVisible;

        protected void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged == null)
            {
                return;
            }
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
