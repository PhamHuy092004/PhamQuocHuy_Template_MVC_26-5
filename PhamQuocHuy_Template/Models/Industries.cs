using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhamQuocHuy_Template.Models
{
    public class Industries
    {
        public int IdIndustries { get; set; }
        public string NameIndust { get;set; }
        public ICollection<IndustriesDetails> IndustriesDetails {  get; set; }
    }
}
