using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WebScraper
{
    class ScrapeCriteriaPartBuilder
    {
        private string Regex;
        private RegexOptions RegexOption;

        public ScrapeCriteriaPartBuilder()
        {
            Regex = string.Empty;
            RegexOption = RegexOptions.None;
        }

        public ScrapeCriteriaPartBuilder WithRegex(string regex) {
            Regex = regex;
            return this;
        }

        public ScrapeCriteriaPartBuilder WithRegexOptions(RegexOptions regexOption) {
            RegexOption = regexOption;
            return this;
        }

        public ScrapeCriteriaPart Build() {
            ScrapeCriteriaPart scrapeCriteriaPart = new ScrapeCriteriaPart();
            scrapeCriteriaPart.Regex = Regex;
            scrapeCriteriaPart.RegexOption = RegexOption;
            return scrapeCriteriaPart;
        }

    }
}
