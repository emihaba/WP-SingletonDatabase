using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBaseSingleton db = DataBaseSingleton.getInstance();

            Person person1 = new Person();
            person1.setIdPerson(1);
            person1.setName("Habka");
            person1.setAge(21);
            person1.setIdProduct(3);

            db.PersonToDatebase(person1);

            Person person2 = new Person();
            person2.setIdPerson(2);
            person2.setName("Habuszka");
            person2.setAge(20);
            person2.setIdProduct(4);

            db.PersonToDatebase(person2);

            Product product1 = new Product();
            product1.setIdProduct(1);
            product1.setPrice(20);

            db.ProductToDatebase(product1);

            Person person3 = db.getPerson(2);
            Console.WriteLine(person3.getName());
            Console.WriteLine(person3.getCreationDate());
            Console.ReadKey();




        }
    }
}
