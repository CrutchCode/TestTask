using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAccounting.Models
{
    public class Project
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime DateOfCreation { get; set; }

        public int? CompanyProjectId { get; set; }
        public Company CompanyProject { get; set; }
        public ICollection<User> Users { get; set; }
        public Project()
        {
            Users = new List<User>();
        }
    }
}
