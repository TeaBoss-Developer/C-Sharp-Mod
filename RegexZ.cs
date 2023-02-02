using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace CLINd
{
    public static class RegexZ
    {
        /// <summary>
        /// 截取字符串中开始和结束字符串中间的字符串
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="startStr">开始字符串</param>
        /// <param name="endStr">结束字符串</param>
        /// <returns>中间字符串</returns>
        public static string SubstringSingle(string source, string startStr, string endStr)
        {
            Regex rg = new Regex("(?<=(" + startStr + "))[.\\s\\S]*?(?=(" + endStr + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(source).Value;
        }

        /// <summary>
        /// （批量）截取字符串中开始和结束字符串中间的字符串
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="startStr">开始字符串</param>
        /// <param name="endStr">结束字符串</param>
        /// <returns>中间字符串</returns>
        public static List<string> SubstringMultiple(string source, string startStr, string endStr)
        {
            Regex rg = new Regex("(?<=(" + startStr + "))[.\\s\\S]*?(?=(" + endStr + "))", RegexOptions.Multiline | RegexOptions.Singleline);

            MatchCollection matches = rg.Matches(source);

            List<string> resList = new List<string>();

            foreach (Match item in matches)
                resList.Add(item.Value);

            return resList;
        }
        public static byte[] Encoding_String_To_Byte_UTF8(string Content)
        {
            buf1 = Encoding.UTF8.GetBytes(Content);
            return (buf1);
        }
        public static byte[] Encoding_Byte_To_String_UTF8(byte[] Bytes)
        {
            buf1 = Encoding.UTF8.GetString(Bytes);
            return (buf1);
        }
    }
}
