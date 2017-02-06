using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.Entities;

namespace CoffeeCat.RiotDatabase
{
    public class RiotContext : DbContext
    {
        public DbSet<StreamerEntity> Streamers { get; set; }
        public DbSet<StreamEntity> Streams { get; set; }
        public DbSet<SummonerEntity> Summoners { get; set; }
        public DbSet<MatchEntity> Matches { get; set; }
        public DbSet<ParticipantEntity> Participants { get; set; }
        public DbSet<ApiVersionEntity> ApiVersions { get; set; }

        public RiotContext(string connectionString) : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<StreamEntity>()
                .HasRequired(s => s.Streamer)
                .WithMany(s => s.Streams)
                .Map(m => m.MapKey("StreamerId"));

            modelBuilder.Entity<StreamEntity>()
                .HasRequired(s => s.Match)
                .WithMany(m => m.Streams)
                .Map(m => m.MapKey("MatchId"));

            modelBuilder.Entity<SummonerEntity>()
                .HasRequired(s => s.Streamer)
                .WithMany(s => s.Summoners)
                .Map(m => m.MapKey("StreamerId"));

            modelBuilder.Entity<ParticipantEntity>()
                .HasRequired(p => p.Match)
                .WithMany(m => m.Participants)
                .Map(m => m.MapKey("MatchId"));

            modelBuilder.Entity<ParticipantEntity>()
                .HasOptional(p => p.Summoner)
                .WithMany(m => m.Participants)
                .Map(m => m.MapKey("SummonerId"));
        }
    }
}