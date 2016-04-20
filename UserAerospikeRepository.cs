using Aerospike.Client;
using System.Collections.Generic;

namespace CLM.AerospikeDemo.Repository
{
  public class UserAerospikeRepository
  {
    private string server;
    private int port;
    public UserAerospikeRepository(string server, int port)
    {
      this.server = server;
      this.port = port;
    }
    public void SaveUser(CLM.AerospikeDemo.Domain.User userToSave)
    {
      // Establish connection the server
        AerospikeClient client = new AerospikeClient(server, port);

        // Create key
        Key userKey = new Key("test", "Users", userToSave.Email);

        Bin[] userBins = new Bin[7];

        // Create Bins
        Bin firstNameBin = new Bin("FirstName", userToSave.FirstName);
        userBins[0] = firstNameBin;

        Bin lastNameBin = new Bin("LastName", userToSave.LastName);
        userBins[1] = lastNameBin;

        Bin emailBin = new Bin("Email", userToSave.Email);
        userBins[2] = emailBin;

        Bin cityBin = new Bin("City", userToSave.City);
        userBins[3] = cityBin;

        Bin countryBin = new Bin("Country", userToSave.Country);
        userBins[4] = countryBin;

        Bin jobBin = new Bin("Job", userToSave.Job);
        userBins[5] = jobBin;

        Bin companyBin = new Bin("Company", userToSave.Company);
        userBins[6] = companyBin;
        
        try
        {
          client.Put(null, userKey, userBins);
        }
        finally
        {
          client.Close();
        }

        
    }
    
    public List<string> GetUserEmailsFromCity(string city)
    {
      List<string> userEmails = new List<string>();
      AerospikeClient client = new AerospikeClient(server, port);
      
      Statement stmt = new Statement();
      stmt.SetNamespace("test");
      stmt.SetSetName("Users");
      stmt.SetBinNames("Email");
      stmt.SetFilters(Filter.Equal("City", city));

      RecordSet userEmailsRecordSet = client.Query(null, stmt);
      
      try
      {
          while (userEmailsRecordSet.Next())
          {
              Record emailRecord = userEmailsRecordSet.Record;
              string userEmailFromCity = emailRecord.GetValue("Email").ToString();
              userEmails.Add(userEmailFromCity);
          }
      }
      finally
      {
          userEmailsRecordSet.Close();
          client.Close();
      }
      
      return userEmails;
    }
  }
}
