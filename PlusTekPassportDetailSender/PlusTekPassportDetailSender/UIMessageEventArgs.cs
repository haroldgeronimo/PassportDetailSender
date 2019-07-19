using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusTekPassportDetailSender
{
    class UIMessageEventArgs : EventArgs
    {
        readonly string message;
        public UIMessageEventArgs(string message)
        {
            this.message = message;
        }

       

        public string Message
        {
            get { return this.message; }
        }
    }

    class UIStatusEventArgs : EventArgs
    {
        readonly string status;
        public UIStatusEventArgs(string status)
        {
            this.status = status;
        }



        public string Status
        {
            get { return this.status; }
        }
    }
}
