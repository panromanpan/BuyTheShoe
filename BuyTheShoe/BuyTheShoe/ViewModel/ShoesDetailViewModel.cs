using System.ComponentModel;
using System.Windows.Input;
using BuyTheShoe.Messeges;
using BuyTheShoe.Services;
using BuyTheShoe.Utility;

namespace BuyTheShoe.ViewModel
{
    public class ShoesDetailViewModel : INotifyPropertyChanged, IShoesDetailViewModel
    {
        private IDialogService dialogService;
        private IShoesDataService shoesDataService;

        private Shoe selectedShoe;

        public Shoe SelectedShoe
        {
            get
            {
                return selectedShoe;
            }
            set
            {
                selectedShoe = value;
                RaisePropertyChanged("SelectedShoe");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ShoesDetailViewModel(IShoesDataService shoesDataService, IDialogService dialogService)
        {
            this.shoesDataService = shoesDataService;
            this.dialogService = dialogService;

            Messenger.Default.Register<Shoe>(this, OnShoeReceived);

            SaveCommand = new CustomCommand(SaveShoe, CanSaveShoe);
            DeleteCommand = new CustomCommand(DeleteShoe, CanDeleteShoe);
        }

        private bool CanDeleteShoe(object obj)
        {
            return true;
        }

        private void DeleteShoe(object shoe)
        {
            shoesDataService.DeleteShoe(selectedShoe);

            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }

        private bool CanSaveShoe(object obj)
        {
            return true;
        }

        private void SaveShoe(object shoe)
        {
            shoesDataService.UpdateShoe(selectedShoe);

            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }
        private void OnShoeReceived(Shoe shoe)
        {
            SelectedShoe = shoe;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}