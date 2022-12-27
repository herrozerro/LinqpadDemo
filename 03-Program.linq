<Query Kind="Program">
  <NuGetReference>ClosedXML</NuGetReference>
  <NuGetReference>Microsoft.Net.Http</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
</Query>

async Task Main()
{
	var apikey = "".apiKey();

	var inputstring = "Museum of Natural History";

	var querystring = $"findplacefromtext/json?input={inputstring}&inputtype=textquery&fields=name,geometry,formatted_address,type&key={apikey}";

	var client = new HttpClient();
	client.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/place/");

	var result = await client.GetAsync(querystring);

	var str = await result.Content.ReadAsStringAsync();

	str.Dump();

	JObject jsn = JObject.Parse(str);

	var s = (string)jsn["candidates"][0]["name"];
	
	s.Dump();
}

// Define other methods and classes here