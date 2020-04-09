using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Console.Configuration
{
    public class Services
    {
        public static void Configure(HostBuilderContext context, IServiceCollection services)
        {
            services.AddLogging();
            services.AddTransient<Commands.Rename.Command>();
        }
    }
}
