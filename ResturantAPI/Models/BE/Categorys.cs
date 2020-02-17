using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantAPI.Models.BE
{
    public class Categorys
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public bool IsPublic { get; set; }
        public string TitleSeo { get; set; }
        public string KeywordsSeo { get; set; }
        public string DescriptionSeo { get; set; }
        public bool IsMenu { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
