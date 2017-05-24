using System.Collections.Generic;

namespace BuyTheShoe.DAL
{
    public interface IShoesRepository
    {
        void DeleteShoe(Shoe shoe);
        Shoe GetAShoe();
        Shoe GetShoeById(int id);
        List<Shoe> GetShoes();
        void UpdateShoe(Shoe shoe);
    }
}