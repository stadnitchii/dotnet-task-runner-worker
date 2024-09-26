namespace task_runner_api.LongRunningTask
{
    public class LongRunningTaskInformationAttribute : Attribute
    {
        public readonly string Name;
        public readonly string Description;
        public readonly string Creator;

        public readonly uint CPUPrediction;
        public readonly uint MemoryPrediction;

        public LongRunningTaskInformationAttribute(string name, string description, string creator, uint cpuPrediction, uint memoryPrediction)
        {
            Name = name;
            Description = description;
            Creator = creator;

            CPUPrediction = cpuPrediction;
            MemoryPrediction = memoryPrediction;
        }
    }
}
