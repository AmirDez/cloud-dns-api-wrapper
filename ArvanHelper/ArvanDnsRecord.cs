using System;
using System.Collections.Generic;



namespace CloudDnsApiWrapper.ArvanHelper
{
  public class Value
    {
        public string ip { get; set; }
        public string port { get; set; }
        public string weight { get; set; }
        public string country { get; set; }
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

    public class ArvanDnsRecord
    {
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public IList<Value> value { get; set; }
        public string ttl { get; set; }
        public bool cloud { get; set; }
        public string upstream_https { get; set; }
        public IpFilterMode ip_filter_mode { get; set; }
        public bool can_delete { get; set; }
        public bool health_check_status { get; set; }
        public HealthCheckSetting health_check_setting { get; set; }
        public String created_at { get; set; }
        public String updated_at { get; set; }
    }

}
