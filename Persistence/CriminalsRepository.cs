using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class CriminalsRepository : Repository<Criminal>
    {
        readonly DataContext database;
        public CriminalsRepository(NCDDataContext dataContext) : base(dataContext)
        {
            database = dataContext;
        }

        public IEnumerable<Criminal> Search(Criminal criminal)
        {
            return GetAll().Where(x => x.Id == criminal.Id ||
            SqlMethods.Like(x.Name, criminal.Name) || x.NationalityID == criminal.NationalityID
            || x.Sex.Equals(criminal.Sex) || (x.HieghtMax > criminal.HieghtMax
            && x.HieghtMin < criminal.HieghtMin) || (x.WeightMax > criminal.WeightMax
            && x.WeightMin < criminal.WeightMin) || (x.AgeMin < criminal.AgeMin && x.AgeMax > criminal.AgeMax)).ToList();

        }
    }
}
