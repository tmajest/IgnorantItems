using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Dto.Match;
using Newtonsoft.Json;

namespace CoffeeCat.RiotCommon.Contracts.UploaderV2
{
    [Table("Participants")]
    public class ParticipantEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

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
                this.MasteryList = this.MasteryList ?? new List<MasteryDto>();
                return JsonConvert.SerializeObject(this.MasteryList);
            }
            set
            {
                this.MasteryList = value == null
                    ? new List<MasteryDto>()
                    : JsonConvert.DeserializeObject<List<MasteryDto>>(value);
            }
        }

        [Required]
        public string Runes
        {
            get
            {
                this.RuneList = this.RuneList ?? new List<RuneDto>();
                return JsonConvert.SerializeObject(this.RuneList);
            }
            set
            {
                this.RuneList = value == null
                    ? new List<RuneDto>()
                    : JsonConvert.DeserializeObject<List<RuneDto>>(value);
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
        public int SummonerSpell1 { get; set; }

        [Required]
        public int SummonerSpell2 { get; set; }

        [Required]
        [MaxLength(8)]
        public string Team { get; set; }

        public virtual MatchEntity Match { get; set; }

        public virtual SummonerEntity Summoner { get; set; }

        [NotMapped]
        public List<MasteryDto> MasteryList { get; set; }

        [NotMapped]
        public List<RuneDto> RuneList { get; set; }

        [NotMapped]
        public List<int> ItemsBought { get; set; }
    }
}