using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.BL;

namespace WebApplication1.Controllers
{
// My name is Pooja
    public class TestController : Controller
    {
        private readonly EmployeeDbcontext employeeDbcontext;
        private readonly IEmployee _IEmployee;

        public TestController(EmployeeDbcontext employeeDbcontext,IEmployee IEmployee)
        {
            this.employeeDbcontext = employeeDbcontext; 
            this._IEmployee = IEmployee;
        }
        public IActionResult Index()
        {
            //var list = employeeDbcontext.Employees.ToList(); 
            //return View(list);

            var list = _IEmployee.Getlist();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create( Employee e) 
        {
          //if(ModelState.IsValid) 
          //  {
          //      employeeDbcontext.Add(e);
          //      await employeeDbcontext.SaveChangesAsync();
          //      return RedirectToAction("Index");
          //  }
          //  return View();

            if(ModelState.IsValid)
            {
                _IEmployee.Create(e);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //var eid= employeeDbcontext.Employees.Where(x=>x.Id==id).FirstOrDefault();
            //return View(eid);
            var data=_IEmployee.GetEmployee(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult>Edit(Employee e)
        {
            //if(ModelState.IsValid)
            //{
            //    employeeDbcontext.Entry(e).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //    await employeeDbcontext.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}
            //return View();

            if(ModelState.IsValid)
            {
                _IEmployee.Editemp(e);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var Emp = _IEmployee.GetEmployee(id);
            return View(Emp);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var eid = employeeDbcontext.Employees.Where(x => x.Id == id).FirstOrDefault();

            return View(eid);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Employee e)
        {
            if (ModelState.IsValid)
            {
                employeeDbcontext.Entry(e).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await employeeDbcontext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
     


    }
}
