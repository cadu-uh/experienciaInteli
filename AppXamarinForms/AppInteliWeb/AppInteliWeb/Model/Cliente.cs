using System;
using System.Collections.Generic;
using System.Text;

namespace AppInteliWeb.Model
{
    class Cliente
    {
        public Guid Id { get; set; }  
        public string FirstName { get; set; }
        public string SurName { get; set; }   
        public int Age { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
