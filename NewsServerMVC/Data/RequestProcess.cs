using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewsServerMVC.Data
{
    public class RequestProcess
    {
        public static String Serializer(List<Models.NewsModel> values)
        {
            
            string jsonData = JsonConvert.SerializeObject(values);
            jsonData = Regex.Unescape(jsonData);
            return jsonData;
        }

        public static String SerializerRate(List<Models.NewsRateModel> valuesRate)
        {
            string jsonDataRate = JsonConvert.SerializeObject(valuesRate);
            return jsonDataRate;
        }

        public static int CreateNews(int newsId, string newsTitle, string newsContent, string newsTopic, string newsImage, DateTime newsDate)
        {
            if (newsId != 0)
            {
            Models.NewsModel data = new Models.NewsModel
            {
                newsId = newsId,
                newsTitle = newsTitle,
                newsContent = newsContent,
                newsTopic = newsTopic,
                newsImage = newsImage,
                newsDate = newsDate
            };

            string sql = @"insert into News (newsId, newsTitle, newsContent, newsTopic, newsImageUrl, newsDate) values (@newsId, @newsTitle, @newsContent, @newsTopic, @newsImage, @newsDate)";

            return DataAccess.SaveData(sql, data);
            }
            return '0';
        }

        public static List<Models.NewsModel> LoadValues()
        {
            string sql = @"select newsId, newsTitle, newsTopic, newsDate from News;";

            return DataAccess.LoadData<Models.NewsModel>(sql);
        }

        public static List<Models.NewsModel> LoadValuesInt(int newsId)
        {
            string sql = @"select newsId, newsTitle, newsTopic, newsDate from News;";
            if (newsId != 0)
            {
                sql = @"select newsId, newsTitle, newsTopic, newsDate from News where newsId = " + newsId + ";";
            }
            return DataAccess.LoadData<Models.NewsModel>(sql);
        }

        public static List<Models.NewsModel> LoadValuesString(String newsTopic)
        {
            string sql = @"select newsId, newsTitle, newsTopic, newsDate from News;";

                sql = @"select newsId, newsTitle, newsTopic, newsDate from News where newsTopic = '" + newsTopic + "';";
            
            return DataAccess.LoadData<Models.NewsModel>(sql);
        }

        public static List<Models.NewsRateModel> LoadValuesRate(int newsId)
        {
            string sql = @"select newsId, likes, dislikes, viewCount from NewsRate;";
            if (newsId != 0)
            {
                sql = @"select newsId, likes, dislikes, viewCount from NewsRate;";
            }
            return DataAccess.LoadData<Models.NewsRateModel>(sql);
        }
    }
}
