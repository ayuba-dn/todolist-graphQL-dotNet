using System;

namespace TodoListQL.models
{
    public class ItemList
    {
        public ItemList(){
            ItemDatas = new HashSet<ItemData>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ItemData> ItemDatas { get; set; }
        //item list have item datas
    }
}
