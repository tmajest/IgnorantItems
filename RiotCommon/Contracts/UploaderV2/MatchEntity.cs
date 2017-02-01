using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.UploaderV2
{
    [Table("Matches")]
    public class MatchEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Region { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        [MaxLength(8)]
        public string Winner { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        [Required]
        public string BlueBans
        {
            get
            {
                this.BlueSideBans = this.BlueSideBans ?? new List<int>();
                return JsonConvert.SerializeObject(this.BlueSideBans);
            }
            set
            {
                this.BlueSideBans = value == null
                    ? new List<int>()
                    : JsonConvert.DeserializeObject<List<int>>(value);
            }
        }

        [Required]
        public string RedBans
        {
            get
            {
                this.RedSideBans = this.RedSideBans ?? new List<int>();
                return JsonConvert.SerializeObject(this.RedSideBans);
            }
            set
            {
                this.RedSideBans = value == null
                    ? new List<int>()
                    : JsonConvert.DeserializeObject<List<int>>(value);
            }
        }

        public virtual ICollection<ParticipantEntity> Participants { get; set; }

        [NotMapped]
        public List<int> RedSideBans { get; set; }

        [NotMapped]
        public List<int> BlueSideBans { get; set; }

    }
}
