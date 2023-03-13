using Admin.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Admin
{
    static class WorkWithBD
    {
        public static byte[] ConvertFileToByte(string sPath)
        {
            byte[] data = null;
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)numBytes);
            return data;
        }
        
        public static BitmapSource ConvertByteToImage(byte[] photo)
        {
            using (MemoryStream ms = new MemoryStream(photo))
            {
                var decoder = BitmapDecoder.Create(ms,
                    BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                return decoder.Frames[0];
            }
        }

        public static async void SaveProduct(string _title, string _desc, string _price, string _count,string _photo)
        {
            Prod prod = new Prod()
            {
                Title = _title,
                Description = _desc,
                Price = Convert.ToDecimal(_price),
                Count = Convert.ToInt32(_count),
                Photo = ConvertFileToByte(_photo)
            };
            
            using(var httpClient = new HttpClient())
                await httpClient.PostAsJsonAsync("https://localhost:7236/products", prod);
        
        }

    }
}
