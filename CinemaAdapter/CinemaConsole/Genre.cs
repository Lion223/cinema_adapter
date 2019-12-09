using System;
using System.Data;

namespace CinemaAdapter
{
    public class GAdapter : Genre, ITable
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
            Console.Write("Name: ");
            string name = Console.ReadLine();
            this.addRecord(table, id, name);
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
            Console.Write("Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            this.updRecord(table, id, name);
        }

        public void View(DataTable table)
        {
            Console.WriteLine("\nShowing DB...\n");
            this.viewTable(table);
        }

        public void SortAsc(DataTable table)
        {
            Console.WriteLine("\nDataView - \"Genre\", name by ascending");
            this.srtAsc(table);
        }
    }

    // adaptee
    public class Genre
    {
        public DataTable createTable()
        {
            Console.WriteLine("\nCreating \"Genre\"...\n");
            DataTable genre = new DataTable("Genre");
            DataColumn id_g = new DataColumn("Id");
            id_g.DataType = typeof(int);
            id_g.Unique = true;
            id_g.AllowDBNull = false;
            id_g.Caption = "Id";
            genre.Columns.Add(id_g);

            DataColumn name_g = new DataColumn("Name");
            name_g.DataType = typeof(string);
            name_g.MaxLength = 25;
            name_g.Unique = false;
            name_g.AllowDBNull = false;
            name_g.Caption = "Name";
            genre.Columns.Add(name_g);

            genre.PrimaryKey = new DataColumn[] { id_g };

            return genre;
        }

        public void addRecord(DataTable table, int id, string name)
        {
            table.Rows.Add(id, name);
            table.AcceptChanges();
        }

        public void remRecord(DataTable table, int id)
        {
            DataRow toRem = table.Rows.Find(id);
            table.Rows.Remove(toRem);
            table.AcceptChanges();
        }

        public void updRecord(DataTable table, int id, string name)
        {
            table.LoadDataRow(new object[] { id, name }, false);
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
            view.Sort = "Name ASC";

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
