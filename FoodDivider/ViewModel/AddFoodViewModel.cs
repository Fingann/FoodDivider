using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodDivider.Model;
using GalaSoft.MvvmLight;

namespace FoodDivider.ViewModel
{
    class AddFoodViewModel: ViewModelBase   
    {
        public AddFoodViewModel()
        {
              Food = new Food();  
        }

        public AddFoodViewModel(Food FoodToEdit)
        {
            Food = FoodToEdit;
        }

        private Food _food;

        public Food Food
        {
            get { return _food; }
            set
            {
                _food = value;
                RaisePropertyChanged();
            }
        }
    }
}
