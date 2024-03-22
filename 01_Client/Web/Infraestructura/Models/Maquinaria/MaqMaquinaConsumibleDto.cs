﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Models.Maquinaria
{
    public class MaqMaquinaConsumibleDto
    {
        public int IdmaqMaquinaConsumible { get; set; }
        public int IdmaqConsumible { get; set; }
        public int Idmaquinaria { get; set; }
        public MaquinariaDto Maquina { get; set; } 
        public MaqConsumibleDto Consumible { get; set; } 
        public bool VerDetalle {  get; set; }   
    }
}
