using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.Frontend;
using CoffeeCat.RiotCommon.Contracts.Uploader;
using MatchContracts = CoffeeCat.RiotCommon.Dto.Match;

namespace CoffeeCat.RiotCommon.Utils
{
    [InheritedExport(typeof(IDtoConverter))]
    public interface IDtoConverter
    {
        Match GetMatchContract(MatchInfo matchInfo, FormatType type);

        Rune GetRuneContract(MatchContracts.RuneDto runeDto);

        Mastery GetMasteryContract(MatchContracts.MasteryDto masteryDto);
    }
}
