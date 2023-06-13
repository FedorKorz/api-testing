using JsonPlaceholderTask.api;
using JsonPlaceholderTask.models;
using NUnit.Framework;
using System.Net;

namespace JsonPlaceholderTask.tests
{
    public class Tests : BaseTest
    {
        ApiMethods apiMethods = new ApiMethods();

        private string expectedName = TestDataModel.User().SelectToken("name")!.ToString();
        private string expectedUsername = TestDataModel.User().SelectToken("username")!.ToString();
        private string expectedEmail = TestDataModel.User().SelectToken("email")!.ToString();
        private string expectedPhone = TestDataModel.User().SelectToken("phone")!.ToString();
        private string expectedWebsite = TestDataModel.User().SelectToken("website")!.ToString();

        [Test]
        [TestCase("id")]
        public void TestGetAllPosts(string orderedBy)
        {
            var response = apiMethods.GetAllPosts();
            List<Post> ExpectedPosts = response.Posts.OrderBy(p => p.id).ToList();
            List<Post> ActualPosts = response.Posts;

            Assert.That(response.HTTPResponseCode.Equals(HttpStatusCode.OK), "HTTP response code is not OK");
            Assert.That(response.ContentType.Contains("json"), Is.True, "Respone type isn't JSON");
            Assert.That(ActualPosts, Is.EqualTo(ExpectedPosts), "Issue related to sort with actual posts");
            Assert.That(response.Posts, Is.Ordered.Ascending.By(orderedBy), "Posts aren't sorted");
            Assert.That(response.Posts, Is.Not.Ordered.Descending.By(orderedBy), "Posts are sorted in descending order");
        }


        [Test]
        [TestCase(99)]
        public void TestGetPost99(int index)
        {
            var response = apiMethods.GetSpecificPost(index);
            Assert.That(response.title, Is.Not.Empty, "Title of 99th post is empty");
            Assert.That(response.body, Is.Not.Empty, "Body of 99th post is empty");
            Assert.IsNotNull(response.id, "id of 99th post is empty");
            Assert.IsNotNull(response.userId, "id of 99th post is empty");
            Assert.That(response.HTTPResponseCode, Is.EqualTo(HttpStatusCode.OK), "The post hasn't been created");
        }


        [Test]
        [TestCase(150)]
        public void TestGetPost(int index)
        {
            var response = apiMethods.Get150thPost(index);
            Assert.That(TestDataModel.EmptyResponse(), Is.EqualTo(response.Content), $"Post {index} is Exist!");
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), $"The user {index} has been found");
        }

        [Test]
        public void TestPostUserInfo()
        {
            var response = apiMethods.MakeAPost();
            Assert.That(response.userId, Is.EqualTo(1), "User's id is not equal to test data");
            Assert.That(response.title, Is.EqualTo("Test Post"), "Title is not equal to test data");
            Assert.That(response.id, Is.EqualTo(101), "Id is not equal to test data");
            Assert.That(response.body, Is.EqualTo("This is a test post created with RestSharp"), "Body is not equal to test data");
        }

        [Test]
        [TestCase(5)]
        public void TestGetUsersInfo(int index)
        {
            var response = apiMethods.GetUser(index);
            Assert.Multiple(() =>
            {
                Assert.That(response.Name, Is.EqualTo(expectedName), "Name is not equal to test data");
                Assert.That(response.Username, Is.EqualTo(expectedUsername), "Username is not equal to test data");
                Assert.That(response.Email, Is.EqualTo(expectedEmail), "Email is not equal to test data");
                Assert.That(response.Phone, Is.EqualTo(expectedPhone), "Phone is not equal to test data");
                Assert.That(response.Website, Is.EqualTo(expectedWebsite), "Website is not equal to test data");
                Assert.That(response.Address.ToString(), Is.EqualTo(TestDataModel.Address()), "Adressess aren't equal");
                Assert.That(response.Company.ToString(), Is.EqualTo(TestDataModel.Company()), "Companies aren't equal");
                Assert.That(response.HTTPResponseCode, Is.EqualTo(HttpStatusCode.OK), "Server's response is incorrect");
            });
        }

        [Test]
        [TestCase(5)]
        public void TestGet5thInfo(int index)
        {
            var response = apiMethods.Get5thUser(index);
            Assert.Multiple(() =>
            {
                Assert.That(response.Name, Is.EqualTo(expectedName), "Name is not equal to test data");
                Assert.That(response.Username, Is.EqualTo(expectedUsername), "Username is not equal to test data");
                Assert.That(response.Email, Is.EqualTo(expectedEmail), "Email is not equal to test data");
                Assert.That(response.Phone, Is.EqualTo(expectedPhone), "Phone is not equal to test data");
                Assert.That(response.Website, Is.EqualTo(expectedWebsite), "Website is not equal to test data");
                Assert.That(response.Address.ToString(), Is.EqualTo(TestDataModel.Address()), "Adressess aren't equal");
                Assert.That(response.Company.ToString(), Is.EqualTo(TestDataModel.Company()), "Companies aren't equal");
                Assert.That(response.HTTPResponseCode, Is.EqualTo(HttpStatusCode.OK), "Server's response is incorrect");
            });
        }
    }

}