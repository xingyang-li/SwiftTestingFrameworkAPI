using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Newtonsoft.Json;
using SwiftTestingFramework.Utils;
using System.Net.Http;
using System.Reflection;

namespace SwiftTestingFramework 
{
    [TestClass]
    public class SwiftTests
    {
        static readonly HttpClient client = new HttpClient();

        [TestMethod]
        [Description("Run TcpPing against VM from a Windows App")]
        public void TestVMConnectionWindows()
        {
            try
            {
                string testPath = "/PingVM";
                HttpRequestMessage message = new HttpRequestMessage();
                HttpResponseMessage response = Helper.SendRequest(client, Constants.WindowsAppUrl + testPath, HttpMethod.Post);
                response.EnsureSuccessStatusCode();
                string stringBody = response.Content.ReadAsStringAsync().Result;
                TestResponse testResponse = JsonConvert.DeserializeObject<TestResponse>(stringBody);
                Assert.AreEqual(testResponse.TestResult, "Success", testResponse.ErrorMessage);
                Logger.LogMessage("Test Passed");
            }
            catch (Exception ex)
            {
                //Replace with AntaresEventProvider or email send functionality
                Logger.LogMessage(ex.ToString());
                throw;
            }
        }

        [TestMethod]
        [Description("Send a curl request to VM from a Linux App.")]
        public void TestVMConnectionLinux()
        {
            try
            {
                string testPath = "/PingVM";
                HttpRequestMessage message = new HttpRequestMessage();
                HttpResponseMessage response = Helper.SendRequest(client, Constants.LinuxAppUrl + testPath, HttpMethod.Post);
                response.EnsureSuccessStatusCode();
                string stringBody = response.Content.ReadAsStringAsync().Result;
                TestResponse testResponse = JsonConvert.DeserializeObject<TestResponse>(stringBody);
                Assert.AreEqual(testResponse.TestResult, "Success", testResponse.ErrorMessage);
            }
            catch (Exception ex)
            {
                //Replace with AntaresEventProvider or email send functionality
                Logger.LogMessage(ex.ToString());
                throw;
            }
        }

        [TestMethod]
        [Description("Upload an empty 512B page blob to a container in the storage account")]
        public void TestStorageUpload()
        {
            try
            {
                string testPath = "/StorageUpload";
                HttpRequestMessage message = new HttpRequestMessage();
                HttpResponseMessage response = Helper.SendRequest(client, Constants.WindowsAppUrl + testPath, HttpMethod.Post);
                response.EnsureSuccessStatusCode();
                string stringBody = response.Content.ReadAsStringAsync().Result;
                TestResponse testResponse = JsonConvert.DeserializeObject<TestResponse>(stringBody);
                Assert.AreEqual(testResponse.TestResult, "Success", testResponse.ErrorMessage);
            }
            catch (Exception ex)
            {
                //Replace with AntaresEventProvider or email send functionality
                Logger.LogMessage(ex.ToString());
                throw;
            }

        }
    }
}

