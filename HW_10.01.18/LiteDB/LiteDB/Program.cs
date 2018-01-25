using AdoBankingSystem.Shared.DTOs;
using LiteDB.OfflineDAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDB
{
    class Program
    {
        static void Main(string[] args)
        {
            BankClientOffline dao = new BankClientOffline();

            BankClientDto dto = new BankClientDto("Alisher", "Alisher", "Alisher", "Alisher", "Alisher");
            string id = dao.Create(dto);

            Console.WriteLine(dao.Read(id));

            dto.FirstName = "Diana";
            dto.LastName = "Diana";

            dao.Update(dto);

            BankClientDto getAgain = dao.Read(id);

            Console.WriteLine(getAgain);
            Console.ReadLine();
        }
    }
}
