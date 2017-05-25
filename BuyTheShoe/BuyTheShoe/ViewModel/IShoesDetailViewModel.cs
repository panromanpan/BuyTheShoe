using System.ComponentModel;
using System.Windows.Input;

namespace BuyTheShoe.ViewModel
{
    public interface IShoesDetailViewModel
    {
        ICommand DeleteCommand { get; set; }
        event PropertyChangedEventHandler PropertyChanged;
        ICommand SaveCommand { get; set; }
        Shoe SelectedShoe { get; set; }
    }
}