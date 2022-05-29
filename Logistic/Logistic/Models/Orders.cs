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
        public DbSet<Order> OrdersList { get; set; }
    }

    [Table("orders")]
    public class Order
    {
        [Key]
        public int ID_Order { get; set; }
        public string Nubmer_Of_Order { get; set; }
        public DateTime Start_Date { get; set; }
        public decimal Summary { get; set; }
        public string Address { get; set; }

        [ForeignKey("ID_Treatie")]
        public int ID_Treatie { get; set; }

        public Treatie treatie { get { return Program.db.TreatiesList.Find( ID_Treatie ); } }

        public override string ToString()
        {
            return Nubmer_Of_Order;
        }

    }
}
