// Copyright (c) Oleksii Nikiforov, 2021. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace Nikiforovall.ES.Template.Infrastructure.Persistence;

using Marten;
using Marten.Events.Projections;
using Nikiforovall.ES.Template.Domain.ProjectAggregate;

public class MartenApplicationRegistry : MartenRegistry
{
    public MartenApplicationRegistry()
    {
        this.For<Project>().Identity(x => x.Id);
        this.For<ToDoItem>().Identity(x => x.Id);
    }

    public static void RegisterProjections(StoreOptions options)
    {
        options.Projections.SelfAggregate<Project>();
        options.Projections.Add<ToDoItemProjection>(ProjectionLifecycle.Async);
    }
}