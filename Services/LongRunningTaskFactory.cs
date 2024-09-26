using task_runner_api.LongRunningTask;
using task_runner_api.Models;

namespace task_runner_api.Services
{
    public class LongRunningTaskFactory
    {
        private readonly List<LongRunningTaskInformation> definedLongRunningTasks = new List<LongRunningTaskInformation>();
        private readonly IServiceProvider rootServiceProvider;

        public LongRunningTaskFactory(IServiceProvider rootProvider)
        {
            this.rootServiceProvider = rootProvider;
            //this finds all the classes that implement the interface ILongRunningTask
            //then it creates a dictionary with string name and the type
            definedLongRunningTasks = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => p.IsClass && !p.IsAbstract && p.IsSubclassOf(typeof(LongRunningTaskBase)))
                .Select(p =>
                {
                    var attr = p.GetCustomAttributes(true)
                        .Select(e => e as LongRunningTaskInformationAttribute)
                        .Where(e => e != null)
                        .FirstOrDefault();

                    if (attr == null)
                        throw new Exception("Every task must have an information attribute");

                    return new LongRunningTaskInformation()
                    {
                        Name = attr.Name,
                        NormalizedName = normalizeTaskName(attr.Name),
                        Description = attr.Description,
                        Creator = attr.Creator,
                        CLRType = p,

                        CPUPrediction = attr.CPUPrediction,
                        MemoryPrediction = attr.MemoryPrediction,
                    };
                }).ToList();
        }

        private string normalizeTaskName(string name)
        {
            return name.ToLower().Replace(" ", string.Empty);
        }

        public IEnumerable<LongRunningTaskInformation> GetDefinedTasks()
        {
            return definedLongRunningTasks;
        }

        public async Task<LongRunningTaskResult> RunTaskByName(string name)
        {
            var normalizedName = normalizeTaskName(name);
            var foundTask = definedLongRunningTasks.FirstOrDefault(e => e.NormalizedName == normalizedName);

            if (foundTask == null)
                return new LongRunningTaskResult() { Success = false, Message = $"Could not find task by the name of {name}" };

            var c = Activator.CreateInstance(foundTask.CLRType) as LongRunningTaskBase;

            if (c == null)
                return new LongRunningTaskResult() { Success = false, Message = $"Somethign went wrong while instantiating the task" };


            c.serviceProvider = rootServiceProvider;
            return await c.RunAsync();
        }
    }
}
