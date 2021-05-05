using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Extensions.Logging;
using StreamDeckLib;
using StreamDeckLib.Config;

namespace YTMDesktop
{
    class Program
    {
        public static ILoggerFactory LoggerFactory;

        private static Timer _timer;

        static async Task Main(string[] args)
        {
            using (var config = ConfigurationBuilder.BuildDefaultConfiguration(args))
            {
                LoggerFactory = config.LoggerFactory;
                await ConnectionManager.Initialize(args, config.LoggerFactory)
                    .RegisterAllActions(typeof(Program).Assembly)
                    .StartAsync();
            }
        }

    }
}