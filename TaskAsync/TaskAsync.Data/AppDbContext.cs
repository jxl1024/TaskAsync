using System.Data.Entity;
using TaskAsync.Model;

namespace TaskAsync.Data
{
    /// <summary>
    /// 数据上下文类，继承自父类的DbContext
    /// </summary>
    public class AppDbContext:DbContext
    {
        /// <summary>
        /// 通过创建连接，给父类的构造函数传递参数
        /// 参数是连接字符串的名称
        /// 表示使用连接字符串中名字为DbConnectionString的去连接数据库
        /// </summary>
        public AppDbContext():base("name=DbConnectionString")
        {

        }

        /// <summary>
        /// 重写OnModelCreating方法
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 配置生成的表名
            modelBuilder.Entity<Student>().ToTable("T_Student");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
    }
}
