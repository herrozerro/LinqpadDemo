<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationUI.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\ReachFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Configuration.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\System.Printing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\UIAutomationProvider.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\UIAutomationTypes.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
  <Namespace>System.Windows.Forms.Integration</Namespace>
</Query>

void Main()
{
	var w = new Window();
	var i = 0;
	var button = null as Button;
	var searchBox = null as TextBox;
	var textBlock = null as TextBlock;
	var searchPanel = new StackPanel{
		MaxWidth = 400
	};
	var stackPanel = new StackPanel
	{
		MaxWidth = 400,
		Children =
		{
			(button = new Button{ Content = "Search" }),
			(searchBox = new TextBox(){IsEnabled = true}),
			(searchPanel)
		}
	};

	button.Click += async (s, e) => 
		{
			var locData = await GetData(searchBox.Text);
			var component = new StackPanel{
				Children = {
					(new TextBlock{Text = locData.Name}),
					(new TextBlock{Text = locData.Lat}),
					(new TextBlock{Text = locData.Lon}),
					(new TextBlock{Text = locData.Address}),
				}
			};
			searchPanel.Children.Clear();
			searchPanel.Children.Add(component);
		};
	
	//stackPanel.Dump();
	
	w.Content = stackPanel;
	ElementHost.EnableModelessKeyboardInterop(w);
	w.Show();
}

// Define other methods and classes here
public static HttpClient client = new HttpClient() { BaseAddress = new Uri("https://maps.googleapis.com/maps/api/place/")};

public async Task<LocData> GetData(string searchQuery){
		
	var apikey = "".apiKey();
	
	var inputstring = searchQuery;

	var querystring = $"findplacefromtext/json?input={inputstring}&inputtype=textquery&fields=name,geometry,formatted_address,type&key={apikey}";
	
	var result = await client.GetAsync(querystring);

	var str = await result.Content.ReadAsStringAsync();
	
	JToken jsn = JToken.Parse(str);
	
	LocData ld = new LocData();
	
	ld.Name = (string)jsn["candidates"][0]["name"];
	ld.Address = (string)jsn["candidates"][0]["formatted_address"];
	ld.Lat = (string)jsn["candidates"][0]["geometry"]["location"]["lat"];
	ld.Lon = (string)jsn["candidates"][0]["geometry"]["location"]["lng"];
	ld.Type = (string)jsn["candidates"][0]["type"];
	
	return ld;
}

public class LocData{
	public string Name {get;set;}
	public string Lat {get;set;}
	public string Lon {get;set;}
	public string Address {get;set;}
	public string Type {get;set;}
}