using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAccounting.Models
{
    public class Company
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }

        public ICollection<Project> Projects { get; set; }
        public ICollection<User> Users { get; set; }

        public Company()
        {
            Projects = new List<Project>();
            Users = new List<User>();
        }
    }
}
