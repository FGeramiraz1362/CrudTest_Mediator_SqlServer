using Application.Common.Behaviours;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Common;
using FluentValidation;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Implements;
using Infrastructure.Repositories.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Web.Controllers;

namespace Mc2.CrudTest.AcceptanceTests.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext scenario;

        public Hooks(ScenarioContext scenario)
        {
            this.scenario = scenario;
        }

        [BeforeScenario]
        public void CreateTestEmployeeCollection()
        {
            // Create list of employee Ids. Use whatever type for List<T>
            // that your API returns. This example uses a Guid. Could be
            // and int. Check your API documentation.

            var mapperConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });

            IMapper mapper = mapperConfig.CreateMapper();

            IServiceProvider serviceProvider = new ServiceCollection()
                .AddDbContext<ApplicationContext>(options =>
                            options.UseInMemoryDatabase(@"TestDB"))
                .AddScoped<IApplicationContext>(provider => provider.GetService<ApplicationContext>())

                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<ICustomerRepo, CustomerRepo>()
                .AddMediatR(cfg =>
                {
                    cfg.RegisterServicesFromAssemblies(
                       Assembly.GetAssembly(typeof(IApplicationContext)));
                    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
                    cfg.AddOpenRequestPostProcessor(typeof(RequestPostProcessor<,>));
                    cfg.AutoRegisterRequestProcessors = false;
                    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

                })
                .AddSingleton(mapper)
                .AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(IApplicationContext)))
                .AddLogging()
                .BuildServiceProvider();

            var customerController = new CustomerController(serviceProvider.GetService<IMediator>());
            scenario["customerController"] = customerController;


        }


    }
}