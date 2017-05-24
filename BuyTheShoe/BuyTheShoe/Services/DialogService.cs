using System.Windows;
using BuyTheShoe.Views;

namespace BuyTheShoe.Services
{
    public class DialogService : IDialogService
    {

        Window shoesDetailView = null;

        public void ShowDetailDialog()
        {
            shoesDetailView = new ShoesDetailView();
            shoesDetailView.ShowDialog();
        }

        public void CloseDetailDialog()
        {
            shoesDetailView?.Close();
        }
    }
}