using System.Collections.Generic;
using System;

using CLM.AerospikeDemo.Domain;
using CLM.AerospikeDemo.Repository;

public class Program
{
    public static void Main (string[] args)
    {
      UserAerospikeRepository userAeroRepo = new UserAerospikeRepository("192.168.0.12", 3000);
            
      User userToSave1 = new User 
      { 
        FirstName = "Liviu", 
        LastName = "Costea", 
        Email = "email.lcostea@gmail.com",
        Job = "Software Developer",
        Company = "Biz Pro Technologies",
        City = "Iasi",
        Country = "Romania" 
      };
       
      
      userAeroRepo.SaveUser(userToSave1);
      
      
      User userToSave2 = new User 
      { 
        FirstName = "Ion", 
        LastName = "Popescu", 
        Email = "ion.popescu@email.ro",
        Job = "Software Developer",
        Company = "Another Company",
        City = "Bacau",
        Country = "Romania" 
      };
      
      userAeroRepo.SaveUser(userToSave2);
      
      
      User userToSave3 = new User 
      { 
        FirstName = "Raluca", 
        LastName = "Popescu", 
        Email = "raluca.popescu@email.ro",
        Job = "Software Developer",
        Company = "Yet Another Company",
        City = "Iasi",
        Country = "Romania" 
      };
      
      userAeroRepo.SaveUser(userToSave3);
      
      List<string> userEmailsFromCity = userAeroRepo.GetUserEmailsFromCity("Iasi");
      
      Console.WriteLine("Emails from Iasi: ");
      foreach(string email in userEmailsFromCity)
      {
          Console.WriteLine(email);
      }
      
      Console.ReadLine();
      
    }
}
