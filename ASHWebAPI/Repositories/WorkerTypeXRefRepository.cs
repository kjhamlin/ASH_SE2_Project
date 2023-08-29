using ASHWebAPI.dbContext;

namespace ASHWebAPI.Repositories
{
    public class WorkerTypeXRefRepository : IWorkerTypeXRefRepository
    {
        private readonly ASHDbContext _dbContext;

        public WorkerTypeXRefRepository(ASHDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public int GetEmployeeWorkerTypeId()
        {
            var result = _dbContext.WorkerTypeXRefs.Where(row => row.WorkerType == "Employee").First();
            return result.WorkerTypeId;
        }
    }
}
