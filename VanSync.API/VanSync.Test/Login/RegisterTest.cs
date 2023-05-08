using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using VanSync.Domain.Models;
using VanSyncTests;

namespace VanSync.Test.Login
{
    public class RegisterTest
    {
        private static readonly string _token = "";

        [Fact]
        public async Task Register()
        {
            await using var application = new VanSyncApplication();

            using var client = application.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            LoginModel login = new LoginModel()
            {
                Id = Guid.NewGuid(),
                Name = "Alexandre",
                Email = "alexandre@outlook.com",
                Password = "12345",
                ConfirmPassword = "12345"
            };

            var response = await client.PostAsync("v1/login/register", new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = JsonConvert.DeserializeObject<LoginModel>(await response.Content.ReadAsStringAsync());

            if (result != null)
                Assert.True(true);
        }
    }
}
