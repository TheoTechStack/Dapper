using System;
using System.Data;
using Dapper;
using DapperDemo.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client.Extensibility;

namespace DapperDemo 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("!");
            DataContext dataContext = new DataContext();
            string sqlCommand = "SELECT GETDATE()";
            DateTime dateTime = dataContext.LoadDataSingle<DateTime>(sqlCommand);
            Console.WriteLine(dateTime);
            
            Computer computer = new() 
            {
                Motherboard = "x001",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.UtcNow,
                Price = 101.1m,
                VideoCard = "3090GTX"

            };
            string sql = @"INSERT INTO TutorialAppSchema.Computer(
                Motherboard ,
                HasWifi,
                HasLTE,
                ReleaseDate , 
                Price,
                VideoCard  
            ) VALUES('" +computer.Motherboard
                    +"','" + computer.HasWifi
                    +"','" + computer.HasLTE
                    +"','" + computer.ReleaseDate
                    +"','" + computer.Price
                    +"','" + computer.VideoCard
            +"')";

            Console.WriteLine(sql);
            int result = dataContext.ExecuteSqlWithRowCount<Computer>(sql);
            Console.WriteLine($"output {result}");

            string sqlSelect = @"
            SELECT * FROM TutorialAppSchema.Computer ";
            IEnumerable<Computer> computers = dataContext.LoadData<Computer>(sqlSelect);


            List<Computer> selectedComputers = computers
                                                .Where(c => c.HasWifi)
                                                .OrderBy(c => c.ReleaseDate)
                                                .ToList(); 

             selectedComputers.ForEach(computer =>
            {
                Console.WriteLine($"Motherboard: {computer.Motherboard}");
                Console.WriteLine($"Has Wifi: {computer.HasWifi}");
                Console.WriteLine($"Has LTE: {computer.HasLTE}");
                Console.WriteLine($"Release Date: {computer.ReleaseDate}");
                Console.WriteLine($"Price: {computer.Price}");
                Console.WriteLine($"Video Card: {computer.VideoCard}");
                Console.WriteLine();
            });        



        }
    }
}