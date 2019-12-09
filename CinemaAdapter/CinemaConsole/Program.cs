using CinemaAdapter;
using System;
using System.Data;

// interface for tables
public interface ITable
{
    DataTable Create();
    void Add(DataTable table);
    void Delete(DataTable table);
    void Update(DataTable table);
    void View(DataTable table);
    void SortAsc(DataTable table);
}

namespace CinemaAdapter
{

    class Program
    {
        // main menu
        static public int Menu()
        {
            Console.Clear();
            Console.WriteLine("///Menu:");
            Console.WriteLine("1. Work with Tables");
            Console.WriteLine("2. View DataSet");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Choice: ");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }

        static void Main(string[] args)
        {
            // 4 adapters - 4 classes(tables)
            ITable fAdapter = new FAdapter();
            ITable gAdapter = new GAdapter();
            ITable aAdapter = new AAdapter();
            ITable sAdapter = new SAdapter();

            // 4 tables
            DataTable films = fAdapter.Create();
            DataTable genre = gAdapter.Create();
            DataTable actors = aAdapter.Create();
            DataTable fga = sAdapter.Create();

            // dataset
            DataSet cinema = new DataSet("Cinema");
            cinema.Tables.Add(films);
            cinema.Tables.Add(genre);
            cinema.Tables.Add(actors);
            cinema.Tables.Add(fga);

            cinema.Relations.Add("films_throughttable", films.Columns["Id"], fga.Columns["Film_Id"]);
            cinema.Relations.Add("genre_throughttable", genre.Columns["Id"], fga.Columns["Genre_Id"]);
            cinema.Relations.Add("actors_throughttable", actors.Columns["Id"], fga.Columns["Actor_Id"]);

            // working with info
            do
            {
                switch (Menu())
                {
                    case 1:
                        {
                        tableMenu:
                            Console.Clear();
                            Console.WriteLine("///Tables:");
                            Console.WriteLine("1. Films");
                            Console.WriteLine("2. Genre");
                            Console.WriteLine("3. Actors");
                            Console.WriteLine("4. FGA");
                            Console.WriteLine("5. Previous menu");
                            Console.WriteLine("Choice: ");

                            var result = Console.ReadLine();
                            if (Convert.ToInt32(result) == 1)
                            {
                            filmMenu:
                                Console.Clear();
                                Console.WriteLine("///Films:");
                                Console.WriteLine("1. Add a record");
                                Console.WriteLine("2. Delete a record");
                                Console.WriteLine("3. Update a record");
                                Console.WriteLine("4. View a table");
                                Console.WriteLine("5. View sort name by ascending");
                                Console.WriteLine("6. Previous menu");
                                Console.WriteLine("Choice: ");

                                var result1 = Console.ReadLine();
                                if (Convert.ToInt32(result1) == 1)
                                {
                                    fAdapter.Add(films);
                                    goto filmMenu;
                                }
                                else if (Convert.ToInt32(result1) == 2)
                                {
                                    fAdapter.Delete(films);
                                    goto filmMenu;
                                }
                                else if (Convert.ToInt32(result1) == 3)
                                {
                                    fAdapter.Update(films);
                                    goto filmMenu;
                                }
                                else if (Convert.ToInt32(result1) == 4)
                                {
                                    fAdapter.View(films);
                                    Console.WriteLine("\nPress to continue.");
                                    Console.ReadKey();
                                    goto filmMenu;
                                }
                                else if (Convert.ToInt32(result1) == 5)
                                {
                                    fAdapter.SortAsc(films);
                                    Console.WriteLine("\nPress to continue.");
                                    Console.ReadKey();
                                    goto filmMenu;
                                }
                                else if (Convert.ToInt32(result1) == 6)
                                {
                                    goto tableMenu;
                                }
                            }
                            else if (Convert.ToInt32(result) == 2)
                            {
                            genreMenu:
                                Console.Clear();
                                Console.WriteLine("///Genre:");
                                Console.WriteLine("1. Add a record");
                                Console.WriteLine("2. Delete a record");
                                Console.WriteLine("3. Update a record");
                                Console.WriteLine("4. View a table");
                                Console.WriteLine("5. View sort name by ascending");
                                Console.WriteLine("6. Previous menu");
                                Console.WriteLine("Choice: ");

                                var result1 = Console.ReadLine();
                                if (Convert.ToInt32(result1) == 1)
                                {
                                    gAdapter.Add(genre);
                                    goto genreMenu;
                                }
                                else if (Convert.ToInt32(result1) == 2)
                                {
                                    gAdapter.Delete(genre);
                                    goto genreMenu;
                                }
                                else if (Convert.ToInt32(result1) == 3)
                                {
                                    gAdapter.Update(genre);
                                    goto genreMenu;
                                }
                                else if (Convert.ToInt32(result1) == 4)
                                {
                                    gAdapter.View(genre);
                                    Console.WriteLine("\nPress to continue.");
                                    Console.ReadKey();
                                    goto genreMenu;
                                }
                                else if (Convert.ToInt32(result1) == 5)
                                {
                                    gAdapter.SortAsc(genre);
                                    Console.WriteLine("\nPress to continue.");
                                    Console.ReadKey();
                                    goto genreMenu;
                                }
                                else if (Convert.ToInt32(result1) == 6)
                                {
                                    goto tableMenu;
                                }
                            }
                            else if (Convert.ToInt32(result) == 3)
                            {
                            actorsMenu:
                                Console.Clear();
                                Console.WriteLine("///Actors:");
                                Console.WriteLine("1. Add a record");
                                Console.WriteLine("2. Delete a record");
                                Console.WriteLine("3. Update a record");
                                Console.WriteLine("4. View a table");
                                Console.WriteLine("5. View sort names by ascending");
                                Console.WriteLine("6. Previous menu");
                                Console.WriteLine("Choice: ");

                                var result1 = Console.ReadLine();
                                if (Convert.ToInt32(result1) == 1)
                                {
                                    aAdapter.Add(actors);
                                    goto actorsMenu;
                                }
                                else if (Convert.ToInt32(result1) == 2)
                                {
                                    aAdapter.Delete(actors);
                                    goto actorsMenu;
                                }
                                else if (Convert.ToInt32(result1) == 3)
                                {
                                    aAdapter.Update(actors);
                                    goto actorsMenu;
                                }
                                else if (Convert.ToInt32(result1) == 4)
                                {
                                    aAdapter.View(actors);
                                    Console.WriteLine("\nPress to continue.");
                                    Console.ReadKey();
                                    goto actorsMenu;
                                }
                                else if (Convert.ToInt32(result1) == 5)
                                {
                                    aAdapter.SortAsc(actors);
                                    Console.WriteLine("\nPress to continue.");
                                    Console.ReadKey();
                                    goto actorsMenu;
                                }
                                else if (Convert.ToInt32(result1) == 6)
                                {
                                    goto tableMenu;
                                }
                            }
                            else if (Convert.ToInt32(result) == 4)
                            {
                            fgaMenu:
                                Console.Clear();
                                Console.WriteLine("///FGA:");
                                Console.WriteLine("1. Add a record");
                                Console.WriteLine("2. Delete a record");
                                Console.WriteLine("3. Update a record");
                                Console.WriteLine("4. View a table");
                                Console.WriteLine("5. View sort names by ascending");
                                Console.WriteLine("6. Previous menu");
                                Console.WriteLine("Choice: ");

                                var result1 = Console.ReadLine();
                                if (Convert.ToInt32(result1) == 1)
                                {
                                    sAdapter.Add(fga);
                                    goto fgaMenu;
                                }
                                else if (Convert.ToInt32(result1) == 2)
                                {
                                    sAdapter.Delete(fga);
                                    goto fgaMenu;
                                }
                                else if (Convert.ToInt32(result1) == 3)
                                {
                                    sAdapter.Update(fga);
                                    goto fgaMenu;
                                }
                                else if (Convert.ToInt32(result1) == 4)
                                {
                                    sAdapter.View(fga);
                                    Console.WriteLine("\nPress to continue.");
                                    Console.ReadKey();
                                    goto fgaMenu;
                                }
                                else if (Convert.ToInt32(result1) == 5)
                                {
                                    sAdapter.SortAsc(fga);
                                    Console.WriteLine("\nPress to continue.");
                                    Console.ReadKey();
                                    goto fgaMenu;
                                }
                                else if (Convert.ToInt32(result1) == 6)
                                {
                                    goto tableMenu;
                                }
                            }
                            else if (Convert.ToInt32(result) == 5)
                                break;
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("\nDataSet:\n");
                            fAdapter.View(films);
                            gAdapter.View(genre);
                            aAdapter.View(actors);
                            sAdapter.View(fga);

                            Console.WriteLine("\nPress to continue.");
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            return;
                        }
                }

            } while (true);
        }
    }
}
