using AutoMapper;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using WebClientContracts;

namespace BusinessServices
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
    public class UserService : IUserService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public bool Authenticate(string password, string email)
        {
            string Email = Encrypt(email);
            string Password = Encrypt(password);
            User user = unitOfWork.UserRepository.GetAll().Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();
            if (user != null)
            {
                user.LastLogin = DateTime.Now;
                unitOfWork.Commit();
                return true;
            }
            return false;
        }

        public void Register(UserDTO user)
        {
            User regUser = Mapper.Map<User>(user);
            regUser.Email = Encrypt(regUser.Email);
            regUser.Password = Encrypt(regUser.Password);
            unitOfWork.UserRepository.InsertOnSubmit(regUser);
            unitOfWork.Commit();
        }
        private string Encrypt(string credential)
        {
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            StringBuilder hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(credential), 0, Encoding.UTF8.GetByteCount(credential));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

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
