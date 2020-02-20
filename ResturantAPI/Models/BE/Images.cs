using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantAPI.Models.BE
{
    public class Images
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public byte[] Data { get; set; }
        public bool IsArticle { get; set; }
        public bool IsLogo { get; set; }
        public bool IsOther { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
