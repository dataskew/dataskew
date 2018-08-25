# Code Samples
@Todo

------------------------------

<br>
## Prerequisites
We're assuming that you have: 
* An active subscription to a [pricing tier](./#pricing) and a valid API key. [If not, please follow the steps here](./get-api-keys).
* You've installed tools that'll enable you to make API calls: curl or [postman](https://www.getpostman.com/) or [fiddler](https://www.telerik.com/fiddler). And that you have familiarity with those tools.

<br>
## Making your first API call
Let us start with a very simple example. 

Let's assume your subscription (and API key) gives you access to the [AMFI APIs](./apis-amfi). Say, you're interested in fetching the list of AMCs (asset management companies) registered with AMFI. 

1. Figure out the API url to call: @Todo

2. Set your API key in the request header as follows:
```
ocp-apim-subscription-key: {your api key}
```
3. Make the API call.
![Sending GET request to DataSkew server](./images/code-samples-1.jpg)

4. The server sends the response in JSON format.
![Getting response from DataSkew server](./images/code-samples-2.jpg)


<br>
## Usage notes

#### Authentication

#### Paging
Server-side paging is supported. 

* If the collection being returned has more than 1000 items, then the API returns the collection in chunks/pages of 1000 items each (note: this number is not configurable at present).

* The response headers will then contain **```x-ds-continuationtoken```**, which is a continuation token required to fetch the next chunk. Note that this token value is opaque and will changes on each subsequent chunk.  
![In case of paging, the server response contains a continuation token in the header](./images/code-samples-3.jpg)

* In order to retrieve the next chunk, the client must specify the last returned continuation token value as query parameter **```continuationtoken```** in their next request.
![Specify the continuation token value as query string parameter in next call](./images/code-samples-4.jpg)

* If the server response does not return a **```x-ds-continuationtoken```** header, then it means that the current chunk/page is the last one in the collection. 

#### Filtering
At present, server-side filtering is not supported. You'll have to filter the data on the client-side.

#### Sorting
At present, server-side sorting is not supported. You'll have to sort the data on the client-side.

#### Headers

#### OpenAPI (swagger) definitions

<br>
## FAQs on code samples

#### Can I test the APIs without writing code (or using curl)?
Yes, you can use the API console on the DataSkew dev portal. @Todo

#### Do you also have an Java/C#/Python/JS SDK?
Not yet. Currently, we only have REST APIs. But we plan to ship SDKs in the future. Please watch this space.


<br>
_Please also check out our main [FAQs](./faqs) page._

------------------------------