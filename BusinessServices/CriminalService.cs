using AutoMapper;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebClientContracts;

namespace BusinessServices
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
    public class CriminalService : ICriminalService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public CriminalService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Create(CriminalDTO criminal)
        {
            Criminal addCriminal = _mapper.Map<Criminal>(criminal);
            unitOfWork.CriminalRepository.InsertOnSubmit(addCriminal);
            unitOfWork.Commit();
        }

        public IEnumerable<CriminalDTO> GetCriminals()
        {
           return unitOfWork.CriminalRepository.GetAll().Project<Criminal>().To<CriminalDTO>() as IEnumerable<CriminalDTO>;
        }

        public bool SearchCriminals(CriminalDTO criminal, string[] emails)
        {
            Criminal criteria = Mapper.Map<Criminal>(criminal);
            IEnumerable<Criminal> criminals = unitOfWork.CriminalRepository.GetAll().Where(x => x.Id == criminal.Id ||
            x.Name.Equals(criminal.Name, StringComparison.InvariantCultureIgnoreCase) || x.NationalityID == x.NationalityID
            || x.Sex.Equals((string)criminal.Sex) || x.HieghtMax > criminal.HieghtMax
            || x.HieghtMin > x.HieghtMin || x.WeightMax > criminal.WeightMax
            || x.WeightMin < x.WeightMin).ToList();
            if (criminals!=null)
            {
                var thread = new Thread(SendMailThread.Instace.DoWork);
                thread.Start();
                SendCriminalRecords(criminals, emails);
                return true;
            }
            return false;
        }

        public void SendCriminalRecords(IEnumerable<Criminal> criminals, string[] emails)
        {
            foreach (string email in emails)
            {
                int i = 0;
                foreach (var criminal in criminals)
                {
                    if (i <= 10)
                    {
                        Document doc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
                            doc.Open();

                            string nationality = unitOfWork.NationalityRepository.GetAll().Where(x => x.Id == criminal.NationalityID).FirstOrDefault().NationalityName;
                            Phrase line1 = new Phrase("Criminal Record: ", FontFactory.GetFont("dax-black"));
                            //line1.Chunks.First().SetUnderline(0.5f, -1.5f);
                            doc.Add(line1);
                            string details = "Name: " + criminal.Name + " Age: " + criminal.AgeMin +
                                "-" + criminal.AgeMax + " Height: " + criminal.HieghtMin +
                                "-" + criminal.HieghtMax + " Gender: " + criminal.Sex +
                                " Weight: " + criminal.WeightMin + "-" + criminal.WeightMax +
                                " Nationality: " + nationality;
                            Phrase line2 = new Phrase(details);
                            doc.Add(line2);
                            doc.Close();
                            byte[] bytes = memoryStream.ToArray();
                            memoryStream.Close();
                            MailMessage mail = new MailMessage("NCD", email, "Criminal Record:" + criminal.Name, "");
                            mail.Attachments.Add(new Attachment(new MemoryStream(bytes), criminal.Name + ".pdf"));
                            SendMailThread.Instace.Messages.Enqueue(mail);
                        }
                    }
                }


            }

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        private IMapper _mapper;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    unitOfWork.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }


        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
