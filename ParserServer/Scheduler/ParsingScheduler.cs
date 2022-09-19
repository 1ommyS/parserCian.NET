using System;
using Microsoft.Extensions.DependencyInjection;
using ParserServer.Factory;
using ParserServer.Jobs;
using Quartz;
using Quartz.Impl;

namespace ParserServer.Scheduler
{
    public class ParsingScheduler
    {
        // public static async void Start(IServiceProvider serviceProvider)
        // {
        //     IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
        //     scheduler.JobFactory = serviceProvider.GetService<JobFactory>();
        //     await scheduler.Start();
        //
        //     IJobDetail jobDetail = JobBuilder.Create<ParsingJob>().Build();
        //     ITrigger trigger = TriggerBuilder.Create()
        //         .WithIdentity("MailingTrigger", "default")
        //         .StartNow()
        //         .WithSimpleSchedule(x => x
        //             .WithIntervalInSeconds(30)
        //             .RepeatForever())
        //         .Build();
        //
        //     await scheduler.ScheduleJob(jobDetail, trigger);
        // }
    }
}   