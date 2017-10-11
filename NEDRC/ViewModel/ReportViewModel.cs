using NEDRC.Models;
using System.Collections.Generic;

namespace NEDRC.ViewModel
{
    public class ReportViewModel
    {
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
        public Reports Reports { get; set; }
    }
}