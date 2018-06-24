﻿using System;
using Autofac;
using Welo.Domain.Interfaces.Services;
using Welo.Domain.Services;
using Module = Autofac.Module;

namespace Welo.IoC
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            
            builder.RegisterType<LeadService>()
                   .As<ILeadService>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<BotCommandsService>()
                   .As<IStandardCommandService>()
                   .InstancePerLifetimeScope();

            #region WebApplication

            builder.RegisterType<MovieService>()
                   .As<IMovieService>()
                   .InstancePerLifetimeScope();

            #endregion
        }
    }
}