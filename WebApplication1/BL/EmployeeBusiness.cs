using Microsoft.CodeAnalysis.Differencing;
using WebApplication1.Models;

namespace WebApplication1.BL
{
    public class EmployeeBusiness : IEmployee
    {
        private readonly EmployeeDbcontext _EmployeeDbcontext;
        public EmployeeBusiness(EmployeeDbcontext EmployeeDbcontext)
        {
           this._EmployeeDbcontext = EmployeeDbcontext;
        }

        public IEnumerable<Employee> Create(Employee e)
        {
           _EmployeeDbcontext.Employees.Add(e);
            _EmployeeDbcontext.SaveChanges();
            return _EmployeeDbcontext.Employees;
        }

        public IEnumerable<Employee> Delete(Employee e)
        {
            throw new NotImplementedException();
        }





        //public IEnumerable<Employee> Details(int id)
        //{
        //    var Details = _EmployeeDbcontext.Employees.Where(x => x.Id == id).FirstOrDefault();
        //    return Details;
        //}

        public IEnumerable<Employee> Editemp(Employee emp)
        {
            _EmployeeDbcontext.Entry(emp).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _EmployeeDbcontext.SaveChanges();
            return _EmployeeDbcontext.Employees;    
        }

        public Employee GetEmployee(int id)
        {
            var Eid = _EmployeeDbcontext.Employees.Where(x => x.Id == id).FirstOrDefault();
            return Eid;
        }

        public IEnumerable<Employee> Getlist()
        {
            var list = _EmployeeDbcontext.Employees.ToList();
            return (list);
        }

        
    }
}
