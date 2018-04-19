using System;

namespace Deep.Logging
{
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class LoggerNameAttribute : Attribute
    {
        public LoggerNameAttribute(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Cannot be null or whitespace.", nameof(name));
            }

            Name = name;
        }

        public string Name { get; private set; }
    }
}