using ASHWebAPI.Models;
using ASHWebAPI.Repositories;
using ASHWebAPI.Services;
using Moq;

namespace ASHWebAPITests
{
    public class Tests
    {
        private EmployeeService? _employeeService;
        private Worker? _worker;
        private Mock<IEmployeeRepository>? _mockEmployeeRepository;
        private Mock<IWorkerTypeXRefRepository>? _mockWorkerTypeXRefRepository;
        
        [SetUp]
        public void Setup()
        {
            _mockWorkerTypeXRefRepository = new Mock<IWorkerTypeXRefRepository>();
            _mockWorkerTypeXRefRepository.Setup(repo => repo.GetEmployeeWorkerTypeId()).Returns(1);
            
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _mockEmployeeRepository.Setup(repo => repo.AddEmployee(It.IsAny<Worker>()));

            _worker = new Worker
            {
                WorkerId = 1,
                FirstName = "John",
                LastName = "Doe",
                Address1 = "1234 Rainbow Rd",
                WorkerTypeId = 0
            };

            _employeeService = new EmployeeService(
                _mockEmployeeRepository.Object,
                _mockWorkerTypeXRefRepository.Object
                );
        }

        [Test]
        public void AddEmployee_ShouldCallGetEmployeeWorkerTypeId()
        {
            _employeeService.AddEmployee(_worker);

            _mockWorkerTypeXRefRepository.Verify(x => x.GetEmployeeWorkerTypeId(), Times.Once());
        }

        [Test]
        public void AddEmployee_ShouldCallAddEmployee()
        {
            _employeeService.AddEmployee(_worker);

            _mockEmployeeRepository.Verify(x => x.AddEmployee(It.IsAny<Worker>()), Times.Once());
        }

        [TearDown]
        public void TearDown() 
        { 
            _employeeService = null;
            _worker = null;
            _mockEmployeeRepository = null;
            _mockWorkerTypeXRefRepository = null;
        }
    }
}