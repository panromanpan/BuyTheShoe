using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheShoe.DAL
{
    class ShoesRepository : IShoesRepository
    {

        private readonly ShoesContext _context;

        public ShoesRepository(ShoesContext context)
        {
            _context = context;
        }
        public void DeleteShoe(Shoe shoe)
        {
            if (_context.Entry(shoe).State == EntityState.Detached)
            {
                _context.Shoes.Attach(shoe);
            }
            _context.Shoes.Remove(shoe);
            _context.SaveChanges();
        }

        public Shoe GetAShoe()
        {
            return _context.Shoes.FirstOrDefault();
        }

        public Shoe GetShoeById(int id)
        {
            return _context.Shoes.FirstOrDefault(c => c.ShoeId == id);
        }

        public List<Shoe> GetShoes()
        {
            List<Shoe> shoes = _context.Shoes.ToList();

            return shoes;
        }

        public void UpdateShoe(Shoe shoe)
        {
                if (shoe == null)
                {
                    throw new ArgumentException("Trying to update null ");
                }

            _context.Shoes.AddOrUpdate(shoe);
            _context.SaveChanges();
        }
    }
}
