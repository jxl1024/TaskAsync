using System.Collections.Generic;
using System.Threading.Tasks;
using TaskAsync.Model;

namespace TaskAsync.IService
{
    public interface IStudentService
    {
        /// <summary>
        /// 增加的异步方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> AddPersonAsync(Student entity);

        /// <summary>
        /// 删除的异步方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteByIdAsync(int id);

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Student>> GetAllAsync();

        /// <summary>
        /// 根据Id获取单一值
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Student> GetStudentByIdAsync(int id);

        /// <summary>
        /// 更新的异步方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(Student entity);
    }
}
