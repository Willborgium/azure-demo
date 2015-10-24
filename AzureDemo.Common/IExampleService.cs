using System.ServiceModel;
using System.ServiceModel.Web;

namespace AzureDemo.Common
{
    /// <summary>
    /// Provides a contract that defines the RESTful API for this service.
    /// </summary>
    [ServiceContract(Namespace = "example")]
    public interface IExampleService
    {
        /// <summary>
        /// Returns the message associated with the given key.
        /// </summary>
        /// <param name="key">The key the message is associated with.</param>
        /// <returns>The message associated with the given key. If it is not found, returns null.</returns>
        [WebGet(UriTemplate = "GetMessage/{key}", ResponseFormat = WebMessageFormat.Json)]
        string GetMessage(string key);

        /// <summary>
        /// Saves the given message. If a key is provided, updates the message associated with the given key.
        /// </summary>
        /// <param name="key">The key update. If null or empty, a new key is generated.</param>
        /// <param name="message">The message to save.</param>
        /// <returns>The key the message that was saved can be retrieved with.</returns>
        [WebInvoke(UriTemplate = "SaveMessage/{key}", ResponseFormat = WebMessageFormat.Json)]
        string SaveMessage(string key, string message);
    }
}