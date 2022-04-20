using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL.EFCore.Entities
{
    public class EncryptionAlgorithm
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string CodeName { get; set; } = "";

        [Required]
        [MaxLength(128)]
        public string Name { get; set; } = "";

        [MaxLength(1024)]
        public string Description { get; set; } = "";

        public ICollection<PasswordDb> PasswordDbs { get; set; }
    }
}
