namespace Application
{
    public class Class1
    {
        /*  Application Layer Functionality 
            As mentioned earlier, the Application Layer will contain the 
            Interfaces and Types that are specific to this Application.

        Firstly, Add Reference to the Domain Project.
        Install-Package MediatR.Extensions.Microsoft.DependencyInjection
        Install-Package Microsoft.EntityFrameworkCore

        you can invert the dependencies to build scalable applications. 
        Now, the advantage is that tomorrow, you need a different implementation of the ApplicationDbContext, 
        you don’t need to touch the existing code base, but just add another Infrastructure layer for this purpose
        and implement the IApplicationDbContext. As simple as that.

        Create a new folder Interfaces in the Application Project. Add a new interface in it, IApplicationDbContext.

        https://stackoverflow.com/questions/70472624/dotnet-6-how-to-create-class-library-for-service-extensions
        */
    }
}