using Microsoft.EntityFrameworkCore;

namespace SocketServer.DataAccess 
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        { }
    }
}