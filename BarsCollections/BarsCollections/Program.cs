using System;
using System.Collections.Generic;

namespace BarsCollections
{
    class Entity
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
    }
    static class Test
    {
        static public Dictionary<int, List<Entity>> Work(List<Entity> entities)
        {
            var dict = new Dictionary<int, List<Entity>>();
            foreach (Entity ent in entities)
            {
                if (!(dict.ContainsKey(ent.ParentId)))
                {
                    dict.Add(ent.ParentId, new List<Entity> { ent });
                }
                else
                {
                    dict[ent.ParentId].Add(ent);
                }
            }
            return dict;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var MyList = new List<Entity> { 
                new Entity { Id = 1, ParentId = 0, Name = "Root entity"}, 
                new Entity { Id = 2, ParentId = 1, Name = "Child of 1 entity"},
                new Entity { Id = 3, ParentId = 1, Name = "Child of 1 entity"},
                new Entity { Id = 4, ParentId = 2, Name = "Child of 2 entity"},
                new Entity { Id = 5, ParentId = 4, Name = "Child of 4 entity"} 
            };

            var Diction = Test.Work(MyList);

            //Печать элементов полученного словаря
            foreach(var dict in Diction)
            {
                Console.Write($"Key = {dict.Key}, Value = {{");
                foreach(var ent in dict.Value)
                {
                    Console.Write($"Entity{{Id = {ent.Id}}}, ");
                }
                Console.WriteLine("\b\b}");
            }

        }
    }
}
