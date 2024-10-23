﻿using System.ComponentModel.DataAnnotations;

namespace BackEnd.Model
{
    public class IdentificationType
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }

        public bool IsDelete { get; set; } = false;  // Valor por defecto en falso

    }
}
