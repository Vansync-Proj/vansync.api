using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using VanSync.Domain.Models;
using VanSyncTests;

namespace VanSync.Test.Admin
{
    public class AdminTest
    {
        private static readonly string _token = "";

        [Fact]
        public async Task RegisterUser()
        {
            await using var application = new VanSyncApplication();

            using var client = application.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            UserModel user = new UserModel()
            {
                Id = Guid.NewGuid(),
                Age = 20,
                Name = "Alexandre Edit",
                Street = "Fermino Belluca",
                Neighborhood = "Portal são josé",
                City = "Barra Bonita",
                NumberHouse = "194-A",
                AmountToPay = 600_50
            };

            var response = await client.PostAsync("v1/admin/register-user", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());

            if (result != null)
                Assert.True(true);
        }

        [Fact]
        public async Task EditUser()
        {
            await using var application = new VanSyncApplication();

            using var client = application.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            UserModel user = new UserModel()
            {
                Id = Guid.NewGuid(),
                Age = 20,
                Name = "Alexandre Edit",
                Street = "Fermino Belluca",
                Neighborhood = "Portal são josé",
                City = "Barra Bonita",
                NumberHouse = "194-A",
                AmountToPay = 600_50
            };

            var response = await client.PostAsync("v1/admin/register-user", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());

            if (result != null)
                Assert.True(true);
        }

        [Fact]
        public async Task DeleteUser()
        {
            await using var application = new VanSyncApplication();

            using var client = application.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            UserModel user = new UserModel() { Id = Guid.NewGuid() };

            var response = await client.PostAsync("v1/admin/delete-user", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());

            if (result != null)
                Assert.True(true);
        }
    }
}
