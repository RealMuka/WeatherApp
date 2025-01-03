using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GetWeather
{
	public class ApiResponce
	{
		[JsonPropertyName("name")] public string Name { get; set; }

		[JsonPropertyName("main")] public MainInfo Main { get; set; }
	}

	public class MainInfo
	{
		[JsonPropertyName("temp_min")] public float MinTemp { get; set; }

		[JsonPropertyName("temp")] public float Temp { get; set; }

		[JsonPropertyName("feels_like")] public float FeelingTemp { get; set; }

		[JsonPropertyName("temp_max")] public float MaxTemp { get; set; }
	}
}
