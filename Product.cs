using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Product
    {
        int idProduct;
        double price;
        DateTime createdAt;
        DateTime updatedAt;
        int modifiedById;
        int updatedById;

        public double getPrice()
        {
            return price;
        }

        public int getIdProduct()
        {
            return idProduct;
        }

        public Product setIdProduct(int idProduct)
        {
        if(idProduct < 0)
        {
                throw new Exception("Id cannot be negative!");
            }
        else{
                this.idProduct = idProduct;
            }
        return this;
        }

        public Product setPrice(double price)
        {
        if(price < 0)
        {
                throw new Exception("Price cannot be negative!");
            }
        else{
                this.price = price;
            }
        return this;
        }

        public Product setCreationDate(DateTime createdAt)
        {

            this.createdAt = createdAt;

            return this;
        }

        public Product setUpdateDate(DateTime updatedAt)
        {

            this.updatedAt = updatedAt;

            return this;
        }

    }
}
