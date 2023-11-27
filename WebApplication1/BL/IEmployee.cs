using System.Collections;
using WebApplication1.Models;
namespace WebApplication1.BL
{
    public interface IEmployee
    {
        IEnumerable<Employee> Getlist();

        IEnumerable<Employee> Create(Employee e);

        Employee GetEmployee(int id);
       

        IEnumerable<Employee> Editemp(Employee emp);
        

        IEnumerable<Employee> Delete(Employee e);
    }
}
