using MovieApi.Application.Common.Mappings;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.TodoLists.Queries.ExportTodos;
public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}