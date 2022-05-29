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
        public DbSet<Okei> OkeiList { get; set; }
    }

    [Table("okei")]
    public class Okei
    {
        [Key]
        public int ID_OKEI { get; set; }
        public string Unit { get; set; }

        public override string ToString()
        {
            return Unit;
        }

    }
}
