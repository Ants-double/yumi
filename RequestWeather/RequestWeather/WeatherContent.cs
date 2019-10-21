using System;
using System.Collections.Generic;
using System.Text;

namespace RequestWeather
{
    class WeatherContent
    {
        public String city { get; set; }
        public String cityid { get; set; }
        public String temp { get; set; }
        public String WD { get; set; }
        public String WS { get; set; }
        public String SD { get; set; }
        public String AP { get; set; }
        public String njd { get; set; }
        public String WSE { get; set; }
        public String time { get; set; }
        public String sm { get; set; }
        public String isRadar { get; set; }
        public String Radar { get; set; }

        public override string ToString()
        {
            return $"city：{city},cityId:{cityid},temp:{temp}," +
                $"WD:{WD},WS:{WS},SD:{SD},AP:{AP},njd:{njd},WSE:{WSE}," +
                $"time:{time},sm:{sm},isRadar:{isRadar},Radar:{Radar}";
        }
    }
}
