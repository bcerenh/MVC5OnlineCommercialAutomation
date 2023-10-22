﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWebTicariOtomasyon.Models.Siniflar
{
    public class mesaj
    {
        [Key]
        public int MesajID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Gonderici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Alici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Konu { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string icerik { get; set; }


        [Column(TypeName = "Smalldatetime")]
        public DateTime Tarih { get; set; }
    }
}