using Microsoft.EntityFrameworkCore;
using task_runner_api.Models;

namespace task_runner_api
{
	public class MyContext : DbContext
	{
		public MyContext(DbContextOptions<MyContext> options) : base(options) { }

		public DbSet<QueuedTask> QueuedTasks { get; set; }
	}
}
