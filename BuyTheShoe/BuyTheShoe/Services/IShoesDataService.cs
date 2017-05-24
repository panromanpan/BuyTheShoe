using System.Collections.Generic;
using BuyTheShoe.Model;
namespace BuyTheShoe.Services
{
    public interface IShoesDataService
    {
        void DeleteShoe(Shoe shoe);
        List<Shoe> GetAllShoes();
        Shoe GetShoeDetail(int shoeId);
        void UpdateShoe(Shoe shoe);
    }
}