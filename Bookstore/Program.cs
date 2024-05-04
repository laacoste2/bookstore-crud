using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Bookstore
{
    class Program
    {
        static void Main()
        {
            string cnnString = "Server=localhost;Port=3306;Database=bookstore;Uid=root;Pwd=1234";
            MySqlConnection cnn = new MySqlConnection(cnnString);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Escolha uma operação CRUD a ser realizada: ");
                Console.WriteLine("[C]reate [R]ead [U]pdate [D]elete");
                char operationChoosed = char.Parse(Console.ReadLine());

                if (operationChoosed == 'C')
                {
                    Crud.AddDataOnDatabase(cnn);
                }
                else if (operationChoosed == 'R')
                {
                    Crud.ShowTableFromDatabase(cnn);
                }
                else if (operationChoosed == 'U')
                {
                    Crud.UpdateDataFromDatabase(cnn);
                }
                else if (operationChoosed == 'D')
                {
                    Crud.RemoveDataFromDatabase(cnn);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Operação Invalida.");
                }
            }
                    
        }
    }
}
