using ASHWebAPI.Models;
using ASHWebAPI.Repositories;

namespace ASHWebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWorkerTypeXRefRepository _workerTypeXRefRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IWorkerTypeXRefRepository workerTypeXRefRepository) 
        {
            _employeeRepository = employeeRepository;
            _workerTypeXRefRepository = workerTypeXRefRepository;
        }

        public void AddEmployee(Worker worker)
        {
            var employeeTypeId = _workerTypeXRefRepository.GetEmployeeWorkerTypeId();
            worker.WorkerTypeId = employeeTypeId;

            _employeeRepository.AddEmployee(worker);
        }

        public IEnumerable<Worker> GetAllWorkers()
        {
            return _employeeRepository.GetAllWorkers();
        }
    }
}
