using System.Collections.Generic;
using BuyTheShoe.DAL;
namespace BuyTheShoe.Services
{
    public class ShoesDataService : IShoesDataService
    {
        private readonly IShoesRepository _repository;

        public ShoesDataService(IShoesRepository repository)
        {
            this._repository = repository;
        }
        public void DeleteShoe(Shoe shoe)
        {
            _repository.DeleteShoe(shoe);
        }

        public List<Shoe> GetAllShoes()
        {
            return _repository.GetShoes();
        }

        public Shoe GetShoeDetail(int shoeId)
        {
            return _repository.GetShoeById(shoeId);
        }

        public void UpdateShoe(Shoe shoe)
        {
            _repository.UpdateShoe(shoe);
        }
    }
}