using DemoApp.UI.DTOs;
using System.Net.Http.Json;
using System.Net.Mime;

namespace DemoApp.UI
{
    public class IO
    {
        // Fields
        private readonly Uri uri;

        public static readonly HttpClient httpClient = new HttpClient();

        // Constructors
        public IO (Uri uri)
        {
            this.uri = uri;
        }


        // Methods
        public async Task BeginAsync()
        {
            Console.WriteLine("ConsoleApp Running...");
            bool loop = true;

            do
            {
                int choice = MainMenu();
                switch(choice)
                {
                    case -1:
                        Console.WriteLine("Bad input, please try again.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        break;
                    case 0:
                        loop = false; break;
                    case 1:
                        await DisplayAllCustomersAsync();
                        break;
                }
            }while (loop == true);
        }

        private int MainMenu()
        {
            Console.Clear();
            int choice = -1;
            Console.WriteLine("Please select the option of your choice:");
            Console.WriteLine("[0] - Exit");
            Console.WriteLine("[1] - Get All Customers");
            Console.WriteLine("[2] - Get A Customer's Information");
            string? input = Console.ReadLine();
            Console.Clear();
            //if (int.TryParse(input, out choice))
            //{
            //    return choice;
            //}
            //else
            //{
            //    choice = -1;
            //    return choice;
            //}
            if (!int.TryParse(input, out choice))
            { choice = -1; }
            return choice;
        }
        
        private async Task DisplayAllCustomersAsync()
        {   
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "api/customer");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            //try
            //{
            //    response = await httpClient.SendAsync(request);

            //}
            //catch (HttpRequestException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine("Press any key to continue.");
            //    Console.ReadLine();
            //}

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                List<CustomerDTO> customers = await response.Content.ReadFromJsonAsync<List<CustomerDTO>>();
                if (customers != null)
                {
                    Console.WriteLine("Customers: ");
                    foreach (var customer in customers)
                    {
                        Console.WriteLine("Customers Name: " + customer.first_name + " " + customer.last_name);
                    }
                }
                else
                {
                    Console.WriteLine("No customers found.");
                   
                }
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}