public class Product
{
    // attributes
    private string name;
    private double price;
    private double weight;
    private int quantity;

    // default constructor
    public Product()
    {
        this.name = "";
        this.price = 0;
        this.weight = 0;
        this.quantity = 0;
    }
    
    // modified constructor
    public Product(string n, double p, double w, int q)
    {
        this.name = n;
        this.price = p;
        this.weight = w;
        this.quantity = q;
    }

    // mutators
    public void setName(string n)
    {
        this.name = n;
    }

    public void setPrice(double p)
    {
        this.price = p;
    }

    public void setWeight(double w)
    {
        this.weight = w;
    }

    public void setQuantity(int q)
    {
        this.quantity = q;
    }

    // accessors
    public string getName()
    {
        return this.name;
    }

    public double getPrice()
    {
        return this.price;
    }

    public double getWeight()
    {
        return this.weight;
    }

    public int getQuantity()
    {
        return this.quantity;
    }
}