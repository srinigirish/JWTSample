using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static ConsoleAppClient.Models;

namespace ConsoleAppClient
{
    class Program
    {

        //URL pointer to GatewayAPI 
        static readonly string _gwapibaseUrl = "https://localhost:44396";
        static HttpClient _httpclient = new HttpClient();

        static async Task<AuthenticationSecurityToken> Authenticate(Login login)
        {
            var response = await _httpclient.PostAsJsonAsync($"/authentication/authenticate", new { Username = login.UserName, Password = login.Password });
            var token = await response.Content.ReadAsStringAsync();
            return new AuthenticationSecurityToken { auth_token = token };
            
        }

        static void Main(string[] args)
        {
            InvokeAsync().Wait();
        }

        static async Task InvokeAsync()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Authentication using JSON Web Token");

            //Set the Attributes for HttpClient
            _httpclient.BaseAddress = new Uri(_gwapibaseUrl);
            _httpclient.DefaultRequestHeaders.Accept.Clear();
            _httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                //Read Login Credentials
                var login = AcquireLoginInfo();

                //Authenticate the user
                var accessToken = await Authenticate(login);

                _httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken.auth_token);
                Console.WriteLine("\n Login Successfull.");
                Console.WriteLine();
                Console.WriteLine("JWT Token Returned is....");
                Console.WriteLine();
                Console.WriteLine(accessToken.auth_token);
                Console.WriteLine();
                Console.WriteLine("Split and Display Individual parts of the token");
                Console.WriteLine();

                //Returned token is in format [Header].[PayLoad].[Signature]

                string[] token = accessToken.auth_token.Split(".");
                Console.WriteLine("JWT Header is:{0}", token[0]);
                Console.WriteLine();
                Console.WriteLine("JWT Payload is:{0}", token[1]);
                Console.WriteLine();
                Console.WriteLine("JWT Signature is:{0}", token[2]);



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("App interrupted.");
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("Finished Displaying individual components of JWT Token");
            }

            Console.ReadLine();

        }
        static Login AcquireLoginInfo()
        {
            Console.WriteLine();
            Console.Write("Enter Login user name: ");
            var username = Console.ReadLine();
            Console.Write("Enter Login password: ");
            var password = Console.ReadLine();
            return new Login() { UserName = username, Password = password };
        }


    }
}
