using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using ParserServer.Jobs;
using Quartz;
using Quartz.Spi;

namespace ParserServer
{
    public class QuartzHostedService : IHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;
        private readonly IEnumerable<MyJob> _jobs;

        public QuartzHostedService(ISchedulerFactory schedulerFactory, IJobFactory jobFactory, IEnumerable<MyJob> jobs)
        {
            _schedulerFactory = schedulerFactory;
            _jobFactory = jobFactory;
            _jobs = jobs;
        }

        public IScheduler Scheduler { get; set; }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            Scheduler.JobFactory = _jobFactory;

            foreach (var myJob in _jobs)
            {
                var job = CreateJob(myJob);
                var trigger = CreateTrigger(myJob);

                await Scheduler.ScheduleJob(job, trigger, cancellationToken);
            }

            await Scheduler.Start(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Scheduler.Shutdown(cancellationToken);
        }

        private static IJobDetail CreateJob(MyJob job)
        {
            var type = job.Type;
            return JobBuilder.Create(type).WithDescription(type.Name).WithIdentity(type.FullName).Build();
        }

        private static ITrigger CreateTrigger(MyJob job)
        {
            return TriggerBuilder.Create().WithDescription(job.Expression).WithCronSchedule(job.Expression)
                .WithIdentity($"{job.Type.FullName}.trigger").Build();
        }
    }
}