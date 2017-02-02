using System.ComponentModel.Composition;
using CoffeeCat.RiotCommon.Contracts.Entities;
using CoffeeCat.RiotCommon.Contracts.RiotApi.Match;
using CoffeeCat.RiotFrontend.BusinessLogic.Formatter;
using CoffeeCat.RiotFrontend.Models;

namespace CoffeeCat.RiotFrontend.BusinessLogic.Converters
{
    [InheritedExport(typeof(IDtoConverter))]
    public interface IDtoConverter
    {
        Match GetMatchContract(MatchEntity matchInfo, FormatType type);

        Rune GetRuneContract(RuneDto runeDto);

        Mastery GetMasteryContract(MasteryDto masteryDto);
    }
}
