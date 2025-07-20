using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using LIBWEATHER.GETWEATHER;
using log = LIBWEATHER.LogManager.LogManager;
using LIBWEATHER.DBase;


namespace LIBWEATHER
{

    public static class Main
    {
        public static void GETWEATHER()
        {
            /*тут надо подумать как получать ссылку с гис метео.*/
            string url = "https://services.gismeteo.ru/inform-service/inf_chrome/forecast/?city=13051&lang=ru";
            string filePath = "weather.xml";
            var request = WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/xml";
            Stream responseStream = null;
            try
            {
                /// Получаем ответ 
                var response = request.GetResponse();
                responseStream = response.GetResponseStream();

            }
            catch (WebException ex)
            {
                log.WriteException(ex);
                return;
            }

            if (responseStream == null)
            {
                log.Write("Пришел пустой ответ от сервера " + url);
                return;
            }

            /*делаю запоминалку для потока*/
            using MemoryStream stream = new MemoryStream();
            responseStream.CopyTo(stream);
            stream.Position = 0;


            string response_string = string.Empty;
            using (var reader = new StreamReader(stream, System.Text.Encoding.UTF8))
            {
                response_string = reader.ReadToEnd();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Weather));
            try
            {
                using var reader = new StringReader(response_string);
                Weather weather = (Weather)serializer.Deserialize(reader);
                ///записываем погоду 
                var sql = new SqlLight();
                int weather_id = sql.InsertWeatherInDB(response_string: response_string);
                if (weather_id > 0)
                {
                    log.Write("Данные о погоде получены и блогополучно записаны в таблицу weather.");
                    /// записываем все остальное. 
                    if (weather != null)
                        sql.InsertLocationIndDB(weather_id: weather_id, weather: weather);
                }
                else
                {
                    throw new Exception("Не удалось записать данные о погоде в БД.");
                }
                // save dataBase

            }
            catch
            (Exception ex)
            {
                log.WriteException(ex);
            }
        }
    }
}
