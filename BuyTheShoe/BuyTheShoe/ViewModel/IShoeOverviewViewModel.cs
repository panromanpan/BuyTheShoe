using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace BuyTheShoe.ViewModel
{
    public interface IShoeOverviewViewModel
    {
        ObservableCollection<Shoe> Shoes { get; set; }
        ICommand EditCommand { get; set; }
        event PropertyChangedEventHandler PropertyChanged;
        Shoe SelectedShoe { get; set; }
    }
}