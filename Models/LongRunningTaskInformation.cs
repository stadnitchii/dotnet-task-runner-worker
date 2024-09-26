using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Text.Json.Serialization;

namespace task_runner_api.Models
{
    public class LongRunningTaskInformation
    {
        public required string Name { get; set; }
        public required string NormalizedName { get; set; }
		public required string Description { get; set; }
        public required string Creator { get; set; }
        public required Type CLRType { get; set; }
		public required uint MemoryPrediction { get; set; }
        public required uint CPUPrediction { get; set; }

        public LongRunningTaskInformationJson toJsonObject()
        {
			return new LongRunningTaskInformationJson()
			{
				Name = Name,
				NormalizedName = NormalizedName,
				Description = Description,
				Creator = Creator,
				CLRType = CLRType.FullName,
				MemoryPrediction = MemoryPrediction,
				CPUPrediction = CPUPrediction
			};
        }
    }

	public class LongRunningTaskInformationJson
	{
		public required string? Name { get; set; }
		public required string? NormalizedName { get; set; }
		public required string? Description { get; set; }
		public required string? Creator { get; set; }
		public required string? CLRType { get; set; }
		public required uint MemoryPrediction { get; set; }
		public required uint CPUPrediction { get; set; }
	}
}
