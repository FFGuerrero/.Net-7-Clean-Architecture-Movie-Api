﻿using FluentAssertions;
using MovieApi.Application.Common.Exceptions;
using MovieApi.Application.TodoItems.Commands.CreateTodoItem;
using MovieApi.Application.TodoItems.Commands.DeleteTodoItem;
using MovieApi.Application.TodoLists.Commands.CreateTodoList;
using MovieApi.Domain.Entities;
using NUnit.Framework;

using static MovieApi.Application.IntegrationTests.Testing;

namespace MovieApi.Application.IntegrationTests.TodoItems.Commands;
public class DeleteTodoItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new DeleteTodoItemCommand(99);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        var itemId = await SendAsync(new CreateTodoItemCommand
        {
            ListId = listId,
            Title = "New Item"
        });

        await SendAsync(new DeleteTodoItemCommand(itemId));

        var item = await FindAsync<TodoItem>(itemId);

        item.Should().BeNull();
    }
}