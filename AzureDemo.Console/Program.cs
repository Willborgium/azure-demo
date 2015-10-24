namespace AzureDemo.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;

            using (var client = new ExampleServiceClient())
            {
                while (input != "quit")
                {
                    System.Console.WriteLine("Get or save?");

                    input = System.Console.ReadLine();

                    var key = string.Empty;

                    var message = string.Empty;

                    switch (input)
                    {
                        case "get":
                            System.Console.WriteLine("Key?");

                            key = System.Console.ReadLine();

                            message = client.GetMessage(key);

                            System.Console.WriteLine("Message is: {0}", message);

                            break;

                        case "save":

                            System.Console.WriteLine("Key?");

                            key = System.Console.ReadLine();

                            System.Console.WriteLine("Message?");

                            message = System.Console.ReadLine();

                            key = client.SaveMessage(key, message);
                            
                            System.Console.WriteLine("Key is: {0}", key);
                            
                            break;

                        default:
                            break;
                    }

                    System.Console.WriteLine("Continue or quit?");

                    input = System.Console.ReadLine();
                }
            }
        }
    }
}