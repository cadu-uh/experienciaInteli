using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiInteliWeb.Models
{
    public class Cliente
    {     
        [Key] 
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este Campo é obrigatorio")]
        public string FirstName { get; set; }

        public string SurName { get; set; }

        [Required(ErrorMessage = "Este Campo é obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Sua idade tem que ser maior que zero")]
        public int Age { get; set; }

        public DateTime CreationDate { get; set; }

        public Cliente()
        {
            this.Id = Guid.NewGuid();
            this.CreationDate = DateTime.Now;
        }    
    }
}
