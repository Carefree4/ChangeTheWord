using System.Collections.Generic;

namespace ChangeTheWord.Api.Models
{
    public class Suggestions
    {
        public List<ReplacementWord> ReplacementWords { get; set; }
        public List<string> MostUsedWords { get; set; }
    }

    public class ReplacementWord
    {
        public string Original { get; set; }
        public List<string> Replacements { get; set; }
    }
}