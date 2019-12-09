using System;
using System.Data;

namespace CinemaAdapter
{
    public class SAdapter : FGA, ITable
    {
        public DataTable Create()
        {
            return this.createTable();
        }

        public void Add(DataTable table)
        {
            Console.WriteLine("\nAdding a new record...\n");
            Console.Write("Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Film Id: ");
            int film_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Genre Id: ");
            int genre_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Actor Id: ");
            int actor_id = Convert.ToInt32(Console.ReadLine());
            this.addRecord(table, id, film_id, genre_id, actor_id);
        }

        public void Delete(DataTable table)
        {
            Console.WriteLine("\nDeleting a record...\n");
            Console.Write("Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            this.remRecord(table, id);
        }

        public void Update(DataTable table)
        {
            Console.WriteLine("\nUpdating a record...\n");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Film Id: ");
            int film_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Genre Id: ");
            int genre_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Actor Id: ");
            int actor_id = Convert.ToInt32(Console.ReadLine());
            this.updRecord(table, id, film_id, genre_id, actor_id);
        }

        public void View(DataTable table)
        {
            Console.WriteLine("\nShowing DB...\n");
            this.viewTable(table);
        }

        public void SortAsc(DataTable table)
        {
            Console.WriteLine("\nDataView - \"FGA\", film id by ascending");
            this.srtAsc(table);
        }
    }

    // adaptee
    public class FGA
    {
        public DataTable createTable()
        {
            Console.WriteLine("\nCreating \"FGA\"...\n");
            DataTable fga = new DataTable("FGA");
            DataColumn id_fga = new DataColumn("Id");
            id_fga.DataType = typeof(int);
            id_fga.Unique = true;
            id_fga.AllowDBNull = false;
            id_fga.Caption = "Id";
            fga.Columns.Add(id_fga);

            DataColumn id_f = new DataColumn("Film_Id");
            id_f.DataType = typeof(int);
            id_f.Unique = true;
            id_f.AllowDBNull = false;
            id_f.Caption = "Film_Id";
            fga.Columns.Add(id_f);

            DataColumn id_fg = new DataColumn("Genre_Id");
            id_fg.DataType = typeof(int);
            id_fg.Unique = true;
            id_fg.AllowDBNull = false;
            id_fg.Caption = "Genre_Id";
            fga.Columns.Add(id_fg);

            DataColumn id_fa = new DataColumn("Actor_Id");
            id_fa.DataType = typeof(int);
            id_fa.Unique = true;
            id_fa.AllowDBNull = false;
            id_fa.Caption = "Actor_Id";
            fga.Columns.Add(id_fa);

            fga.PrimaryKey = new DataColumn[] { id_f, id_fg, id_fa };

            return fga;
        }

        public void addRecord(DataTable table, int id, int film_id, int genre_id, int actor_id)
        {
            table.Rows.Add(id, film_id, genre_id, actor_id);
            table.AcceptChanges();
        }

        public void remRecord(DataTable table, int id)
        {
            DataRow toRem = table.Rows.Find(id);
            table.Rows.Remove(toRem);
            table.AcceptChanges();
        }

        public void updRecord(DataTable table, int id, int film_id, int genre_id, int actor_id)
        {
            table.LoadDataRow(new object[] { id, film_id, genre_id, actor_id }, false);
            table.AcceptChanges();
        }

        public void viewTable(DataTable table)
        {
            Console.WriteLine(table.TableName + " ");
            foreach (DataRow x in table.Rows)
            {
                foreach (DataColumn y in table.Columns)
                {
                    Console.Write(x[y] + " ");
                }
                Console.WriteLine();
            }
        }

        public void srtAsc(DataTable table)
        {
            DataView view = new DataView(table);
            view.Sort = "Film_Id ASC";

            foreach (DataRowView dr in view)
            {
                foreach (DataColumn dc in view.Table.Columns)
                {
                    Console.Write(dr.Row[dc] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
