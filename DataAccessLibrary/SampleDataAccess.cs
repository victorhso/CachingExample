using Microsoft.Extensions.Caching.Memory;

namespace DataAccessLibrary
{
    public class SampleDataAccess
    {
        private readonly IMemoryCache _memoryCache;
        public SampleDataAccess(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> output = new();

            output.Add(new() { FirstName = "Victor", LastName = "Oliveira", });
            output.Add(new() { FirstName = "Lucas", LastName = "Alves", });
            output.Add(new() { FirstName = "Fabio", LastName = "Tirela", });

            Thread.Sleep(3000);

            return output;
        }

        public async Task<List<EmployeeModel>> GetEmployeesAsync()
        {
            List<EmployeeModel> output = new();

            output.Add(new() { FirstName = "Victor", LastName = "Oliveira", });
            output.Add(new() { FirstName = "Lucas", LastName = "Alves", });
            output.Add(new() { FirstName = "Fabio", LastName = "Tirela", });

            await Task.Delay(3000);

            return output;
        }

        public async Task<List<EmployeeModel>> GetEmployeesCache()
        {
            List<EmployeeModel> output;

            output = _memoryCache.Get<List<EmployeeModel>>("employees");

            if (output is null)
            {
                output = new();

                output.Add(new() { FirstName = "Victor", LastName = "Oliveira", });
                output.Add(new() { FirstName = "Vinicius", LastName = "Moreira", });
                output.Add(new() { FirstName = "Fabio", LastName = "Tirela", });

                await Task.Delay(3000);

                _memoryCache.Set("employees", output, TimeSpan.FromSeconds(7));
            }

            return output;
        }
    }
}
