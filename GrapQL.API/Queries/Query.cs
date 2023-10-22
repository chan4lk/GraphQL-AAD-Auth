using System.Linq;
using System.Security.Claims;
using GrapQL.API.Models;

namespace GrapQL.API.Queries
{
    public class Query
    {
        public Book GetBook(ClaimsPrincipal claimsPrincipal) =>
            new Book
            {
                Title = "C# in depth.",
                Author = new Author
                {
                    Name = claimsPrincipal.Claims.FirstOrDefault(c=>  c.Type == "name")?.Value 
                }
            };
    }

}