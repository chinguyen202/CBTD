using CBTD.DataAccess.Models;

namespace CBTD.Infrastructure.Interfaces;

public interface IOrderHeaderRepository<T> : IGenericRepository<OrderHeader>
{
    void UpdateStatus(int id, string orderStatus, string paymentStatus = null);
}