using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    internal class SendMailThread : ISendMailThread
    {
        private static readonly SendMailThread Instance = new SendMailThread();
        private volatile bool _shouldStop = false;
        public static SendMailThread Instace { get { return Instance; } }

        //Here is our Queue
        public ConcurrentQueue<MailMessage> Messages { get; private set; }

        public SendMailThread()
        {
            Messages = new ConcurrentQueue<MailMessage>();
        }

        public void DoWork()
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("ar27111994@gmail.com", "MyIDIs1994");
            smtp.EnableSsl = true;

            while (!_shouldStop)
            {

                if (!Messages.IsEmpty)
                {

                    var failed = new Queue<MailMessage>();

                    MailMessage message;
                    while (Messages.TryDequeue(out message))
                    {
                        try
                        {
                            smtp.Send(message);
                        }
                        catch (SmtpException)
                        {
                            //Enqueue again if failed
                            failed.Enqueue(message);
                        }
                    }

                    foreach (var mailMessage in failed)
                    {
                        Messages.Enqueue(mailMessage);
                    }

                    smtp.Dispose();
                }
            }
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }
    }
}
