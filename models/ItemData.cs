using System;
using System.ComponentModel.DataAnnotations;

namespace TodoListQL.models
{
    public class ItemData
    {   
       // [Key,EmailAddress,Phone,DefaultValue("hirra")]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }

        public int ListId { get; set; }

        public virtual ItemList ItemList {get; set;}
        //Item data belongs to item list
    }
}
