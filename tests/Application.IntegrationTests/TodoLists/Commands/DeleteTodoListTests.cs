using FluentAssertions;
using MovieApi.Application.Common.Exceptions;
using MovieApi.Application.TodoLists.Commands.CreateTodoList;
using MovieApi.Application.TodoLists.Commands.DeleteTodoList;
using MovieApi.Domain.Entities;
using NUnit.Framework;

using static MovieApi.Application.IntegrationTests.Testing;

namespace MovieApi.Application.IntegrationTests.TodoLists.Commands;
public class DeleteTodoListTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        var command = new DeleteTodoListCommand(99);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoList()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        await SendAsync(new DeleteTodoListCommand(listId));

        var list = await FindAsync<TodoList>(listId);

        list.Should().BeNull();
    }
}
