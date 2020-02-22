using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAsync.Data;
using TaskAsync.IService;
using TaskAsync.Model;

namespace TaskAsync.Service
{
    public class StudentService : IStudentService
    {
        /// <summary>
        /// 新增 方法标注为async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> AddPersonAsync(Student entity)
        {
            using (AppDbContext dbContext = new AppDbContext())
            {
                dbContext.Students.Add(entity);
                // 调用异步方法
                int count = await dbContext.SaveChangesAsync();
                return count;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteByIdAsync(int id)
        {
            using (AppDbContext dbContext = new AppDbContext())
            {
                Student student =await dbContext.Students.FindAsync(new object[] { id });
                if(student!=null)
                {
                    dbContext.Students.Remove(student);
                    return await dbContext.SaveChangesAsync();
                }
                else
                {
                    return 0;
                }
            }
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            List<Student> list = await Task.Run<List<Student>>(() => 
            {
                using (AppDbContext dbContext = new AppDbContext())
                {
                    return dbContext.Students.ToList();
                }
            });

            return list;
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            using (AppDbContext dbContext = new AppDbContext())
            {
                Student student = await dbContext.Students.FindAsync(new object[] { id });
                if (student != null)
                {
                    return student;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<int> UpdateAsync(Student entity)
        {
            using (AppDbContext dbContext = new AppDbContext())
            {
                Student student = await dbContext.Students.FindAsync(new object[] { entity.Id });
                if (student != null)
                {
                    student.Name = entity.Name;
                    student.Age = entity.Age;
                    student.Gender = entity.Gender;
                    dbContext.Entry(student).State = System.Data.Entity.EntityState.Modified;
                    return await dbContext.SaveChangesAsync();
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
