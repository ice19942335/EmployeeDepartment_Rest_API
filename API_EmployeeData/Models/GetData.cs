using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API_EmployeeData.Models
{
    public class GetData
    {
        private SqlConnection sqlConnection;

        /// <summary>
        /// Constructor
        /// </summary>
        public GetData()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial Catalog=Lesson_7;
                                        Integrated Security=True;
                                        Pooling=False";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }

        /// <summary>
        /// Sendig list of Departments from DB to Client
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Department> GetListDep()
        {
            ObservableCollection<Department> collection = new ObservableCollection<Department>();

            string sql = @"SELECT * FROM departments ORDER BY id";

            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        collection.Add(
                                        new Department()
                                        {
                                            Id = int.Parse(reader["id"].ToString()),
                                            Name = reader["name"].ToString(),
                                            Location = reader["location"].ToString(),
                                            Salary = reader["salary"].ToString()
                                        }
                                      );
                    }
                }
            }

            return collection;
        }

        /// <summary>
        /// Sendig list of Employee from DB to Client
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Employee> GetListEmp()
        {
            ObservableCollection<Employee> collection = new ObservableCollection<Employee>();

            string sql = @"SELECT * FROM employee ORDER BY id";

            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        collection.Add(
                            new Employee()
                            {
                                Id = int.Parse(reader["id"].ToString()),
                                Name = reader["name"].ToString(),
                                Surename = reader["surename"].ToString(),
                                Salary = reader["salary"].ToString(),
                                Deplist = reader["deplist"].ToString()
                            }
                        );
                    }
                }
            }

            return collection;
        }

        /// <summary>
        /// This method is only an example to get Department by ID This method is not USED
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Department GetDepartmentId(int Id)
        {
            string sql = $@"SELECT * FROM departments WHERE id={Id}";
            Department dep = new Department();

            using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dep = new Department()
                        {
                            Id = int.Parse(reader["id"].ToString()),
                            Name = reader["name"].ToString(),
                            Location = reader["location"].ToString(),
                            Salary = reader["salary"].ToString()
                        };
                    }
                }
            }

            return dep;

        }

        /// <summary>
        /// Adding new Department to DB and responsing for client about status of operation
        /// </summary>
        /// <param name="dep"></param>
        /// <returns></returns>
        public bool AddDepartment(Department dep)
        {
            try
            {
                string sqlAdd = $@"INSERT INTO departments 
                                    (name, location, salary) VALUES (
                                      N'{dep.Name}',
                                      N'{dep.Location}',
                                      N'{dep.Salary}'
                                    )";

                using (var command = new SqlCommand(sqlAdd, sqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Deleting Department from DB and responsing for client about status of operation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteDepartment(int id)
        {
            try
            {
                string sqlDel = $"DELETE departments WHERE id={id}";

                using (var command = new SqlCommand(sqlDel, sqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Adding new Employee to DB and responsing for client about status of operation
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public bool AddEmployee(Employee emp)
        {
            try
            {
                string sqlAdd = $@"INSERT INTO employee 
                                    (name, surename, salary, deplist) VALUES (
                                      N'{emp.Name}',
                                      N'{emp.Surename}',
                                      N'{emp.Salary}',
                                      N'{emp.Deplist}'
                                    )";

                using (var command = new SqlCommand(sqlAdd, sqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Deleting Employee from DB and responsing for client about status of operation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteEmployee(int id)
        {
            try
            {
                string sqlDel = $"DELETE employee WHERE id={id}";

                using (var command = new SqlCommand(sqlDel, sqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Adding Department in to the list of departent ON EMPLOYEE and responsing for client about status of operation
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public bool AddDepToEmp(Employee emp)
        {
            try
            {
                string sqlAdd = $@"UPDATE employee SET deplist = '{emp.Deplist}' WHERE id = {emp.Id}";

                using (var command = new SqlCommand(sqlAdd, sqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Deleting Department from list of departent ON EMPLOYEE and responsing for client about status of operation
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public bool DelDepFromEmp(Employee emp)
        {
            try
            {
                string sqlAdd = $@"UPDATE employee SET deplist = '{emp.Deplist}' WHERE id = {emp.Id}";

                using (var command = new SqlCommand(sqlAdd, sqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}