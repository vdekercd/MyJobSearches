namespace MyJobSearches.DataAccess.Entities;

[Table("Companies")]
public class CompanyEntity : Int32Entity
{
    public CompanyEntity() : base() 
    {
        Name = String.Empty;
    }

    public string Name { get; set; }
}

