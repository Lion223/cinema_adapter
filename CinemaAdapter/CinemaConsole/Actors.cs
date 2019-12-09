using System;
using System.Data;

namespace CinemaAdapter
{
    public class AAdapter : Actors, ITable
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
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Lastname: ");
            string lastName = Console.ReadLine();
            this.addRecord(table, id, firstName, lastName);
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
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Lastname: ");
            string lastName = Console.ReadLine();
            this.updRecord(table, id, firstName, lastName);
        }

        public void View(DataTable table)
        {
            Console.WriteLine("\nShowing DB...\n");
            this.viewTable(table);
        }

        public void SortAsc(DataTable table)
        {
            Console.WriteLine("\nDataView - \"Actors\", names by ascending");
            this.srtAsc(table);
        }
    }

    // adaptee
    public class Actors
    {
        public DataTable createTable()
        {
            Console.WriteLine("\nCreating \"Actors\"...\n");
            DataTable actors = new DataTable("Actors");
            DataColumn id_a = new DataColumn("Id");
            id_a.DataType = typeof(int);
            id_a.Unique = true;
            id_a.AllowDBNull = false;
            id_a.Caption = "Id";
            actors.Columns.Add(id_a);

            DataColumn firstName = new DataColumn("firstName");
            firstName.DataType = typeof(string);
            firstName.MaxLength = 25;
            firstName.Unique = false;
            firstName.AllowDBNull = false;
            firstName.Caption = "firstName";
            actors.Columns.Add(firstName);

            DataColumn lastName = new DataColumn("lastName");
            lastName.DataType = typeof(string);
            lastName.MaxLength = 25;
            lastName.Unique = false;
            lastName.AllowDBNull = false;
            lastName.Caption = "lastName";
            actors.Columns.Add(lastName);

            actors.PrimaryKey = new DataColumn[] { id_a };

            return actors;
        }

        public void addRecord(DataTable table, int id, string firstName, string lastName)
        {
            table.Rows.Add(id, firstName, lastName);
            table.AcceptChanges();
        }

        public void remRecord(DataTable table, int id)
        {
            DataRow toRem = table.Rows.Find(id);
            table.Rows.Remove(toRem);
            table.AcceptChanges();
        }

        public void updRecord(DataTable table, int id, string firstName, string lastName)
        {
            table.LoadDataRow(new object[] { id, firstName, lastName }, false);
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
            view.Sort = "firstName ASC, lastName ASC";

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
