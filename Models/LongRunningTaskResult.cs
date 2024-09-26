namespace task_runner_api.Models
{
    public class LongRunningTaskResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
