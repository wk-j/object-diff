using System;
using Ninject;
using ObjectDiffer;

namespace Diff {
    class Person {
        public string Name { set; get; }
        public int Id { set; get; }
    }
    class Program {
        static void Main(string[] args) {
            var p1 = new Person { Id = 1 };
            var p2 = new Person { Id = 2 };

            var factory = new DifferFactory();
            var differ = factory.GetDefault();
            var d = differ.Diff(p1, p2);

            foreach (var item in d.ChildDiffs) {
                Console.WriteLine(item.PropertyName);
            }
        }
    }
}
