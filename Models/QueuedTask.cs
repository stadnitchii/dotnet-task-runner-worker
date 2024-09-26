using System.ComponentModel.DataAnnotations;

namespace task_runner_api.Models
{
	public class QueuedTask
	{
		[Key]
		public int QueuedTaskId { get; set; }
		public DateTime DateQueued { get; set; }
		public DateTime? DateStarted { get; set; }
		public DateTime? DateCompleted { get; set; }
		public required string Creator { get; set; }
		public string? Host { get; set; }
		public string? State { get; set; }
		public string? JsonArguments { get; set; }
		public string? JsonResults { get; set; }
	}
}
