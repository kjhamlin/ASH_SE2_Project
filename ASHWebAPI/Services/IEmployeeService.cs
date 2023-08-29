using ASHWebAPI.Models;

namespace ASHWebAPI.Services
{
    public interface IEmployeeService
    {
        public IEnumerable<Worker> GetAllWorkers();
        public void AddEmployee(Worker worker);
    }
}
