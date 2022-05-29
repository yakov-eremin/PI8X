using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


using System.Windows.Forms;

namespace Logistic.Models
{
    public partial class LogisticContext : DbContext
    {
        public LogisticContext()
        {

            try
            {
                Database.EnsureCreated();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseMySQL(
                "server=localhost;user=root;password=12345;database=testdb;"
            );
        }
    }
}
