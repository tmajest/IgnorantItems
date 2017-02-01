using CoffeeCat.RiotCommon.Contracts.Frontend;
using CoffeeCat.RiotCommon.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.RiotApi.Match;

namespace CoffeeCat.RiotCommon.Utils
{
    [InheritedExport(typeof(IDtoConverter))]
    public interface IDtoConverter
    {
        Match GetMatchContract(MatchEntity matchInfo, FormatType type);

        Rune GetRuneContract(RuneDto runeDto);

        Mastery GetMasteryContract(MasteryDto masteryDto);
    }
}
