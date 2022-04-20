using DemoApp.UI.DTOs;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Linq;

namespace DemoApp.UI
{
    public class IO
    {
        // Fields
        private readonly Uri uri;

        public static readonly HttpClient httpClient = new HttpClient();

        // Constructors
        public IO(Uri uri)
        {
            this.uri = uri;
        }


        // Methods
        public async Task BeginAsync()
        {
            bool loop = true;

            do
            {
                int choice = MainMenu();
                switch (choice)
                {
                    case -1:
                        Console.WriteLine("Bad input, please try again.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        continue;
                    case 0:
                        loop = false; break;
                    case 1:
                        await DisplayAllCustomersAsync();
                        continue;
                    case 2:
                        await SearchCustomerAsync();
                        continue;
                    case 3:
                        await CreateAnOrder();
                        continue;
                    case 4:
                        await GetLocationOrdersAsync();
                        continue;
                }
            } while (loop == true);
        }

        private int MainMenu()
        {
            Console.Clear();
            int choice = -1;
            Console.WriteLine("Please select the option of your choice:");
            Console.WriteLine("[0] - Exit");
            Console.WriteLine("[1] - Get All Past Customers");
            Console.WriteLine("[2] - Get An Order's Information");
            Console.WriteLine("[3] - Create An Order");
            Console.WriteLine("[4] - View Location Details");
            string? input = Console.ReadLine();
            Console.Clear();
            if (!int.TryParse(input, out choice))
            { choice = -1; }
            return choice;
        }
        // Product Methods
        private async Task CreateAnOrder(List<ProductDTO>? order_list = null)
        {
            Console.WriteLine("Please enter a location id to see the current inventory");
            string input = Console.ReadLine();
            await SeeInventory(input, order_list);
        }
        private async Task SeeInventory(string input, List<ProductDTO>? order_list = null)
        {
            Console.Clear();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + $"api/product/{input}");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();

                if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                List<ProductDTO> products = await response.Content.ReadFromJsonAsync<List<ProductDTO>>();
                if (products != null)
                {
                    if(order_list == null)
                    {
                        Console.WriteLine("Products: ");
                        foreach (ProductDTO product in products)
                        {
                            Console.WriteLine($"Id: {product.id} | Name: {product.name} | Amount: {product.amount} | Price: {product.price} | Description: {product.description}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Products: ");
                        foreach (ProductDTO product in products)
                        {
                            for (int i = 0; i < order_list.Count; i++)
                            {
                                if(product.id == order_list[i].id)
                                {
                                    product.amount = product.amount - order_list[i].amount;
                                }
                            }
                            Console.WriteLine($"Id: {product.id} | Name: {product.name} | Amount: {product.amount} | Price: {product.price} | Description: {product.description}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No products found.");

                }
                await MakePurchase(Int32.Parse(input), products, order_list);
            }
            
            Console.Clear();
        }
        private async Task MakePurchase(int location_id, List<ProductDTO> products, List<ProductDTO>? order_list = null, string PID = "")
        {
            Console.WriteLine("\nType in product id Or 0 to Exit.");
            string Pid = Console.ReadLine();
            if (Pid != "0")
            {
                IEnumerable<ProductDTO> product_amt = products.Where(product => product.id == Int32.Parse(Pid));
                List<ProductDTO> product_list = product_amt.ToList();
                Console.WriteLine($"Selected: {product_list[0].name} | Amount Remaining: {product_list[0].amount} | Price: {product_list[0].price}");
                Console.WriteLine("Type in amount of product the customer would like");
                string total = Console.ReadLine();
                if (Int32.Parse(total) > product_list[0].amount)
                {
                    Console.Clear();
                    Console.WriteLine("total given is higher than the amount in location's inventory, type in any key to continue");
                    Console.ReadLine();
                    MakePurchase(location_id, products, order_list, PID);
                }
                else
                {
                    if (order_list == null)
                    {
                        order_list = new List<ProductDTO>();
                    }
                    order_list.Add(new ProductDTO(product_list[0].id, product_list[0].name, Int32.Parse(total), product_list[0].price, product_list[0].description, product_list[0].location_id, product_list[0].createdAt, product_list[0].updatedAt));
                    decimal order_total = 0.00M;
                    foreach (ProductDTO product in order_list)
                    {
                        order_total += (Convert.ToDecimal(product.price) * product.amount);
                    }
                    Console.WriteLine($"Current price in cart equates to: {order_total}");
                    string cart = "";
                    foreach (ProductDTO product in order_list)
                    {
                        cart += ($"x{product.amount} {product.name} ");
                    }
                    Console.WriteLine($"The cart contains: {cart}");
                    Console.WriteLine("Would you like to continue ordering? Y/N/CANCEL");
                    string answer = Console.ReadLine();
                    if(answer.ToUpper() == "Y")
                    {
                        await SeeInventory(location_id.ToString(), order_list);
                    }
                    else if(answer.ToUpper() == "CANCEL")
                    {

                    }
                    else
                    {
                        await ConfirmPurchase(order_list, location_id, order_total.ToString(), cart);
                    }
                    
                }
                Console.Clear();
            }
        }
        private async Task ConfirmPurchase(List<ProductDTO> order_list, int location_id, string session_total, string order_content)
        {
            await CreateCustomer(location_id, session_total, order_content);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri.ToString() + "api/Product/purchase");
            request.Content = JsonContent.Create(order_list);
            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
            }
            // request.Content = JsonContent.Create(new ProductDTO());
        }
        // Customer Methods
        #region
        private async Task CreateCustomer(int location_id, string session_total, string order_content)
        {
            Console.WriteLine("Enter Customer first name:");
            string first_name = Console.ReadLine();
            Console.WriteLine("Enter Customer last name");
            string last_name = Console.ReadLine();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri.ToString() + "api/customer");
            // request.Content = JsonContent.Create(new CustomerDTO(first_name, last_name, session_total, order_content, location_id));
            CustomerDTO customer = new CustomerDTO(first_name, last_name, session_total, order_content, location_id);
            request.Content = JsonContent.Create(customer);
            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
            }
        }
        private async Task DisplayAllCustomersAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "api/customer");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

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
                        Console.WriteLine($"First Name: {customer.first_name} | Last Name: {customer.last_name} | id: {customer.id} | order contents: {customer.order_content} | session total: {customer.session_total}");
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
        private async Task SearchCustomerAsync()
        {
            Console.Clear();
            Console.WriteLine("Search up a customer by either their first or last name:");
            string input = Console.ReadLine();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + $"api/customer/{input}");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                if (response.Content?.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                List<CustomerDTO> customers = await response.Content.ReadFromJsonAsync<List<CustomerDTO>>();
                if (customers != null)
                {
                    Console.WriteLine("Search Results: ");
                    foreach (CustomerDTO customer in customers)
                    {
                        Console.WriteLine($"First Name: {customer.first_name} | Last Name: {customer.last_name} | id: {customer.id} | order contents: {customer.order_content} | session total: {customer.session_total}");
                    }
                }
                else
                {
                    Console.WriteLine("No customers found");
                }
                Console.WriteLine("\n Press any key to continue");
                Console.ReadLine();
                Console.Clear();
            }
        }
        #endregion
        // Location Methods
        #region
        private async Task<List<LocationDTO>>? GetAllLocationsAsync()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + $"api/location/");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                if (response.Content?.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                List<LocationDTO> locations = await response.Content.ReadFromJsonAsync<List<LocationDTO>>();
                if (locations != null)
                {
                    return locations;
                }
                else
                {
                    return null;
                }
            }
        }
        private async Task GetLocationOrdersAsync()
        {
            Console.Clear();
            Console.WriteLine(@"Here are all the store locations and their store id's");
            List<LocationDTO> locations = await GetAllLocationsAsync();
            foreach (LocationDTO location in locations)
            {
                Console.WriteLine($"Location name: {location.name} | location id: {location.id}");
            }
                
            Console.WriteLine("Type in the locations id to get the location's customers/order history");
            int input = Int32.Parse(Console.ReadLine());
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + $"api/location/{input}");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                if (response.Content?.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
                {
                    throw new ArrayTypeMismatchException();
                }

                List<CustomerDTO> customers = await response.Content.ReadFromJsonAsync<List<CustomerDTO>>();
                if (customers != null)
                {
                    foreach (CustomerDTO customer in customers)
                    {
                        Console.WriteLine($"Name: {customer.first_name} {customer.last_name} | Order: {customer.order_content} | Order Total: {customer.session_total}");
                    }
                }
                else
                {
                    Console.WriteLine("No customers found at location");
                }
                Console.WriteLine("\n Press any key to continue");
                Console.ReadLine();
                Console.Clear();
            }
        }
        #endregion
    }
}