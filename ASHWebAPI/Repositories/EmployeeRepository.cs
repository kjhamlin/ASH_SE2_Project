using ASHWebAPI.dbContext;
using ASHWebAPI.Models;

namespace ASHWebAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ASHDbContext _dbContext;

        public EmployeeRepository(ASHDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void AddEmployee(Worker worker)
        {
            _dbContext.Add(worker);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Worker> GetAllWorkers()
        {
            return _dbContext.Workers.AsEnumerable();
        }
    }
}
