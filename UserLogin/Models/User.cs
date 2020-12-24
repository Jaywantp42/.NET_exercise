using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserLogin.Models
{
    public class User
    {
        [Key]
        [DataType(DataType.Text)]
        public string LoginName { get; set; }

        [MaxLength(10), MinLength(4)]
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [MaxLength(10), MinLength(4)]
        [Required(ErrorMessage = "Please enter Field")]
        [DataType(DataType.Text)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter Field")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }


        public int CityId { get; set; }


        [Required(ErrorMessage = "Please enter Field")]
        [DataType(DataType.Text)]
        [MaxLength(10), MinLength(10)]
        public string Phone { get; set; }


        public IEnumerable<SelectListItem> Cities { get; set; }
        
        public string CityName { get; set; }
    }
}