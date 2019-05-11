using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace RewardsTest
{
    public class ShowCustomers
    {
        public IList<Person> ShowUsers()
        {
            string connStr = @"data source = ./BarberShopRewardsData.db3";
            IList<Person> people = new List<Person>();
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    conn.Open();
                    cmd.CommandText = "select Customers.FirstName, Customers.LastName, Customers.PhoneNumber, Rewards.RewardCount from Customers " +
                    "left outer join Rewards on Customers.CustID = Rewards.CustID;";
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            people.Add(new Person
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                RewardCount = Int32.Parse(reader["RewardCount"].ToString())
                            });
                        }
                    }
                    conn.Close();
                    return people;
                }
            }
        }
    }
}
