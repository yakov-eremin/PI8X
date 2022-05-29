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
        public DbSet<Treatie> TreatiesList { get; set; }
    }

    [Table("treaties")]
    public class Treatie
    {
        [Key]
        public int ID_Treatie { get; set; }
        public string Number_Of_Treatie { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public decimal Summary { get; set; }
        public string Status { get; set; }
        public int Claims_Days { get; set; }
        public int Swap_Days { get; set; }
        public int Supply_Delay { get; set; }
        public decimal Fine { get; set; }


        [ForeignKey("ID_Customer")]
        public int ID_Customer { get; set; }

        public Customer customer { get { return Program.db.CustomersList.Find( ID_Customer ); } }

        public override string ToString()
        {
            return Number_Of_Treatie;
        }

    }
}
