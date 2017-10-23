using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NEDRC.Models
{
    public class Reports
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ReportId { get; set; }
        [Required(ErrorMessage = "Please enter the reports name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter the description of the report.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]

        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter the Date ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }
        [Display(Name = "Is Approved?")]
        public bool IsApproved { get; set; }
        public Reports()
        {
            IsApproved = false;
        }
        [Required(ErrorMessage = "Please upload the report file.")]
        public byte[] Content { get; set; }
        [Display(Name = "Assigned To")]
        public ApplicationUser User { get; set; }
        
    }
}