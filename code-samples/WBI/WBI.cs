using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WBI
{
    class WBI
    {
        private static readonly string baseAddress = "https://dataskew.azure-api.net/api/wbi";
        private static readonly string uriFetchLendingTypes = $"{baseAddress}/lendingtypes";
        private static readonly string uriFetchIncomeLevels = $"{baseAddress}/incomelevels";
        private static readonly string uriFetchRegions = $"{baseAddress}/regions";
        private static readonly string uriFetchCountries = $"{baseAddress}/countries";
        private static readonly string uriFetchSources = $"{baseAddress}/sources";
        private static readonly string uriFetchTopics = $"{baseAddress}/topics";
        private static readonly string uriFetchIndicators = $"{baseAddress}/indicators";

        static readonly string continuationTokenQueryString = "continuationtoken";

        static readonly string continuationTokenHeaderName = "x-ds-continuationtoken";
        static readonly string apiKeyHeaderName = "Ocp-Apim-Subscription-Key";
        static readonly string apiKeyHeaderValue = "YOUR-API-KEY"; // replace with your API key

        static readonly HttpClient httpClient = new HttpClient();

        static async Task FetchIndicatorDataForCountry()
        {
            Console.WriteLine("Fetching data for Indicator '1.1_ACCESS.ELECTRICITY.TOT' for Country 'IND'");
            Console.WriteLine("--------------------------------------------------------------------------");

            var response = await httpClient.GetStringAsync($"{uriFetchCountries}/Ind/indicators/1.1_ACCESS.ELECTRICITY.TOT");
            foreach (var token in JArray.Parse(response))
            {
                Console.WriteLine($"{token["date"]} : {token["value"]}");
            }

            WaitForUser();
        }

        static Task FetchIndicatorsForTopic()
        {
            throw new NotImplementedException();
        }

        static async Task FetchIndicatorsForSource()
        {
            Console.WriteLine("Fetching Indicators for Source with id = 30");
            Console.WriteLine("-------------------------------------------");

            var response = await httpClient.GetStringAsync($"{uriFetchSources}/30/indicators");
            foreach (var token in JArray.Parse(response))
            {
                Console.WriteLine($"{token["id"]} : {token["name"]}");
            }

            WaitForUser();
        }

        static Task FetchCountriesForRegion()
        {
            throw new NotImplementedException();
        }

        static async Task FetchCountriesForIncomeLevel()
        {
            Console.WriteLine("Fetching countries for Income Level id = LMC");
            Console.WriteLine("--------------------------------------------");

            var response = await httpClient.GetStringAsync($"{uriFetchIncomeLevels}/LMC/countries");
            foreach (var token in JArray.Parse(response))
            {
                Console.WriteLine($"{token["id"]} : {token["name"]}");
            }

            WaitForUser();
        }

        static async Task FetchCountriesForLendingType()
        {
            Console.WriteLine("Fetching countries for Lending Type id = IDB");
            Console.WriteLine("--------------------------------------------");

            var response = await httpClient.GetStringAsync($"{uriFetchLendingTypes}/IDB/countries");
            foreach (var token in JArray.Parse(response))
            {
                Console.WriteLine($"{token["id"]} : {token["name"]}");
            }

            WaitForUser();
        }

        static async Task FetchIndicatorsById()
        {
            Console.WriteLine("Fetching Indicator with id = 1.1_ACCESS.ELECTRICITY.TOT");
            Console.WriteLine("-------------------------------------------------------");

            var response = await httpClient.GetStringAsync($"{uriFetchIndicators}/1.1_ACCESS.ELECTRICITY.TOT");
            var token = JToken.Parse(response);
            Console.WriteLine($"{token["id"]} : {token["name"]}");

            WaitForUser();
        }

        /// <remarks>
        /// Demonstrates paging for large time-series datasets.
        /// Note: There are 15000+ indicators, we'll only retrieve the first 2000 for this demo.
        /// </remarks>
        static async Task FetchFirst2500Indicators()
        {
            Console.WriteLine("Fetching first 2000 Indicators");
            Console.WriteLine("------------------------------");

            var count = 0;
            var continuationToken = string.Empty;
            do
            {
                var uri = string.Concat(
                    uriFetchIndicators,
                    !string.IsNullOrWhiteSpace(continuationToken)
                        ? $"?{continuationTokenQueryString}={continuationToken}"
                        : string.Empty);

                var response = await httpClient.GetAsync(uri);
                var tokens = JArray.Parse(await response.Content.ReadAsStringAsync());
                foreach (var token in tokens)
                {
                    Console.WriteLine($"{token["id"]} : {token["name"]}");
                }

                count += tokens.Count;

                IEnumerable<string> headerValues = new List<string>();
                continuationToken = response.Headers.TryGetValues(continuationTokenHeaderName, out headerValues)
                    ? headerValues.First()
                    : string.Empty;
            }
            while (!string.IsNullOrWhiteSpace(continuationToken) || count < 2000);

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
            Console.WriteLine("Fetching Country with id = ARG");
            Console.WriteLine("------------------------------");

            var response = await httpClient.GetStringAsync($"{uriFetchCountries}/ARG");
            var token = JToken.Parse(response);
            Console.WriteLine($"{token["id"]} : {token["name"]}");

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
            await FetchCountryById();
            await FetchCountriesForLendingType();
            await FetchCountriesForIncomeLevel();
            //await FetchCountriesForRegion();
            await FetchFirst2500Indicators();
            await FetchIndicatorsById();
            await FetchIndicatorsForSource();
            //await FetchIndicatorsForTopic();
            await FetchIndicatorDataForCountry();
        }
    }
}
