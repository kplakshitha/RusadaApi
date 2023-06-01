using Microsoft.AspNetCore.Hosting;
using static System.Net.Mime.MediaTypeNames;
using System.Buffers.Text;

namespace Business.Services
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment env;

        public FileService(IHostingEnvironment env)
        {
            this.env = env;
        }

        public string Base64ToImage(string imagestr)
        {
            var strImage = imagestr.Split("base64,")[1];
            var fileName = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            var folderPath = Path.Combine(env.WebRootPath, "imgs");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            File.WriteAllBytes(Path.Combine(folderPath, $"{fileName}.jpg"), Convert.FromBase64String(strImage));
            return $"{fileName}.jpg";
        }
    }
}
