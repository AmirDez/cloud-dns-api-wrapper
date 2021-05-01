using System;

namespace CloudDnsApiWrapper.ArvanHelper
{
  public class ArvanDnsTxtRecordClassHolder
    {
        public static ArvanTxtDnsRecordTemplate ArvanTxtDnsRecordTemplater(String name, String value)
        {
            ArvanTxtDnsRecordTemplate obj = new ArvanTxtDnsRecordTemplate();
            obj.name = name;
            obj.type = "txt";
            Value valueObj = new Value();
            valueObj.text = value;
            obj.value = valueObj;
            obj.ttl = 120;
            obj.cloud = false;
            obj.upstream_https = "default";
            IpFilterMode ipFilterModeObj = new IpFilterMode();
            ipFilterModeObj.count = "single";
            ipFilterModeObj.geo_filter = "none";
            ipFilterModeObj.order = "none";
            obj.ip_filter_mode = ipFilterModeObj;

            obj.can_delete = true;
            obj.health_check_status = false;
            HealthCheckSetting healthCheckSettingObj = new HealthCheckSetting();

            healthCheckSettingObj.port = "";
            healthCheckSettingObj.protocol = "http";
            healthCheckSettingObj.uri = "";
            obj.health_check_setting = healthCheckSettingObj;
            return obj;
        }
        public class Value
        {
            public string text { get; set; }
        }

        public class IpFilterMode
        {
            public string count { get; set; }
            public string order { get; set; }
            public string geo_filter { get; set; }
        }

        public class HealthCheckSetting
        {
            public string protocol { get; set; }
            public string port { get; set; }
            public string uri { get; set; }
        }

        public class ArvanTxtDnsRecordTemplate
        {
            public string type { get; set; }
            public string name { get; set; }
            public Value value { get; set; }
            public int ttl { get; set; }
            public bool cloud { get; set; }
            public string upstream_https { get; set; }
            public IpFilterMode ip_filter_mode { get; set; }
            public bool can_delete { get; set; }
            public bool health_check_status { get; set; }
            public HealthCheckSetting health_check_setting { get; set; }
        }
    }
}
