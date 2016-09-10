using AutoMapper;
using BusinessServices.MapperConfig;
using Persistence;
using System;
using System.Collections;
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
    public class RoleService : IRoleService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public RoleService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public void Create(RoleDTO role)
        {
            Role regRole = _mapper.Map<Role>(role);
            unitOfWork.RoleRepository.InsertOnSubmit(regRole);
            unitOfWork.Commit();
        }

        public IEnumerable<RoleDTO> GetRoles()
        {
            return unitOfWork.RoleRepository.GetAll().Project().To<RoleDTO>() as IEnumerable<RoleDTO>;
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