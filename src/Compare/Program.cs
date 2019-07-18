using System;
using KellermanSoftware.CompareNetObjects;

namespace Compare {
    class Grade {
        public int Gpa { set; get; }
        public override string ToString() => $"gpa = {Gpa}";
    }

    class Person {
        public int Id { set; get; }
        public string Name { set; get; }
        public Grade Grade { set; get; }
    }
    class Program {
        static void Main(string[] args) {
            var p1 = new Person { Id = 1, Name = "aaaa", Grade = new Grade { Gpa = 100 } };
            var p2 = new Person { Id = 2, };

            var compareLogic = new CompareLogic(new ComparisonConfig {
                MaxDifferences = 10,
                MembersToIgnore = new System.Collections.Generic.List<string> {
                    "Id",
                    "Grade"
                }
            });
            var diff = compareLogic.Compare(p1, p2);
            foreach (var item in diff.Differences) {
                var t = item.Object1TypeName;
                var str = $"{item.PropertyName} [{t}]  {item.Object1Value}, {item.Object2Value}";
                Console.WriteLine(str);
            }
        }
    }
}
