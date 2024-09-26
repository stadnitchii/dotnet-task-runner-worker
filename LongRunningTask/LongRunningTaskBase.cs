using task_runner_api.Models;

namespace task_runner_api.LongRunningTask
{
    public abstract class LongRunningTaskBase
    {
        public required IServiceProvider serviceProvider { get; set; }

        public abstract Task<LongRunningTaskResult> RunAsync();

    }
}
