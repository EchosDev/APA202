using System;
using System.Collections.Generic;
using System.Text;

namespace _10_GenericTypesCollections.Models
{
    internal class Library<T> where T : Book
    {
        private List<T> items = new List<T>();
        public string Name { get; set; }

        public Library(string name)
        {
            Name = name;
        }
        public void Add(T item)
        {
            items.Add(item);
            Console.WriteLine($"{item.Title} adli kitab kitabxanaya elave edildi");
        }
        public void Remove(T item)
        {
            items.Remove(item);
            Console.WriteLine($"{item.Title} adli kitab kitabxanadan silindi");
        }
        public List<T> GetAll()
        {
            return items;
        }
        public int Count()
        {
            return items.Count;
        }
        public T FindByIndex(int index)
        {
            if (index < items.Count)
            {
                return items[index];
            }
            throw new Exception("Verilen index listin uzunlugundan boyukdur");
        }
    }
}
