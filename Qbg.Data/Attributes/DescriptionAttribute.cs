using System;
using System.Collections.Generic;
using System.Text;

namespace Qbg.Data.Attributes
{
    public class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string description)
        {
            this.Description = description;
        }

        public string Description { get; set; }
    }
}
