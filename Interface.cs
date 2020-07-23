using System;
using System.Xml;

public class Interface
{
    private Depot[] depotArray;

    public Interface()
    {
        depotArray = new Depot[4];
    }

    public void Run()
    {
        int selector;
        string tempName;

        do
        {
            // menu ui
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("1.  Add a depot.");
            Console.WriteLine("2.  Remove a depot.");
            Console.WriteLine("3.  Add a product to a depot.");
            Console.WriteLine("4.  Remove multiple product items at once.");
            Console.WriteLine("5.  Query for a list of depots.");
            Console.WriteLine("6.  Query for a list of products in a depot.");
            Console.WriteLine("7.  Query about a product's presence in the depots.");
            Console.WriteLine("8.  Query for the cumulative value of all products in a depot.");
            Console.WriteLine("9.  Export depot and product information to a file.");
            Console.WriteLine("10. Import depot and product information from a file.");
            Console.WriteLine("11. Exit \n");

            // navigate the menu
            Console.Write("Input: ");
            selector = Convert.ToInt32(Console.ReadLine());

            // 1. Add a depot
            if (selector == 1)
            {
                // loop every depot
                int depotCounter = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (depotArray[i] != null)
                    {
                        if (depotArray[i].getName() != "")
                        {
                            depotCounter++;
                        }
                    }
                }

                // There are already 4 depots
                if (depotCounter == 4)
                {
                    Console.WriteLine("There are already 4 depots.");
                }
                else
                {
                    Console.WriteLine("-----------Add a depot-----------");
                    Console.Write("New depot name: ");
                    tempName = Console.ReadLine();

                    // Loop user input against pre-existing depots
                    bool exists = false;
                    for (int i = 0; i < 4; i++)
                    {
                        if (depotArray[i] != null)
                        {
                            if (tempName == depotArray[i].getName())
                            {
                                exists = true;
                                break;
                            }
                        }
                    }

                    // Display message for matching depots
                    if (exists == true)
                    {
                        Console.WriteLine("Depot \"{0}\" already exists.", tempName);
                    }
                    else
                    {
                        // Array hasn't been instantiated
                        for (int i = 0; i < 4; i++)
                        {
                            if (depotArray[i] == null)
                            {
                                depotArray[i] = new Depot(tempName);
                                Console.WriteLine("{0} has been successfully added.", depotArray[i].getName());
                                break;
                            }
                        }
                    }
                }
            }

            // 2. Remove a depot.
            if (selector == 2)
            {
                Console.WriteLine("-----------Remove a depot-----------");
                Console.Write("Depot name: ");
                tempName = Console.ReadLine();

                // loop through each depot
                bool depotRemoved = false;
                for (int i = 0; i < 4; i++)
                {
                    if (depotArray[i] != null)
                    {
                        // input matches depot name
                        if (tempName == depotArray[i].getName())
                        {
                            depotArray[i] = null;
                            depotRemoved = true;
                            Console.WriteLine("Depot \"{0}\" successfully removed.", tempName);
                            break;
                        }
                    }
                }

                // depot does not exist
                if (depotRemoved == false)
                {
                    Console.WriteLine("Depot does not exist.");
                }
            }

            // 3. Add a product to a depot.
            if (selector == 3)
            {
                Console.WriteLine("-----------Add a product to a depot-----------");
                Console.Write("Depot name: ");
                tempName = Console.ReadLine();

                bool isDepot = false;

                // loop through each depot
                for (int i = 0; i < 4; i++)
                {
                    if (depotArray[i] != null)
                    {
                        // input matches depot name
                        if (tempName == depotArray[i].getName())
                        {
                            isDepot = true;

                            // input product name
                            string productName;
                            do
                            {
                                Console.Write("Product name: ");
                                productName = Console.ReadLine();

                                // error message for pre-existing product
                                if (depotArray[0].CheckProduct(productName) == true)
                                {
                                    Console.WriteLine("Product already exists.");
                                }
                            } while (depotArray[i].checkFull() == true || depotArray[0].CheckProduct(productName) == true);

                            // add the product
                            depotArray[i].addProduct(productName);

                            break;
                        }
                    }
                }

                // error
                if (isDepot == false)
                {
                    Console.WriteLine("Depot \"{0}\" does not exist.", tempName);
                }
            }

            // 4. Remove multiple product items at once.
            if (selector == 4)
            {
                Console.WriteLine("--------Remove multiple product items at once--------");

                int depotP = 0;

                // input depot
                Console.Write("Depot name: ");
                tempName = Console.ReadLine();

                bool depotExists = false;

                // loop through each depot
                for (int i = 0; i < 4; i++)
                {
                    if (depotArray[i] != null)
                    {
                        if (depotArray[i].getName() == tempName)
                        {
                            depotExists = true;
                            depotP = i;
                            break;
                        }
                    }
                }

                // input product
                Console.Write("Product name: ");
                string productName = Console.ReadLine();


                // search for product and set in boolean
                bool productFound = false;
                productFound = depotArray[depotP].SearchProduct(productName);


                // control
                if (depotExists == false)
                {
                    Console.WriteLine("Depot not found.");
                }
                else
                {
                    if (productFound == false)
                    {
                        Console.WriteLine("Product not found.");
                    }
                    else
                    {
                        // input quantity
                        int quantity = 0;
                        do
                        {
                            Console.Write("Quantity: ");
                            quantity = int.Parse(Console.ReadLine());
                        } while (quantity < 0);

                        // removing products
                        depotArray[depotP].RemoveProducts(productName, quantity);
                    }
                }
            }

            // 5.  Query for a list of depots.
            if (selector == 5)
            {
                Console.WriteLine("---------Query for a list of depots---------");

                bool depotExists = false;

                // loop depots
                for (int i = 0; i < 4; i++)
                {
                    if (depotArray[i] != null)
                    {
                        Console.WriteLine("Depot \"{0}\" has {1} products.", depotArray[i].getName(), depotArray[i].CalculateProducts());
                        depotExists = true;
                    }
                }

                // error message
                if (depotExists == false)
                {
                    Console.WriteLine("No depots exist.");
                }
            }

            // 6.  Query for a list of products in a depot.
            if (selector == 6)
            {
                Console.WriteLine("------Query for a list of products in a depot------");

                Console.Write("Depot name: ");
                tempName = Console.ReadLine();

                // loop through each depot
                for (int i = 0; i < 4; i++)
                {
                    if (depotArray[i] != null)
                    {
                        if (tempName == depotArray[i].getName())
                        {
                            // list all products in the depot
                            depotArray[i].getProductDetails();
                            break;
                        }
                    }
                }
            }

            // 7. Query about a product's presence in the depots.
            if (selector == 7)
            {
                Console.WriteLine("------Query about a product's presence in the depots------");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();

                bool pFound = false;        // product found

                // searching every depot
                for (int i = 0; i < 4; i++)
                {
                    // depot exists
                    if (depotArray[i] != null)
                    {
                        if (depotArray[i].GetProduct(productName) == productName)
                        {
                            Console.WriteLine("Product \"{0}\" is in \"{1}\".", depotArray[i].GetProduct(productName), depotArray[i].getName());
                            pFound = true;
                            break;
                        }
                    }
                }

                // product not found
                if (pFound == false)
                {
                    Console.WriteLine("Product not found.");
                }
            }

            // 8. Query for the cumulative value of all products in a depot.
            if (selector == 8)
            {
                Console.WriteLine("------------Query for the cumulative value of all products in a depot------------");
                Console.Write("Depot name: ");
                tempName = Console.ReadLine();
                bool depotExists = false;

                // loop through every depot
                for (int i = 0; i < 4; i++)
                {
                    if (depotArray[i] != null)
                    {
                        if (depotArray[i].getName() == tempName)
                        {
                            depotExists = true;
                            Console.WriteLine("Depot \"{0}\" has cumulative product value ${1}.", depotArray[i].getName(), depotArray[i].GetValue());
                            break;
                        }
                    }
                }

                // depot not found
                if (depotExists == false)
                {
                    Console.WriteLine("Depot does not exist.");
                }
            }

            // 9. Export depot and product information to a file.
            if (selector == 9)
            {
                Console.WriteLine("---------------Export depot and product information to a file---------------");

                string[] lines = new string[4];

                // looping through each depot to create lines
                for (int i = 0; i < 4; i++)
                {
                    if (depotArray[i] != null)
                    {
                        lines[i] = depotArray[i].WriteLine();
                    }
                }                

                // create file name
                System.IO.File.WriteAllLines(@"D:\Visual Studio Projects\C# Recreation\SENG1110 Assignment2 (CSharp)\SENG1110-Assignment-in-C-\output.txt", lines);

                Console.WriteLine("File exported.");
            }

            // 10. Import depot and product information from a file.
            if (selector == 10)
            {
                Console.WriteLine("-------Import depot and product information from a file-------");

                Console.WriteLine("Example txt file was cannot be found.");

                /*
                    https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-read-from-a-text-file 
                */
            }

        } while (selector != 11);
    }

    // start of program
    static void Main(string[] args)
    {
        Interface intFace = new Interface();
        intFace.Run();
    }
}
