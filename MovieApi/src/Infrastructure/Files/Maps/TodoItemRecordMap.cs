using System.Globalization;
using CsvHelper.Configuration;
using MovieApi.Application.TodoLists.Queries.ExportTodos;

namespace MovieApi.Infrastructure.Files.Maps;
public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).Convert(arg => arg.Value.Done ? "Yes" : "No");
    }
}
