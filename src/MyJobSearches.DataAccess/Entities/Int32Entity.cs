namespace MyJobSearches.DataAccess.Entities;

public abstract class Int32Entity
{
    protected Int32Entity()
    {
        Id = 0;
        CreatedDateTime = DateTime.Now;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    private DateTime CreatedDateTime { get; set; }
}

