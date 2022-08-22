using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    internal class Person
    {
        private Dictionary<int, string> personDic = new Dictionary<int, string>();
        internal Person()
        {
            personDic.Add(1, "Sami");
            personDic.Add(2, "Ümit");
            personDic.Add(3, "Ömer");
            personDic.Add(4, "Burcu");
        }
        internal string GetPerson(int getKey)
        {
            return personDic[getKey];
        }
        internal void ListPerson()
        {
            int personCount = 1;
            foreach (var person in personDic)
            {
                Console.WriteLine(" ({0})    {1}", personCount,person.Value);
                personCount++;
            }

        }
    }

}
