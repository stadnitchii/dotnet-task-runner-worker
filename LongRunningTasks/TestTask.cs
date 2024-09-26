using task_runner_api.Models;
using task_runner_api.LongRunningTask;

namespace task_runner_api.LongRunningTasks
{

	[LongRunningTaskInformation(
		"Test",
		"Description",
		"Vasile Stadnitchii",
		4,
		1000
	)]
	public class TestTask : LongRunningTaskBase
	{
		public override async Task<LongRunningTaskResult> RunAsync()
		{
			await Task.Delay(1000);

			return new LongRunningTaskResult() { Success = true, Message = "Task Completed Succesfully" };
		}
	}
}
