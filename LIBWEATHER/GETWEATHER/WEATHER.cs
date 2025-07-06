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

    /// <summary>
    /* 
        id="13051" — уникальный ID локации (Пермь / Большое Савино)

        lat, lng — координаты(широта, долгота)

        tzone="300" — часовой пояс(в минутах от UTC, т.е. +5 часов)

        cur_time — текущее время на сервере
    */
    /// </summary>
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
    /// <summary>
    /*
        valid — дата/время фактических данных

        tod — время суток (0 — ночь, 1 — утро, 2 — день, 3 — вечер, 4 — текущий момент)

        sunrise, sunset — Unix-время восхода и заката

        <values> внутри <fact>:

            t — температура (°C)

            tflt / tcflt — температура по ощущениям

            p — давление (мм рт. ст.)

            ws — скорость ветра (м/с)

            wd — направление ветра (см. ниже)

            hum — влажность (%)

            hi — температура по ощущениям

            cl — облачность (0 — ясно, 1 — малооблачно, 2 — облачно, 3 — пасмурно)

            pt — наличие осадков (0 — нет, 1 — есть)

            pr — интенсивность осадков (0 — нет, 1 — слабый дождь, 2 — дождь/гроза)

            prflt — количественное значение осадков (мм)

            ts — гроза (0 — нет, 1 — есть)

            water_t — температура воды

            icon — иконка для отрисовки погоды (например, c4.r1)

            descr — описание состояния погоды

            grade — условная степень дискомфорта (0 — минимальный, 5 — высокий)
     */
    /// </summary>
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


    /// <summary>
    /*
        date — дата

        tmin, tmax — минимальная и максимальная температура

        pmin, pmax — давление (мм рт. ст.)

        wsmin, wsmax — скорость ветра

        hummin, hummax — влажность

        cl, pt, pr, ts, icon, descr, prflt — см. выше

        gust_speed — порывы ветра (м/с)
    */
    /// </summary>
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

    /// <summary>
    /*
        valid — дата и время прогноза

        tod — время суток:

        1 — ночь/утро (00–06)

        2 — день (06–12)

        3 — вечер (12–18)

        4 — ночь (18–24)

        <values> внутри — аналогичны значениям из <fact>
     */
    /// </summary>
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
        [XmlAttribute("p")] public string Pressure { get; set; } // давление (мм рт. ст.)
        [XmlAttribute("ws")] public string WindSpeed { get; set; } // скорость ветра (м/с)
        [XmlAttribute("wd")] public string WindDirection { get; set; } // направление ветра (см. ниже)
        [XmlAttribute("hum")] public string Humidity { get; set; } // влажность (%) 
        [XmlAttribute("hi")] public string HeatIndex { get; set; } // температура по ощущениям
        [XmlAttribute("cl")] public string Cloudiness { get; set; } // облачность (0 — ясно, 1 — малооблачно, 2 — облачно, 3 — пасмурно) 
        [XmlAttribute("pt")] public string PrecipType { get; set; } // наличие осадков (0 — нет, 1 — есть)
        [XmlAttribute("pr")] public string PrecipKind { get; set; } // интенсивность осадков (0 — нет, 1 — слабый дождь, 2 — дождь/гроза)
        [XmlAttribute("prflt")] public string PrecipAmount { get; set; } // количественное значение осадков (мм)
        [XmlAttribute("ts")] public string Thunderstorm { get; set; } // гроза (0 — нет, 1 — есть)
        [XmlAttribute("water_t")] public string WaterTemperature { get; set; } // температура воды
        [XmlAttribute("icon")] public string Icon { get; set; } // иконка для отрисовки погоды (например, c4.r1)
        /*
         c4 — тип облачности:

                c1 — ясно

                c2 — малооблачно

                c3 — облачно

                c4 — пасмурно

                r1, r2 — наличие осадков:

                r1 — небольшой дождь

                r2 — дождь

                r3 — ливень / сильный дождь

                d. / n. — день/ночь (например d.c3.r2.st)

                d — дневная версия

                n — ночная версия

                .st — гроза (storm)
         */
        [XmlAttribute("descr")] public string Description { get; set; }
        [XmlAttribute("grade")] public string Grade { get; set; } // описание состояния погоды
        [XmlAttribute("gust_speed")] public string GustSpeed { get; set; } // условная степень дискомфорта (0 — минимальный, 5 — высокий)
    }

}
