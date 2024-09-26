using Microsoft.AspNetCore.Mvc;
using task_runner_api.Services;

namespace task_runner_api.Controllers
{
    [ApiController]
	[Route("/v1/[controller]/[action]")]
	public class TasksController : ControllerBase
	{
		private readonly ILogger<TasksController> logger;
		private readonly LongRunningTaskFactory taskFactory;

		public TasksController(ILogger<TasksController> logger, LongRunningTaskFactory taskFactory)
		{
			this.logger = logger;
			this.taskFactory = taskFactory;
		}

		[HttpGet]
		public async Task<object> RunTask(string taskName)
		{
			return await taskFactory.RunTaskByName(taskName);
		}


		[HttpGet]
		public object GetDefinedTasks()
		{
			return taskFactory.GetDefinedTasks().Select(e => e.toJsonObject());
		}
	}
}
