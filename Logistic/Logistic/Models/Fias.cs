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
        public DbSet<Fias> FiasList { get; set; }
    }

    [Table("fias")]
    public class Fias
    {
        [Key]
        public int ID_FIAS { get; set; }

        public string Address_Of_Reciever { get; set; }

        public override string ToString()
        {
            return Address_Of_Reciever;
        }

    }
}
