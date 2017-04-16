using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace FoodDivider.Model
{
    public class Food: ViewModelBase, IDataErrorInfo
    {
        private string _name;
        private double _price;
        private double _procentageUsed = 100;

        public Food()
        {
            
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged();
            }
        }

        //For calculating what procentage of the food is used. 
        public double ProcentageUsed
        {
            get { return _procentageUsed; }
            set
            {
                _procentageUsed = value;
                RaisePropertyChanged();
            }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;



                if (string.IsNullOrWhiteSpace(Name))

                {

                    result = "You must have a name. ";

                }

                return result;

            }
        }
        

        public string Error { get; }
    }
}
