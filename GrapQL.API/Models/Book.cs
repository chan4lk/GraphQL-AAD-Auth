using GrapQL.API.Auth;
using HotChocolate.AspNetCore.Authorization;

namespace GrapQL.API.Models
{
    [Authorize(Roles = new string[] {"Guest", "Admin" })]
    public class Book
    {
        public string Title { get; set; }

        [CustomAuth(Roles = new string[] {"Admin"} )]
        public Author Author { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }
    }

}