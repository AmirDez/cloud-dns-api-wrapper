using System;
using System.Linq;
using CloudDnsApiWrapper.ArvanHelper;

namespace CLI
{
  class Program
    {

        static void Main(string[] args)
        {
            ArvanDnsHelper arvandDnsHelperObj = new ArvanDnsHelper();
            string domain = "amidez.me";
            string arvanDnsid = "12345";
            string name = "DevDezApiTest";
            string value = "sample txt dez";
            string cmd = " ";
       
            // Test if input arguments were supplied:
            if (args.Length == 0)
            {
                System.Console.WriteLine("I cant find any domain");
            }
            else
            {
                ///Get Args
                foreach (var arg in args)
                {
                    if (arg.StartsWith("domain"))
                    {
                        domain = getValue(arg);
                        domain = domain.Replace("*.", "");
                        while (domain.Count(f => f == '.') > 1)
                        {
                            domain = domain.Substring(domain.IndexOf(".") + 1).Trim();
                        }

                    }
                    else if (arg.StartsWith("arvanDnsid"))
                    {
                        arvanDnsid = getValue(arg);
                    }
                    else if (arg.StartsWith("name"))
                    {
                        name = getValue(arg);
                        if (name.ToLower().Contains(domain))
                        {
                            name = name.Replace("." + domain, "");
                        }
                    }
                    else if (arg.StartsWith("value"))
                    {
                        value = getValue(arg);
                    }
                    else if (arg.StartsWith("cmd"))
                    {
                        cmd = getValue(arg);
                    }
                }
                switch (cmd)
                {
                    case "getall":
                        {
                            ///Get Records
                            ///
                            foreach (var record in arvandDnsHelperObj.GetArvanDnsRecords(domain))
                            {
                                Console.WriteLine(record.name);
                            }
                            break;
                        }
                    case "get":
                        {
                            ///Get Record
                            ///
                            Console.WriteLine(arvandDnsHelperObj.GetArvanDnsRecord(domain, "20cd1e18-bcf1-4f73-af96-c43d64772856").name);
                            break;
                        }
                    case "create":
                        {
                            ///create Record
                            ///
                            Console.WriteLine(arvandDnsHelperObj.CreateArvanDnsTxtRecord(domain, name, value).name);
                            break;
                        }
                    case "delete":
                        {
                            ///delete Record
                            ///
                            if (arvandDnsHelperObj.DeleteArvanDnsRecord(domain, arvanDnsid))
                            {
                                Console.WriteLine("delete done");
                            }
                            else
                            {
                                Console.WriteLine("delete failed");
                            }

                            break;

                        }
                    case "delete_all":
                        {
                            ///delete all Record
                            ///
                            if (arvandDnsHelperObj.DeleteArvanDnsRecordsByName(domain, name))
                            {
                                Console.WriteLine("delete all done");
                            }
                            else
                            {
                                Console.WriteLine("delete all failed");
                            }

                            break;
                        }

                    default:
                        Console.WriteLine("just give me a command...");
                        break;
                }
            }
        }
        static string getValue(string arg)
        {
            string a = arg.Substring(arg.LastIndexOf('=') + 1);
            return arg.Substring(arg.LastIndexOf('=') + 1); ;

        }
    }
}
