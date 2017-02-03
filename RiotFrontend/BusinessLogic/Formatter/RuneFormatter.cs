using System;
using System.Linq;
using CoffeeCat.RiotCommon.Utils;
using CoffeeCat.RiotFrontend.Models;
using CoffeeCat.RiotCommon.Contracts.RiotApi.Match;

namespace CoffeeCat.RiotFrontend.BusinessLogic.Formatter
{
    internal class RuneFormatter : BaseFormatter
    {
        public RuneFormatter(IStaticData staticData) : base(staticData)
        {
        }

        public Rune FormatRune(RuneDto runeDto)
        {
            Validation.ValidateNotNull(runeDto, nameof(runeDto));

            var staticRune = this.staticData.RuneList.Data[runeDto.RuneId.ToString()];
            var clonedRune = CloneDto(staticRune);
            clonedRune.SanitizedDescription = GetModifiedRuneDescription(clonedRune.SanitizedDescription, runeDto.Rank);

            return new Rune
            {
                Data = clonedRune,
                Rank = runeDto.Rank
            };
        }

        private string GetModifiedRuneDescription(string description, long rank)
        {
            var modified = description
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s =>
                {
                    var start = "";
                    var end = "";
                    if (s.StartsWith("("))
                    {
                        start += "(";
                        s = s.Substring(1);
                    }
                    if (s.StartsWith("+") || s.StartsWith("-"))
                    {
                        start += s[0];
                        s = s.Substring(1);
                    }
                    if (s.EndsWith("%"))
                    {
                        end += "%";
                        s = s.Substring(0, s.Length - 1);
                    }

                    double value;
                    if (double.TryParse(s, out value))
                    {
                        var newValue = value * rank;
                        return string.Concat(start, newValue, end);
                    }

                    return s;
                });

            return string.Join(" ", modified);
        }
    }
}
