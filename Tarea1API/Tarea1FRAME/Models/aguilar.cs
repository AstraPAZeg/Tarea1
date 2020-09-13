using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tarea1FRAME.Models
{
    public class aguilar
    {
        [Key]
        public int aguilar_ID { get; set; }

        [Required]
        [DisplayName("Nombre completo")]
        [StringLength(24, ErrorMessage = "This field must contain between {2} and {1} characters", MinimumLength = 2)]
        public string FriendofAguilar { get; set; }

        [Required]
        public Place Place_lista { get; set; }

        [EmailAddress]
        public string email { get; set; }

        [DisplayName("Cumpleaños")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public enum Place
        {
            plaza, cine, teatro, colegio, universidad
        }
    }
}