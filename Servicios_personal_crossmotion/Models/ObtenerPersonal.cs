﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Servicios_personal_crossmotion.Models
{
    public partial class ObtenerPersonal
    {
        public int IdPersonal { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Edad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Departamento { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}