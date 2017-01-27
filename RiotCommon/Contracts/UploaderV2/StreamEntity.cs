using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Contracts.UploaderV2
{
    public class StreamEntity
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Url { get; set; }

        [Required]
        public int Offset { get; set; }

        [ForeignKey("StreamerId")]
        public virtual StreamerEntity Streamer { get; set; }
    }
}
