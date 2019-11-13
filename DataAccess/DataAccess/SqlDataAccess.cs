using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using DataLibrary.Models;



namespace DataLibrary.DataAccess
{
    public class SqlDataAccess
    {
        public string GetConnectionString()
        {
            AppConfiguration conn = new AppConfiguration();
            return conn.ConnectionString;
        }

        // =============== //
        // === INSERTS === //
        // =============== //
        public void CreateStudent(string first, string last)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("create_student", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter fName = new SqlParameter("@first", first);
                SqlParameter lName = new SqlParameter("@last", last);

                command.Parameters.Add(fName);
                command.Parameters.Add(lName);

                command.ExecuteNonQuery();
            }
        }
        public void CreateInstructor(string first, string last)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("create_instructor", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter fName = new SqlParameter("@first", first);
                SqlParameter lName = new SqlParameter("@last", last);

                command.Parameters.Add(fName);
                command.Parameters.Add(lName);

                command.ExecuteNonQuery();
            }
        }
        public void CreateClass(string nClassName, string nClassSubject, int nInstructorID)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("create_class", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter className = new SqlParameter("@className", nClassName);
                SqlParameter classSubject = new SqlParameter("@classSubject", nClassSubject);
                SqlParameter instructorID = new SqlParameter("@instructor", nInstructorID);

                command.Parameters.Add(instructorID);
                command.Parameters.Add(className);
                command.Parameters.Add(classSubject);

                command.ExecuteNonQuery();
            }
        }
        public void CreateTest(string nTestTitle, int nClassID)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("create_test", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter testTitle = new SqlParameter("@testTitle", nTestTitle);
                SqlParameter classID = new SqlParameter("@classID", nClassID);

                command.Parameters.Add(testTitle);
                command.Parameters.Add(classID);

                command.ExecuteNonQuery();
            }
        }
        public void CreateQuestion(string nContent, bool nIsLongAnswer, int nTestID)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("create_question", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter content = new SqlParameter("@questionContent", nContent);
                SqlParameter isLongAnswer = new SqlParameter("@isLongAnswer", nIsLongAnswer);
                SqlParameter testID = new SqlParameter("@testID", nTestID);

                command.Parameters.Add(content);
                command.Parameters.Add(isLongAnswer);
                command.Parameters.Add(testID);

                command.ExecuteNonQuery();
            }
        }
        public void CreateAnswer(bool nIsLongAnswer, string nContent, int nQuestionID)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("create_answer", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter content = new SqlParameter("@answerContent", nContent);
                SqlParameter isLongAnswer = new SqlParameter("@isLongAnswer", nIsLongAnswer);
                SqlParameter testID = new SqlParameter("@questionID", nQuestionID);

                command.Parameters.Add(content);
                command.Parameters.Add(isLongAnswer);
                command.Parameters.Add(testID);

                command.ExecuteNonQuery();
            }
        }
        public void AddStudentToClass(int nStudentID, int nClassID)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("create_student_class", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter studentID = new SqlParameter("@studentID", nStudentID);
                SqlParameter classID = new SqlParameter("@classID", nClassID);

                command.Parameters.Add(studentID);
                command.Parameters.Add(classID);

                command.ExecuteNonQuery();
            }
        }
        public void AddScoreToTest(decimal nPercent, int nNumberCorrect, int nStudentID, int ntestID)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("create_test_score", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter percent = new SqlParameter("@score_percent", nPercent);
                SqlParameter correct = new SqlParameter("@number_correct", nNumberCorrect);
                SqlParameter studentID = new SqlParameter("@student_id", nStudentID);
                SqlParameter testID = new SqlParameter("@test_id", ntestID);

                command.Parameters.Add(percent);
                command.Parameters.Add(correct);
                command.Parameters.Add(studentID);
                command.Parameters.Add(testID);

                command.ExecuteNonQuery();
            }
        }

        // =============== //
        // === UPDATES === //
        // =============== //
        public void UpdateStudent(int nStudentID, string first, string last)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("update_student", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter studentID = new SqlParameter("@studentID", nStudentID);
                SqlParameter fName = new SqlParameter("@first", first);
                SqlParameter lName = new SqlParameter("@last", last);

                command.Parameters.Add(studentID);
                command.Parameters.Add(fName);
                command.Parameters.Add(lName);

                command.ExecuteNonQuery();
            }
        }
        public void UpdateInstructor(int nInstructorID, string first, string last)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("update_instructor", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter instructorID = new SqlParameter("@instructorID", nInstructorID);
                SqlParameter fName = new SqlParameter("@first", first);
                SqlParameter lName = new SqlParameter("@last", last);

                command.Parameters.Add(instructorID);
                command.Parameters.Add(fName);
                command.Parameters.Add(lName);

                command.ExecuteNonQuery();
            }
        }
        public void UpdateClass(int nClassID, string nClassName, string nClassSubject, int nInstructorID)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("update_class", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter classID = new SqlParameter("@classID", nClassID);
                SqlParameter className = new SqlParameter("@className", nClassName);
                SqlParameter classSubject = new SqlParameter("@classSubject", nClassSubject);
                SqlParameter instructorID = new SqlParameter("@instructorID", nInstructorID);

                command.Parameters.Add(classID);
                command.Parameters.Add(instructorID);
                command.Parameters.Add(className);
                command.Parameters.Add(classSubject);

                command.ExecuteNonQuery();
            }
        }
        public void UpdateTest(int nTestID, string nTestTitle, int nClassID)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("update_test", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter testID = new SqlParameter("@testID", nTestID);
                SqlParameter testTitle = new SqlParameter("@testTitle", nTestTitle);
                SqlParameter classID = new SqlParameter("@classID", nClassID);

                command.Parameters.Add(testID);
                command.Parameters.Add(testTitle);
                command.Parameters.Add(classID);

                command.ExecuteNonQuery();
            }
        }
        public void UpdateQuestion(int nQuestionID, string nContent, bool nIsLongAnswer, int nTestID)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("update_question", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter questionID = new SqlParameter("@questionID", nQuestionID);
                SqlParameter content = new SqlParameter("@questionContent", nContent);
                SqlParameter isLongAnswer = new SqlParameter("@isLongAnswer", nIsLongAnswer);
                SqlParameter testID = new SqlParameter("@testID", nTestID);

                command.Parameters.Add(questionID);
                command.Parameters.Add(content);
                command.Parameters.Add(isLongAnswer);
                command.Parameters.Add(testID);

                command.ExecuteNonQuery();
            }
        }
        public void UpdateAnswer(int nAnswerID, bool nIsLongAnswer, string nContent, int nQuestionID)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("update_answer", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter answerID = new SqlParameter("@answerID", nAnswerID);
                SqlParameter content = new SqlParameter("@answerContent", nContent);
                SqlParameter isLongAnswer = new SqlParameter("@isLongAnswer", nIsLongAnswer);
                SqlParameter testID = new SqlParameter("@questionID", nQuestionID);

                command.Parameters.Add(answerID);
                command.Parameters.Add(content);
                command.Parameters.Add(isLongAnswer);
                command.Parameters.Add(testID);

                command.ExecuteNonQuery();
            }
        }
        




        // =============== //
        // === QUERIES === //
        // =============== //
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Get_Student_List", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        Student s = new Student();

                        s.studentID = (int)reader[0];
                        s.lName = reader[1].ToString();
                        s.fName = reader[2].ToString();
                        s.scores = null;
                        s.classes = null;

                        students.Add(s);
                    }
                }
            }

            return students;
        }
        public List<Student> GetInstructorClasses(int intructorID)
        {
            List<Student> classes = new List<Student>();
            /*
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Get_Class_List", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Student s = new Student();

                        s.studentID = (int)reader[0];
                        s.lName = reader[1].ToString();
                        s.fName = reader[2].ToString();
                        s.scores = null;
                        s.classes = null;

                        students.Add(s);
                    }
                }
            }
            */
            return classes;
        }




    }
}
