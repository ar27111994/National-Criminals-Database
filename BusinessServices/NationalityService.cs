using AutoMapper;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using WebClientContracts;

namespace BusinessServices
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
    public class NationalityService : INationalityService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public NationalityService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Create(NationalityDTO nationality)
        {
            Nationality regNationality = _mapper.Map<Nationality>(nationality);
            unitOfWork.NationalityRepository.InsertOnSubmit(regNationality);
            unitOfWork.Commit();

        }

        public IEnumerable<NationalityDTO> GetNationalities()
        {
            return unitOfWork.NationalityRepository.GetAll().Project<Nationality>().To<NationalityDTO>() as IEnumerable<NationalityDTO>;
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
