using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace StoneTrackAdmin.Utilites
{
    public interface IBasicUtility
    {
        string UploadImage(IFormFile file, string folderName);
        Task<string> UploadFile(IFormFile formFile, string FolderName);
        string ImageToBase64(IFormFile file);
        string Base64ToImage(string imagedata, string foldername);
        Task<string> SendOtp();
        Task<string> GenerateJobNo();
        Task SendSmsAsync(string number, string message, string templateid);
        void SendPushNotification(string deviceId, string description, string heading, string type, int ID);
        string GenrateForgetPasswordEmail(string Url);
        string GenrateOTPEmailTamplet(string OTP);
        string GenrateOrderEmailTamplet(int OrderId, string CustomerName, string ServiceName, decimal TotalAmount, DateTime OrderDate);
        string GenrateEmailUploadDoucmentTamplet(string CustomerName, string ServiceName);
    }
    public class BasicUtility : IBasicUtility
    {
        [Obsolete]
        private IHostingEnvironment _env;
        public IConfiguration _configuration;
        [Obsolete]
        public BasicUtility(IHostingEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
        }

        [Obsolete]
        public async Task<string> UploadFile(IFormFile formFile, string FolderName)
        {

            string fileName = Path.GetFileNameWithoutExtension(formFile.FileName);
            string fileExt = Path.GetExtension(formFile.FileName);
            //var newFilename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + filetype;
            string filedir = Path.Combine(_env.WebRootPath, FolderName);
            if (!Directory.Exists(filedir))
            { //check if the folder exists;
                Directory.CreateDirectory(filedir);
            }
            var filePath = Path.Combine(filedir) + $@"\{formFile.FileName}";
            string Url = filePath.Replace(filePath, "/" + FolderName + "/" + formFile.FileName);
            if (formFile.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
            return Url;
        }


        [Obsolete]
        public string UploadImage(IFormFile postedFile, string folderName)
        {
            string filePath = "";
            try
            {
                string path = Path.Combine(_env.WebRootPath, folderName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //Save the uploaded Excel file.
                string fileName = Path.GetFileNameWithoutExtension(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                filePath = Path.Combine(path, fileName + DateTime.Now.ToString("yyyyMMddHHmmss") + extension);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return filePath;
        }
        public string ImageToBase64(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                string s = Convert.ToBase64String(fileBytes);
                // act on the Base64 data
                return s;
            }
        }
        public string Base64ToImage(string imagedata, string foldername)
        {
            string extension = "";
            string cleandata = "";
            if (imagedata.Contains("data:image/png;base64"))
            {
                cleandata = imagedata.Replace("data:image/png;base64,", "");
                extension = ".png";
            }
            else if (imagedata.Contains("data:image/jpeg;base64"))
            {
                cleandata = imagedata.Replace("data:image/jpeg;base64,", "");
                extension = ".jpeg";
            }
            else if (imagedata.Contains("data:image/jpg;base64"))
            {
                cleandata = imagedata.Replace("data:image/jpg;base64,", "");
                extension = ".jpg";
            }
            else
            {
                cleandata = imagedata.Replace("data:image/jpeg;base64,", "");
                extension = ".jpeg";
            }
            var bytes = Convert.FromBase64String(cleandata);// a.base64image 
            string filedir = "";
            filedir = Path.Combine(_env.WebRootPath, foldername);
            if (!Directory.Exists(filedir))
            { //check if the folder exists;
                Directory.CreateDirectory(filedir);
            }
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            string fff = GuidString;
            string getDat = fff.Replace("/", "");
            string getDat1 = getDat.Replace(":", "");
            string getDat2 = getDat1.Replace(" ", "");
            string filePath = Path.Combine(filedir, getDat2 + extension);
            string Url = filePath.Replace(filePath, "/" + foldername + "/" + getDat2 + extension);
            if (bytes.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                }
            }
            return Url;
        }

        public async Task<string> SendOtp()
        {
            try
            {
                string numbers = "1234567890";
                string characters = numbers;
                characters += numbers;
                string otp = string.Empty;
                int length = 4;
                for (int i = 0; i < length; i++)
                {
                    string character = string.Empty;
                    do
                    {
                        int index = new Random().Next(0, characters.Length);
                        character = characters.ToCharArray()[index].ToString();
                    } while (otp.IndexOf(character) != -1);
                    otp += character;
                }
                return otp;

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GenerateJobNo()
        {
            try
            {
                string numbers = "1234567890";
                string characters = numbers;
                characters += numbers;
                string otp = string.Empty;
                int length = 6;
                for (int i = 0; i < length; i++)
                {
                    string character = string.Empty;
                    do
                    {
                        int index = new Random().Next(0, characters.Length);
                        character = characters.ToCharArray()[index].ToString();
                    } while (otp.IndexOf(character) != -1);
                    otp += character;
                }
                return otp;

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task SendSmsAsync(string number, string message, string templateid)
        {
            String sURL = "";
            System.IO.StreamReader objReader;

            sURL = "http://msg.pwasms.com/app/smsapi/index.php?key=25F203550DC8E7&campaign=0&routeid=9&type=text&contacts=" + number + "&senderid=SGKCAK&msg=" + message + "&template_id=" + templateid + "";
            System.Net.WebRequest wrGETURL;
            wrGETURL = System.Net.WebRequest.Create(sURL);
            try
            {
                System.IO.Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                objReader = new System.IO.StreamReader(objStream);
                objReader.Close();
                return Task.FromResult(1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SendPushNotification(string deviceId, string description, string heading, string type, int ID)
        {
            try
            {
                string serverKey = _configuration.GetSection("FireBaseKey")["ServerKey"];
                string senderId = _configuration.GetSection("FireBaseKey")["SenderId"];

                const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
                const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
                ServicePointManager.SecurityProtocol = Tls12;
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentType = "application/json";

                string postbody = null;
                {
                    var payload = new
                    {

                        to = deviceId,
                        priority = "high",
                        content_available = true,
                        notification = new
                        {
                            message = description,
                            title = heading,
                            badge = 1,
                            type = type,
                            ID = ID,
                            sound = "default",

                        },
                    };
                    postbody = JsonConvert.SerializeObject(payload).ToString();
                }

                Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                {
                                    String sResponseFromServer = tReader.ReadToEnd();
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GenrateForgetPasswordEmail(string Url)
        {
            var htmlFilePath = _env.WebRootFileProvider.GetFileInfo("/EmailHtmlTemplate/forget_password_email_templet.html")?.PhysicalPath;
            var fileContent = System.IO.File.ReadAllText(htmlFilePath);
            var replaceContent = fileContent.Replace("RESET_LINK_HERE", Url);

            return replaceContent;
        }

        public string GenrateOTPEmailTamplet(string OTP)
        {
            var htmlFilePath = _env.WebRootFileProvider.GetFileInfo("/EmailHtmlTemplate/EmailOTPVerification.html")?.PhysicalPath;
            var fileContent = System.IO.File.ReadAllText(htmlFilePath);
            var replaceContent = fileContent.Replace("123456", OTP);
            return replaceContent;
        }
        // result.CustomerName, result.ServiceName, result.TotalAmount,
        [Obsolete]
        public string GenrateOrderEmailTamplet(int OrderId, string CustomerName, string ServiceName, decimal TotalAmount, DateTime OrderDate)
        {
            var htmlFilePath = _env.WebRootFileProvider.GetFileInfo("/EmailHtmlTemplate/Send_OrderEmail.html")?.PhysicalPath;
            var fileContent = System.IO.File.ReadAllText(htmlFilePath);
            var Uname = fileContent.Replace("UserName", CustomerName);
            var OrderId1 = Uname.Replace("OrderId", OrderId.ToString());
            var ServiceName1 = OrderId1.Replace("ServiceName", ServiceName);
            var Amount1 = ServiceName1.Replace("Price1", TotalAmount.ToString());
            var OrderDate1 = Amount1.Replace("OrderDate", OrderDate.ToString("dd MMM yyyy hh:mm tt"));
            return OrderDate1;
        }

        [Obsolete]
        public string GenrateEmailUploadDoucmentTamplet( string CustomerName, string ServiceName)
        {
            var htmlFilePath = _env.WebRootFileProvider.GetFileInfo("/EmailHtmlTemplate/SendEmail_UploadDoucment.html")?.PhysicalPath;
            var fileContent = System.IO.File.ReadAllText(htmlFilePath);
            var Uname = fileContent.Replace("UserName", CustomerName);
            var OrderId1 = Uname.Replace("ServiceName", ServiceName);
            return OrderId1;
        }
    }
}


