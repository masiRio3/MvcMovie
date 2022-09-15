using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using NuGet.Packaging.Signing;

namespace MvcMovie.Models.SeedData
{
    public class SeedData
    {
        public static void Initialize (IServiceProvider serviceProvider)
        {
            using (var context= new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                //Busca cualquier película
                if (context.Movie.Any())
                {
                    return; // La base de datos ha sido "Sembrada"

                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Titulo= "Cuando Harry conoció a Sally",
                        FechaLanzamiento= DateTime.Parse("1989-2-12"),
                        Genero= "Comedia Romantica",
                        Rating="G",
                        Precio= 7.99M


                    },
                    new Movie
                    {
                        Titulo="CazaFantasmas",
                        FechaLanzamiento= DateTime.Parse("1984-3-13"),
                        Genero="Comedia",
                        Rating="R",
                        Precio= 8.99M
                    },
                    new Movie
                    {
                        Titulo = "CazaFantasmas 2",
                        FechaLanzamiento = DateTime.Parse("1986-2-23"),
                        Genero = "Comedia",
                        Rating="B",
                        Precio = 9.99M
                    },
                    new Movie
                    {
                        Titulo="Rio Bravo",
                        FechaLanzamiento= DateTime.Parse("1959-4-15"),
                        Genero="Western",
                        Rating="E",
                        Precio= 3.99M
                    }

                );
                context.SaveChanges();

            }
        }
    }
}
