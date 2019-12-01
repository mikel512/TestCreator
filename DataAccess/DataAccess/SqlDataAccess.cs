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

        #region Inserts
        // =============== //
        // === INSERTS === //
        // =============== //

        public void CreateClass(string nClassName, string nClassSubject, string nInstructorID)
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
        #endregion

        #region Updates
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
        #endregion

        #region Queries
        // =============== //
        // === QUERIES === //
        // =============== //
        public List<ClassModel> GetInstructorClassrooms(string instructorId)
        {
            var classrooms = new List<ClassModel>();

            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Get_All_Instructor_Classrooms", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter instructorID = new SqlParameter("@instructor_id", instructorId);

                command.Parameters.Add(instructorID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ClassModel classModel = new ClassModel()
                        {
                            classID = (int)reader[0],
                            className = (string)reader[1],
                            classSubject = (string)reader[2]
                        };

                        classrooms.Add(classModel);
                    }
                }
            }
            return classrooms;
        }

        public ClassModel GetClassroomById(int classId)
        {
            ClassModel c = new ClassModel();

            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Get_Classroom_By_ID", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter instructorID = new SqlParameter("@class_id", classId);


                command.Parameters.Add(instructorID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        c.classID = (int)reader[0];
                        c.className = (string)reader[1];
                        c.classSubject = (string)reader[2];
                        c.instructorId = (string)reader[3];
                        //c.tests = GetTestByClassId(classId);
                    }
                }
            }
            return c;
        }

        public List<ExamModel> GetTestByClassId(int classId)
        {
            List<ExamModel> exams = new List<ExamModel>();

            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Get_Test_By_Class_ID", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter instructorID = new SqlParameter("@class_id", classId);

                command.Parameters.Add(instructorID);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ExamModel e = new ExamModel
                        {
                            testID = (int)reader[0],
                            testTitle = (string)reader[1],
                            classID = (int)reader[2]
                        };
                        exams.Add(e);

                    }
                }
            }
            return exams;
        }

        public List<ExamModel> GetInstructorExams(int intructorID)
        {
            List<ExamModel> tests = new List<ExamModel>();

            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Get_Instructor_Test_List", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var t = new ExamModel();

                        t.testID = (int)reader[0];
                        t.classID = (int)reader[1];
                        t.testTitle = reader[2].ToString();
                        t.questions = GetTestQuestionList(t.testID);

                        tests.Add(t);
                    }
                }
            }

            return tests;
        }
        public List<QuestionModel> GetTestQuestionList(int testID)
        {
            List<QuestionModel> questions = new List<QuestionModel>();

            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Get_Test_Question_List", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        QuestionModel q = new QuestionModel();

                        q.questionID = (int)reader[0];
                        q.questionContent = reader[1].ToString();
                        q.isLongAnswer = (bool)reader[2];
                        q.answers = GetQuestionAnswersList(q.questionID);

                        questions.Add(q);
                    }
                }
            }

            return questions;
        }
        public List<AnswerModel> GetQuestionAnswersList(int questionID)
        {
            List<AnswerModel> answers = new List<AnswerModel>();

            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("Get_Question_Answer_List", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var a = new AnswerModel();

                        a.answerID = (int)reader[0];
                        a.isLongAnswer = (bool)reader[1];
                        a.answerContent = reader[2].ToString();

                        answers.Add(a);
                    }
                }
            }

            return answers;
        }
        #endregion

    }
}
