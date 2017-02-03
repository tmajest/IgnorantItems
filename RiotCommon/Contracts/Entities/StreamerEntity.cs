using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.RiotCommon.Contracts.Entities
{
    [Table("Streamers")]
    public class StreamerEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(64)]
        [Required]
        public string ProName { get; set; }

        [MaxLength(64)]
        [Required]
        public string TwitchName { get; set; }

        public virtual ICollection<SummonerEntity> Summoners { get; set; }

        public virtual ICollection<StreamEntity> Streams { get; set; }
    }
}
