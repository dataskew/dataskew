using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WBI
{
    class WBI
    {
        private static readonly string baseAddress = "https://dataskew.azure-api.net/api/Wbi";
        private static readonly string uriFetchLendingTypes = $"{baseAddress}/lendingtypes";
        private static readonly string uriFetchIncomeLevels = $"{baseAddress}/incomelevels";
        private static readonly string uriFetchRegions = $"{baseAddress}/regions";
        private static readonly string uriFetchCountries = $"{baseAddress}/countries";
        private static readonly string uriFetchSources = $"{baseAddress}/sources";
        private static readonly string uriFetchTopics = $"{baseAddress}/topics";

        static readonly string continuationTokenQueryString = "continuationtoken";

        static readonly string continuationTokenHeaderName = "x-ds-continuationtoken";
        static readonly string apiKeyHeaderName = "Ocp-Apim-Subscription-Key";
        static readonly string apiKeyHeaderValue = "YOUR-API-KEY"; // replace with your API key

        static readonly HttpClient httpClient = new HttpClient();

        static async Task FetchIndicatorDataForCountry()
        {
            WaitForUser();
        }

        static async Task FetchIndicatorsForTopic()
        {
            WaitForUser();
        }

        static async Task FetchIndicatorsForSource()
        {
            WaitForUser();
        }

        static async Task FetchCountriesForRegion()
        {
            WaitForUser();
        }

        static async Task FetchCountriesForIncomeLevel()
        {
            WaitForUser();
        }

        static async Task FetchCountriesForLendingType()
        {
            WaitForUser();
        }

        static async Task FetchIndicatorsById()
        {
            WaitForUser();
        }

        static async Task FetchAllIndicators()
        {
            Console.WriteLine("Fetching all Indicators");
            Console.WriteLine("-----------------------");

            WaitForUser();
        }

        static async Task FetchLendingTypesById()
        {
            Console.WriteLine("Fetching Lending Type with id = IDB");
            Console.WriteLine("-----------------------------------");

            var response = await httpClient.GetStringAsync($"{uriFetchLendingTypes}/IDB");
            var token = JToken.Parse(response);
            Console.WriteLine($"{token["id"]} : {token["value"]}");

            WaitForUser();
        }

        static async Task FetchAllLendingTypes()
        {
            Console.WriteLine("Fetching all Lending Types");
            Console.WriteLine("--------------------------");

            var response = await httpClient.GetStringAsync(uriFetchLendingTypes);
            foreach (var token in JArray.Parse(response))
            {
                Console.WriteLine($"{token["id"]} : {token["value"]}");
            }

            WaitForUser();
        }

        static async Task FetchIncomeLevelsById()
        {
            Console.WriteLine("Fetching Income Level with id = LMC");
            Console.WriteLine("-----------------------------------");

            var response = await httpClient.GetStringAsync($"{uriFetchIncomeLevels}/LMC");
            var token = JToken.Parse(response);
            Console.WriteLine($"{token["id"]} : {token["value"]}");

            WaitForUser();
        }

        static async Task FetchAllIncomeLevels()
        {
            Console.WriteLine("Fetching all Income Levels");
            Console.WriteLine("--------------------------");

            var response = await httpClient.GetStringAsync(uriFetchIncomeLevels);
            foreach (var token in JArray.Parse(response))
            {
                Console.WriteLine($"{token["id"]} : {token["value"]}");
            }

            WaitForUser();
        }

        static async Task FetchRegionById()
        {
            Console.WriteLine("Fetching Region with id = NAF");
            Console.WriteLine("-----------------------------");

            var response = await httpClient.GetStringAsync($"{uriFetchRegions}/NAF");
            var token = JToken.Parse(response);
            Console.WriteLine($"{token["id"]} : {token["name"]}");

            WaitForUser();
        }

        static async Task FetchAllRegions()
        {
            Console.WriteLine("Fetching all Regions");
            Console.WriteLine("--------------------");

            var response = await httpClient.GetStringAsync(uriFetchRegions);
            foreach (var token in JArray.Parse(response))
            {
                Console.WriteLine($"{token["id"]} : {token["name"]}");
            }

            WaitForUser();
        }

        static async Task FetchCountryById()
        {
            WaitForUser();
        }

        static async Task FetchAllCountries()
        {
            Console.WriteLine("Fetching all Countries");
            Console.WriteLine("----------------------");

            var response = await httpClient.GetStringAsync(uriFetchCountries);
            foreach (var token in JArray.Parse(response))
            {
                Console.WriteLine($"{token["id"]} : {token["name"]}");
            }

            WaitForUser();
        }

        static async Task FetchTopicById()
        {
            Console.WriteLine("Fetching Topic with id = 10");
            Console.WriteLine("---------------------------");

            var response = await httpClient.GetStringAsync($"{uriFetchTopics}/10");
            var token = JToken.Parse(response);
            Console.WriteLine($"{token["id"]} : {token["value"]}");

            WaitForUser();
        }

        static async Task FetchAllTopics()
        {
            Console.WriteLine("Fetching all Topics");
            Console.WriteLine("-------------------");

            var response = await httpClient.GetStringAsync(uriFetchTopics);
            foreach (var token in JArray.Parse(response))
            {
                Console.WriteLine($"{token["id"]} : {token["value"]}");
            }

            WaitForUser();
        }

        static async Task FetchSourceById()
        {
            Console.WriteLine("Fetching Source with id = 31");
            Console.WriteLine("----------------------------");

            var response = await httpClient.GetStringAsync($"{uriFetchSources}/31");
            var token = JToken.Parse(response);
            Console.WriteLine($"{token["id"]} : {token["name"]}");

            WaitForUser();
        }

        static async Task FetchAllSources()
        {
            Console.WriteLine("Fetching all Sources");
            Console.WriteLine("--------------------");

            var response = await httpClient.GetStringAsync(uriFetchSources);
            foreach (var token in JArray.Parse(response))
            {
                Console.WriteLine($"{token["id"]} : {token["name"]}");
            }

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

            await FetchAllSources();
            await FetchSourceById();
            await FetchAllTopics();
            await FetchTopicById();
            await FetchAllRegions();
            await FetchRegionById();
            await FetchAllIncomeLevels();
            await FetchIncomeLevelsById();
            await FetchAllLendingTypes();
            await FetchLendingTypesById();
            await FetchAllCountries();
            //await FetchCountryById();
            //await FetchCountriesForLendingType();
            //await FetchCountriesForIncomeLevel();
            //await FetchCountriesForRegion();
            //await FetchAllIndicators();
            //await FetchIndicatorsById();
            //await FetchIndicatorsForSource();
            //await FetchIndicatorsForTopic();
            //await FetchIndicatorDataForCountry();
        }
    }
}
