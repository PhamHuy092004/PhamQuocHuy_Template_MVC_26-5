using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhamQuocHuy_Template.Models
{
    public class Users
    {
        public int IdUser { get;set; }
       
  
        [Required(ErrorMessage = "Họ và tên là bắt buộc")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Ngày sinh là bắt buộc")]
        [DataType(DataType.Date)]
        public DateTime Birth { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Giới tính là bắt buộc")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [RegularExpression(@"^(0\d{9,10})$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get; set; }
        public int Status { get; set; }
        public ICollection<IndustriesDetails> IndustriesDetails { get;set; }
     
    }
}
