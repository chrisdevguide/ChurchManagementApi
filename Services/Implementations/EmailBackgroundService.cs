namespace ChurchManagementApi.Services.Implementations
{
    public class EmailBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public EmailBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using IServiceScope scope = _serviceProvider.CreateScope();
                IAutomatedEmailServices automatedEmailServices = scope.ServiceProvider.GetRequiredService<IAutomatedEmailServices>();

                try
                {
                    await automatedEmailServices.SendAutomatedEmails();
                }
                catch (Exception e)
                {
                }


                await Task.Delay(TimeSpan.FromHours(6), stoppingToken);
            }
        }
    }
}
