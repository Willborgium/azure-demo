using System;
using System.Collections.Generic;
using AzureDemo.Common;
using System.ServiceModel;

namespace AzureDemo.Console
{
    /// <summary>
    /// Provides a C# client capable of interacting with an IExampleService implementation.
    /// </summary>
    public class ExampleServiceClient : ClientBase<IExampleService>, IExampleService
    {
        /// <summary>
        /// Returns the message associated with the given key.
        /// </summary>
        /// <param name="key">The key the message is associated with.</param>
        /// <returns>The message associated with the given key. If it is not found, returns null.</returns>
        public string GetMessage(string key)
        {
            return this.Channel.GetMessage(key);
        }

        /// <summary>
        /// Saves the given message. If a key is provided, updates the message associated with the given key.
        /// </summary>
        /// <param name="key">The key update. If null or empty, a new key is generated.</param>
        /// <param name="message">The message to save.</param>
        /// <returns>The key the message that was saved can be retrieved with.</returns>
        public string SaveMessage(string key, string message)
        {
            return this.Channel.SaveMessage(key, message);
        }
    }
}