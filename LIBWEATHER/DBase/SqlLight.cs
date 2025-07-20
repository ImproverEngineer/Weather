using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIBWEATHER.GETWEATHER;
using Microsoft.Data.Sqlite;

namespace LIBWEATHER.DBase
{
    public class SqlLight
    {
        string connectionString = String.Empty;
        public SqlLight()
        {
            connectionString = "Data Source = WEATHER.db";

        }

        public int InsertWeatherInDB(string response_string)
        {
            using (var conneciton = new SqliteConnection(connectionString))
            {
                conneciton.Open();
                SqliteCommand cmd = new();
                cmd.Connection = conneciton;
                cmd.CommandText = "insert into weather(stream) values ('" + response_string + "')";
                int numberCount = cmd.ExecuteNonQuery();
                if (numberCount > 0)
                {
                    /// получаем Id вставленного элемента.
                    cmd.CommandText = "select id from weather order by id desc limit 1";
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                return reader.GetInt32(0);
                            }
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
                return -1;

            }
        }

        public void InsertLocationIndDB(int weather_id, Weather weather)
        {
            using (var conneciton = new SqliteConnection(connectionString))
            {
                conneciton.Open();
                SqliteCommand cmd = new();
                cmd.Connection = conneciton;
                cmd.CommandText = "insert into location( name, name_r, county_id, country_name, district_id, district_name, kind, lat, lng, tzone, cur_time, nowcast_url, nowcast_teaser, weather_id) values " +
                                   $"('{weather.Location.Name}', '{weather.Location.NameR}', '{weather.Location.CountryId}', '{weather.Location.CountryName}', '{weather.Location.DistrictId}', '{weather.Location.DistrictName}', " +
                                   $" '{weather.Location.Kind}', '{weather.Location.Latitude}', '{weather.Location.Longitude}', '{weather.Location.TimeZone}', '{weather.Location.CurrentTime}', '{weather.Location.NowcastUrl}', '{weather.Location.NowcastTeaser}', " +
                                   $" {weather_id.ToString()} )";
                int numberCount = cmd.ExecuteNonQuery();
                if (numberCount > 0)
                {
                    int location_id;
                    cmd.CommandText = "select id from location order by id desc limit 1";
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                location_id = reader.GetInt32(0);
                                /// записать fact
                                InsertFactInDB(location_id, weather.Location.Fact);
                                /// записать day
                            }
                        }
                    }

                }
            }
        }
        public void InsertFactInDB(int location_id, Fact fact)
        {
            using (var conneciton = new SqliteConnection(connectionString))
            {
                int values_id = InsertValuesInDb(fact.Values);
            }
        }

        public int InsertValuesInDb(Values values)
        {
            using (var conneciton = new SqliteConnection(connectionString))
            {
                conneciton.Open();
                SqliteCommand cmd = new();
                cmd.Connection = conneciton;
                cmd.CommandText = "insert into values(temperature,temperature_feels_like,peressure,wind_speed,humidity,heat_index,Cloudiness,precip_kind,precip_type,precip_amount,thunderstorm,water_temperature,icon,descr,grade,gust_speed) values (" +
                                  $"'{values.Temperature}','{values.TemperatureFeelsLike}','{values.Pressure}','{values.WindSpeed}','{values.Humidity}','{values.HeatIndex}','{values.Cloudiness}','{values.PrecipKind}'," +
                                  $"'{values.PrecipType}','{values.PrecipAmount}','{values.Thunderstorm}','{values.WaterTemperature}','{values.Icon}','{values.Description}','{values.Grade}','{values.GustSpeed}')";

                int numberCount = cmd.ExecuteNonQuery();
                if (numberCount > 0)
                {
                    int location_id;
                    cmd.CommandText = "select id from values order by id desc limit 1";
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                location_id = reader.GetInt32(0);
                                return location_id;
                            }
                        }
                    }
                    return -1;
                }
                return -1;
            }
        }

    }
}
