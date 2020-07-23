using System;
using System.Net.Http.Headers;

public class Depot
{
    private string name;
    private Product[] productArray;

    public Depot()
    {
        this.name = "";
        productArray = new Product[5];
    }

    public Depot(string n)
    {
        this.name = n;
        productArray = new Product[5];
    }

    public void setName(string n)
    {
        this.name = n;
    }

    public string getName()
    {
        return name;
    }

    // number of products is full
    public bool checkFull()
    {
        int productCounter = 0;

        for(int i = 0; i < 5; i++)
        {
            if(productArray[i] != null)
            {
                productCounter++;
            }
        }

        if (productCounter == 5)
        {
            Console.WriteLine("Depot already holds 5 different products.");
            return true;
        }
        else
        {
            return false;
        }
    }

    // product with name already exists
    public bool checkName(string n)
    {
        for (int i = 0; i < 5; i++)
        {
            if (productArray[i] != null)
            {
                if (n == productArray[i].getName())
                {
                    Console.WriteLine("Product with name already exists in depot \"{0}\".", this.name);
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckProduct(string name)
    {
        for (int i = 0; i < 5; i++)
        {
            if (productArray[i] != null)
            {
                if (name == productArray[i].getName())
                {
                    return true;
                }
            }
        }
        return false;
    }

    public string GetProduct(string productName)
    {
        // loop through every product
        for (int i = 0; i < 5; i++)
        {
            if (productArray[i] != null)
            {
                if (productName == productArray[i].getName())
                {
                    return "" + productArray[i].getName();
                }
            }
        }

        return "";
    }

    public bool isEmpty()
    {
        int emptyCounter = 0;

        for (int i = 0; i < 5; i++)
        {
            if (productArray[i] == null)
            {
                emptyCounter++;
            }
        }

        // check empty
        if(emptyCounter == 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void addProduct(string productName)
    {
        double price;
        do
        {
            Console.Write("Enter price: ");
            price = double.Parse(Console.ReadLine());
        } while (price < 0);
        double weight;
        do
        {
            Console.Write("Enter weight: ");
            weight = double.Parse(Console.ReadLine());
        } while (weight < 0);
        int quantity;
        do
        {
            Console.Write("Enter quantity: ");
            quantity = int.Parse(Console.ReadLine());
        } while (quantity < 0);

        for (int i = 0; i < 5; i++)
        {
            if (productArray[i] == null)
            {
                productArray[i] = new Product(productName, price, weight, quantity);

                Console.WriteLine(
                    "Depot \"{0}\" has added product \"{1}\" with price ${2} and weight {3}. Adding {4} items.",
                        this.name,
                        productArray[i].getName(),
                        productArray[i].getPrice(),
                        productArray[i].getWeight(),
                        productArray[i].getQuantity()
                );

                return;
            }
        }
    }

    public void getProductDetails()
    {
        for (int i = 0; i < 5; i++)
        {
            if (productArray[i] != null)
            {
                Console.WriteLine("Product \"{0}\" has price ${1}, weight {2}kg, and quantity {3}", productArray[i].getName(), productArray[i].getPrice(), productArray[i].getWeight(), productArray[i].getQuantity());
            }
        }
    }
}