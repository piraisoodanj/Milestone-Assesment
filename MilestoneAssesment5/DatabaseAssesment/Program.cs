using System.Data.SqlClient;

namespace DatabaseAssesment
{
    internal class Program
    {

        public static SqlConnection CreateConnection()
        {
            Console.WriteLine("Creating db connection.............");
            SqlConnection con = new
                SqlConnection("Data Source=62212DCB81D85A7;Initial Catalog=SampleDB;Integrated Security=True;");
            Console.WriteLine("DB Connection successfull.");
            return con;
        }

        public static void GetData(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("select * from Users", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine(rdr["id"]+" | " + rdr["Name"].ToString().Trim()+" | "+ rdr["Email"]);
            }
            con.Close();
        }

     
        static void Main(string[] args)
        {
            SqlConnection conn = CreateConnection();
            Console.WriteLine("Loading Data..........");
            Console.WriteLine("Displaying loaded Data.");
            GetData(conn);
        }
    }
}