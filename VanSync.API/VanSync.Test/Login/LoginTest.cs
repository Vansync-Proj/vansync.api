using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using VanSync.Domain.Models;
using VanSyncTests;

namespace VanSync.Test.Login
{
    public class LoginTest
    {
        private static readonly string _token = "";

        [Fact]
        public async Task Login()
        {
            await using var application = new VanSyncApplication();

            using var client = application.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            LoginModel login = new LoginModel()
            {
                Email = "alexandre@outlook.com",
                Password = "12345"
            };

            var response = await client.PostAsync("v1/login/login", new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = JsonConvert.DeserializeObject<LoginModel>(await response.Content.ReadAsStringAsync());

            if (result != null)
                Assert.True(true);
        }

        [Fact]
        public async Task AlterPassWord()
        {
            await using var application = new VanSyncApplication();

            using var client = application.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            AlterPassWordModel login = new AlterPassWordModel()
            {
                Email = "alexandre@outlook.com",
                OldPassword = "12345",
                NewPassword = "374859",
                ConfirmPasswordNewPassWord = "374859"
            };

            var response = await client.PostAsync("v1/login/alter-password", new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = JsonConvert.DeserializeObject<AlterPassWordModel>(await response.Content.ReadAsStringAsync());

            if (result != null)
                Assert.True(true);
        }
    }
}
