using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoRandom
{
    public class EditDataClass
    {
        private string strTitle = string.Empty;
        private string strMessage = string.Empty;
        private string strFileName = string.Empty;

        public string Title
        {
            get { return this.strTitle; }
            set { this.strTitle = value; }
        }

        public string Message
        {
            get { return this.strMessage; }
            set { this.strMessage = value; }
        }

        public string FileName
        {
            get { return this.strFileName; }
            set { this.strFileName = value; }
        }
    }
}
