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
    public class ParticipantEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SummonerId { get; set; }

        [Required]
        [MaxLength(64)]
        public string SummonerName { get; set; }

        [Required]
        public int ChampionId { get; set; }

        [Required]
        public string Masteries
        {
            get
            {
                this.MasteryList = this.MasteryList ?? new List<MasteryInstance>();
                return JsonConvert.SerializeObject(this.MasteryList);
            }
            set
            {
                this.MasteryList = value == null
                    ? new List<MasteryInstance>()
                    : JsonConvert.DeserializeObject<List<MasteryInstance>>(value);
            }
        }

        [Required]
        public string Runes
        {
            get
            {
                this.RuneList = this.RuneList ?? new List<RuneInstance>();
                return JsonConvert.SerializeObject(this.RuneList);
            }
            set
            {
                this.RuneList = value == null
                    ? new List<RuneInstance>()
                    : JsonConvert.DeserializeObject<List<RuneInstance>>(value);
            }
        }

        [Required]
        public string Items
        {
            get
            {
                this.ItemsBought = this.ItemsBought ?? new List<int>();
                return JsonConvert.SerializeObject(this.ItemsBought);
            }
            set
            {
                this.ItemsBought = value == null
                    ? new List<int>()
                    : JsonConvert.DeserializeObject<List<int>>(value);
            }
        }

        [Required]
        public bool Won { get; set; }

        [Required]
        public int Kills { get; set; }

        [Required]
        public int Deaths { get; set; }

        [Required]
        public int Assists { get; set; }

        [Required]
        [MaxLength(8)]
        public string Team { get; set; }

        public virtual ICollection<MatchEntity> Matches { get; set; }

        [NotMapped]
        public List<MasteryInstance> MasteryList { get; set; }

        [NotMapped]
        public List<RuneInstance> RuneList { get; set; }

        [NotMapped]
        public List<int> ItemsBought { get; set; }
    }
}
