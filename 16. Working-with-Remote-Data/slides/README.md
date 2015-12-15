<!-- section start -->
<!-- attr: { class:'slide-title', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Working with Remote Data in UWP
## HttpWebRequest and HttpClient
## JSON.NET and AngleSharp
<div class="signature">
    <p class="signature-course">Windows Applications for Mobile</p>
    <p class="signature-initiative">Telerik Software Academy</p>
    <a href="http://academy.telerik.com" class="signature-link">http://academy.telerik.com</a>
</div>


<!-- section start -->
<!-- attr: { showInPresentation:true, style:'' } -->
# Table of Contents
* Consuming Web Services with C# and UWP
  * Using `WebRequest` and `HttpWebRequest`
  * Using `HttpClient` and `IHttpContent`
* Working with JSON and HTML data
  * `JSON.NET` for JSON
  * `AngleSharp` for HTML

  
<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Consuming Web Services with `C#` and `UWP`


<!-- attr: { showInPresentation:true, style:'font-size:0.95em' } -->
# Consuming Web Services
* Using `WebClient`
  * One-line-of-code GET and POST HTTP requests
  * Easy for use, hard to customize
  * Not available in UWP!
* Using `HttpWebRequest`
  * More configurable than WebClient
  * Nice way of performing ANY HTTP requests
* Using `HttpClient` with `HttpRequestMessage`
  * Look like a native HTTP request
  * Obsoletes `HttpWebRequest` in .NET 4.5
    * Better async operations


<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# The `HttpWebRequest` Class


<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# HttpWebRequest
* `WebClient` is good, but kind of hard to play with REST. Also not supported in UWP.
* `HttpWebRequest` is a class that can access the full power of REST in an easy-to-use way
  * Much more easily configurable than `WebClient`

```cs
// Create the HTTP request
var request = WebRequest.CreateHttp(resourceUrl);
// Configure the HTTP request
request.ContentType = "application/json";
request.Method = "GET";
// Send the request
var response = await request.GetResponseAsync();
// Read the response body
```


<!-- attr: { showInPresentation:true, style:'' } -->
# Working with `HttpWebRequest`
* How does `HttpWebRequest` work?
  * The client (the C# app) builds a `HttpWebRequest` object
  * The client sends the HTTP request to the server
    * Through the `GetResponseAsync()` method
  * Then the server returns a response
    * Wrapped in a `WebResponse` object
  * Accessing the request/response body happens through a `Stream` object

  
<!-- attr: { showInPresentation:true, style:'font-size:0.95em' } -->
# Request/Response body access
* `HttpWebRequest` and `WebResponse` have bodies
  * Data sent to/received from the server
    * e.g. in a POST request
  * `GetRequestStream()`/`GetResponseStream()`
* A `Stream` can be read/written with a `StreamReader`/`StreamWriter`

```cs
var writer = new StreamWriter(request.GetRequestStream());
await writer.WriteAsync(dataString);
writer.Close(); // or put the writer in a using directive
var response = request.GetResponse();
var reader = new StreamReader(response.GetResponseStream());
var data = await reader.ReadToEndAsync();
Console.WriteLine(data);
reader.Close(); // or put the reader in a using directive
```


<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Using `HttpWebRequest` and `WebResponse` in UWP -->
##  [Demo]()


<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# `HttpClient` and `HttpRequestMessage`
##  The new APIs in .NET


<!-- attr: { showInPresentation:true, style:'' } -->
# `HttpClient`
* Modern HTTP client for .NET
  * Use the one in `Windows.Web.Http` for UWP
* Flexible API for accessing HTTP resources
* Has ONLY asynchronous methods
  * Can be used with the new `async`/`await` paradigm
* Sends and receives HTTP requests and responses
  * `HttpRequestMessage`, `HttpResponseMessage`
  * Responses/requests are accessed ONLY async
* Can have defaults configured for requests


<!-- attr: { showInPresentation:true, style:'font-size:0.9em' } -->
<!-- # `HttpClient` (2 ) -->
* Methods for directly sending `GET`, `POST`, `PUT` and `DELETE` requests
  * For commonly used requests
  * No need to construct the request from scratch
* As easy as:
```cs
using Windows.Web.Http;
// ...
private async Task<string> ReadAsString(string url)
{
    var response = await this.httpClient.GetAsync(new Uri(url));
    var result = await response.Content.ReadAsStringAsync();
    return result;
}
```


<!-- attr: { showInPresentation:true, style:'' } -->
# `IHttpContent`
* `IHttpContent` defines the response content
  * `BufferAllAsync();`
  * `ReadAsBufferAsync();`
  * `ReadAsInputStreamAsync();`
  * `ReadAsStringAsync();`
  * `TryComputeLength(out ulong length);`
  * `WriteToStreamAsync(IOutputStream outputStream);`
  * `HttpContentHeaderCollection Headers`


<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Using `HttpClient` in UWP -->
##  [Demo]()


<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# JSON.NET
## How to work with JSON data in UWP


<!-- attr: { showInPresentation:true, style:'' } -->
# JSON.NET
* `JSON.NET` is a popular open source .NET framework for working with JSON data
* `JSON.NET` supports:
  * Serializing .NET objects into JSON objects
  * Deserializing JSON objects into .NET objects
  * LINQ-to-JSON
  * Converting JSON data to and from XML
* `JSON.NET` is also supported in UWP applications


<!-- attr: { showInPresentation:true, style:'' } -->
# Serializing and Deserializing .NET Objects
* Serialization and deserialization of objects is done using methods of the `JsonConvert` facade:

```cs
Person person = new Person
   { FirstName = "Nikolay", LastName = "Kostov", Age = 25 };
string personAsJson = JsonConvert.SerializeObject(person);
// {"FirstName":"Nikolay","LastName":"Kostov","Age":25}

Person personDeserialized = JsonConvert
               .DeserializeObject<Person>(personAsJson);
```


<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Using JSON.NET in UWP -->
##  [Demo]()


<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# AngleSharp
## How to work with HTML data in UWP


<!-- attr: { showInPresentation:true, style:'' } -->
# AngleSharp
* `AngleSharp` is a .NET library that gives you the ability to parse angle bracket based hyper-texts
  * HTML, SVG, MathML
  * XML (without validation) is also supported
  * CSS can also be parsed
* Perfectly portable HTML5 DOM representation of the given source code
  * Built-in CSS query selector
* Similar library: "Html Agility Pack"


<!-- attr: { showInPresentation:true, style:'' } -->
# Parsing and traversing HTML

```cs
// Setup the configuration to support document loading
var config = Configuration.Default.WithDefaultLoader();

// Load the names of all The Big Bang Theory episodes
var address = ".../List_of_The_Big_Bang_Theory_episodes";

// Asynchronously get the document in a new context
var document = await BrowsingContext.New(config)
                                    .OpenAsync(address);

// This CSS selector gets the desired content
var cellSelector = "tr.vevent td:nth-child(3)";

// Perform the query to get all cells with the content
var cells = document.QuerySelectorAll(cellSelector);

// We are only interested in the text
var titles = cells.Select(m => m.TextContent);
```


<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Using AngleSharp in UWP -->
##  [Demo]()


<!-- section start -->
<!-- attr: { id:'questions', class:'slide-section', showInPresentation:true } -->
<!-- # Questions -->
## Working with Remote Data
[link to Telerik Academy Forum](http://telerikacademy.com/Forum/Category/64/windows-mobile-apps)
