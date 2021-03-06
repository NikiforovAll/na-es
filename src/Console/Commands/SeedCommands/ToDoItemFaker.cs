// Copyright (c) Oleksii Nikiforov, 2021. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace NikiforovAll.ES.Template.Console.Commands.SeedCommands;

using AutoBogus;
using NikiforovAll.ES.Template.Domain.ProjectAggregate;

public class ToDoItemFaker : AutoFaker<ToDoItem>
{
    public ToDoItemFaker()
    {
        this.RuleFor(faker => faker.Description, faker => faker.Lorem.Paragraph());
        this.RuleFor(faker => faker.Title, faker => faker.Name.JobTitle());

        this.Configure(builder => builder
            .WithSkip<ToDoItem>(t => t.ProjectNumber));
    }
}
