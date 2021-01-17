using System;

namespace Cooking
{
    [AttributeUsage(AttributeTargets.Property)]
    internal sealed class ImportantPropertyAttribute : Attribute
    {
        public ImportantPropertyAttribute(string reason)
        {
            this.Reason = reason;
        }

        public string Reason { get; }
    }
}