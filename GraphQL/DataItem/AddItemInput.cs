using System;

namespace TodoListQL.GraphQL.DataItem
{
    public record AddItemInput(string title, string description, bool IsDone, int listId);
    
}
