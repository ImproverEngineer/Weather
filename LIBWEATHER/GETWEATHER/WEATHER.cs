using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LIBWEATHER.GETWEATHER
{
    [XmlRoot("weather")]
    public class Weather
    {
        [XmlElement("location")]
        public Location Location { get; set; }
    }

    public class Location
    {
        [XmlAttribute("id")] public string Id { get; set; }
        [XmlAttribute("name")] public string Name { get; set; }
        [XmlAttribute("name_r")] public string NameR { get; set; }
        [XmlAttribute("country_id")] public string CountryId { get; set; }
        [XmlAttribute("country_name")] public string CountryName { get; set; }
        [XmlAttribute("district_id")] public string DistrictId { get; set; }
        [XmlAttribute("district_name")] public string DistrictName { get; set; }
        [XmlAttribute("kind")] public string Kind { get; set; }
        [XmlAttribute("lat")] public string Latitude { get; set; }
        [XmlAttribute("lng")] public string Longitude { get; set; }
        [XmlAttribute("tzone")] public string TimeZone { get; set; }
        [XmlAttribute("cur_time")] public DateTime CurrentTime { get; set; }
        [XmlAttribute("nowcast_url")] public string NowcastUrl { get; set; }
        [XmlAttribute("nowcast_teaser")] public string NowcastTeaser { get; set; }

        [XmlElement("fact")]
        public Fact Fact { get; set; }

        [XmlElement("day")]
        public List<Day> Days { get; set; }
    }

    public class Fact
    {
        [XmlAttribute("valid")] public DateTime Valid { get; set; }
        [XmlAttribute("tod")] public string TimeOfDay { get; set; }
        [XmlAttribute("risem")] public string RiseMinutes { get; set; }
        [XmlAttribute("setm")] public string SetMinutes { get; set; }
        [XmlAttribute("durm")] public string DurationMinutes { get; set; }
        [XmlAttribute("sunrise")] public string SunriseUnix { get; set; }
        [XmlAttribute("sunset")] public string SunsetUnix { get; set; }

        [XmlElement("values")]
        public Values Values { get; set; }
    }

    public class Day
    {
        [XmlAttribute("date")] public DateTime Date { get; set; }
        [XmlAttribute("risem")] public string RiseMinutes { get; set; }
        [XmlAttribute("setm")] public string SetMinutes { get; set; }
        [XmlAttribute("durm")] public string DurationMinutes { get; set; }
        [XmlAttribute("sunrise")] public string SunriseUnix { get; set; }
        [XmlAttribute("sunset")] public string SunsetUnix { get; set; }

        [XmlAttribute("tmin")] public string Tmin { get; set; }
        [XmlAttribute("tmax")] public string Tmax { get; set; }
        [XmlAttribute("pmin")] public int Pmin { get; set; }
        [XmlAttribute("pmax")] public string Pmax { get; set; }
        [XmlAttribute("wsmin")] public string Wsmin { get; set; }
        [XmlAttribute("wsmax")] public string Wsmax { get; set; }
        [XmlAttribute("hummin")] public string Hummin { get; set; }
        [XmlAttribute("hummax")] public string Hummax { get; set; }

        [XmlAttribute("cl")] public string Cloudiness { get; set; }
        [XmlAttribute("pt")] public string PrecipType { get; set; }
        [XmlAttribute("pr")] public string PrecipKind { get; set; }
        [XmlAttribute("ts")] public string Thunderstorm { get; set; }
        [XmlAttribute("icon")] public string Icon { get; set; }
        [XmlAttribute("descr")] public string Description { get; set; }
        [XmlAttribute("ws")] public string WindSpeed { get; set; }
        [XmlAttribute("wd")] public string WindDirection { get; set; }
        [XmlAttribute("hum")] public string Humidity { get; set; }
        [XmlAttribute("grademax")] public string GradeMax { get; set; }
        [XmlAttribute("prflt")] public string PrecipAmount { get; set; }
        [XmlAttribute("gust_speed")] public string GustSpeed { get; set; }

        [XmlElement("forecast")]
        public List<Forecast> Forecasts { get; set; }
    }

    public class Forecast
    {
        [XmlAttribute("valid")] public DateTime Valid { get; set; }
        [XmlAttribute("tod")] public string TimeOfDay { get; set; }

        [XmlElement("values")]
        public Values Values { get; set; }
    }

    public class Values
    {
        [XmlAttribute("t")] public string Temperature { get; set; }
        [XmlAttribute("tflt")] public string TemperatureFeelsLike { get; set; }
        [XmlAttribute("tcflt")] public string TemperatureCFeelsLike { get; set; }
        [XmlAttribute("p")] public string Pressure { get; set; }
        [XmlAttribute("ws")] public string WindSpeed { get; set; }
        [XmlAttribute("wd")] public string WindDirection { get; set; }
        [XmlAttribute("hum")] public string Humidity { get; set; }
        [XmlAttribute("hi")] public string HeatIndex { get; set; }
        [XmlAttribute("cl")] public string Cloudiness { get; set; }
        [XmlAttribute("pt")] public string PrecipType { get; set; }
        [XmlAttribute("pr")] public string PrecipKind { get; set; }
        [XmlAttribute("prflt")] public string PrecipAmount { get; set; }
        [XmlAttribute("ts")] public string Thunderstorm { get; set; }
        [XmlAttribute("water_t")] public string WaterTemperature { get; set; }
        [XmlAttribute("icon")] public string Icon { get; set; }
        [XmlAttribute("descr")] public string Description { get; set; }
        [XmlAttribute("grade")] public string Grade { get; set; }
        [XmlAttribute("gust_speed")] public string GustSpeed { get; set; }
    }

}
