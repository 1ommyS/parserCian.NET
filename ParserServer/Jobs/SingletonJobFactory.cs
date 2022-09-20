using System;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;

namespace ParserServer.Jobs
{
    public class SingletonJobFactory : IJobFactory
    {
        private readonly IServiceProvider Container;

        public SingletonJobFactory(IServiceProvider serviceProvider)
        {
            Container = serviceProvider;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return Container.GetService(bundle.JobDetail.JobType) as IJob;
        }

        public void ReturnJob(IJob job)
        {
        }
    }
}