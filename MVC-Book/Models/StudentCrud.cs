using System.Data.SqlClient;

namespace MVC_Book.Models
{
    public class StudentCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public StudentCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(configuration.GetConnectionString("defaultConnection"));
        }
        public IEnumerable<Student> GetAllStudents()
        {
            List<Student> list = new List<Student>();
            string qry = "select * from Student where isActive=1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student b = new Student();
                    b.RollId = Convert.ToInt32(dr["rollId"]);
                    b.Name = dr["name"].ToString();
                    b.Branch = dr["branch"].ToString();
                    
                    list.Add(b);

                }
            }
            con.Close();
            return list;
        }
        public Student GetStudentById(int rollId)
        {
            Student b = new Student();
            string qry = "select * from Student where rollId=@rollId";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@rollId", rollId);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    b.RollId = Convert.ToInt32(dr["rollId"]);
                    b.Name = dr["name"].ToString();
                    b.Branch = dr["branch"].ToString();
                }
            }
            con.Close();
            return b;
        }
        public int AddStudent(Student student)
        {
            student.isActive = 1;
            int result = 0;
            string qry = "insert into Student values(@name,@branch,@isActive)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@branch", student.Branch);
            cmd.Parameters.AddWithValue("@isActive", student.isActive);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;


        }
        public int UpdateStudent(Student student)
        {
            student.isActive = 1;
            int result = 0;
            string qry = "update Student set name=@name,branch=@branch,isActive=@isActive where rollId=@rollId";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@branch", student.Branch);
            cmd.Parameters.AddWithValue("@isActive", student.isActive);
            cmd.Parameters.AddWithValue("@rollId", student.RollId);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }


        public int DeleteStudent(int id)
        {
            int result = 0;
            string qry = "update Student set isActive=0 where rollId=@rollId";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@rollId", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
