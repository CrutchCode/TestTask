using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAccounting.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserLastName { get; set; }
        public string UserPosition { get; set; }
        public int? CompanyUserId { get; set; }
        public Company CompanyUser { get; set; }

        public ICollection<Project> Projects { get; set; }
        public User()
        {
            Projects = new List<Project>();
        }
    }
}
