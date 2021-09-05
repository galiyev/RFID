using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RFIDLib
{
    public class RFIDTag
    {
        public DateTime ReadTime { get; set; }

        private string _tag;

        public RFIDTag(string tag)
        {
            Tag = tag;
        }

        public string Tag
        {
            get => _tag;
            set => _tag = value;
        }
    }
}
