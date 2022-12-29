using MovieApi.Application.TodoLists.Queries.ExportTodos;

namespace MovieApi.Application.Common.Interfaces;
public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}