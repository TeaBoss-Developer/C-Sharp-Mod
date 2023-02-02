using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RainServerCommunity
{
	/// <summary>
	/// 获取网页源码类
	/// </summary>
	static class Web
	{
		public static string GetWebClient(string url)
		{
			string strHTML = "";
			WebClient myWebClient = new WebClient();
			Stream myStream = myWebClient.OpenRead(url);
			StreamReader sr = new StreamReader(myStream, System.Text.Encoding.GetEncoding("utf-8"));
			strHTML = sr.ReadToEnd();
			myStream.Close();
			return strHTML;
		}
		public static string GetWebRequest(string url)
		{
			Uri uri = new Uri(url);
			WebRequest myReq = WebRequest.Create(uri);
			WebResponse result = myReq.GetResponse();
			Stream receviceStream = result.GetResponseStream();
			StreamReader readerOfStream = new StreamReader(receviceStream, System.Text.Encoding.GetEncoding("utf-8"));
			string strHTML = readerOfStream.ReadToEnd();
			readerOfStream.Close();
			receviceStream.Close();
			result.Close();
			return strHTML;
		}
		public static string GetHttpWebRequest(string url)
		{
			Uri uri = new Uri(url);
			HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(uri);
			myReq.UserAgent = "User-Agent:Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705";

			myReq.Accept = "*/*";
			myReq.KeepAlive = true;
			myReq.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.5");
			myReq.Method = "GET";
			myReq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
			myReq.Headers.Add("Accept-Language", "zh-cn,zh;q=0.8,en-us;q=0.5,en;q=0.3");
			myReq.UserAgent = "Mozilla/5.0 (Windows NT 5.2; rv:12.0) Gecko/20100101 Firefox/12.0";
			HttpWebResponse result = (HttpWebResponse)myReq.GetResponse();
			Stream receviceStream = result.GetResponseStream();
			StreamReader readerOfStream = new StreamReader(receviceStream, System.Text.Encoding.GetEncoding("utf-8"));
			string strHTML = readerOfStream.ReadToEnd();
			readerOfStream.Close();
			receviceStream.Close();
			result.Close();
			return strHTML;
		}

		/// <summary>
		 /// Post提交数据
		 /// </summary>
		 /// <param name="url">URL</param>
		 /// <param name="postData">参数</param>
		 /// <returns></returns>
		public static async Task<string> PostRequest(string url, string jsonData)
		{
			string str = string.Empty;

			var webReq = (HttpWebRequest)WebRequest.Create(new Uri(url));
			webReq.Method = "POST";
			webReq.ContentType = "application/json";
			var sw = new StreamWriter(webReq.GetRequestStream());
			sw.Write(jsonData);
			sw.Flush();
			sw.Close();
			var response = (HttpWebResponse)webReq.GetResponse();
			var sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
			str = sr.ReadToEnd();
			sr.Close();
			response.Close();

			return str;

		}
	}
}
