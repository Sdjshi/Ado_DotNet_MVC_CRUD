using Microsoft.Data.SqlClient;
using Student_Jquery.Models;
using Student_Jquery.Utility;
using System.Data;

namespace Student_Jquery.Data
{
    public class StudentDAL
    {
        string connectionString = ConnectionStrings.CName;

        public IEnumerable<Student> GetAllStudent()
        {
            List<Student> liststudents = new List<Student>();
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SPGetAllStudent", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.Id = Convert.ToInt32(reader["ID"]);
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.Email = reader["Email"].ToString();
                    student.Mobile = reader["Mobile"].ToString();
                    student.Address = reader["Address"].ToString();
                    liststudents.Add(student);
                }
                con.Close();
            }
            return liststudents;
        }

   

        public void AddStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SPAddStudent", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@FirstName", student.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", student.LastName);
                sqlCommand.Parameters.AddWithValue("@Email", student.Email);
                sqlCommand.Parameters.AddWithValue("@Mobile", student.Mobile);
                sqlCommand.Parameters.AddWithValue("@Address", student.Address);
                con.Open();
                sqlCommand.ExecuteNonQuery();
                con.Close() ;
            }
        }

        public void AddOrEditStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SPAddOrEditStudent", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", student.Id);

                sqlCommand.Parameters.AddWithValue("@FirstName", student.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", student.LastName);
                sqlCommand.Parameters.AddWithValue("@Email", student.Email);
                sqlCommand.Parameters.AddWithValue("@Mobile", student.Mobile);
                sqlCommand.Parameters.AddWithValue("@Address", student.Address);
                con.Open();
                sqlCommand.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SPUpdateStudent", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", student.Id);
                sqlCommand.Parameters.AddWithValue("@FirstName", student.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", student.LastName);
                sqlCommand.Parameters.AddWithValue("@Email", student.Email);
                sqlCommand.Parameters.AddWithValue("@Mobile", student.Mobile);
                sqlCommand.Parameters.AddWithValue("@Address", student.Address);
                con.Open();
                sqlCommand.ExecuteNonQuery();
                con.Close();
            }
        }
        public void DeleteStudent(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SPdeleteStudent", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", id);
                
                con.Open();
                sqlCommand.ExecuteNonQuery();
                con.Close();
            }
        }

        public Student GetStudentData(int? id)
        {
            Student student = new Student();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM tbl_Student WHERE Id =@Id";
                SqlCommand sqlCommand = new SqlCommand(query, con);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                   
                    student.Id = Convert.ToInt32(reader["ID"]);
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.Email = reader["Email"].ToString();
                    student.Mobile = reader["Mobile"].ToString();
                    student.Address = reader["Address"].ToString();
                    
                }
                con.Close();
            }
            return student;
        }

    }
}
