﻿using System;
using Hangfire;
using Hangfire.Storage.SQLite;

namespace ConsoleSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // you can use LiteDB Storage and specify the connection string name
                GlobalConfiguration.Configuration
                    .UseColouredConsoleLogProvider()
                    .UseSQLiteStorage();

                //you have to create an instance of background job server at least once for background jobs to run
                using (new BackgroundJobServer())
                {
                    BackgroundJob.Enqueue(() => Console.WriteLine("Background Job: Hello, world!"));

                    RecurringJob.AddOrUpdate(() => TaskMethod(), Cron.Minutely);

                    Console.WriteLine("Press Enter to exit...");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in execution. Detail: {ex.ToString()}");
            }
            
            Console.ReadLine();
        }

        public static void TaskMethod()
        {
            Console.WriteLine("Testing Web Sample!!!");
        }
    }
}
