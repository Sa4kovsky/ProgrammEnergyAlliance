using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Contracts.Objects;
using Npgsql;
using NpgsqlTypes;

namespace Contracts
{
    class Connects
    {
        public static string connStr;
        public void ConnectsSQL(string connectingPath)
        {
            System.IO.StreamReader file =
               new System.IO.StreamReader(connectingPath);
            connStr = file.ReadLine();

            using (var conn = new NpgsqlConnection(connStr))
            {
                try
                {
                    //пробуем подключится
                    conn.Open();
                }
                catch (NpgsqlException se)
                {
                    MessageBox.Show("Ошибка подключения:{0}", se.Message);
                    return;
                }
                MessageBox.Show("Соедение успешно произведено");
                conn.Close();
                conn.Dispose();
            }
        }

        #region Executors

        public List<Executor> Executors = new List<Executor>();

        public void ShowFieldsExecutors()
        {  
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
                //Выводим значение на экран
                using (NpgsqlCommand cmd = new NpgsqlCommand("Select * From Executor", conns))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Executors.Add(new Executor(Convert.ToInt32(reader[0]), reader[1].ToString(),
                                reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(),
                                reader[6].ToString(), reader[7].ToString()));
                        }
                    }
                }
                conns.Close();
        }

        public void InsertToTableExecutors(string nameExecutor, string nameExecutors, string positionExecutor, string positionExecutors, string actingOnTheBasis, string number, string date)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Insert Into Executor" +
                "(nameExecutor,nameExecutors, positionExecutor, positionExecutors, actingOnTheBasis, number, date) Values (@nameExecutor,@nameExecutors, @positionExecutor, @positionExecutors, @actingOnTheBasis, @number, @date)", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@nameExecutor";
                //задаем значение параметра
                param.Value = nameExecutor;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Text;
                //передаем параметр объекту класса SqlCommand
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@nameExecutors";
                param.Value = nameExecutors;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@positionExecutor";
                param.Value = positionExecutor;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@positionExecutors";
                param.Value = positionExecutors;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@actingOnTheBasis";
                param.Value = actingOnTheBasis;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@number";
                param.Value = number;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@date";
                param.Value = date;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка, при выполнении запроса на добавление записи");
                }
            }


        }

        public void DeleteFromTableExecutors(int id)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Delete From Executor" +
                 " where idExecutor = @idExecutor", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@idExecutor";
                //задаем значение параметра
                param.Value = id;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                //передаем параметр объекту класса SqlCommand
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка, при выполнении запроса на удаление записи");
                    MessageBox.Show("Возможно запись уже удалена");
                }
            }

        }

        public void UpdateFromTableExecutors(int id, string nameExecutor, string nameExecutors, string positionExecutor, string positionExecutors, string actingOnTheBasis, string number, string date)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Update Executor " +
                "Set (nameExecutor,nameExecutors, positionExecutor, positionExecutors, actingOnTheBasis, number, date) = (@nameExecutor, @nameExecutors, @positionExecutor, @positionExecutors, @actingOnTheBasis, @number, @date) " +
                " where idExecutor = @idExecutor", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idExecutor";
                param.Value = id;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@nameExecutor";
                param.Value = nameExecutor;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@nameExecutors";
                param.Value = nameExecutors;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@positionExecutor";
                param.Value = positionExecutor;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@positionExecutors";
                param.Value = positionExecutors;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@actingOnTheBasis";
                param.Value = actingOnTheBasis;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@number";
                param.Value = number;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@date";
                param.Value = date;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка, при выполнении запроса на изменение записи(ей)");
                    }
                }
            }
        }
#endregion

        #region Таблиц Works

        public List<Works> Works = new List<Works>();
        public void ShowFieldsWorks()
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("Select * From Works", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Works.Add(new Works(Convert.ToInt32(reader[0]), reader[1].ToString()));
                    }
                }
            }
            conns.Close();
        }

        public void InsertToTableWorks(string worksType)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Insert Into Works" +
                "(worksType) Values (@worksType)", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@worksType";
                //задаем значение параметра
                param.Value = worksType;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Text;
                //передаем параметр объекту класса SqlCommand
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка, при выполнении запроса на добавление записи");
                }
            }
        }

        public void DeleteFromTableWorks(int id)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Delete From Works" +
                 " where idWorks = @idWorks", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@idWorks";
                //задаем значение параметра
                param.Value = id;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                //передаем параметр объекту класса SqlCommand
                cmd.Parameters.Add(param);
                Console.WriteLine("Удаляем запись");
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка, при выполнении запроса на удаление записи");
                    MessageBox.Show("Возможно запись уже удалена");
                }
            }

        }

        public void UpdateFromTableWorks(int id, string worksType)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Update Works" +
                    " Set worksType = @worksType where idWorks = @idWorks", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@worksType";
                param.Value = worksType;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idWorks";
                param.Value = id;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);

                Console.WriteLine("Изменяем запись(и)");
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка, при выполнении запроса на изменение записи(ей)");
                    }
                }
            }
        }
        #endregion

        #region NameCustomer

        public List<NameCustomers> NameCustomerses = new List<NameCustomers>();

        public void ShowFieldsNameCustomer()
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT NameCustomer.idNameCustomer, Customer.nameInstitution, NameCustomer.nameNameCustomer, NameCustomer.nameNameCustomers, NameCustomer.positionNameCustomer, NameCustomer.positionNameCustomers, NameCustomer.actingOnTheBasis, NameCustomer.number, NameCustomer.date FROM NameCustomer INNER JOIN Customer ON Customer.idCustomer = NameCustomer.idCustomer", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        NameCustomerses.Add(new NameCustomers(Convert.ToInt32(reader[0]), reader[1].ToString(),
                            reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(),
                            reader[6].ToString(), reader[7].ToString(), reader[8].ToString()));
                    }
                }
            }
            conns.Close();
        }

        public void InsertToTableNameCustomer(int idCustomer, string nameCustomer, string nameCustomers, string positionCustomer, string positionCustomers, string actingOnTheBasis, string number, string date)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Insert Into NameCustomer" +
                "(idCustomer,nameNameCustomer, nameNameCustomers, positionNameCustomer, positionNameCustomers, actingOnTheBasis, number,date) Values (@idCustomer,@nameNameCustomer, @nameNameCustomers, @positionNameCustomer, @positionNameCustomers, @actingOnTheBasis, @number, @date)", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idCustomer";
                param.Value = idCustomer;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@nameNameCustomer";
                //задаем значение параметра
                param.Value = nameCustomer;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Text;
                //передаем параметр объекту класса SqlCommand
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@nameNameCustomers";
                param.Value = nameCustomers;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@positionNameCustomer";
                param.Value = positionCustomer;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@positionNameCustomers";
                param.Value = positionCustomers;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@actingOnTheBasis";
                param.Value = actingOnTheBasis;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@number";
                param.Value = number;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@date";
                param.Value = date;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка, при выполнении запроса на добавление записи");
                }
            }


        }

        public void DeleteFromTableNameCustomer(int id)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Delete From NameCustomer" +
                 " where idNameCustomer = @idNameCustomer", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@idNameCustomer";
                //задаем значение параметра
                param.Value = id;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                //передаем параметр объекту класса SqlCommand
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка, при выполнении запроса на удаление записи");
                    MessageBox.Show("Возможно запись уже удалена");
                }
            }

        }

        public void UpdateFromTableNameCustomer(int id, int idCustomer, string nameCustomer, string nameCustomers, string positionCustomer, string positionCustomers, string actingOnTheBasis, string number, string date)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Update NameCustomer " +
                "Set (idCustomer,nameNameCustomer, nameNameCustomers, positionNameCustomer, positionNameCustomers, actingOnTheBasis, number,date) = (@idCustomer,@nameNameCustomer, @nameNameCustomers, @positionNameCustomer, @positionNameCustomers, @actingOnTheBasis, @number, @date) " +
                " where idNameCustomer = @idNameCustomer", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idCustomer";
                param.Value = idCustomer;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@nameNameCustomer";
                //задаем значение параметра
                param.Value = nameCustomer;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Text;
                //передаем параметр объекту класса SqlCommand
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@nameNameCustomers";
                param.Value = nameCustomers;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@positionNameCustomer";
                param.Value = positionCustomer;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@positionNameCustomers";
                param.Value = positionCustomers;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@actingOnTheBasis";
                param.Value = actingOnTheBasis;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@number";
                param.Value = number;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@date";
                param.Value = date;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idNameCustomer";
                param.Value = id;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка, при выполнении запроса на изменение записи(ей)");
                    }
                }
            }
        }
        #endregion

        #region Таблиц Bank

        public List<Banks> Bankses =new List<Banks>();
        public void ShowFieldsBank()
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("Select * From Bank", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Bankses.Add(new Banks(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString()));
                    }
                }
            }
            conns.Close();
        }

        public void ShowFieldsBankSearch(string address)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Bank WHERE nameBank like '%" + address + "%'", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Bankses.Add(new Banks(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString()));
                    }
                }
            }
            conns.Close();
        }

        public void InsertToTableBank(string nameBank, string address)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Insert Into Bank" +
                "(nameBank,address) Values (@nameBank,@address)", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@nameBank";
                //задаем значение параметра
                param.Value = nameBank;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Text;
                //передаем параметр объекту класса SqlCommand
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@address";
                //задаем значение параметра
                param.Value = address;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Text;
                //передаем параметр объекту класса SqlCommand
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка, при выполнении запроса на добавление записи");
                }
            }


        }

        public void DeleteFromTableBank(int id)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Delete From Bank" +
                 " where idBank = @idBank", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@idBank";
                //задаем значение параметра
                param.Value = id;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                //передаем параметр объекту класса SqlCommand
                cmd.Parameters.Add(param);
                Console.WriteLine("Удаляем запись");
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка, при выполнении запроса на удаление записи");
                    MessageBox.Show("Возможно запись уже удалена");
                }
            }

        }

        public void UpdateFromTableBank(int id, string nameBank, string address)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Update Bank" +
                    " Set (nameBank,address) = (@nameBank,@address)" +
                    " where idBank = @idBank", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@nameBank";
                param.Value = nameBank;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@address";
                //задаем значение параметра
                param.Value = address;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Text;
                //передаем параметр объекту класса SqlCommand
                cmd.Parameters.Add(param); 
                param = new NpgsqlParameter();
                param.ParameterName = "@idBank";
                param.Value = id;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                Console.WriteLine("Изменяем запись(и)");
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка, при выполнении запроса на изменение записи(ей)");
                    }
                }
            }
        }
        #endregion

        #region Select
        public List<NameCustomerSelect> NameCustomerSelectses = new List<NameCustomerSelect>();

        public void ShowFieldsNameCustomerSelect(int name)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT idNameCustomer, nameNameCustomer,positionNameCustomer FROM NameCustomer " +
               "WHERE idCustomer = " + name , conns))
            { 
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        NameCustomerSelectses.Add(new NameCustomerSelect(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString()));
                    }
                }
            }
            conns.Close();
        }
#endregion

        #region Customers
        public List<Customers> Customerses = new List<Customers>();

        public void ShowFieldsCustomerses()
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT Customer.idCustomer, Customer.nameInstitution, Customer.LegalAddress, Customer.addressWork, Customer.checkingAccount, Bank.nameBank,Customer.unp,Customer.okpo "+
                "FROM Customer INNER JOIN Bank ON Bank.idBank = Customer.idBank", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customerses.Add(new Customers(Convert.ToInt32(reader[0]), reader[1].ToString(), 
                            reader[2].ToString(), reader[3].ToString(), reader[4].ToString(),
                            reader[5].ToString(), reader[6].ToString(), reader[7].ToString()));
                    }
                }
            }
            conns.Close();
        }

        public void ShowFieldsCustomersesSerch(string name)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Customer WHERE nameInstitution like '%" + name + "%'", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customerses.Add(new Customers(Convert.ToInt32(reader[0]), reader[1].ToString(),
                            reader[2].ToString(), reader[3].ToString(), reader[4].ToString(),
                            reader[5].ToString(), reader[6].ToString(), reader[7].ToString()));
                    }
                }
            }
            conns.Close();
        }

        public void InsertToTableCustomerses(string nameInstitution, string LegalAddress, string addressWork, string checkingAccount, int idBank, string unp, string okpo)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Insert Into Customer (nameInstitution, LegalAddress, addressWork, checkingAccount, idBank,unp,okpo) Values (@nameInstitution, @LegalAddress, @addressWork, @checkingAccount, @idBank,@unp,@okpo)", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@nameInstitution";
                param.Value = nameInstitution;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);    
                param = new NpgsqlParameter();
                param.ParameterName = "@LegalAddress";
                param.Value = LegalAddress;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@addressWork";
                param.Value = addressWork;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@checkingAccount";
                param.Value = checkingAccount;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idBank";
                param.Value = idBank;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@unp";
                param.Value = unp;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@okpo";
                param.Value = okpo;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка, при выполнении запроса на добавление записи");
                }
            }


        }

        public void DeleteFromTableCustomerses(int id)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Delete From Customer" +
                 " where idCustomer = @idCustomer", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@idCustomer";
                //задаем значение параметра
                param.Value = id;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                //передаем параметр объекту класса SqlCommand
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка, при выполнении запроса на удаление записи");
                    MessageBox.Show("Возможно запись уже удалена");
                }
            }

        }

        public void UpdateFromTableCustomerses(int id, string nameInstitution, string LegalAddress, string addressWork, string checkingAccount, int idBank, string unp, string okpo)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Update Customer " +
                "Set (nameInstitution, LegalAddress, addressWork, checkingAccount, idBank,unp,okpo) = (@nameInstitution, @LegalAddress, @addressWork, @checkingAccount, @idBank ,@unp,@okpo)" +
                " where idCustomer = @idCustomer", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@nameInstitution";
                param.Value = nameInstitution;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);    
                param = new NpgsqlParameter();
                param.ParameterName = "@LegalAddress";
                param.Value = LegalAddress;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@addressWork";
                param.Value = addressWork;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@checkingAccount";
                param.Value = checkingAccount;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idBank";
                param.Value = idBank;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@unp";
                param.Value = unp;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@okpo";
                param.Value = okpo;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idCustomer";
                param.Value = id;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка, при выполнении запроса на изменение записи(ей)");
                    }
                }
            }
        }
        #endregion

        #region ViewContractses
        public List<ViewContracts> ViewContractses = new List<ViewContracts>();

        public void ShowFieldsViewContractses()
        {
               var conns = new NpgsqlConnection(connStr);
               try
               {
                   conns.Open();

               }
               catch
               {

               }
     
               //Выводим значение на экран
               using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT Contracts.idContrects,Contracts.numberContrects, Contracts.signWork, Executor.nameExecutor,Executor.nameExecutors,Executor.positionExecutor,Executor.positionExecutors,Executor.actingOnTheBasis,Executor.number,Executor.date,Contracts.financing,Works.worksType, Contracts.dateStart,Contracts.dateFinish,Contracts.costServices,Contracts.prepayment,Contracts.sumPrepayment,Customer.nameInstitution,NameCustomer.nameNameCustomer,NameCustomer.nameNameCustomers,NameCustomer.positionNameCustomer,NameCustomer.positionNameCustomers,NameCustomer.actingOnTheBasis,NameCustomer.number,NameCustomer.date,Customer.LegalAddress,Contracts.addressWork,Customer.checkingAccount,Bank.nameBank,Bank.address,Customer.unp,Customer.okpo FROM Contracts,Executor,Works,Bank,Customer,NameCustomer where Contracts.idExecutor = Executor.idExecutor and Contracts.idCustomer=Customer.idCustomer and Contracts.idWorks=Works.idWorks and Contracts.idNameCustomer = NameCustomer.idNameCustomer and Customer.idBank=Bank.idBank", conns))
               {
                   using (NpgsqlDataReader reader = cmd.ExecuteReader())
                   {
                       while (reader.Read())
                       {
                           ViewContractses.Add(new ViewContracts(Convert.ToInt32(reader[0]), reader[1].ToString(),
                               reader[2].ToString(), reader[3].ToString(), reader[4].ToString(),
                               reader[5].ToString(), reader[6].ToString(), reader[7].ToString(),
                               reader[8].ToString(), reader[9].ToString(), reader[10].ToString(),
                               reader[11].ToString(), reader[12].ToString(), reader[13].ToString(),
                               reader[14].ToString(), reader[15].ToString(), reader[16].ToString(),
                               reader[17].ToString(), reader[18].ToString(), reader[19].ToString(),
                               reader[20].ToString(), reader[21].ToString(), reader[22].ToString(),
                               reader[23].ToString(), reader[24].ToString(), reader[25].ToString(),
                               reader[26].ToString(), reader[27].ToString(), reader[28].ToString(),
                               reader[29].ToString(), reader[30].ToString(), reader[31].ToString()));
                       }
                   }
               }
               conns.Close();
        }

        public void InsertToTableViewContractses(int numberContrects, string signWork, int idExecutor, int idCustomer, int idNameCustomer, string financing, int idWorks, string dateStart, string dateFinish, string costServices, string prepayment, string sumPrepayment, string addressWork)
        {
            var conns = new NpgsqlConnection(connStr);
            try
            {
                conns.Open();

            }
            catch
            {

            }

            using (NpgsqlCommand cmd = new NpgsqlCommand("Insert Into Contracts (numberContrects,signWork, idExecutor, idCustomer,idNameCustomer, financing, idWorks, dateStart,dateFinish,costServices,prepayment,sumPrepayment, addressWork) Values (@numberContrects,@signWork,@idExecutor,@idCustomer,@idNameCustomer,@financing,@idWorks,@dateStart,@dateFinish,@costServices,@prepayment,@sumPrepayment,@addressWork)", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@numberContrects";
                param.Value = numberContrects;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@signWork";
                param.Value = signWork;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idExecutor";
                param.Value = idExecutor;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idCustomer";
                param.Value = idCustomer;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idNameCustomer";
                param.Value = idNameCustomer;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@financing";
                param.Value = financing;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idWorks";
                param.Value = idWorks;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@dateStart";
                param.Value = dateStart;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@dateFinish";
                param.Value = dateFinish;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@costServices";
                param.Value = costServices;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@prepayment";
                param.Value = prepayment;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@sumPrepayment";
                param.Value = sumPrepayment;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@addressWork";
                param.Value = addressWork;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
              
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка, при выполнении запроса на добавление записи");
                }
            }


        }

        public void DeleteFromTableViewContractses(int id)
        {
            var conns = new NpgsqlConnection(connStr);
            try
            {
                conns.Open();

            }
            catch
            {

            }

            using (NpgsqlCommand cmd = new NpgsqlCommand("Delete From Contracts" +
                 " where idContrects = @idContrects", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@idContrects";
                //задаем значение параметра
                param.Value = id;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                //передаем параметр объекту класса SqlCommand
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка, при выполнении запроса на удаление записи");
                    MessageBox.Show("Возможно запись уже удалена");
                }
            }

        }

        public void UpdateFromSum(string sum, int id)
        {
            var conns = new NpgsqlConnection(connStr);
            try{conns.Open();}
            catch{}
            using (NpgsqlCommand cmd = new NpgsqlCommand("Update Contracts Set (costServices)= (@costServices) where idContrects = @idContrects", conns))
            {
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@costServices";
                param.Value = sum;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idContrects";
                param.Value = id;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                {
                    try{cmd.ExecuteNonQuery();}
                    catch{MessageBox.Show("Ошибка, при выполнении запроса на изменение записи(ей)");}
                }
            }
        }

        

        public void UpdateFromTableViewContractses(int id, int numberContrects, string signWork, int idExecutor, int idCustomer, int idNameCustomer, string financing, int idWorks, string dateStart, string dateFinish, string costServices, string prepayment, string sumPrepayment, string addressWork)
        {
            var conns = new NpgsqlConnection(connStr);
            try
            {
                conns.Open();

            }
            catch
            {

            }

            using (NpgsqlCommand cmd = new NpgsqlCommand("Update Contracts " +
                "Set (numberContrects,signWork, idExecutor, idCustomer,idNameCustomer, financing, idWorks, dateStart,dateFinish,costServices,prepayment,sumPrepayment, addressWork)= (@numberContrects,@signWork, @idExecutor, @idCustomer,@idNameCustomer, @financing, @idWorks, @dateStart,@dateFinish,@costServices,@prepayment,@sumPrepayment, @addressWork) " +
                " where idContrects = @idContrects", conns))
            {
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@numberContrects";
                param.Value = numberContrects;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@signWork";
                param.Value = signWork;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idExecutor";
                param.Value = idExecutor;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idCustomer";
                param.Value = idCustomer;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idNameCustomer";
                param.Value = idNameCustomer;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@financing";
                param.Value = financing;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idWorks";
                param.Value = idWorks;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@dateStart";
                param.Value = dateStart;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@dateFinish";
                param.Value = dateFinish;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@costServices";
                param.Value = costServices;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@prepayment";
                param.Value = prepayment;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@sumPrepayment";
                param.Value = sumPrepayment;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@addressWork";
                param.Value = addressWork;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idContrects";
                param.Value = id;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка, при выполнении запроса на изменение записи(ей)");
                    }
                }
            }
        }
        #endregion

        #region     viewDateSelect
        public List<SelectDateView> SelectDateViewse = new List<SelectDateView>();

        public void ShowFieldsSelectDate(int name)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT Contracts.idContrects, Contracts.numberContrects, Contracts.signWork, Customer.nameInstitution, Contracts.addressWork, Customer.LegalAddress, Customer.checkingAccount, Customer.unp ,Customer.okpo,Contracts.dateStart,Bank.nameBank,Bank.address,Executor.nameExecutor,Executor.positionExecutor,NameCustomer.nameNameCustomer,NameCustomer.positionNameCustomer "+
                            "FROM Contracts,Customer, Bank,Executor,NameCustomer WHERE Contracts.idCustomer = Customer.idCustomer and Contracts.idExecutor = Executor.idExecutor and Customer.idCustomer = NameCustomer.idCustomer and Customer.idBank = Bank.idBank " +
                              " and dateStart  LIKE '%" + name + "%'", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SelectDateViewse.Add(new SelectDateView(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(),
                            reader[11].ToString(),reader[12].ToString(),reader[13].ToString(),reader[14].ToString(),reader[15].ToString()));
                    }
                }
            }
            conns.Close();
        }
#endregion

        #region Score
        public List<Score> Scores = new List<Score>();

        public void ShowFieldsScore(int id)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM score WHERE idContrects = " + id, conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Scores.Add(new Score(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), Convert.ToInt32(reader[3]), Convert.ToInt32(reader[4]), Convert.ToInt32(reader[5]), Convert.ToInt32(reader[6])));
                    }
                }
            }
            conns.Close();
        }

        public void InsertToTableScore(int idContrects, string address, int oneFlow, int twoFlow, int threeFlow, int manometer)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Insert Into score" +
                " (idContrects, address, oneFlow, twoFlow, threeFlow, manometer) Values (@idContrects, @address, @oneFlow, @twoFlow, @threeFlow, @manometer)", conns))
            {
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idContrects";
                param.Value = idContrects;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@address";
                param.Value = address;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@oneFlow";
                param.Value = oneFlow;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@twoFlow";
                param.Value = twoFlow;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@threeFlow";
                param.Value = threeFlow;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@manometer";
                param.Value = manometer;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка, при выполнении запроса на добавление записи");
                }
            }


        }

        public void DeleteFromTableScore(int id)
        {
            var conns = new NpgsqlConnection(connStr);
            try{conns.Open();}
            catch{}

            using (NpgsqlCommand cmd = new NpgsqlCommand("Delete From Score" +
                 " where idScore = @idScore", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@idScore";
                //задаем значение параметра
                param.Value = id;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                //передаем параметр объекту класса SqlCommand
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка, при выполнении запроса на удаление записи");
                    MessageBox.Show("Возможно запись уже удалена");
                }
            }

        }

        public void UpdateFromTableScore(int id, int idContrects, string address, int oneFlow, int twoFlow, int threeFlow, int manometer)
        {
            var conns = new NpgsqlConnection(connStr);
            try
            {
                conns.Open();

            }
            catch
            {

            }

            using (NpgsqlCommand cmd = new NpgsqlCommand("Update Score " +
                "Set (idContrects, address, oneFlow, twoFlow, threeFlow, manometer)= (@idContrects, @address, @oneFlow, @twoFlow, @threeFlow, @manometer) " +
                " where idScore = @idScore", conns))
            {
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idContrects";
                param.Value = idContrects;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@address";
                param.Value = address;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@oneFlow";
                param.Value = oneFlow;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@twoFlow";
                param.Value = twoFlow;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@threeFlow";
                param.Value = threeFlow;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@manometer";
                param.Value = manometer;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idScore";
                param.Value = id;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка, при выполнении запроса на изменение записи(ей)");
                    }
                }
            }
        }
        #endregion

        #region Materials
        public List<DevaisesMaterials> DevaisesMaterialses = new List<DevaisesMaterials>();

        public void ShowFieldsDevaisesMaterialses()
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("Select Materials.idMaterials, Customer.nameInstitution, Materials.address, Materials.typeCounter, Materials.typeAccount, Materials.brandEnergyMeter, Materials.du, Materials.tb, Materials.ipp, Materials.ppr, Materials.tsp, Materials.note, Materials.data From Materials,Customer where Materials.idCustomer=Customer.idCustomer", conns))       
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DevaisesMaterialses.Add(new DevaisesMaterials(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(),reader[3].ToString(),reader[4].ToString(),reader[5].ToString(),
                            reader[6].ToString(),reader[7].ToString(),reader[8].ToString(),reader[9].ToString(),reader[10].ToString(),reader[11].ToString(),reader[12].ToString()));
                    }
                }
            }
            conns.Close();
        }

        public void InsertToTableDevaisesMaterialses(int idCustomer, string address, string typeCounter, string typeAccount, string brandEnergyMeter, string du,
        string tb, string ipp, string ppr, string tsp, string note, string date)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Insert Into Materials (idCustomer, address, typeCounter, typeAccount, brandEnergyMeter, du,tb,ipp,ppr ,tsp,note ,data) Values (@idCustomer, @address, @typeCounter, @typeAccount, @brandEnergyMeter, @du, @tb, @ipp, @ppr , @tsp, @note ,@date)", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idCustomer";
                param.Value = idCustomer;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@address";
                param.Value = address;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@typeCounter";
                param.Value = typeCounter;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@typeAccount";
                param.Value = typeAccount;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@brandEnergyMeter";
                param.Value = brandEnergyMeter;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@du";
                param.Value = du;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@tb";
                param.Value = tb;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@ipp";
                param.Value = ipp;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@ppr";
                param.Value = ppr;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@tsp";
                param.Value = tsp;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@note";
                param.Value = note;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@date";
                param.Value = date;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка, при выполнении запроса на добавление записи");
                }
            }


        }

        public void DeleteFromTableDevaisesMaterialses(int id)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Delete From Materials" +
                 " where idMaterials = @idMaterials", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@idMaterials";
                //задаем значение параметра
                param.Value = id;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                //передаем параметр объекту класса SqlCommand
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка, при выполнении запроса на удаление записи");
                    MessageBox.Show("Возможно запись уже удалена");
                }
            }

        }

        public void UpdateFromTableDevaisesMaterialses(int idMaterials, int idCustomer, string address, string typeCounter, string typeAccount, string brandEnergyMeter, string du,
        string tb, string ipp, string ppr, string tsp, string note, string date)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Update Materials " +
                "Set (idCustomer, address, typeCounter, typeAccount, brandEnergyMeter, du,tb,ipp,ppr ,tsp,note ,data) = (@idCustomer, @address, @typeCounter, @typeAccount, @brandEnergyMeter, @du, @tb, @ipp, @ppr , @tsp, @note ,@date)" +
                " where idMaterials = @idMaterials", conns))
            {
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idCustomer";
                param.Value = idCustomer;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@address";
                param.Value = address;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@typeCounter";
                param.Value = typeCounter;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@typeAccount";
                param.Value = typeAccount;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@brandEnergyMeter";
                param.Value = brandEnergyMeter;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@du";
                param.Value = du;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@tb";
                param.Value = tb;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@ipp";
                param.Value = ipp;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@ppr";
                param.Value = ppr;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@tsp";
                param.Value = tsp;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@note";
                param.Value = note;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@date";
                param.Value = date;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idMaterials";
                param.Value = idMaterials;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка, при выполнении запроса на изменение записи(ей)");
                    }
                }
            }
        }
#endregion 

        #region Counter
        public List<TypeCounterOne> TypeCounter = new List<TypeCounterOne>();
        public List<TypeCounterTwo> TypeCounterTwo = new List<TypeCounterTwo>();
        public List<TypeCounterThree> TypeCounterThree = new List<TypeCounterThree>();
        public List<Manometr> Manometr = new List<Manometr>();

        public void ShowFieldsTypeCounterOne(string address, int date)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("select count(idMaterials) from  Materials where typeCounter like '%однопоточное%'" +
                    "and address like '%" + address + "%' and  data like '%" + date + "%' ", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TypeCounter.Add(new TypeCounterOne(Convert.ToInt32(reader[0])));
                    }
                }
            }
            conns.Close();
        }

        public void ShowFieldsTypeCounterTwo(string address, int date)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("select count(idMaterials) from  Materials where typeCounter like '%двухпоточное%'" +
                    "and address like '%" + address + "%' and  data like '%" + date + "%' ", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TypeCounterTwo.Add(new TypeCounterTwo(Convert.ToInt32(reader[0])));
                    }
                }
            }
            conns.Close();
        }

        public void ShowFieldsTypeCounterThree(string address, int date)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("select count(idMaterials) from  Materials where typeCounter like '%трехпоточное%'" +
                    "and address like '%" + address + "%' and  data like '%" + date + "%' ", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TypeCounterThree.Add(new TypeCounterThree(Convert.ToInt32(reader[0])));
                    }
                }
            }
            conns.Close();
        }

        public void ShowFieldsManometr(string address, int date)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("select count(idMaterials) from  Materials where typeCounter like '%манометр%'" +
                    "and address like '%" + address + "%' and  data like '%" + date + "%' ", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Manometr.Add(new Manometr(Convert.ToInt32(reader[0])));
                    }
                }
            }
            conns.Close();
        }
        #endregion

        #region Equipment
        public List<Equipment> Equipment = new List<Equipment>();

        public void ShowFieldsEquipment()
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();
            //Выводим значение на экран
            using (NpgsqlCommand cmd = new NpgsqlCommand("Select Equipment.idEquipment, Customer.nameInstitution, Equipment.address, Equipment.typeEquipment, Equipment.typeAccount, Equipment.brandEquipment, Equipment.du, Equipment.brandValves, Equipment.note From Equipment,Customer where Equipment.idCustomer=Customer.idCustomer", conns))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Equipment.Add(new Equipment(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(),
                            reader[6].ToString(), reader[7].ToString(), reader[8].ToString()));
                    }
                }
            }
            conns.Close();
        }

        public void InsertToTableEquipment(int idCustomer, string address, string typeEquipment, string typeAccount,
               string brandEquipment, string du, string brandValves, string note)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Insert Into Equipment (idCustomer,address,typeEquipment,typeAccount,brandEquipment,du,brandValves,note) Values (@idCustomer,@address,@typeEquipment,@typeAccount,@brandEquipment,@du,@brandValves,@note)", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idCustomer";
                param.Value = idCustomer;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@address";
                param.Value = address;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@typeEquipment";
                param.Value = typeEquipment;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@typeAccount";
                param.Value = typeAccount;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@brandEquipment";
                param.Value = brandEquipment;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@du";
                param.Value = du;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@brandValves";
                param.Value = brandValves;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@note";
                param.Value = note;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка, при выполнении запроса на добавление записи");
                }
            }


        }

        public void DeleteFromTableEquipment(int id)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Delete From Equipment" +
                 " where idEquipment = @idEquipment", conns))
            {
                //объявляем объект класса NpgsqlParameter
                NpgsqlParameter param = new NpgsqlParameter();
                //задаем имя параметра
                param.ParameterName = "@idEquipment";
                //задаем значение параметра
                param.Value = id;
                //задаем тип параметра
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                //передаем параметр объекту класса SqlCommand
                cmd.Parameters.Add(param);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Ошибка, при выполнении запроса на удаление записи");
                    MessageBox.Show("Возможно запись уже удалена");
                }
            }

        }

        public void UpdateFromEquipment(int idEquipment, int idCustomer, string address, string typeEquipment, string typeAccount,
               string brandEquipment, string du, string brandValves, string note)
        {
            var conns = new NpgsqlConnection(connStr);
            conns.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand("Update Equipment " +
                "Set (idCustomer,address,typeEquipment,typeAccount,brandEquipment,du,brandValves,note) = (@idCustomer,@address,@typeEquipment,@typeAccount,@brandEquipment,@du,@brandValves,@note)" +
                " where idEquipment = @idEquipment", conns))
            {
                NpgsqlParameter param = new NpgsqlParameter();
                param.ParameterName = "@idCustomer";
                param.Value = idCustomer;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@address";
                param.Value = address;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@typeEquipment";
                param.Value = typeEquipment;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@typeAccount";
                param.Value = typeAccount;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@brandEquipment";
                param.Value = brandEquipment;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@du";
                param.Value = du;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@brandValves";
                param.Value = brandValves;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@note";
                param.Value = note;
                param.NpgsqlDbType = NpgsqlDbType.Text;
                cmd.Parameters.Add(param);
                param = new NpgsqlParameter();
                param.ParameterName = "@idEquipment";
                param.Value = idEquipment;
                param.NpgsqlDbType = NpgsqlDbType.Integer;
                cmd.Parameters.Add(param);
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка, при выполнении запроса на изменение записи(ей)");
                    }
                }
            }
        }
        #endregion 
    }
}
