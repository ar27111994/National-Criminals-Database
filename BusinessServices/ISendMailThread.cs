using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    internal interface ISendMailThread
    {
        ConcurrentQueue<MailMessage> Messages { get; }
        void DoWork();
        void RequestStop();
    }
}
