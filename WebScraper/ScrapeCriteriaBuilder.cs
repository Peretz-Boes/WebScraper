using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WebScraper
{
    class ScrapeCriteriaBuilder
    {
        private string Data;
        private string Regex;
        private RegexOptions regexOptions;
        private List<ScrapeCriteriaPart> parts;
        public ScrapeCriteriaBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults() {
            Data = string.Empty;
            Regex = string.Empty;
            regexOptions = RegexOptions.None;
            parts = new List<ScrapeCriteriaPart>();
        }

        public ScrapeCriteriaBuilder WithData(string data) {
            Data = data;
            return this;
        }

        public ScrapeCriteriaBuilder WithRegex(string regex) {
            Regex = regex;
            return this;
        }

        public ScrapeCriteriaBuilder WithRegexOptions(RegexOptions regexOption) {
            regexOptions = regexOption;
            return this;
        }

        public ScrapeCriteriaBuilder WithPart(ScrapeCriteriaPart scrapeCriteriaPart) {
            parts.Add(scrapeCriteriaPart);
            return this;
        }

        public ScrapeCriteria Build() {
            ScrapeCriteria scrapeCriteria = new ScrapeCriteria();
            scrapeCriteria.Data = Data;
            scrapeCriteria.Regex = Regex;
            scrapeCriteria.RegexOption = regexOptions;
            scrapeCriteria.Parts = parts;
            return scrapeCriteria;
        }

    }
}
