using System;

namespace Deep.Memory.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    internal class OffsetValueNA : Attribute
    {
        public int Value;

        public OffsetValueNA(int val)
        {
            Value = val;
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    internal class OffsetValueCN : Attribute
    {
        public int Value;

        public OffsetValueCN(int val)
        {
            Value = val;
        }
    }
}