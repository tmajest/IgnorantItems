﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Contracts.Entities
{
    [Table("Streams")]
    public class StreamEntity
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string StreamId { get; set; }

        [Required]
        [MaxLength(128)]
        public string Url { get; set; }

        [Required]
        public int Offset { get; set; }

        public virtual StreamerEntity Streamer { get; set; }

        public virtual MatchEntity Match { get; set; }
    }
}
