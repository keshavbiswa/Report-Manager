using NEDRC.Models;
using System.Collections.Generic;

namespace NEDRC.ViewModel
{
    public class ReportViewModel
    {
        public Reports Reports { get; set; }
        public int ApplicationUser { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
    }
}