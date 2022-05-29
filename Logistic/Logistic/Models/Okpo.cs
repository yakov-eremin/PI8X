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
        public DbSet<Okpo> OkpoList { get; set; }
    }

    [Table("okpo")]
    public class Okpo
    {
        [Key]
        public int ID_OKPO { get; set; }

        public string OKPO { get; set; }

        public override string ToString()
        {
            return OKPO;
        }

    }
}