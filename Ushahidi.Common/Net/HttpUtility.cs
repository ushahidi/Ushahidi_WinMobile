using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace Ushahidi.Common.Net
{
    /// <summary>Provides methods for encoding and decoding URLs when processing Web requests. This class cannot be inherited.</summary>
    public sealed class HttpUtility
    {
        /// <summary>
        /// Decodes all the bytes in the specified byte array into a string.
        /// </summary>
        /// <remarks>
        /// Replace the method "System.Text.Encoding.ASCII.GetString(byte[] bytes);" in .Net Framework.
        /// </remarks>
        /// <param name="bytes">The byte array containing the sequence of bytes to decode.</param>
        /// <returns>A String containing the results of decoding the specified sequence of bytes.</returns>
        private static string ASCIIGetString(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }
            return Encoding.ASCII.GetString(bytes, 0, bytes.Length);

        }

        private static readonly char[] EntityEndingChars = new [] { ';', '&' };

        //internal static string AspCompatUrlEncode(string s)
        //{
        //    s = UrlEncode(s);
        //    s = s.Replace("!", "%21");
        //    s = s.Replace("*", "%2A");
        //    s = s.Replace("(", "%28");
        //    s = s.Replace(")", "%29");
        //    s = s.Replace("-", "%2D");
        //    s = s.Replace(".", "%2E");
        //    s = s.Replace("_", "%5F");
        //    s = s.Replace(@"\", "%5C");
        //    return s;
        //}

        //internal static string CollapsePercentUFromStringInternal(string s, Encoding e)
        //{
        //    int length = s.Length;
        //    UrlDecoder decoder = new UrlDecoder(length, e);
        //    if (s.IndexOf("%u", StringComparison.Ordinal) == -1)
        //    {
        //        return s;
        //    }
        //    for (int i = 0; i < length; i++)
        //    {
        //        char ch = s[i];
        //        if (((ch == '%') && (i < (length - 5))) && (s[i + 1] == 'u'))
        //        {
        //            int num4 = HexToInt(s[i + 2]);
        //            int num5 = HexToInt(s[i + 3]);
        //            int num6 = HexToInt(s[i + 4]);
        //            int num7 = HexToInt(s[i + 5]);
        //            if (((num4 >= 0) && (num5 >= 0)) && ((num6 >= 0) && (num7 >= 0)))
        //            {
        //                ch = (char) ((((num4 << 12) | (num5 << 8)) | (num6 << 4)) | num7);
        //                i += 5;
        //                decoder.AddChar(ch);
        //                continue;
        //            }
        //        }
        //        if ((ch & 0xff80) == 0)
        //        {
        //            decoder.AddByte((byte) ch);
        //        }
        //        else
        //        {
        //            decoder.AddChar(ch);
        //        }
        //    }
        //    return decoder.GetString();
        //}

        //internal static string FormatHttpCookieDateTime(DateTime dt)
        //{
        //    if ((dt < DateTime.MaxValue.AddDays(-1.0)) && (dt > DateTime.MinValue.AddDays(1.0)))
        //    {
        //        dt = dt.ToUniversalTime();
        //    }
        //    return dt.ToString("ddd, dd-MMM-yyyy HH':'mm':'ss 'GMT'", DateTimeFormatInfo.InvariantInfo);
        //}

        //internal static string FormatHttpDateTime(DateTime dt)
        //{
        //    if ((dt < DateTime.MaxValue.AddDays(-1.0)) && (dt > DateTime.MinValue.AddDays(1.0)))
        //    {
        //        dt = dt.ToUniversalTime();
        //    }
        //    return dt.ToString("R", DateTimeFormatInfo.InvariantInfo);
        //}

        //internal static string FormatHttpDateTimeUtc(DateTime dt)
        //{
        //    return dt.ToString("R", DateTimeFormatInfo.InvariantInfo);
        //}

        //internal static string FormatPlainTextAsHtml(string s)
        //{
        //    if (s == null)
        //    {
        //        return null;
        //    }
        //    StringBuilder sb = new StringBuilder();
        //    StringWriter output = new StringWriter(sb);
        //    FormatPlainTextAsHtml(s, output);
        //    return sb.ToString();
        //}

        //internal static void FormatPlainTextAsHtml(string s, TextWriter output)
        //{
        //    if (s != null)
        //    {
        //        int length = s.Length;
        //        char ch = '';
        //        for (int i = 0; i < length; i++)
        //        {
        //            char ch2 = s[i];
        //            switch (ch2)
        //            {
        //                case '\n':
        //                    output.Write("<br>");
        //                    goto Label_0113;

        //                case '\r':
        //                    goto Label_0113;

        //                case ' ':
        //                    if (ch != ' ')
        //                    {
        //                        break;
        //                    }
        //                    output.Write("&nbsp;");
        //                    goto Label_0113;

        //                case '"':
        //                    output.Write("&quot;");
        //                    goto Label_0113;

        //                case '&':
        //                    output.Write("&amp;");
        //                    goto Label_0113;

        //                case '<':
        //                    output.Write("<");
        //                    goto Label_0113;

        //                case '>':
        //                    output.Write(">");
        //                    goto Label_0113;

        //                default:
        //                    if ((ch2 >= '\x00a0') && (ch2 < 'Ā'))
        //                    {
        //                        output.Write("&#");
        //                        output.Write(((int) ch2).ToString(NumberFormatInfo.InvariantInfo));
        //                        output.Write(';');
        //                    }
        //                    else
        //                    {
        //                        output.Write(ch2);
        //                    }
        //                    goto Label_0113;
        //            }
        //            output.Write(ch2);
        //        Label_0113:
        //            ch = ch2;
        //        }
        //    }
        //}

        //internal static string FormatPlainTextSpacesAsHtml(string s)
        //{
        //    if (s == null)
        //    {
        //        return null;
        //    }
        //    StringBuilder sb = new StringBuilder();
        //    StringWriter writer = new StringWriter(sb);
        //    int length = s.Length;
        //    for (int i = 0; i < length; i++)
        //    {
        //        char ch = s[i];
        //        if (ch == ' ')
        //        {
        //            writer.Write("&nbsp;");
        //        }
        //        else
        //        {
        //            writer.Write(ch);
        //        }
        //    }
        //    return sb.ToString();
        //}

        private static int HexToInt(char h)
        {
            if ((h >= '0') && (h <= '9'))
            {
                return (h - '0');
            }
            if ((h >= 'a') && (h <= 'f'))
            {
                return ((h - 'a') + 10);
            }
            if ((h >= 'A') && (h <= 'F'))
            {
                return ((h - 'A') + 10);
            }
            return -1;
        }

        ///// <summary>Minimally converts a string to an HTML-encoded string.</summary>
        ///// <returns>An encoded string.</returns>
        ///// <param name="s">The string to encode. </param>
        //public static string HtmlAttributeEncode(string s)
        //{
        //    if (s == null)
        //    {
        //        return null;
        //    }
        //    int num = IndexOfHtmlAttributeEncodingChars(s, 0);
        //    if (num == -1)
        //    {
        //        return s;
        //    }
        //    StringBuilder builder = new StringBuilder(s.Length + 5);
        //    int length = s.Length;
        //    int startIndex = 0;
        //Label_002A:
        //    if (num > startIndex)
        //    {
        //        builder.Append(s, startIndex, num - startIndex);
        //    }
        //    switch (s[num])
        //    {
        //        case '"':
        //            builder.Append("&quot;");
        //            break;

        //        case '&':
        //            builder.Append("&amp;");
        //            break;

        //        case '<':
        //            builder.Append("<");
        //            break;
        //    }
        //    startIndex = num + 1;
        //    if (startIndex < length)
        //    {
        //        num = IndexOfHtmlAttributeEncodingChars(s, startIndex);
        //        if (num != -1)
        //        {
        //            goto Label_002A;
        //        }
        //        builder.Append(s, startIndex, length - startIndex);
        //    }
        //    return builder.ToString();
        //}

        ///// <summary>Minimally converts a string into an HTML-encoded string and sends the encoded string to a <see cref="T:System.IO.TextWriter"></see> output stream.</summary>
        ///// <param name="s">The string to encode </param>
        ///// <param name="output">A <see cref="T:System.IO.TextWriter"></see> output stream. </param>
        //public static unsafe void HtmlAttributeEncode(string s, TextWriter output)
        //{
        //    if (s != null)
        //    {
        //        int num = IndexOfHtmlAttributeEncodingChars(s, 0);
        //        if (num == -1)
        //        {
        //            output.Write(s);
        //        }
        //        else
        //        {
        //            int num2 = s.Length - num;
        //            fixed (char* str = ((char*) s))
        //            {
        //                char* chPtr = str;
        //                char* chPtr2 = chPtr;
        //                while (num-- > 0)
        //                {
        //                    chPtr2++;
        //                    output.Write(chPtr2[0]);
        //                }
        //                while (num2-- > 0)
        //                {
        //                    chPtr2++;
        //                    char ch = chPtr2[0];
        //                    if (ch > '<')
        //                    {
        //                        goto Label_00A2;
        //                    }
        //                    char ch2 = ch;
        //                    if (ch2 != '"')
        //                    {
        //                        if (ch2 == '&')
        //                        {
        //                            goto Label_008B;
        //                        }
        //                        if (ch2 != '<')
        //                        {
        //                            goto Label_0098;
        //                        }
        //                        output.Write("<");
        //                    }
        //                    else
        //                    {
        //                        output.Write("&quot;");
        //                    }
        //                    continue;
        //                Label_008B:
        //                    output.Write("&amp;");
        //                    continue;
        //                Label_0098:
        //                    output.Write(ch);
        //                    continue;
        //                Label_00A2:
        //                    output.Write(ch);
        //                }
        //            }
        //        }
        //    }
        //}

        //internal static void HtmlAttributeEncodeInternal(string s, HttpWriter writer)
        //{
        //    int num = IndexOfHtmlAttributeEncodingChars(s, 0);
        //    if (num == -1)
        //    {
        //        writer.Write(s);
        //        return;
        //    }
        //    int length = s.Length;
        //    int index = 0;
        //Label_001D:
        //    if (num > index)
        //    {
        //        writer.WriteString(s, index, num - index);
        //    }
        //    switch (s[num])
        //    {
        //        case '"':
        //            writer.Write("&quot;");
        //            break;

        //        case '&':
        //            writer.Write("&amp;");
        //            break;

        //        case '<':
        //            writer.Write("<");
        //            break;
        //    }
        //    index = num + 1;
        //    if (index < length)
        //    {
        //        num = IndexOfHtmlAttributeEncodingChars(s, index);
        //        if (num != -1)
        //        {
        //            goto Label_001D;
        //        }
        //        writer.WriteString(s, index, length - index);
        //    }
        //}

        /// <summary>Converts a string that has been HTML-encoded for HTTP transmission into a decoded string.</summary>
        /// <returns>A decoded string.</returns>
        /// <param name="s">The string to decode. </param>
        public static string HtmlDecode(string s)
        {
            if (s == null)
            {
                return null;
            }
            if (s.IndexOf('&') < 0)
            {
                return s;
            }
            StringBuilder sb = new StringBuilder();
            StringWriter output = new StringWriter(sb);
            HtmlDecode(s, output);
            return sb.ToString();
        }

        /// <summary>Converts a string that has been HTML-encoded into a decoded string, and sends the decoded string to a <see cref="T:System.IO.TextWriter"></see> output stream.</summary>
        /// <param name="s">The string to decode. </param>
        /// <param name="output">A <see cref="T:System.IO.TextWriter"></see> stream of output. </param>
        public static void HtmlDecode(string s, TextWriter output)
        {
            if (s != null)
            {
                if (s.IndexOf('&') < 0)
                {
                    output.Write(s);
                }
                else
                {
                    int length = s.Length;
                    for (int i = 0; i < length; i++)
                    {
                        char ch = s[i];
                        if (ch == '&')
                        {
                            int num3 = s.IndexOfAny(EntityEndingChars, i + 1);
                            if ((num3 > 0) && (s[num3] == ';'))
                            {
                                string entity = s.Substring(i + 1, (num3 - i) - 1);
                                if ((entity.Length > 1) && (entity[0] == '#'))
                                {
                                    try
                                    {
                                        if ((entity[1] == 'x') || (entity[1] == 'X'))
                                        {
                                            ch = (char)int.Parse(entity.Substring(2), NumberStyles.AllowHexSpecifier);
                                        }
                                        else
                                        {
                                            ch = (char)int.Parse(entity.Substring(1));
                                        }
                                        i = num3;
                                    }
                                    catch (FormatException)
                                    {
                                        i++;
                                    }
                                    catch (ArgumentException)
                                    {
                                        i++;
                                    }
                                }
                                else
                                {
                                    i = num3;
                                    char ch2 = HtmlEntities.Lookup(entity);
                                    if (ch2 != '\0')
                                    {
                                        ch = ch2;
                                    }
                                    else
                                    {
                                        output.Write('&');
                                        output.Write(entity);
                                        output.Write(';');
                                        return;
                                    }
                                }
                            }
                        }
                        output.Write(ch);
                    }
                }
            }
        }

        ///// <summary>Converts a string to an HTML-encoded string.</summary>
        ///// <returns>An encoded string.</returns>
        ///// <param name="s">The string to encode. </param>
        //public static string HtmlEncode(string s)
        //{
        //    if (s == null)
        //    {
        //        return null;
        //    }
        //    int num = IndexOfHtmlEncodingChars(s, 0);
        //    if (num == -1)
        //    {
        //        return s;
        //    }
        //    StringBuilder builder = new StringBuilder(s.Length + 5);
        //    int length = s.Length;
        //    int startIndex = 0;
        //Label_002A:
        //    if (num > startIndex)
        //    {
        //        builder.Append(s, startIndex, num - startIndex);
        //    }
        //    char ch = s[num];
        //    if (ch > '>')
        //    {
        //        builder.Append("&#");
        //        builder.Append(((int) ch).ToString(NumberFormatInfo.InvariantInfo));
        //        builder.Append(';');
        //    }
        //    else
        //    {
        //        char ch2 = ch;
        //        if (ch2 != '"')
        //        {
        //            switch (ch2)
        //            {
        //                case '<':
        //                    builder.Append("<");
        //                    goto Label_00D5;

        //                case '=':
        //                    goto Label_00D5;

        //                case '>':
        //                    builder.Append(">");
        //                    goto Label_00D5;

        //                case '&':
        //                    builder.Append("&amp;");
        //                    goto Label_00D5;
        //            }
        //        }
        //        else
        //        {
        //            builder.Append("&quot;");
        //        }
        //    }
        //Label_00D5:
        //    startIndex = num + 1;
        //    if (startIndex < length)
        //    {
        //        num = IndexOfHtmlEncodingChars(s, startIndex);
        //        if (num != -1)
        //        {
        //            goto Label_002A;
        //        }
        //        builder.Append(s, startIndex, length - startIndex);
        //    }
        //    return builder.ToString();
        //}

        ///// <summary>Converts a string into an HTML-encoded string, and returns the output as a <see cref="T:System.IO.TextWriter"></see> stream of output.</summary>
        ///// <param name="s">The string to encode </param>
        ///// <param name="output">A <see cref="T:System.IO.TextWriter"></see> output stream. </param>
        //public static unsafe void HtmlEncode(string s, TextWriter output)
        //{
        //    if (s != null)
        //    {
        //        int num = IndexOfHtmlEncodingChars(s, 0);
        //        if (num == -1)
        //        {
        //            output.Write(s);
        //        }
        //        else
        //        {
        //            int num2 = s.Length - num;
        //            fixed (char* str = ((char*) s))
        //            {
        //                char* chPtr = str;
        //                char* chPtr2 = chPtr;
        //                while (num-- > 0)
        //                {
        //                    chPtr2++;
        //                    output.Write(chPtr2[0]);
        //                }
        //                while (num2-- > 0)
        //                {
        //                    chPtr2++;
        //                    char ch = chPtr2[0];
        //                    if (ch > '>')
        //                    {
        //                        goto Label_00C4;
        //                    }
        //                    char ch2 = ch;
        //                    if (ch2 != '"')
        //                    {
        //                        switch (ch2)
        //                        {
        //                            case '<':
        //                            {
        //                                output.Write("<");
        //                                continue;
        //                            }
        //                            case '=':
        //                                goto Label_00BA;

        //                            case '>':
        //                            {
        //                                output.Write(">");
        //                                continue;
        //                            }
        //                            case '&':
        //                                goto Label_00AD;
        //                        }
        //                        goto Label_00BA;
        //                    }
        //                    output.Write("&quot;");
        //                    continue;
        //                Label_00AD:
        //                    output.Write("&amp;");
        //                    continue;
        //                Label_00BA:
        //                    output.Write(ch);
        //                    continue;
        //                Label_00C4:
        //                    if ((ch >= '\x00a0') && (ch < 'Ā'))
        //                    {
        //                        output.Write("&#");
        //                        output.Write(((int) ch).ToString(NumberFormatInfo.InvariantInfo));
        //                        output.Write(';');
        //                    }
        //                    else
        //                    {
        //                        output.Write(ch);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //private static unsafe int IndexOfHtmlAttributeEncodingChars(string s, int startPos)
        //{
        //    int num = s.Length - startPos;
        //    fixed (char* str = ((char*) s))
        //    {
        //        char* chPtr = str;
        //        char* chPtr2 = chPtr + startPos;
        //        while (num > 0)
        //        {
        //            char ch = chPtr2[0];
        //            if (ch <= '<')
        //            {
        //                switch (ch)
        //                {
        //                    case '"':
        //                    case '&':
        //                    case '<':
        //                        return (s.Length - num);
        //                }
        //            }
        //            chPtr2++;
        //            num--;
        //        }
        //    }
        //    return -1;
        //}

        //private static unsafe int IndexOfHtmlEncodingChars(string s, int startPos)
        //{
        //    int num = s.Length - startPos;
        //    fixed (char* str = ((char*) s))
        //    {
        //        char* chPtr = str;
        //        char* chPtr2 = chPtr + startPos;
        //        while (num > 0)
        //        {
        //            char ch = chPtr2[0];
        //            if (ch <= '>')
        //            {
        //                switch (ch)
        //                {
        //                    case '<':
        //                    case '>':
        //                    case '"':
        //                    case '&':
        //                        return (s.Length - num);

        //                    case '=':
        //                        goto Label_007A;
        //                }
        //            }
        //            else if ((ch >= '\x00a0') && (ch < 'Ā'))
        //            {
        //                return (s.Length - num);
        //            }
        //        Label_007A:
        //            chPtr2++;
        //            num--;
        //        }
        //    }
        //    return -1;
        //}

        internal static char IntToHex(int n)
        {
            if (n <= 9)
            {
                return (char)(n + 0x30);
            }
            return (char)((n - 10) + 0x61);
        }

        private static bool IsNonAsciiByte(byte b)
        {
            if (b < 0x7f)
            {
                return (b < 0x20);
            }
            return true;
        }

        internal static bool IsSafe(char ch)
        {
            if ((((ch >= 'a') && (ch <= 'z')) || ((ch >= 'A') && (ch <= 'Z'))) || ((ch >= '0') && (ch <= '9')))
            {
                return true;
            }
            switch (ch)
            {
                case '\'':
                case '(':
                case ')':
                case '*':
                case '-':
                case '.':
                case '_':
                case '!':
                    return true;
            }
            return false;
        }

        ///// <summary>Parses a query string into a <see cref="T:System.Collections.Specialized.NameValueCollection"></see> using <see cref="P:System.Text.Encoding.UTF8"></see> encoding.</summary>
        ///// <returns>A <see cref="T:System.Collections.Specialized.NameValueCollection"></see> of query parameters and values.</returns>
        ///// <param name="query">The query string to parse.</param>
        ///// <exception cref="T:System.ArgumentNullException">query is null. </exception>
        //public static NameValueCollection ParseQueryString(string query)
        //{
        //    return ParseQueryString(query, Encoding.UTF8);
        //}

        ///// <summary>Parses a query string into a <see cref="T:System.Collections.Specialized.NameValueCollection"></see> using the specified <see cref="T:System.Text.Encoding"></see>. </summary>
        ///// <returns>A <see cref="T:System.Collections.Specialized.NameValueCollection"></see> of query parameters and values.</returns>
        ///// <param name="encoding">The <see cref="T:System.Text.Encoding"></see> to use.</param>
        ///// <param name="query">The query string to parse.</param>
        ///// <exception cref="T:System.ArgumentNullException">query is null.- or -encoding is null.</exception>
        //public static NameValueCollection ParseQueryString(string query, Encoding encoding)
        //{
        //    if (query == null)
        //    {
        //        throw new ArgumentNullException("query");
        //    }
        //    if (encoding == null)
        //    {
        //        throw new ArgumentNullException("encoding");
        //    }
        //    if ((query.Length > 0) && (query[0] == '?'))
        //    {
        //        query = query.Substring(1);
        //    }
        //    return new HttpValueCollection(query, false, true, encoding);
        //}

        /// <summary>Converts a string that has been encoded for transmission in a URL into a decoded string.</summary>
        /// <returns>A decoded string.</returns>
        /// <param name="str">The string to decode. </param>
        public static string UrlDecode(string str)
        {
            if (str == null)
            {
                return null;
            }
            return UrlDecode(str, Encoding.UTF8);
        }

        /// <summary>Converts a URL-encoded byte array into a decoded string using the specified decoding object.</summary>
        /// <returns>A decoded string.</returns>
        /// <param name="e">The <see cref="T:System.Text.Encoding"></see> that specifies the decoding scheme. </param>
        /// <param name="bytes">The array of bytes to decode. </param>
        public static string UrlDecode(byte[] bytes, Encoding e)
        {
            if (bytes == null)
            {
                return null;
            }
            return UrlDecode(bytes, 0, bytes.Length, e);
        }

        /// <summary>Converts a URL-encoded string into a decoded string, using the specified encoding object.</summary>
        /// <returns>A decoded string.</returns>
        /// <param name="e">The <see cref="T:System.Text.Encoding"></see> that specifies the decoding scheme. </param>
        /// <param name="str">The string to decode. </param>
        public static string UrlDecode(string str, Encoding e)
        {
            if (str == null)
            {
                return null;
            }
            return UrlDecodeStringFromStringInternal(str, e);
        }

        /// <summary>Converts a URL-encoded byte array into a decoded string using the specified encoding object, starting at the specified position in the array, and continuing for the specified number of bytes.</summary>
        /// <returns>A decoded string.</returns>
        /// <param name="offset">The position in the byte to begin decoding. </param>
        /// <param name="count">The number of bytes to decode. </param>
        /// <param name="e">The <see cref="T:System.Text.Encoding"></see> object that specifies the decoding scheme. </param>
        /// <param name="bytes">The array of bytes to decode. </param>
        public static string UrlDecode(byte[] bytes, int offset, int count, Encoding e)
        {
            if ((bytes == null) && (count == 0))
            {
                return null;
            }
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }
            if ((offset < 0) || (offset > bytes.Length))
            {
                throw new ArgumentOutOfRangeException("offset");
            }
            if ((count < 0) || ((offset + count) > bytes.Length))
            {
                throw new ArgumentOutOfRangeException("count");
            }
            return UrlDecodeStringFromBytesInternal(bytes, offset, count, e);
        }

        private static byte[] UrlDecodeBytesFromBytesInternal(byte[] buf, int offset, int count)
        {
            int length = 0;
            byte[] sourceArray = new byte[count];
            for (int i = 0; i < count; i++)
            {
                int index = offset + i;
                byte num4 = buf[index];
                if (num4 == 0x2b)
                {
                    num4 = 0x20;
                }
                else if ((num4 == 0x25) && (i < (count - 2)))
                {
                    int num5 = HexToInt((char)buf[index + 1]);
                    int num6 = HexToInt((char)buf[index + 2]);
                    if ((num5 >= 0) && (num6 >= 0))
                    {
                        num4 = (byte)((num5 << 4) | num6);
                        i += 2;
                    }
                }
                sourceArray[length++] = num4;
            }
            if (length < sourceArray.Length)
            {
                byte[] destinationArray = new byte[length];
                Array.Copy(sourceArray, destinationArray, length);
                sourceArray = destinationArray;
            }
            return sourceArray;
        }

        private static string UrlDecodeStringFromBytesInternal(byte[] buf, int offset, int count, Encoding e)
        {
            UrlDecoder decoder = new UrlDecoder(count, e);
            for (int i = 0; i < count; i++)
            {
                int index = offset + i;
                byte b = buf[index];
                if (b == 0x2b)
                {
                    b = 0x20;
                }
                else if ((b == 0x25) && (i < (count - 2)))
                {
                    if ((buf[index + 1] == 0x75) && (i < (count - 5)))
                    {
                        int num4 = HexToInt((char)buf[index + 2]);
                        int num5 = HexToInt((char)buf[index + 3]);
                        int num6 = HexToInt((char)buf[index + 4]);
                        int num7 = HexToInt((char)buf[index + 5]);
                        if (((num4 < 0) || (num5 < 0)) || ((num6 < 0) || (num7 < 0)))
                        {
                            break;
                        }
                        char ch = (char)((((num4 << 12) | (num5 << 8)) | (num6 << 4)) | num7);
                        i += 5;
                        decoder.AddChar(ch);
                        continue;
                    }
                    int num8 = HexToInt((char)buf[index + 1]);
                    int num9 = HexToInt((char)buf[index + 2]);
                    if ((num8 >= 0) && (num9 >= 0))
                    {
                        b = (byte)((num8 << 4) | num9);
                        i += 2;
                    }
                }
                decoder.AddByte(b);
            }
            return decoder.GetString();
        }

        private static string UrlDecodeStringFromStringInternal(string s, Encoding e)
        {
            int length = s.Length;
            UrlDecoder decoder = new UrlDecoder(length, e);
            for (int i = 0; i < length; i++)
            {
                char ch = s[i];
                if (ch == '+')
                {
                    ch = ' ';
                }
                else if ((ch == '%') && (i < (length - 2)))
                {
                    if ((s[i + 1] == 'u') && (i < (length - 5)))
                    {
                        int num3 = HexToInt(s[i + 2]);
                        int num4 = HexToInt(s[i + 3]);
                        int num5 = HexToInt(s[i + 4]);
                        int num6 = HexToInt(s[i + 5]);
                        if (((num3 < 0) || (num4 < 0)) || ((num5 < 0) || (num6 < 0)))
                        {
                            break;
                        }
                        ch = (char)((((num3 << 12) | (num4 << 8)) | (num5 << 4)) | num6);
                        i += 5;
                        decoder.AddChar(ch);
                        continue;
                    }
                    int num7 = HexToInt(s[i + 1]);
                    int num8 = HexToInt(s[i + 2]);
                    if ((num7 >= 0) && (num8 >= 0))
                    {
                        byte b = (byte)((num7 << 4) | num8);
                        i += 2;
                        decoder.AddByte(b);
                        continue;
                    }
                }
                if ((ch & 0xff80) == 0)
                {
                    decoder.AddByte((byte)ch);
                }
                else
                {
                    decoder.AddChar(ch);
                }
            }
            return decoder.GetString();
        }

        /// <summary>Converts a URL-encoded array of bytes into a decoded array of bytes.</summary>
        /// <returns>A decoded array of bytes.</returns>
        /// <param name="bytes">The array of bytes to decode. </param>
        public static byte[] UrlDecodeToBytes(byte[] bytes)
        {
            return bytes == null ? null : UrlDecodeToBytes(bytes, 0, bytes.Length);
        }

        /// <summary>Converts a URL-encoded string into a decoded array of bytes.</summary>
        /// <returns>A decoded array of bytes.</returns>
        /// <param name="str">The string to decode. </param>
        public static byte[] UrlDecodeToBytes(string str)
        {
            if (str == null)
            {
                return null;
            }
            return UrlDecodeToBytes(str, Encoding.UTF8);
        }

        /// <summary>Converts a URL-encoded string into a decoded array of bytes using the specified decoding object.</summary>
        /// <returns>A decoded array of bytes.</returns>
        /// <param name="e">The <see cref="T:System.Text.Encoding"></see> object that specifies the decoding scheme. </param>
        /// <param name="str">The string to decode. </param>
        public static byte[] UrlDecodeToBytes(string str, Encoding e)
        {
            if (str == null)
            {
                return null;
            }
            return UrlDecodeToBytes(e.GetBytes(str));
        }

        /// <summary>Converts a URL-encoded array of bytes into a decoded array of bytes, starting at the specified position in the array and continuing for the specified number of bytes.</summary>
        /// <returns>A decoded array of bytes.</returns>
        /// <param name="offset">The position in the byte array at which to begin decoding. </param>
        /// <param name="count">The number of bytes to decode. </param>
        /// <param name="bytes">The array of bytes to decode. </param>
        public static byte[] UrlDecodeToBytes(byte[] bytes, int offset, int count)
        {
            if ((bytes == null) && (count == 0))
            {
                return null;
            }
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }
            if ((offset < 0) || (offset > bytes.Length))
            {
                throw new ArgumentOutOfRangeException("offset");
            }
            if ((count < 0) || ((offset + count) > bytes.Length))
            {
                throw new ArgumentOutOfRangeException("count");
            }
            return UrlDecodeBytesFromBytesInternal(bytes, offset, count);
        }

        /// <summary>Converts a byte array into an encoded URL string.</summary>
        /// <returns>An encoded string.</returns>
        /// <param name="bytes">The array of bytes to encode. </param>
        public static string UrlEncode(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            // return Encoding.ASCII.GetString(UrlEncodeToBytes(bytes));
            return ASCIIGetString(UrlEncodeToBytes(bytes));
        }

        /// <summary>Encodes a URL string.</summary>
        /// <returns>An encoded string.</returns>
        /// <param name="str">The text to encode. </param>
        public static string UrlEncode(string str)
        {
            if (str == null)
            {
                return null;
            }
            return UrlEncode(str, Encoding.UTF8);
        }

        /// <summary>Encodes a URL string using the specified encoding object.</summary>
        /// <returns>An encoded string.</returns>
        /// <param name="e">The <see cref="T:System.Text.Encoding"></see> object that specifies the encoding scheme. </param>
        /// <param name="str">The text to encode. </param>
        public static string UrlEncode(string str, Encoding e)
        {
            if (str == null)
            {
                return null;
            }
            // return Encoding.ASCII.GetString(UrlEncodeToBytes(str, e));
            return ASCIIGetString(UrlEncodeToBytes(str, e));
        }

        /// <summary>Converts a byte array into a URL-encoded string, starting at the specified position in the array and continuing for the specified number of bytes.</summary>
        /// <returns>An encoded string.</returns>
        /// <param name="offset">The position in the byte array at which to begin encoding. </param>
        /// <param name="count">The number of bytes to encode. </param>
        /// <param name="bytes">The array of bytes to encode. </param>
        public static string UrlEncode(byte[] bytes, int offset, int count)
        {
            if (bytes == null)
            {
                return null;
            }
            // return Encoding.ASCII.GetString(UrlEncodeToBytes(bytes, offset, count));
            return ASCIIGetString(UrlEncodeToBytes(bytes, offset, count));
        }

        private static byte[] UrlEncodeBytesToBytesInternal(byte[] bytes, int offset, int count, bool alwaysCreateReturnValue)
        {
            int num = 0;
            int num2 = 0;
            for (int i = 0; i < count; i++)
            {
                char ch = (char)bytes[offset + i];
                if (ch == ' ')
                {
                    num++;
                }
                else if (!IsSafe(ch))
                {
                    num2++;
                }
            }
            if ((!alwaysCreateReturnValue && (num == 0)) && (num2 == 0))
            {
                return bytes;
            }
            byte[] buffer = new byte[count + (num2 * 2)];
            int num4 = 0;
            for (int j = 0; j < count; j++)
            {
                byte num6 = bytes[offset + j];
                char ch2 = (char)num6;
                if (IsSafe(ch2))
                {
                    buffer[num4++] = num6;
                }
                else if (ch2 == ' ')
                {
                    buffer[num4++] = 0x2b;
                }
                else
                {
                    buffer[num4++] = 0x25;
                    buffer[num4++] = (byte)IntToHex((num6 >> 4) & 15);
                    buffer[num4++] = (byte)IntToHex(num6 & 15);
                }
            }
            return buffer;
        }

        private static byte[] UrlEncodeBytesToBytesInternalNonAscii(byte[] bytes, int offset, int count, bool alwaysCreateReturnValue)
        {
            int num = 0;
            for (int i = 0; i < count; i++)
            {
                if (IsNonAsciiByte(bytes[offset + i]))
                {
                    num++;
                }
            }
            if (!alwaysCreateReturnValue && (num == 0))
            {
                return bytes;
            }
            byte[] buffer = new byte[count + (num * 2)];
            int num3 = 0;
            for (int j = 0; j < count; j++)
            {
                byte b = bytes[offset + j];
                if (IsNonAsciiByte(b))
                {
                    buffer[num3++] = 0x25;
                    buffer[num3++] = (byte)IntToHex((b >> 4) & 15);
                    buffer[num3++] = (byte)IntToHex(b & 15);
                }
                else
                {
                    buffer[num3++] = b;
                }
            }
            return buffer;
        }

        internal static string UrlEncodeNonAscii(string str, Encoding e)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            if (e == null)
            {
                e = Encoding.UTF8;
            }
            byte[] bytes = e.GetBytes(str);
            bytes = UrlEncodeBytesToBytesInternalNonAscii(bytes, 0, bytes.Length, false);
            // return Encoding.ASCII.GetString(bytes);
            return ASCIIGetString(bytes);
        }

        internal static string UrlEncodeSpaces(string str)
        {
            if ((str != null) && (str.IndexOf(' ') >= 0))
            {
                str = str.Replace(" ", "%20");
            }
            return str;
        }

        /// <summary>Converts a string into a URL-encoded array of bytes.</summary>
        /// <returns>An encoded array of bytes.</returns>
        /// <param name="str">The string to encode. </param>
        public static byte[] UrlEncodeToBytes(string str)
        {
            if (str == null)
            {
                return null;
            }
            return UrlEncodeToBytes(str, Encoding.UTF8);
        }

        /// <summary>Converts an array of bytes into a URL-encoded array of bytes.</summary>
        /// <returns>An encoded array of bytes.</returns>
        /// <param name="bytes">The array of bytes to encode. </param>
        public static byte[] UrlEncodeToBytes(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            return UrlEncodeToBytes(bytes, 0, bytes.Length);
        }

        /// <summary>Converts a string into a URL-encoded array of bytes using the specified encoding object.</summary>
        /// <returns>An encoded array of bytes.</returns>
        /// <param name="e">The <see cref="T:System.Text.Encoding"></see> that specifies the encoding scheme. </param>
        /// <param name="str">The string to encode </param>
        public static byte[] UrlEncodeToBytes(string str, Encoding e)
        {
            if (str == null)
            {
                return null;
            }
            byte[] bytes = e.GetBytes(str);
            return UrlEncodeBytesToBytesInternal(bytes, 0, bytes.Length, false);
        }

        /// <summary>Converts an array of bytes into a URL-encoded array of bytes, starting at the specified position in the array and continuing for the specified number of bytes.</summary>
        /// <returns>An encoded array of bytes.</returns>
        /// <param name="offset">The position in the byte array at which to begin encoding. </param>
        /// <param name="count">The number of bytes to encode. </param>
        /// <param name="bytes">The array of bytes to encode. </param>
        public static byte[] UrlEncodeToBytes(byte[] bytes, int offset, int count)
        {
            if ((bytes == null) && (count == 0))
            {
                return null;
            }
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }
            if ((offset < 0) || (offset > bytes.Length))
            {
                throw new ArgumentOutOfRangeException("offset");
            }
            if ((count < 0) || ((offset + count) > bytes.Length))
            {
                throw new ArgumentOutOfRangeException("count");
            }
            return UrlEncodeBytesToBytesInternal(bytes, offset, count, true);
        }

        /// <summary>Converts a string into a Unicode string.</summary>
        /// <returns>A Unicode string in %UnicodeValue notation.</returns>
        /// <param name="str">The string to convert. </param>
        public static string UrlEncodeUnicode(string str)
        {
            if (str == null)
            {
                return null;
            }
            return UrlEncodeUnicodeStringToStringInternal(str, false);
        }

        private static string UrlEncodeUnicodeStringToStringInternal(string s, bool ignoreAscii)
        {
            int length = s.Length;
            StringBuilder builder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                char ch = s[i];
                if ((ch & 0xff80) == 0)
                {
                    if (ignoreAscii || IsSafe(ch))
                    {
                        builder.Append(ch);
                    }
                    else if (ch == ' ')
                    {
                        builder.Append('+');
                    }
                    else
                    {
                        builder.Append('%');
                        builder.Append(IntToHex((ch >> 4) & '\x000f'));
                        builder.Append(IntToHex(ch & '\x000f'));
                    }
                }
                else
                {
                    builder.Append("%u");
                    builder.Append(IntToHex((ch >> 12) & '\x000f'));
                    builder.Append(IntToHex((ch >> 8) & '\x000f'));
                    builder.Append(IntToHex((ch >> 4) & '\x000f'));
                    builder.Append(IntToHex(ch & '\x000f'));
                }
            }
            return builder.ToString();
        }

        /// <summary>Converts a Unicode string into an array of bytes.</summary>
        /// <returns>A byte array.</returns>
        /// <param name="str">The string to convert. </param>
        public static byte[] UrlEncodeUnicodeToBytes(string str)
        {
            if (str == null)
            {
                return null;
            }
            return Encoding.ASCII.GetBytes(UrlEncodeUnicode(str));
        }

        /// <summary>Encodes the path portion of a URL string for reliable HTTP transmission from the Web server to a client.</summary>
        /// <returns>The URL-encoded text.</returns>
        /// <param name="str">The text to URL-encode. </param>
        public static string UrlPathEncode(string str)
        {
            if (str == null)
            {
                return null;
            }
            int index = str.IndexOf('?');
            if (index >= 0)
            {
                return (UrlPathEncode(str.Substring(0, index)) + str.Substring(index));
            }
            return UrlEncodeSpaces(UrlEncodeNonAscii(str, Encoding.UTF8));
        }

        private class UrlDecoder
        {
            private readonly int _bufferSize;
            private byte[] _byteBuffer;
            private readonly char[] _charBuffer;
            private readonly Encoding _encoding;
            private int _numBytes;
            private int _numChars;

            internal UrlDecoder(int bufferSize, Encoding encoding)
            {
                _bufferSize = bufferSize;
                _encoding = encoding;
                _charBuffer = new char[bufferSize];
            }

            internal void AddByte(byte b)
            {
                if (_byteBuffer == null)
                {
                    _byteBuffer = new byte[_bufferSize];
                }
                _byteBuffer[_numBytes++] = b;
            }

            internal void AddChar(char ch)
            {
                if (_numBytes > 0)
                {
                    FlushBytes();
                }
                _charBuffer[_numChars++] = ch;
            }

            private void FlushBytes()
            {
                if (_numBytes > 0)
                {
                    _numChars += _encoding.GetChars(_byteBuffer, 0, _numBytes, _charBuffer, _numChars);
                    _numBytes = 0;
                }
            }

            internal string GetString()
            {
                if (_numBytes > 0)
                {
                    FlushBytes();
                }
                if (_numChars > 0)
                {
                    return new string(_charBuffer, 0, _numChars);
                }
                return string.Empty;
            }
        }
    }
}
