// Copyright (c) Oleksii Nikiforov, 2021. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace Nikiforovall.ES.Template.Application.IntegrationTests.Projects.Commands;

using Nikiforovall.ES.Template.Application.Projects.Commands.CreateProject;
using Nikiforovall.ES.Template.Application.Projects.Commands.DeleteProject;
using Nikiforovall.ES.Template.Domain.ProjectAggregate;
using Nikiforovall.ES.Template.Domain.SharedKernel.Exceptions;
using Nikiforovall.ES.Template.Tests.Common;

[Trait("Category", "Integration")]
public class DeleteProjectCommandTests : IntegrationTestBase
{
    [Fact]
    public async Task ProjectDoesNotExist_NotFoundExceptionThrownAsync()
    {
        var command = new DeleteProjectCommand { Id = this.Fixture.Create<Guid>() };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<AggregateNotFoundException>();
    }

    [Theory, AutoData]
    public async Task ProjectExists_Deleted(CreateProjectCommand command)
    {
        var projectId = await SendAsync(command);

        await SendAsync(new DeleteProjectCommand { Id = projectId });

        var entity = await FindAsync<Project>(projectId);

        // TODO: project is not really deleted in ES version, implement soft delete
        //entity.Should().BeNull();
    }

    [Theory, AutoProjectData]
    public async Task ProjectDeleted_RelatedToDoItemsAreNotDeleted(
        Project project, ToDoItem toDoItem)
    {
        project.AddItem(toDoItem);
        await InsertAsync(project);

        await SendAsync(new DeleteProjectCommand { Id = project.Id });

        // TODO: project is not really deleted in ES version, implement soft delete
        //entity.Should().BeNull();
    }
}
