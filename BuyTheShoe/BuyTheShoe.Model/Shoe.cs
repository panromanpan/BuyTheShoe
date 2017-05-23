using System.Data.SqlTypes;

namespace BuyTheShoe.Model
{
    public class Shoe
    {
        public int ShoeId { get; set; }

        public string ShoeBrand { get; set; }

        public string ShoeTitle { get; set; }

        public float Size { get; set; }

        public string Category { get; set; }

        public SqlMoney Price { get; set; }

        public bool InStock { get; set; }

    }
}