using System;
using System.Net.Http.Headers;

public class Depot
{
    // attributes
    private string name;
    private Product[] productArray;

    // default constructor
    public Depot()
    {
        this.name = "";
        productArray = new Product[5];
    }

    // modified constructor
    public Depot(string n)
    {
        this.name = n;
        productArray = new Product[5];
    }

    // mutators
    public void setName(string n)
    {
        this.name = n;
    }

    // accessors
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

    public void RemoveProducts(string productName, int quantity)
    {
        // loop each product
        for (int i = 0; i < 5; i++)
        {
            if (productArray[i] != null)
            {
                // product found
                if (productName == productArray[i].getName())
                {
                    if (quantity > productArray[i].getQuantity())
                    {
                        // set to 0
                        productArray[i].setQuantity(0);
                        Console.WriteLine("Product \"{0}\" has been completely removed from depot \"{1}\".", productArray[i].getName(), this.name);
                    }
                    else
                    {
                        // remove amount specified
                        productArray[i].setQuantity(productArray[i].getQuantity() - quantity);
                        Console.WriteLine("{0} items of product \"{1}\" removed from depot \"{2}\".", quantity, productArray[i].getName(), this.name);
                    }
                }
            }
        }
    }

    public bool SearchProduct(string productName)
    {
        // loop through every product
        for (int i = 0; i < 5; i++)
        {
            if (productArray[i] != null)
            {
                if (productName == productArray[i].getName())
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
                    return " " + productArray[i].getName();
                }
            }
        }

        return "";
    }

    public string WriteLine()
    {
        string depotLine = "";

        // loop through each product
        for (int i = 0; i < 5; i++)
        {
            if (productArray[i] != null)
            {
                depotLine += this.name + " " + productArray[i].getName() + " " + productArray[i].getPrice() + " " + productArray[i].getWeight() + " " + productArray[i].getQuantity() + "\n";
            }
        }

        return depotLine;
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
        bool productExists = false;

        for (int i = 0; i < 5; i++)
        {
            if (productArray[i] != null)
            {
                Console.WriteLine("Product \"{0}\" has price ${1}, weight {2}kg, and quantity {3}", productArray[i].getName(), productArray[i].getPrice(), productArray[i].getWeight(), productArray[i].getQuantity());
                productExists = true;
            }
        }

        if (productExists == false)
        {
            Console.WriteLine("No products in depot.");
        }
    }

    public double GetValue()
    {
        double total = 0;

        // loop through each product
        for (int i = 0; i < 5; i++)
        {
            if (productArray[i] != null)
            {
                total += (productArray[i].getQuantity() * productArray[i].getPrice());
            }
        }

        return total;
    }

    public int CalculateProducts()
    {
        int total = 0;

        // loop through each product
        for (int i = 0; i < 5; i++)
        {
            if (productArray[i] != null)
            {
                total += productArray[i].getQuantity();
            }
        }

        return total;
    }
}