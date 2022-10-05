using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;

namespace HW05.Models
{
    public class DBService
    {
        private String ConnString;
        private SqlConnection connection;

        public DBService()
        {
            ConnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public void openConnection()
        {
            try
            {
                connection = new SqlConnection(ConnString);
                connection.Open();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql openConnection() error: " + ex);
            }
        }

        public void closeConnection()
        {
            if (connection != null) connection.Close();
        }

        public List<Book> getAllBooks()
        {
            List<Book> books = new List<Book>();
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand(
                    $"SELECT b.bookid, b.name, a.surname as author, t.name as type, b.pagecount, b.point  " +
                    $"FROM books b,types t, authors a " +
                    $"WHERE b.typeId = t.typeId AND b.authorId = a.authorId;", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            BookID = Convert.ToInt32(reader["bookid"]),
                            Name = reader["name"].ToString(),
                            Author = reader["author"].ToString(),
                            Type = reader["type"].ToString(),
                            PageCount = Convert.ToInt32(reader["pagecount"]),
                            Point = Convert.ToInt32(reader["point"])
                        }); 
                    }
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql getAllBooks() error: " + ex);
            }
            finally
            {
                closeConnection();
            }

            return books;
        }

        public List<Student> getAllStudents()
        {
            List<Student> students = new List<Student>();
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand(
                                    $"SELECT *" +
                                    $"FROM students", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            StudentID = Convert.ToInt32(reader["studentid"]),
                            Name = reader["name"].ToString(),
                            Surname = reader["surname"].ToString(),
                            Class = reader["class"].ToString(),
                            Point = Convert.ToInt32(reader["point"])
                        });
                    }
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql getAllStudents() error: " + ex);
            }
            finally
            {
                closeConnection();
            }
            return students;
        }

        public List<Book> getAllBooksByAuthorId(String id)
        {
            List<Book> books = new List<Book>();
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand(
                    $"SELECT b.bookid, b.name, a.surname as author, t.name as type, b.pagecount, b.point  " +
                    $"FROM books b,types t, authors a " +
                    $"WHERE b.typeId = t.typeId AND b.authorId = a.authorId AND b.authorId = {id};", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            BookID = Convert.ToInt32(reader["bookid"]),
                            Name = reader["name"].ToString(),
                            Author = reader["author"].ToString(),
                            Type = reader["type"].ToString(),
                            PageCount = Convert.ToInt32(reader["pagecount"]),
                            Point = Convert.ToInt32(reader["point"])
                        });
                    }
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql getAllBooksByAuthorId( int id) error: " + ex);
            }
            finally
            {
                closeConnection();
            }

            return books;
        }

        public List<Book> getAllBooksByTypeId(String id)
        {
            List<Book> books = new List<Book>();
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand(
                    $"SELECT b.bookid, b.name, a.surname as author, t.name as type, b.pagecount, b.point  " +
                    $"FROM books b,types t, authors a " +
                    $"WHERE b.typeId = t.typeId AND b.authorId = a.authorId AND b.typeId= {id};", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            BookID = Convert.ToInt32(reader["bookid"]),
                            Name = reader["name"].ToString(),
                            Author = reader["author"].ToString(),
                            Type = reader["type"].ToString(),
                            PageCount = Convert.ToInt32(reader["pagecount"]),
                            Point = Convert.ToInt32(reader["point"])
                        });
                    }
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql getAllBooksByTypeId(int id) error: " + ex);
            }
            finally
            {
                closeConnection();
            }

            return books;
        }

        public List<Book> getAllBooksBySearchText(String searchText)
        {
            List<Book> books = new List<Book>();
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand(
                    $"SELECT b.bookid, b.name, a.surname as author, t.name as type, b.pagecount, b.point  " +
                    $"FROM books b,types t, authors a " +
                    $"WHERE b.typeId = t.typeId AND b.authorId = a.authorId AND b.name LIKE '%{searchText}%';", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            BookID = Convert.ToInt32(reader["bookid"]),
                            Name = reader["name"].ToString(),
                            Author = reader["author"].ToString(),
                            Type = reader["type"].ToString(),
                            PageCount = Convert.ToInt32(reader["pagecount"]),
                            Point = Convert.ToInt32(reader["point"])
                        });
                    }
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql getAllBooksBySearchText(String searchText) error: " + ex);
            }
            finally
            {
                closeConnection();
            }

            return books;
        }

        public List<Book> getAllBooksByAuthorAndTypeId(String authorid, String typeid)
        {
            List<Book> books = new List<Book>();
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand(
                    $"SELECT b.bookid, b.name, a.surname as author, t.name as type, b.pagecount, b.point  " +
                    $"FROM books b,types t, authors a " +
                    $"WHERE b.typeId = t.typeId AND b.authorId = a.authorId AND b.authorid = {authorid} AND b.typeid = {typeid};", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            BookID = Convert.ToInt32(reader["bookid"]),
                            Name = reader["name"].ToString(),
                            Author = reader["author"].ToString(),
                            Type = reader["type"].ToString(),
                            PageCount = Convert.ToInt32(reader["pagecount"]),
                            Point = Convert.ToInt32(reader["point"])
                        });
                    }
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql getAllBooksByAuthorAndTypeId(int authorid, int typeid) error: " + ex);
            }
            finally
            {
                closeConnection();
            }

            return books;
        }

        public List<Book> getAllBooksByAuthorIdAndSearchText(String authorid, String searchText)
        {
            List<Book> books = new List<Book>();
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand(
                    $"SELECT b.bookid, b.name, a.surname as author, t.name as type, b.pagecount, b.point  " +
                    $"FROM books b,types t, authors a " +
                    $"WHERE b.typeId = t.typeId AND b.authorId = a.authorId AND b.authorid = {authorid} AND b.name LIKE '%{searchText}%';", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            BookID = Convert.ToInt32(reader["bookid"]),
                            Name = reader["name"].ToString(),
                            Author = reader["author"].ToString(),
                            Type = reader["type"].ToString(),
                            PageCount = Convert.ToInt32(reader["pagecount"]),
                            Point = Convert.ToInt32(reader["point"])
                        });
                    }
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql getAllBooksByAuthorIdAndSearchText(int authorid, String searchText) error: " + ex);
            }
            finally
            {
                closeConnection();
            }

            return books;
        }

        public List<Book> getAllBooksByTypeIdAndSearchText(String typeid, String searchText)
        {
            List<Book> books = new List<Book>();
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand(
                    $"SELECT b.bookid, b.name, a.surname as author, t.name as type, b.pagecount, b.point " +
                    $"FROM books b,types t, authors a " +
                    $"WHERE b.typeId = t.typeId AND b.authorId = a.authorId AND b.typeId = {typeid} AND b.name LIKE '%{searchText}%';", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            BookID = Convert.ToInt32(reader["bookid"]),
                            Name = reader["name"].ToString(),
                            Author = reader["author"].ToString(),
                            Type = reader["type"].ToString(),
                            PageCount = Convert.ToInt32(reader["pagecount"]),
                            Point = Convert.ToInt32(reader["point"])
                        });
                    }
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql getAllBooksByTypeIdAndSearchText(int typeid, String searchText) error: " + ex);
            }
            finally
            {
                closeConnection();
            }

            return books;
        }

        public List<Book> getAllBooksByTypeAuthorAndSearchText(String authorid, String typeid, String searchText)
        {
            List<Book> books = new List<Book>();
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand(
                    $"SELECT b.bookid, b.name, a.surname as author, t.name as type, b.pagecount, b.point " +
                    $"FROM books b,types t, authors a " +
                    $"WHERE b.typeId = t.typeId AND b.authorId = a.authorId AND b.authorId = {authorid} AND b.typeId = {typeid} AND b.name LIKE '%{searchText}%';", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            BookID = Convert.ToInt32(reader["bookid"]),
                            Name = reader["name"].ToString(),
                            Author = reader["author"].ToString(),
                            Type = reader["type"].ToString(),
                            PageCount = Convert.ToInt32(reader["pagecount"]),
                            Point = Convert.ToInt32(reader["point"])
                        });
                    }
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql getAllBooksByTypeAuthorAndSearchText(int authorid, int typeid, String searchText) error: " + ex);
            }
            finally
            {
                closeConnection();
            }

            return books;
        }

        public List<Student> getStudentsByClass(String Class)
        {
            List<Student> students = new List<Student>();
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand(
                                    $"SELECT * " +
                                    $"FROM students " +
                                    $"WHERE class = '{Class}';", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            StudentID = Convert.ToInt32(reader["studentid"]),
                            Name = reader["name"].ToString(),
                            Surname = reader["surname"].ToString(),
                            Class = reader["class"].ToString(),
                            Point = Convert.ToInt32(reader["point"])
                        });
                    }
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql getStudentsByClass(String Class) error: " + ex);
            }
            finally
            {
                closeConnection();
            }
            return students;
        }

        public List<Student> getStudentsBySearch(String searchtext)
        {
            List<Student> students = new List<Student>();
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand(
                                    $"SELECT * " +
                                    $"FROM students " +
                                    $"WHERE name LIKE '%{searchtext}%';", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            StudentID = Convert.ToInt32(reader["studentid"]),
                            Name = reader["name"].ToString(),
                            Surname = reader["surname"].ToString(),
                            Class = reader["class"].ToString(),
                            Point = Convert.ToInt32(reader["point"])
                        });
                    }
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql getStudentsBySearch(String searchtext) error: " + ex);
            }
            finally
            {
                closeConnection();
            }
            return students;
        }

        public List<Student> getStudentsBySearchAndClass(String Class, String searchtext)
        {
            List<Student> students = new List<Student>();
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand(
                                    $"SELECT * " +
                                    $"FROM students " +
                                    $"WHERE class = '{Class}' AND name LIKE '%{searchtext}%';", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            StudentID = Convert.ToInt32(reader["studentid"]),
                            Name = reader["name"].ToString(),
                            Surname = reader["surname"].ToString(),
                            Class = reader["class"].ToString(),
                            Point = Convert.ToInt32(reader["point"])
                        });
                    }
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql getStudentsBySearchAndClass(String Class, String searchtext) error: " + ex);
            }
            finally
            {
                closeConnection();
            }
            return students;
        }

        public List<Borrow> getBorrowsById(int id)
        {
            List<Borrow> borrows = new List<Borrow>();
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand($"SELECT *,s.name + ' ' + s.surname AS 'fullname' FROM borrows b INNER JOIN students s ON b.studentId = s.studentId WHERE b.bookId = {id} ORDER BY takenDate Desc;", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime? bd = (Convert.IsDBNull(reader["broughtDate"]) ? null : (DateTime?) Convert.ToDateTime(reader["broughtDate"]));
                        
                        borrows.Add(new Borrow
                        {
                            BorrowID = Convert.ToInt32(reader["borrowid"]),
                            TakenDate = Convert.ToDateTime(reader["takendate"]),
                            BroughtDate = bd,
                            FullName = reader["fullname"].ToString()
                        }); 
                    }
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql getBorrowsById(int id) error: " + ex);
            }
            finally
            {
                closeConnection();
            }

            return borrows;
        }

        public List<Type> getAllTypes()
        {
            List<Type> types = new List<Type>();
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand($"SELECT *" +
                    $"FROM types", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        types.Add(new Type
                        {
                            Name = reader["name"].ToString(),
                            TypeID = Convert.ToInt32(reader["typeid"])
                        });
                    }
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql getAllTypes() error: " + ex);
            }
            finally
            {
                closeConnection();
            }

            return types;
        }
        
        public List<Author> getAllAuthors()
        {
            List<Author> authors = new List<Author>();
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand($"SELECT *" +
                    $"FROM authors", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        authors.Add(new Author
                        {
                            Name = reader["name"].ToString(),
                            Surname = reader["surname"].ToString(),
                            AuthorID = Convert.ToInt32(reader["authorid"])
                        });
                    }
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql getAllAuthors() error: " + ex);
            }
            finally
            {
                closeConnection();
            }

            return authors;
        } 

        public bool isAvailable(int id)
        {
            bool available = true;
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand($"SELECT TOP 1 broughtDate FROM borrows WHERE bookId = {id} ORDER BY takenDate DESC;", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Convert.IsDBNull(reader["broughtDate"]))
                        {
                            available = false;
                        }
                    }
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql isAvailable(int id) error: " + ex);
            }
            finally
            {
                closeConnection();
            }

            return available;
        }

        public String getBookNamebyId(int id)
        {
            String name = "";
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand($"SELECT name FROM books WHERE bookId = {id}", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        name = reader["name"].ToString();
                    }
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql getBookNamebyId(int id) error: " + ex);
            }
            finally
            {
                closeConnection();
            }

            return name;
        }

        public List<Class> getAllClasses()
        {
            List<Class> classes = new List<Class>();
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand("SELECT DISTINCT class FROM students ORDER BY class Desc;", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        classes.Add(new Class
                        {
                            ClassName = reader["class"].ToString()
                        });
                    }
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql getAllClasses() error: " + ex);
            }
            finally
            {
                closeConnection();
            }

            return classes;
        }

        public void borrowBook(int studentid, int bookid)
        {
            try
            {
                openConnection();
                var date = DateTime.Now;
                SqlCommand command = new SqlCommand("INSERT INTO borrows (studentId, bookId, takenDate, broughtDate) " +
                                                    $"VALUES ({studentid}, {bookid}, CAST(N'{date}' AS DateTime), NULL)", connection);
                command.ExecuteNonQuery();
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql borrowBook(int studentid, int bookid) error: " + ex);
            }
            finally
            {
                closeConnection();
            }
        }

        public void returnBook(int borrowid)
        {
            try
            {
                openConnection();
                var date = DateTime.Now;
                SqlCommand command = new SqlCommand($"UPDATE borrows SET broughtDate = CAST(N'{date}' AS DateTime) WHERE borrowid = {borrowid};", connection);
                command.ExecuteNonQuery();
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql returnBook(int studentid, int bookid) error: " + ex);
            }
            finally
            {
                closeConnection();
            }
        }

        public StudentBorrowVM getBorrowStudentbyId(int id)
        {
            StudentBorrowVM sbvm = new StudentBorrowVM(); ;
            try
            {
                openConnection();
                SqlCommand command = new SqlCommand($"SELECT TOP 1 studentid, borrowId FROM borrows WHERE bookid = {id} ORDER BY takenDate DESC", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sbvm = new StudentBorrowVM
                        {
                            studentid = Convert.ToInt32(reader["studentid"]),
                            borrowid = Convert.ToInt32(reader["borrowid"])
                        };
                    }
                }
                closeConnection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sql getBorrowStudent(int id) error: " + ex);
            }
            finally
            {
                closeConnection();
            }

            return sbvm;
        }
    }
}