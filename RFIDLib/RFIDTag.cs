using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RFIDLib
{
    public class RFIDDic : Dictionary<string, RFIDTag>
    {
        public void ClearOld(long mill)
        {
            var values =this.Where(a => a.Value.ReadTime >= DateTime.Now.AddMilliseconds(mill)).Select(a=>a.Key);
            foreach (var key in values)
            {
                this.Remove(key);
            }
        }
    }

    public class RFIDTag
    {
        public DateTime ReadTime { get; set; }

        private string _tag;

        public RFIDTag(string tag)
        {
            Tag = tag;
        }

        public RFIDTag()
        {

        }

        public string Tag
        {
            get => _tag;
            set => _tag = value;
        }
    }
}
