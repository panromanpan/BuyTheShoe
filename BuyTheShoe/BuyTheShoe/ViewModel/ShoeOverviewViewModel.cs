using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using BuyTheShoe.Extensions;
using BuyTheShoe.Messeges;
using BuyTheShoe.Services;
using BuyTheShoe.Utility;

namespace BuyTheShoe.ViewModel
{
    public class ShoeOverviewViewModel : IShoeOverviewViewModel
    {
        private Shoe selectedShoe;
        private IDialogService dialogService;
        private IShoesDataService shoesDataService;

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Shoe> shoes;

        public ObservableCollection<Shoe> Shoes
        {
            get
            {
                return shoes;
            }
            set
            {
                shoes = value;
                RaisePropertyChanged("Shoes");
            }
        }

        public ICommand EditCommand { get; set; }

        public Shoe SelectedShoe
        {
            get
            {
                return selectedShoe;
            }
            set
            {
                selectedShoe = value;
                RaisePropertyChanged("SelectedCoffee");
            }
        }
        private void OnUpdateListMessageReceived(UpdateListMessage obj)
        {
            LoadData();
            dialogService.CloseDetailDialog();
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public ShoeOverviewViewModel(IShoesDataService shoesDataService, IDialogService dialogService)
        {
            this.shoesDataService = shoesDataService;
            this.dialogService = dialogService;

            LoadCommands();
            LoadData();

            Messenger.Default.Register<UpdateListMessage>(this, OnUpdateListMessageReceived);
        }

        private void LoadCommands()
        {
            EditCommand = new CustomCommand(EditShoe, CanEditShoe);
        }

        private void EditShoe(object obj)
        {
            Messenger.Default.Send<Shoe>(selectedShoe);
            dialogService.ShowDetailDialog();
        }

        private bool CanEditShoe(object obj)
        {
            if (SelectedShoe != null)
                return true;
            return false;
        }

        private void LoadData()
        {
            Shoes = shoesDataService.GetAllShoes().ToObservableCollection();
        }

    }
}