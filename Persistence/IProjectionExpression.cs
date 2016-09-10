using System.Linq;

namespace Persistence
{
    public interface IProjectionExpression
    {
        IQueryable<TResult> To<TResult>();
    }
}