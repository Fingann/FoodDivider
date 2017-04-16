using System.ComponentModel;
using FoodDivider.Handlers;
using FoodDivider.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace FoodDivider.ViewModel
{
    /// <summary>
    ///     This class contains properties that the main View can data bind to.
    ///     <para>
    ///         See http://www.mvvmlight.net
    ///     </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly DialogHandler _dialogHandler;

        private BindingList<Food> _foodList = new BindingList<Food>();
        private Food _selectedFood;
        private double _total;

        /// <summary>
        ///     Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            _dialogHandler = new DialogHandler(this);

            AddFoodCommand = new RelayCommand<WindowArgument>(_dialogHandler.ExecuteRunDialog);

            AddEntry = new RelayCommand(() =>
            {
                FoodList.Add(new Food());

                //RaisePropertyChanged("FoodList");
            });

            CalculateTotal();

            FoodList.ListChanged += (sender, args) => { CalculateTotal(); };
        }

        public RelayCommand<WindowArgument> AddFoodCommand { get; set; }


        public RelayCommand AddEntry { get; set; }

        public Food SelectedFood
        {
            get { return _selectedFood; }
            set
            {
                _selectedFood = value;
                RaisePropertyChanged();
            }
        }

        public double Total
        {
            get { return _total; }
            set
            {
                _total = value;
                RaisePropertyChanged();
            }
        }


        public BindingList<Food> FoodList
        {
            get { return _foodList; }
            set
            {
                _foodList = value;

                RaisePropertyChanged();
            }
        }

        private void CalculateTotal()
        {
            double sum = 0;
            foreach (var x in FoodList)
                sum += x.ProcentageUsed / 100 * x.Price;

            Total = sum /2;
        }
    }
}