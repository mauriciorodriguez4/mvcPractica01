﻿using System.ComponentModel.DataAnnotations;
namespace mvcPractica01.Models
{
    public class facultades
    {
        [Key]
        public int facultad_id { get; set; }
        public string nombre_facultad { get; set; }
        public string estado { get; set; }
    }
}
