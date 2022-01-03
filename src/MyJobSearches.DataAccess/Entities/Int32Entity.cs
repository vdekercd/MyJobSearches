namespace MyJobSearches.DataAccess.Entities;

public abstract class Int32Entity
{
    public Int32Entity()
    {
        Id = 0;
        CreatedDateTime = DateTime.Now;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public DateTime CreatedDateTime { get; set; }
}

