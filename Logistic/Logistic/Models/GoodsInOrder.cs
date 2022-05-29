using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic.Models
{
    public partial class LogisticContext : DbContext
    {
        public DbSet<GoodsInOrder> GoodsInOrderList { get; set; }
    }

    [Table("goods_in_order")]
    public class GoodsInOrder
    {
        [Key]
        public int ID_Goods_In_Order { get; set; }

        public string Name { get; set; }
        public string Usability { get; set; }
        public string Requierements { get; set; }
        public string Vendor_Code { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }

        [ForeignKey("ID_OKEI")]
        public int ID_OKEI { get; set; }


        [ForeignKey("ID_Order")]
        public int ID_Order { get; set; }


        public Okei okei { get { return Program.db.OkeiList.Find( ID_OKEI ); } }
        public Order order { get { return Program.db.OrdersList.Find( ID_Order ); } }

        public override string ToString()
        {
            return Name;
        }

    }
}
