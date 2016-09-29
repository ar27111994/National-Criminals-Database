using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class UnitOfWork
    {
        public NCDDataContext Database = new NCDDataContext();
        private Repository<User> userRepository;
        private Repository<Role> roleRepository;
        private CriminalsRepository criminalRepository;
        private Repository<Nationality> nationalityRepository;
        private bool disposed;

        public Repository<User> UserRepository
        {
            get
            {

                if (userRepository == null)
                {
                    userRepository = new Repository<User>(Database);
                }
                return userRepository;
            }
        }
        public Repository<Role> RoleRepository
        {
            get
            {

                if (userRepository == null)
                {
                    roleRepository = new Repository<Role>(Database);
                }
                return roleRepository;
            }
        }
        public CriminalsRepository CriminalRepository
        {
            get
            {

                if (criminalRepository == null)
                {
                    criminalRepository = new CriminalsRepository(Database);
                }
                return criminalRepository;
            }
        }
        public Repository<Nationality> NationalityRepository
        {
            get
            {

                if (nationalityRepository == null)
                {
                    nationalityRepository = new Repository<Nationality>(Database);
                }
                return nationalityRepository;
            }
        }

        public void Commit()
        {
            Database.SubmitChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Database.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
