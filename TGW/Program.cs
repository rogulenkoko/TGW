using Autofac;
using TGW;
using TGW.Core.Services;
using TGW.Data;

BuildContainer().Resolve<StartUp>().Run();

static IContainer BuildContainer()
{
    var builder = new ContainerBuilder();
    builder.RegisterType<StartUp>();
    builder.RegisterType<FileConfigurationReader>().AsImplementedInterfaces();
    builder.RegisterType<ConfigurationMergeService>().AsImplementedInterfaces();
    return builder.Build();
}

