﻿
using System.Text;
using System.Text.Json;
using System.Windows.Input;
using net_core_7_maui_rest_demo_2024.MVVM.Models;

namespace net_core_7_maui_rest_demo_2024.MVVM.ViewModels
{
	public class MainViewModel
	{
		private readonly HttpClient _client;
		private readonly JsonSerializerOptions _serializerOptions;
		private readonly string _baseUrl;

		public MainViewModel()
		{
			_client = new HttpClient();
			_baseUrl = "https://643c164570ea0e6602a1163e.mockapi.io";
			_serializerOptions = new JsonSerializerOptions
			{
				WriteIndented = true,
				PropertyNameCaseInsensitive = true
			};

        }

		public ICommand GetAllUsersCommand => new Command(async () =>
		{
			var response = await _client.GetAsync($"{_baseUrl}/users");

			if (response.IsSuccessStatusCode)
			{
				using (var responseStream = await response.Content.ReadAsStreamAsync())
				{
                    var content = await JsonSerializer.DeserializeAsync<List<User>>(responseStream, _serializerOptions);
                }
			}
		});

		public ICommand GetSingleUserCommand => new Command(async () =>
		{
			var response = await _client.GetAsync($"{_baseUrl}/users/10");
			if (response.IsSuccessStatusCode)
			{
				using (var responseStream = await response.Content.ReadAsStreamAsync())
				{
					var data = await JsonSerializer.DeserializeAsync<User>(responseStream, _serializerOptions);
				}
			}
		});

		public ICommand AddUserCommand => new Command(async () =>
		{
			var user = new User
			{
				CreatedAt = DateTime.UtcNow,
				Name = "Test",
				Avatar = "https://fakeimg.pl/350x200/?text=MAUI"
			};
			var json = JsonSerializer.Serialize(user, _serializerOptions);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await _client.PostAsync($"{_baseUrl}/users", content);

        });
	}
}

