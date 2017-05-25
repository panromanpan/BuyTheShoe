using BuyTheShoe.DAL;
using BuyTheShoe.Services;
using BuyTheShoe.ViewModel;

namespace BuyTheShoe
{
    public class ViewModelLocator
    {
        private static IDialogService dialogService = new DialogService();
        private static IShoesDataService shoesDataService = new ShoesDataService(new ShoesRepository(new ShoesContext()));

        private static ShoesOverviewViewModel shoesOverviewViewModel = new ShoesOverviewViewModel(shoesDataService, dialogService);
        private static ShoesDetailViewModel shoesDetailViewModel = new ShoesDetailViewModel(shoesDataService, dialogService);

        public static ShoesDetailViewModel ShoesDetailViewModel
        {
            get
            {
                return shoesDetailViewModel;
            }
        }

        public static ShoesOverviewViewModel ShoeseOverviewViewModel
        {
            get
            {
                return shoesOverviewViewModel;
            }
        }
    }
}