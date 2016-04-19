using CLM.AerospikeDemo.Domain;
using Aerospike.Client;

namespace CLM.AerospikeDemo.Repository
{
  public class UserAerospikeRepository
  {
    public static void SaveUser(CLM.AerospikeDemo.Domain.User userToSave)
    {
      // Establish connection the server
        AerospikeClient client = new AerospikeClient("192.168.0.12", 3000);

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

        // Write record
        client.Put(null, userKey, userBins);

        // Close connection
        client.Close();
    }
  }
}
