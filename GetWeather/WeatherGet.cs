using GetWeather;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

class WeatherGet {

	static async Task Main()
	{
		string city;

		city = Console.ReadLine();

		if (string.IsNullOrWhiteSpace(city))
		{
			city = "London";
			Console.WriteLine("Automaticly taked city is London");
		}

		string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=c0cfb8afcec18b5aa1c71d6dbb0e2b98&units=metric";

		using HttpClient client = new HttpClient();

		try
		{
			HttpResponseMessage response = await client.GetAsync(url);

			if (response.StatusCode == HttpStatusCode.OK)
			{
				var result = await response.Content.ReadAsStringAsync();

				var weatherData = JsonSerializer.Deserialize<ApiResponce>(result);

				if (weatherData != null)
				{
					Console.WriteLine($"City name: {weatherData.Name}\n" +
						$"Min temperature: {weatherData.Main.MinTemp}\n" +
						$"Current temperature: {weatherData.Main.Temp}\n" +
						$"Feeling temperature: {weatherData.Main.FeelingTemp}\n" +
						$"Max temperature: {weatherData.Main.MaxTemp}");
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Somthing wrong... ({ex.Message})");
		}
	}
}

