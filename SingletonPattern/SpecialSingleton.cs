using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class SpecialSingleton
    {
        private string name;
        public static SpecialSingleton instance;

        public SpecialSingleton(string name)
        {
            this.name = name;
            instance = this;
        }

        public void show()
        {
            Console.WriteLine(name);
        }
    }
}
