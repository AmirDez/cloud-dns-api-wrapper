using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace CloudDnsApiWrapper.ArvanHelper
{
  public class ArvanDnsHelper
  {
    readonly string arvanApiBaseUrl = "https://napi.arvancloud.com/cdn/4.0/domains/";

    readonly IRestClient _client;

    public ArvanDnsHelper()
    {

      arvanApiBaseUrl = ConfigurationManager.AppSettings["ArvanApiBaseUrl"];
      string arvanApiKey = ConfigurationManager.AppSettings["ArvanApiKey"];
      
      _client = new RestClient(arvanApiBaseUrl);
      _client.AddDefaultHeader("Accept", "application/json");
      _client.AddDefaultHeader("Accept-Language", "fa");
      _client.AddDefaultHeader("Authorization", arvanApiKey);
      _client.AddDefaultHeader("Charset", "utf-8");
    }

    public T Get<T>(RestRequest request) where T : new()
    {

      var response = _client.Get<T>(request);
      if (response.ErrorException != null)
      {
        const string message = "Error retrieving response.  Check inner details for more info.";
        var twilioException = new Exception(message, response.ErrorException);
        throw twilioException;
      }
      return response.Data;
    }

    public T Delete<T>(RestRequest request) where T : new()
    {

      var response = _client.Delete<T>(request);
      if (response.ErrorException != null)
      {
        const string message = "Error retrieving response.  Check inner details for more info.";
        var twilioException = new Exception(message, response.ErrorException);
        throw twilioException;
      }
      return response.Data;
    }

    public T Post<T>(RestRequest request) where T : new()
    {

      var response = _client.Post<T>(request);
      if (response.ErrorException != null)
      {
        const string message = "Error retrieving response.  Check inner details for more info.";
        var twilioException = new Exception(message, response.ErrorException);
        throw twilioException;
      }
      return response.Data;
    }

    public ArvanDnsRecord GetArvanDnsRecord(string domainName, string arvanDnsid)
    {
      var request = new RestRequest(domainName + "/dns-records/" + arvanDnsid, RestSharp.DataFormat.Json);
      request.RootElement = "data";
      ArvanDnsRecord t = Get<ArvanDnsRecord>(request);
      return t;
    }

    public Boolean DeleteArvanDnsRecord(string domainName, string arvanDnsid)
    {
      var request = new RestRequest(domainName + "/dns-records/" + arvanDnsid, RestSharp.DataFormat.Json);
      request.RootElement = "data";
      ArvanDnsRecordDeleteResponse t = Delete<ArvanDnsRecordDeleteResponse>(request);
      if (t.message.Contains("رکورد dns حذف شد."))
      {
        return true;
      }
      else return false;
    }

    public List<ArvanDnsRecord> GetArvanDnsRecords(string domainName)
    {
      var request = new RestRequest(domainName + "/dns-records/?", RestSharp.DataFormat.Json);
      request.RootElement = "data";
      List<ArvanDnsRecord> t = Get<List<ArvanDnsRecord>>(request);
      return t;
    }

    public ArvanDnsRecord CreateArvanDnsTxtRecord(string domainName, string name, string value)
    {
      var request = new RestRequest(domainName + "/dns-records/", RestSharp.DataFormat.Json);
      request.AddHeader("Content-type", "application/json");
      ArvanDnsTxtRecordClassHolder.ArvanTxtDnsRecordTemplate template = ArvanDnsTxtRecordClassHolder.ArvanTxtDnsRecordTemplater(name, value);
      request.AddJsonBody(JsonConvert.SerializeObject(template));
      request.RootElement = "data";
      return Post<ArvanDnsRecord>(request);
    }

    public Boolean DeleteArvanDnsRecordsByName(string domainName, string name)
    {
      Boolean output = false;
      var records = GetArvanDnsRecords(domainName);
      foreach (var record in records)
      {
        if (!String.IsNullOrEmpty(record.name) & record.name.ToLower().Trim().StartsWith(name.Trim().ToLower()))
        {
          output = DeleteArvanDnsRecord(domainName, record.id);
        }
      }

      return output;
    }

  }
}
