﻿using System;
using Autofac;
using Welo.Domain.Interfaces.Services;
using Welo.Domain.Services;

namespace Welo.IoC
{
    public class WebApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.RegisterType<MovieService>()
                      .As<IMovieService>()
                      .InstancePerLifetimeScope();
        }
    }
}