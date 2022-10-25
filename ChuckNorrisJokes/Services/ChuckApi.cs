using ChuckNorrisJokes.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChuckNorrisJokes.Services
{
    public class ChuckApi
    {

        public ChuckApi() { }

        public JokeModel GetChuckJoke()
        {
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random"),
				Headers =
				{
					{ "accept", "application/json" },
					{ "X-RapidAPI-Key", "fe96c29976msh7164fa7f072bef1p19efc6jsn0ad83cbe2bb2" },
					{ "X-RapidAPI-Host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com" },
				},
			};

			using (var response =  client.SendAsync(request).Result)
			{
				response.EnsureSuccessStatusCode();
				var body =  response.Content.ReadAsStringAsync().Result;

				var joke = JsonConvert.DeserializeObject<ApiResults>(body);

				var jokeModel = new JokeModel();

				jokeModel.IconUrl = joke.icon_url;
				jokeModel.Value = joke.value;

				return jokeModel;
			}


		}







    }
}
