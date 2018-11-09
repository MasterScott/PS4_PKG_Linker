﻿using System;
using SeasideResearch.LibCurlNet;

namespace PS4_PKG_Linker
{
    public class RPI
    {
        static string out1 = "";
        public static string Send(string ip, string port, string type, string cmd)
        {
            try
            {
                Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);

                Easy easy = new Easy();

                Easy.WriteFunction wf = new Easy.WriteFunction(OnWriteData);
                easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);

                // simple post - with a string
                easy.SetOpt(CURLoption.CURLOPT_POSTFIELDS, cmd);//"{\"title_id\":\"CUSA09311\"}";

                easy.SetOpt(CURLoption.CURLOPT_USERAGENT,
                    "Mozilla 4.0 (compatible; MSIE 6.0; Win32");
                easy.SetOpt(CURLoption.CURLOPT_FOLLOWLOCATION, true);

                easy.SetOpt(CURLoption.CURLOPT_URL, "http://" + ip + port + "/api/" + type); //"http://192.168.1.15:12800/api/is_exists");

                easy.SetOpt(CURLoption.CURLOPT_POST, true);

                easy.Perform();
                easy.Dispose();

                Curl.GlobalCleanup();
                return out1;
            }
            catch (Exception ex)
            {
                return out1;
                //Console.WriteLine(ex);
            }
        }

        public static Int32 OnWriteData(Byte[] buf, Int32 size, Int32 nmemb, Object extraData)
        {
            out1 = out1 + System.Text.Encoding.UTF8.GetString(buf);
            return size * nmemb;
        }

    }
    

    public class Read_Exists
    {
        public string status { get; set; }
        public string error { get; set; }
    }

    public class Check_Exists
    {
        public string title_id { get; set; }
    }

    public class Install_pkg
    {
        public string type { get; set; }
        public string[] packages { get; set; }
    }

    public class Install_url
    {
        public string type { get; set; }
        public string url { get; set; }
    }

    public class Uninstall_tid
    {
        public string title_id { get; set; }
    }

    public class Uninstall_cid
    {
        public string content_id { get; set; }
    }

    public class Task
    {
        public int task_id { get; set; }
    }

    public class Find
    {
        public string content_id { get; set; }
        public int sub_type { get; set; }
    }





}


