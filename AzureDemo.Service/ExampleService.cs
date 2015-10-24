using AzureDemo.Common;
using System;
using System.Data.SqlClient;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace AzureDemo.Service
{
    /// <summary>
    /// Provides an IIS-hostable implementation of the IExampleService RESTful service.
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ExampleService : IExampleService
    {
        #region Test Methods

        private string GetMessage_Test(string key)
        {
            return string.Format("{0} : {1}", key, "Hello from the GetMessage method!");
        }

        private string SaveMessage_Test(string key, string message)
        {
            return string.Format("{0} : {1}", key, message);
        }

        #endregion

        #region SQL Methods

        private const string CONNECTION_STRING = "Server=tcp:ut9ndgf7ko.database.windows.net,1433;Database=TestDB1;User ID=wjcustode@ut9ndgf7ko;Password=Link2023;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";

        private string GetMessage_SQL(string key)
        {
            string output = null;

            try
            {
                using (var connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    var cmd = new SqlCommand(string.Format("SELECT Message FROM dbo.BZ_Test WHERE Id = {0}", key), connection);

                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        output = result.ToString();
                    }
                    else
                    {
                        output = "No results returned.";
                    }
                }
            }
            catch(Exception err)
            {
                output = err.Message;
            }

            return output;
        }

        private string SaveMessage_SQL(string key, string message)
        {
            var output = string.Empty;

            try
            {
                using (var connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    var insertScript = string.Format("INSERT INTO dbo.BZ_Test(Message) VALUES('{0}')", message);

                    var updateScript = string.Format("UPDATE dbo.BZ_Test SET Message = '{0}' WHERE Id = {1}", message, key);

                    var doUpdate = false;

                    if (!string.IsNullOrWhiteSpace(key))
                    {
                        if (GetMessage_SQL(key) != "No results returned.")
                        {
                            doUpdate = true;
                        }
                    }

                    var cmd = new SqlCommand(doUpdate ? updateScript : insertScript, connection);

                    var result = cmd.ExecuteNonQuery();

                    output = result == 1 ? "Success" : "Failed";
                }                
            }
            catch (Exception err)
            {
                output = err.Message;
            }

            return output;
        }

        #endregion

        /// <summary>
        /// Returns the message associated with the given key.
        /// </summary>
        /// <param name="key">The key the message is associated with.</param>
        /// <returns>The message associated with the given key. If it is not found, returns null.</returns>
        public string GetMessage(string key)
        {
            //return GetMessage_SQL(key);

            return GetMessage_Test(key);
        }

        /// <summary>
        /// Saves the given message. If a key is provided, updates the message associated with the given key.
        /// </summary>
        /// <param name="key">The key update. If null or empty, a new key is generated.</param>
        /// <param name="message">The message to save.</param>
        /// <returns>The key the message that was saved can be retrieved with.</returns>
        public string SaveMessage(string key, string message)
        {
            //return SaveMessage_SQL(key, message);

            return SaveMessage_Test(key, message);
        }
    }
}