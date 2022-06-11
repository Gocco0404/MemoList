using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoRandom
{
    class ListDataClass
    {
        private int intFileCount = 0;
        private List<DateTime> lstUpdateTime = new List<DateTime>();
        private List<string> lstTitle = new List<string>();
        private List<int> lstFileNo = new List<int>();
        private List<string> lstMessage = new List<string>();
        private List<string> lstFileName = new List<string>();

        public int FileCount
        {
            get { return this.intFileCount; }
            set { this.intFileCount = value; }
        }

        public List<DateTime> UpdateTime
        {
            get { return this.lstUpdateTime; }
            set { this.lstUpdateTime = value; }
        }

        public List<string> Title
        {
            get { return this.lstTitle; }
            set { this.lstTitle = value; }
        }

        public List<int> FileNo
        {
            get { return this.lstFileNo; }
            set { this.lstFileNo = value; }
        }

        public List<string> Message
        {
            get { return this.lstMessage; }
            set { this.lstMessage = value; }
        }

        public List<string> FileName
        {
            get { return this.lstFileName; }
            set { this.lstFileName = value; }
        }
    }
}
