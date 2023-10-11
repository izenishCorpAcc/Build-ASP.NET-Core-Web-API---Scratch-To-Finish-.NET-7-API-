using Microsoft.AspNetCore.Http.HttpResults;
using static System.Reflection.Metadata.BlobBuilder;

namespace nzwalks.API.Models.Domain
{
    public class Walk
    {
        public Guid id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        public Guid Regionid { get; set; }

        public Guid Difficultyid { get; set; }



        //NVIGATION PROPERTY
        public Region Region { get; set; }
        //This says that a WALK will have a difficulty and the Difficultyid is the match to it
        public Difficulty Diffifculty { get; set; }

    }
}




//Navigation properties in ASP.NET models are used to define relationships between entities in an application. They allow for easy navigation and traversal between related entities. Navigation properties represent associations between entities and can be used to access related data.

//In ASP.NET, navigation properties are typically defined using object-oriented principles.For example, if you have two entities, such as Author and Book, and there is a one-to-many relationship between them (one author can have multiple books), you can define a navigation property in the Author entity to represent the collection of books associated with that author.

//Here's an example of how navigation properties can be defined in ASP.NET models:

//public class Author
//{
//    public int Id { get; set; }
//    public string Name { get; set; }

//    public ICollection<Book> Books { get; set; }
//}

//public class Book
//{
//    public int Id { get; set; }
//    public string Title { get; set; }

//    public Author Author { get; set; }
//    public int AuthorId { get; set; }
//}
//In this example , the Author entity has a navigation property called Books, which represents the collection of books associated with that author. Similarly, the Book entity has a navigation property called Author, which represents the author associated with that book.

//Navigation properties allow you to easily navigate between related entities. For example, you can access the books of an author using the Books property of an Author object, or you can access the author of a book using the Author property of a Book object.

//By defining navigation properties in ASP.NET models, you can establish relationships between entities and easily access related data, making it convenient to work with complex data structures and perform operations involving related entities.