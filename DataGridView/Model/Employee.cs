using Bogus;//假数据生成
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView.Model
{
    internal class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int Salary { get; set; }

        public static Employee FakeOne() => employeeFaker.Generate();

        public static IEnumerable<Employee> FakeMany(int count) => employeeFaker.Generate(count);

        private static readonly Faker<Employee> employeeFaker = new Faker<Employee>()
            .RuleFor(x => x.ID, x => x.IndexFaker)
            .RuleFor(x => x.FirstName, x => x.Person.FirstName)
            .RuleFor(x => x.LastName, x => x.Person.LastName)
            .RuleFor(x => x.Birthday, x => x.Person.DateOfBirth)
            .RuleFor(x => x.Salary, x => x.Random.Int(6, 30) * 1000);
    }
}
