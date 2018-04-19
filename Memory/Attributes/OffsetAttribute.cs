using System;

namespace Deep.Memory.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    internal class OffsetAttribute : Attribute
    {
        public string Pattern;
        public string PatternCN;
        public bool Numeric;

        public OffsetAttribute(string pattern, bool numeric = false, int expectedValue = 0)
        {
            Pattern = pattern;
            PatternCN = pattern;
            Numeric = numeric;
        }
        public OffsetAttribute(string pattern, string cnpattern, bool numeric = false, int expectedValue = 0)
        {
            Pattern = pattern;
            PatternCN = cnpattern;
            Numeric = numeric;
        }
    }

    internal class OffsetCNAttribute : OffsetAttribute
    {
        public OffsetCNAttribute(string pattern, bool numeric = false, int expectedValue = 0) : base("", pattern, numeric, expectedValue)
        {
        }
    }
}