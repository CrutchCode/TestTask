using DatabaseAccounting.Models;
using System.Collections.Generic;

namespace AccountingProgrammers.Models
{
    public class ViewModelUserAndProject
    {
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
