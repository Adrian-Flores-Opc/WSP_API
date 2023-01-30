using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WSP.ABSTRACTION.LOGGER
{
    public static class Extension
    {
        private static readonly string LogSectionName = "Logs";
        public static IServiceCollection AddLogger(this IServiceCollection services, string user = "")
        {
            IConfiguration? _configuration;
            var serviceProvider = services.BuildServiceProvider();
            _configuration = serviceProvider.GetService<IConfiguration>();
            LoggerOptions _options = new LoggerOptions();
            _configuration!.GetSection(LogSectionName).Bind(_options);
            services.AddSingleton<ILoggerInfo, Logger>(sp =>
            {
                return new Logger(_options.Path_Log_File, _options.Level, user);
            });
            return services;
        }
    }
}