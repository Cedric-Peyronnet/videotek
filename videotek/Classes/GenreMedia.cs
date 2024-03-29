﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videotek.Classes
{
    public class GenreMedia
    {
        public int IdGenre { get; set; }
        [ForeignKey(nameof(IdGenre))]
        public Genre Genre { get; set; }

        public int IdMedia { get; set; }
        [ForeignKey(nameof(IdMedia))]
        public Media Media { get; set; }


    }
}
