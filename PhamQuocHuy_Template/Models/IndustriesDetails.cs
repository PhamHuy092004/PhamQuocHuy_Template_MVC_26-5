using System.IO.Pipelines;

namespace PhamQuocHuy_Template.Models
{
    public class IndustriesDetails
    {
        public int IdIndustDetails { get; set; }
        public int IdUser { get; set; }
        public int IdIndustries { get; set; }
         public string Description {  get; set; }
        public Users Users { get; set; }
        public Industries Industries { get; set; }
    }
}
