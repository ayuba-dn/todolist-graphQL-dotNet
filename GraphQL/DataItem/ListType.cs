using System;
using TodoListQL.models;
using TodoListQL.data;

namespace TodoListQL.GraphQL.DataItem
{
    public class ListType: ObjectType<ItemData>
    {
        protected override void Configure(IObjectTypeDescriptor<ItemData> descriptor)
        {
            descriptor.Description("This Model is Used As Item for TodoList");
            descriptor.Field(x=>x.ItemList)
            .ResolveWith<Resolvers>(x=>x.GetItems(default!, default!))
            .UseDbContext<ApiDbContext>()
            .Description("This Item Belongs to xxx");
        }

        private class Resolvers{
            public IQueryable<ItemData> GetItems(ItemList list, [ScopedService] ApiDbContext context){
                return context.Items.Where(x=>x.ListId==list.Id);
            }
        }
    }
}
