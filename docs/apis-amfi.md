# AMFI APIs
Fetch time-series NAV data from all AMC schemes registered with the [Association of Mutual Funds of India](https://en.wikipedia.org/wiki/Association_of_Mutual_Funds_of_India).

------------------------------

<br>
## Prerequisites
We're assuming that: 
* You have an active subscription to a [pricing tier](./#pricing) and a valid API key. [If not, please follow the steps here](./api-keys).
* You have read the documentation on [API usage patterns in DataSkew APIs](./api-usage).
* You have seen the [sample code](https://github.com/dataskew/dataskew/tree/master/code-samples) on github.

<br>
## Common operations

#### List all AMCs registered with AMFI
* [API documentation](https://dataskew.portal.azure-api.net/docs/services/dataskew-api/operations/ApiAmfiAMCsGet?&groupBy=tag) \| [Try it in the API console](https://dataskew.portal.azure-api.net/docs/services/dataskew-api/operations/ApiAmfiAMCsGet/console)
* An asset management company (AMC a.k.a mutual fund house) offers mutual fund schemes in various scheme categories. Currently, there are about 43 AMCs registered with AMFI. 

#### List all scheme types
* [API documentation](https://dataskew.portal.azure-api.net/docs/services/dataskew-api/operations/ApiAmfiSchemeTypesGet?&groupBy=tag) \| [Try it in the API console](https://dataskew.portal.azure-api.net/docs/services/dataskew-api/operations/ApiAmfiSchemeTypesGet/console)
* Currently, there are 3 mutual fund scheme types (per AMFI classification): open-ended, close-ended and interval.

#### List all scheme categories
* [API documentation](https://dataskew.portal.azure-api.net/docs/services/dataskew-api/operations/ApiAmfiSchemeCategoriesGet?&groupBy=tag) \| [Try it in the API console](https://dataskew.portal.azure-api.net/docs/services/dataskew-api/operations/ApiAmfiSchemeCategoriesGet/console)
* Currently, there are about 55 mutual fund scheme types (per AMFI classification): equity, debt, hybrid, sectoral, growth, income and more.

#### List all schemes
* [API documentation](https://dataskew.portal.azure-api.net/docs/services/dataskew-api/operations/ApiAmfiSchemesGet?&groupBy=tag) \| [Try it in the API console](https://dataskew.portal.azure-api.net/docs/services/dataskew-api/operations/ApiAmfiSchemesGet/console)

#### List all schemes under a specific AMC
* [API documentation](https://dataskew.portal.azure-api.net/docs/services/dataskew-api/operations/ApiAmfiAMCsByAmcidSchemesGet?&groupBy=tag) \| [Try it in the API console](https://dataskew.portal.azure-api.net/docs/services/dataskew-api/operations/ApiAmfiAMCsByAmcidSchemesGet/console)
* Currently, there are 15000+ schemes registered under AMFI. It is very common for some AMCs to have 1000+ schemes under their umbrella.
* The scheme listing will be served in chunks/pages. You'll have to use continuation tokens to fetch the entire list. [Click here for details](./api-usage#paging).

#### List NAVs for a specific scheme
* [API documentation](https://dataskew.portal.azure-api.net/docs/services/dataskew-api/operations/ApiAmfiSchemesBySchemeidNavsGet?&groupBy=tag) \| [Try it in the API console](https://dataskew.portal.azure-api.net/docs/services/dataskew-api/operations/ApiAmfiSchemesBySchemeidNavsGet/console)
* The NAV data will be served in chunks/pages. You'll have to use continuation tokens to fetch the entire list. [Click here for details](./api-usage#paging).
* You can optionally use filters to limit the time-range of NAV data being fetched. [Click here for details](./api-usage#filtering).
* Note: NAV data prior to 1-Jun-2006 has not be made available by AMFI.

<br>
## FAQs on AMFI APIs

#### Have you shared out any sample code on github?
Yes, [click here](https://github.com/dataskew/dataskew/tree/master/code-samples/AMFI).

#### What information is currently unavailable from the AMFI data sets?
Currently, we only provide time-series NAV data for all mutual fund schemes and asset management companies (AMCs) registered with AMFI. The AMFI API does not provide the following data:

* Asset under management (AUM).
* Folios.
* Expense ratio and fees.
* Statistics on performance.
* Scheme renaming.

#### Is this real-time data?
No. For technical reasons, there currently exists a lag of 14 days between:

* AMCs reporting their scheme NAVs to AMFI AND
* The reported NAVs being made available via DataSkew APIs.

#### Why is data prior to 1-Jun-2006 unavailable?
The data prior to 1-Jun-2006 has not be made available by AMFI.

------------------------------