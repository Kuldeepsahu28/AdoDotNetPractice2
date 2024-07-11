using System;
using System.Data.SqlClient;

namespace AdoDotNetPractice2
{
    class Program
    {
        
      
        // This is Main method - starting point of project.
        // this code is written by Bablusahu27.
        // 3rd line written by bs27.
        

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Get();

            Console.WriteLine("-------------------------------------------------------------");
            //Create();

            //Update();

            Delete();
            Console.WriteLine("-------------------------------------------------------------");
            Get();
            Console.ReadLine();
        }

        public static void Get()
        {

             //string cs = "Data Source=DESKTOP-9CUOKP8; Initial Catalog=ADO_Db;Integrated Security=true";
            string connectionString = "Data Source=DESKTOP-TG03GDL\\MSSQLSERVER01; Initial Catalog=BabluDb; Integrated Security=true";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SpGetUser", con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
           
            while (dr.Read())
            {
                Console.WriteLine("User Id : " + dr[0] + ", Name : " + dr[1] + ", Age : "+dr[2]+", Email : "+dr[3]+", Mobile : "+dr[4]);
             
            }
            con.Close();

          
        }

        public static int GetLastId()
        {

            //string cs = "Data Source=DESKTOP-9CUOKP8; Initial Catalog=ADO_Db;Integrated Security=true";
            string connectionString = "Data Source=DESKTOP-TG03GDL\\MSSQLSERVER01; Initial Catalog=BabluDb; Integrated Security=true";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SpGetUser", con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int lastId = 0;
            while (dr.Read())
            {
                //Console.WriteLine("User Id : " + dr[0] + ", Name : " + dr[1] + ", Age : " + dr[2] + ", Email : " + dr[3] + ", Mobile : " + dr[4]);
                lastId = Convert.ToInt32(dr[0]);
            }
            con.Close();

            return lastId;
        }

        public static void Create()
        {

            int userId = GetLastId();
            userId = userId + 1;
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine(); 
            Console.WriteLine("Enter Age");
            string age = Console.ReadLine();
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Mobile");
            long mobile =Convert.ToInt64(Console.ReadLine());

            string connectionString = "Data Source=DESKTOP-TG03GDL\\MSSQLSERVER01; Initial Catalog=BabluDb; Integrated Security=true";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SpAddUser", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserId",userId);
            cmd.Parameters.AddWithValue("@UserName", name);
            cmd.Parameters.AddWithValue("@Age", age);      
            cmd.Parameters.AddWithValue("@Email", email);  
            cmd.Parameters.AddWithValue("@Mobile", mobile);

            con.Open();
            int status = cmd.ExecuteNonQuery();

            if (status!=0)
            {
                Console.WriteLine("Data Inserted!!");
            }
            con.Close();
        }


        public static void Update()
        {

            Console.WriteLine("Enter User Id");
            int userId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Age");
            int age = Convert.ToInt32(Console.ReadLine());
            string connectionString = "Data Source=DESKTOP-TG03GDL\\MSSQLSERVER01; Initial Catalog=BabluDb; Integrated Security=true";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SpUpdateUser", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@Age", age);

            con.Open();
            int status = cmd.ExecuteNonQuery();

            if (status != 0)
            {
                Console.WriteLine("Data Updated!!");
            }
            con.Close();
        }

        public static void Delete()
        {
            Console.WriteLine("Enter User Id");
            int userId = Convert.ToInt32(Console.ReadLine());


            string connectionString = "Data Source=DESKTOP-TG03GDL\\MSSQLSERVER01; Initial Catalog=BabluDb; Integrated Security=true";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SP_DELETE_User", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@UserId", userId);


            con.Open();
            int status = cmd.ExecuteNonQuery();

            if (status != 0)
            {
                Console.WriteLine("Data Deleted!!");
            }
            con.Close();
        }
    }
}
