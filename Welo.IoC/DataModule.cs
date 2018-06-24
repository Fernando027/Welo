using System;
using Autofac;
using Welo.Data;
using Welo.Data.Repository.WebApplication;
using Welo.Domain.Interfaces.Repositories;

namespace Welo.IoC
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.RegisterType<StandardCommandRepository>()
                   .As<IStandardCommandRepository>()
                   .InstancePerLifetimeScope();
            
            builder.RegisterType<LeadRepository>()
                   .As<ILeadRepository>()
                   .InstancePerLifetimeScope();

            #region WebApplication

            builder.RegisterType<MovieRepository>()
                   .As<IMovieRepository>()
                   .InstancePerLifetimeScope();

            #endregion
        }
    }
}