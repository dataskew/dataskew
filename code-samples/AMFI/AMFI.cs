using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataSkew.CodeSamples.AMFI
{
    class AMFI
    {
        private static readonly string baseAddress = "https://dataskew.azure-api.net/api/amfi";
        private static readonly string uriFetchAMCs = $"{baseAddress}/amcs";
        private static readonly string uriFetchSchemeCategories = $"{baseAddress}/schemecategories";
        private static readonly string uriFetchSchemeTypes = $"{baseAddress}/schemetypes";
        private static readonly string uriFetchSchemes = $"{baseAddress}/schemes";

        private static readonly string continuationTokenQueryString = "continuationtoken";

        private static readonly string continuationTokenHeaderName = "x-ds-continuationtoken";
        private static readonly string apiKeyHeaderName = "Ocp-Apim-Subscription-Key";
        private static readonly string apiKeyHeaderValue = "YOUR-API-KEY"; // replace with your API key

        private static readonly HttpClient httpClient = new HttpClient();

        static async Task FetchAllAMCs()
        {
            Console.WriteLine("Fetching all AMCs");
            Console.WriteLine("-----------------");

            var response = await httpClient.GetStringAsync(uriFetchAMCs);
            foreach (var token in JArray.Parse(response))
            {
                Console.WriteLine($"{token["id"]} : {token["name"]}");
            }

            WaitForUser();
        }

        static async Task FetchAMCById()
        {
            Console.WriteLine("Fetching AMC with id = 35");
            Console.WriteLine("-------------------------");

            // fetching AMC with id = 35 (hdfc asset management company limited)
            var response = await httpClient.GetStringAsync($"{uriFetchAMCs}/35");
            var token = JToken.Parse(response);
            Console.WriteLine($"{token["id"]} : {token["name"]}");

            WaitForUser();
        }

        static async Task FetchAllSchemeCategories()
        {
            Console.WriteLine("Fetching all Scheme Categories");
            Console.WriteLine("------------------------------");

            var response = await httpClient.GetStringAsync(uriFetchSchemeCategories);
            foreach (var token in JArray.Parse(response))
            {
                Console.WriteLine($"{token["id"]} : {token["name"]}");
            }

            WaitForUser();
        }

        static async Task FetchSchemeCategoryById()
        {
            // fetching Scheme Category with id = 9 (hybrid scheme - balanced hybrid fund)
            Console.WriteLine("Fetching Scheme Category with id = 9");
            Console.WriteLine("------------------------------------");

            var response = await httpClient.GetStringAsync($"{uriFetchSchemeCategories}/9");
            var token = JToken.Parse(response);
            Console.WriteLine($"{token["id"]} : {token["name"]}");

            WaitForUser();
        }

        static async Task FetchAllSchemeTypes()
        {
            Console.WriteLine("Fetching all Scheme Types");
            Console.WriteLine("-------------------------");

            var response = await httpClient.GetStringAsync(uriFetchSchemeTypes);
            foreach (var token in JArray.Parse(response))
            {
                Console.WriteLine($"{token["id"]} : {token["name"]}");
            }

            WaitForUser();
        }

        static async Task FetchSchemeTypeById()
        {
            // fetching Scheme Type with id = 2 (close ended)
            Console.WriteLine("Fetching Scheme Type with id = 2");
            Console.WriteLine("--------------------------------");

            var response = await httpClient.GetStringAsync($"{uriFetchSchemeTypes}/2");
            var token = JToken.Parse(response);
            Console.WriteLine($"{token["id"]} : {token["name"]}");

            WaitForUser();
        }

        static async Task FetchSchemesForAMC()
        {
            // fetching all Schemes for AMC with id = 9 (hdfc asset management company limited)
            Console.WriteLine("Fetching Schemes for AMC with id = 9");
            Console.WriteLine("------------------------------------");

            var response = await httpClient.GetStringAsync($"{uriFetchAMCs}/9/schemes");
            foreach (var token in JArray.Parse(response))
            {
                Console.WriteLine($"{token["id"]} : {token["name"]}  : {token["navName"]}");
            }

            WaitForUser();
        }

        /// <remarks>
        /// Demonstrates paging for large time-series datasets.
        /// </remarks>
        static async Task FetchNAVsforScheme()
        {
            // fetching all NAVs for Scheme with id = 100038 
            // (Aditya Birla Sun Life Income Fund : Aditya Birla Sun Life Income Fund - Growth - Regular Plan)
            Console.WriteLine("Fetching NAVs for AMC with id = 9");
            Console.WriteLine("---------------------------------");

            var continuationToken = string.Empty;
            do
            {
                var uri = string.Concat(
                    uriFetchSchemes,
                    "/100038/navs",
                    !string.IsNullOrWhiteSpace(continuationToken)
                        ? $"?{continuationTokenQueryString}={continuationToken}"
                        : string.Empty);

                var response = await httpClient.GetAsync(uri);
                foreach (var token in JArray.Parse(await response.Content.ReadAsStringAsync()))
                {
                    var reportingDate = DateTime.Parse((string)token["reportingDate"]).ToShortDateString();
                    var nav = token["nav"];
                    Console.WriteLine($"{reportingDate} : {nav}");
                }

                IEnumerable<string> headerValues = new List<string>();
                continuationToken = response.Headers.TryGetValues(continuationTokenHeaderName, out headerValues)
                    ? headerValues.First()
                    : string.Empty;
            }
            while (!string.IsNullOrWhiteSpace(continuationToken));

            WaitForUser();
        }

        static void WaitForUser()
        {
            Console.WriteLine("");
            Console.WriteLine("Press 'Enter / Return' key to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        /// <remarks>
        /// We're assuming that API key is tied to Preview-tier, hence no authorization needed.
        /// </remarks>
        public static async Task Main()
        {
            httpClient.DefaultRequestHeaders.Add(apiKeyHeaderName, apiKeyHeaderValue);

            await FetchAllSchemeCategories();
            await FetchSchemeCategoryById();
            await FetchAllSchemeTypes();
            await FetchSchemeTypeById();
            await FetchAllAMCs();
            await FetchAMCById();
            await FetchSchemesForAMC();
            await FetchNAVsforScheme();
        }
    }
}
