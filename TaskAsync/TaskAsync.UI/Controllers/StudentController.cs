using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using TaskAsync.Data;
using TaskAsync.IService;
using TaskAsync.Model;
using TaskAsync.Service;

namespace TaskAsync.UI.Controllers
{
    public class StudentController : Controller
    {
        //private AppDbContext db = new AppDbContext();

        IStudentService service = new StudentService();
        // GET: Student
        public async Task<ActionResult> Index()
        {
            return View(await service.GetAllAsync());
        }

        // GET: Student/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student =await service.GetStudentByIdAsync((int)id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Create([Bind(Include = "Id,Name,Age,Gender")] Student student)
        {
            if (ModelState.IsValid)
            {
                int count = await service.AddPersonAsync(student);
                if(count>0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await service.GetStudentByIdAsync((int)id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Age,Gender")] Student student)
        {
            if (ModelState.IsValid)
            {
                int count = await service.UpdateAsync(student);
                if (count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public async  Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await service.GetStudentByIdAsync((int)id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            int count = await service.DeleteByIdAsync(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
