using System;
using FoodDivider.Model;
using FoodDivider.ViewModel;
using MaterialDesignThemes.Wpf;

namespace FoodDivider.Handlers
{
    public class DialogHandler
    {
        private MainViewModel _mainViewModel;

        public DialogHandler(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        internal async void ExecuteRunDialog(WindowArgument argument)
        {
            AddFoodViewModel model;
            switch (argument)
            {
                case WindowArgument.New:
                    model= new AddFoodViewModel();
                    break;
                case WindowArgument.Edit:
                    model= new AddFoodViewModel(_mainViewModel.SelectedFood);
                    break;
                default:
                    model= new AddFoodViewModel();
                    break;

            }
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new AddFoodView()
            {
                DataContext = model

            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog");

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));

            CalculateDialogResult(argument, result);
           
        }

        private void CalculateDialogResult(WindowArgument argument, object result)
        {
            if (!(result is bool))
            {
                if ((argument == WindowArgument.Edit))
                {
                    var index = _mainViewModel.FoodList.IndexOf(_mainViewModel.SelectedFood);
                    _mainViewModel.FoodList[index] = result as Food;
                }
                if (argument == WindowArgument.New)
                {
                    _mainViewModel.FoodList.Add(result as Food);
                }
            }
        }
    }
}