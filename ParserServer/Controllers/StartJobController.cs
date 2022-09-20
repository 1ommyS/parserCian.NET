using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParserServer.QueryBuilder.Models;
using Quartz;

namespace ParserServer.Controllers
{
    [ApiController]
    [Route("/start")]
    public class StartJobController
    {
        private readonly ISchedulerFactory _factory;

        public StartJobController(ISchedulerFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public async Task StartJob(CancellationToken cancellationToken)
        {
            var scheduler = await _factory.GetScheduler(cancellationToken);
            var jobDataMap = new JobDataMap();

            jobDataMap.Add("test", "test");

            var key = Guid.NewGuid().ToString("N");
            var jobDetail = JobBuilder.Create<OwnJob>()
                .WithIdentity(key, "myjobs")
                .UsingJobData(jobDataMap)
                .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity($"Trigger_{key}", "myjobsTrigger")
                .StartNow()
                .WithCronSchedule("0/30 * * ? * * *")
                .Build();

            await scheduler.ScheduleJob(jobDetail, trigger, cancellationToken);
        }
    }
}