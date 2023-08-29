using ASHWebAPI.Models;

namespace ASHWebAPI.Repositories
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Worker> GetAllWorkers();
        public void AddEmployee(Worker worker);
    }
}
