﻿using BILTIFUL.Core.Entidades.Base;
using System;

namespace BILTIFUL.Core.Entidades
{
    public class Venda : EntidadeBase
    {
        public DateTime dvenda { get; set; }
        //CPF
        public long cliente { get; set; }
        public int vtotal { get; set; }
        public Venda()
        {

        }
    }
}