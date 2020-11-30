using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FrameworkHangman_DL
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [Required, MaxLength(20)]
        public string Name { get; set; }
    }
}
