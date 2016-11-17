using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SecurityWokshop.Models;

namespace SecurityWokshop.DataAccess
{
    public class CreditCardRepo
    {
        private readonly string _connectionString;

        public CreditCardRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<CreditCardModel> GetAllCards()
        {
            var cards = new List<CreditCardModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.CommandText = "SELECT Id, Name, Number, ExpiryMonth, ExpiryYear, CVV FROM CreditCards";
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var card = new CreditCardModel
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Number = reader.GetString(2),
                                ExpiryMonth = reader.GetInt32(3),
                                ExpiryYear = reader.GetInt32(4),
                                Cvv = reader.GetString(5)
                            };
                            cards.Add(card);
                        }
                    }

                    reader.Close();
                }
            }

            return cards;
        }

        public CreditCardModel GetCard(int id)
        {
            var card = new CreditCardModel();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.CommandText =
                        "SELECT Id, Name, Number, ExpiryMonth, ExpiryYear, CVV FROM CreditCards WHERE Id = " + id;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        card.Id = reader.GetInt32(0);
                        card.Name = reader.GetString(1);
                        card.Number = reader.GetString(2);
                        card.ExpiryMonth = reader.GetInt32(3);
                        card.ExpiryYear = reader.GetInt32(4);
                        card.Cvv = reader.GetString(5);
                    }

                    reader.Close();
                }
            }

            return card;
        }

        public bool UpdateCard(CreditCardModel card)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    var sql =
                        $"UPDATE CreditCards SET Name = '{card.Name}', Number = '{card.Number}', ExpiryMonth = {card.ExpiryMonth}, ExpiryYear = {card.ExpiryYear}, CVV = {card.Cvv} WHERE Id = {card.Id}";

                    command.CommandText = sql;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.ExecuteReader();
                }
            }

            return true;
        }

        public bool AddCard(CreditCardModel card)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    var sql =
                        $"INSERT INTO CreditCards (Name, Number, ExpiryMonth, ExpiryYear, CVV) Values ('{card.Name}', '{card.Number}', {card.ExpiryMonth}, {card.ExpiryYear}, {card.Cvv})";

                    command.CommandText = sql;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.ExecuteReader();
                }
            }

            return true;
        }

        public bool DeleteCard(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.CommandText = "DELETE FROM CreditCards WHERE Id = " + id;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.ExecuteReader();
                }
            }

            return true;
        }
    }
}