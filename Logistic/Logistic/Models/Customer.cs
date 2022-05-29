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
        public DbSet<Customer> CustomersList { get; set; }
    }

    [Table("customer")]
    public class Customer
    {
        [Key]
        public int ID_Customer { get; set; }
        public string Organization_Name { get; set; }
        public string Organization_Form { get; set; }
        public string Director_FIO { get; set; }
        public string Law_Address { get; set; }
        public string Mail_Address { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string Checking_Account { get; set; }
        public string Korr_Account { get; set; }
        public string BIK { get; set; }

        [ForeignKey("ID_OKPO")]
        public int ID_OKPO { get; set; }

        [ForeignKey("ID_FIAS")]
        public int ID_FIAS { get; set; }

        public Okpo okpo { get { return Program.db.OkpoList.Find( ID_OKPO ); } }
        public Fias fias { get { return Program.db.FiasList.Find( ID_FIAS ); } }

        public override string ToString()
        {
            return Organization_Name;
        }

    }
}
