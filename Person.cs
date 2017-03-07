using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Person
    {
        int idPerson;
        String name;
        int age;
        DateTime createdAt;
        DateTime updatedAt;
        int modifiedById;
        int updatedById;
        Product product;
        int productId;

        public String getName()
        {
            return name;
        }

        public int getAge()
        {
            return age;
        }

        public int getIdPerson()
        {
            return idPerson;
        }

        public DateTime getCreationDate()
        {
            return createdAt;
        }

        public DateTime getUpdateDate()
        {
            return updatedAt;
        }

        public int getProductId()
        {
            return productId;
        }

        public Product getProduct()
        {
            return product;
        }

        public Person setName(String name) 
        {
        if(name.Length > 50)
        {
                throw new Exception("Name is too long!");
            }
        else{
                this.name = name;
            }
        return this;
        }


        public Person setAge(int age) 
        {
        if(age < 0)
        {
                throw new Exception("Age cannot be negative!");
            }
        else{
                this.age = age;
            }
        return this;
        }

        public Person setIdPerson(int idPerson)
        {
        if(idPerson < 0)
        {
                throw new Exception("Id cannot be negative!");
            }
        else{
                this.idPerson = idPerson;
            }
        return this;
        }

        public Person setIdProduct(int productId)
        {
            if (productId < 0)
            {
                throw new Exception("Id cannot be negative!");
            }
            else
            {
                this.productId = productId;
            }
            return this;
        }

        public Person setProduct(Product product)
        {
            this.product = product;
            return this;
        }

        public Person setCreationDate(DateTime createdAt)
        {
            
            this.createdAt = createdAt;
            
            return this;
        }

        public Person setUpdateDate(DateTime updatedAt)
        {

            this.updatedAt = updatedAt;

            return this;
        }
    }
}
