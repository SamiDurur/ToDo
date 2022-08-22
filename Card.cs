using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    internal class Card
    {
        private string title;
        private string content;
        private string assignedPerson;
        private ToDoSize size;
        private string line;

        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public string AssignedPerson { get => assignedPerson; set => assignedPerson = value; }
        public string Line { get => line; set => line = value; }
        internal ToDoSize Size { get => size; set => size = value; }
        public Card(string title, string content, string assignedPerson, ToDoSize size, string line)
        {
            Title = title;
            Content = content;
            AssignedPerson = assignedPerson;
            Size = size;
            Line = line;
        }
        public Card()
        {

        }
       
    }
}
