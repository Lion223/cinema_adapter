using System;
using System.Data;

namespace CinemaAdapter
{
    public class FAdapter : Films, ITable
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
            Console.Write("Year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            this.addRecord(table, id, name, year);
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
            Console.Write("Year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            this.updRecord(table, id, name, year);
        }

        public void View(DataTable table)
        {
            Console.WriteLine("\nShowing DB...\n");
            this.viewTable(table);
        }

        public void SortAsc(DataTable table)
        {
            Console.WriteLine("\nDataView - \"Films\", name by ascending");
            this.srtAsc(table);
        }
    }

    // adaptee
    public class Films
    {
        public DataTable createTable()
        {
            Console.WriteLine("\nCreating \"Films\"...\n");
            DataTable films = new DataTable("Films");
            DataColumn id = new DataColumn("Id");
            id.DataType = typeof(int);
            id.Unique = true;
            id.AllowDBNull = false;
            id.Caption = "Id";
            films.Columns.Add(id);

            DataColumn name = new DataColumn("Name");
            name.DataType = typeof(string);
            name.MaxLength = 25;
            name.Unique = false;
            name.AllowDBNull = false;
            name.Caption = "Name";
            films.Columns.Add(name);

            DataColumn year = new DataColumn("Year");
            year.DataType = typeof(int);
            year.Unique = false;
            year.AllowDBNull = true;
            year.Caption = "Year";
            films.Columns.Add(year);

            films.PrimaryKey = new DataColumn[] { id };

            return films;
        }

        public void addRecord(DataTable table, int id, string name, int year)
        {
            table.Rows.Add(id, name, year);
            table.AcceptChanges();
        }

        public void remRecord(DataTable table, int id)
        {
            DataRow toRem = table.Rows.Find(id);
            table.Rows.Remove(toRem);
            table.AcceptChanges();
        }

        public void updRecord(DataTable table, int id, string name, int year)
        {
            table.LoadDataRow(new object[] { id, name, year }, false);
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
