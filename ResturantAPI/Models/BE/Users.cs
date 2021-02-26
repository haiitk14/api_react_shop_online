using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantAPI.Models.BE
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Username { get; set; }

        private string _password;
        [JsonIgnore]
        public virtual string Password
        {
            get { return _password; }
            set
            {
                _password = value.Length == 128 ? value : ChangeSha512(value);
            }
        }
        public static String ChangeSha512(String strSoure)
        {
            System.Security.Cryptography.SHA512CryptoServiceProvider x = new System.Security.Cryptography.SHA512CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(strSoure);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();
        }

        public string Image { get; set; }
        public string Token { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
