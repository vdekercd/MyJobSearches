namespace MyJobSearches.API.Infrastructures.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureSwaggerIfDevelopment(this WebApplication @this)
    {
        if (@this.Environment.IsDevelopment())
        {
            @this.UseSwagger();
            @this.UseSwaggerUI();
        }
        return @this;
    }
}

