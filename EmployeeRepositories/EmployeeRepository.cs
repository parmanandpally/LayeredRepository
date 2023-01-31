using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeRepositories.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        efcoredbContext db;
        public EmployeeRepository() { }

        public EmployeeRepository(efcoredbContext context)
        {
            this.db = context;
        }
        public async Task<List<Employee>> GetEmployees()
        {
            return await db.Employees.ToListAsync();
        }

        public async Task<Employee> InsertEmployee(Employee emp)
        {
            db.Employees.Add(emp);
            await db.SaveChangesAsync();
            return emp;
        }
    }
}
