using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantAPI.Models.BE
{
    public class Setting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string CommanyName { get; set; }
        public string Website { get; set; }
        public string Slogan { get; set; }
        public string CopyRight { get; set; }
        public string Email { get; set; }
        public string HotLine { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Google { get; set; }
        public string Youtube { get; set; }
        public string TitleSeo { get; set; }
        public string KeywordsSeo { get; set; }
        public string DescriptionSeo { get; set; }
        public string GoogleAnalytic { get; set; }
        public string HeadTab { get; set; }
        public string BodyTab { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
