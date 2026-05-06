public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool Sold { get; set; }
    public int ProductTypeId { get; set; }
    public DateTime DaysOnShelf { get; set; }

    /* public int DaysOnShelf
    {
        get
        {
            return (DateTime.Now - DateEntered).Days;
        }
    }
    */
}