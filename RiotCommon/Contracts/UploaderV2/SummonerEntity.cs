using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Contracts.UploaderV2
{
    public class SummonerEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [MaxLength(64)]
        [Required]
        public string Name { get; set; }

        [MaxLength(64)]
        [Required]
        public string Region { get; set; }

        [Required]
        public DateTime LastUpdatedTime { get; set; }

        [ForeignKey("StreamerId")]
        public virtual StreamerEntity Streamer { get; set; }
    }
}
