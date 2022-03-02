using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CefSharp;
using Markdig;

namespace HOI4UMT.UI.Common;

public static class ExtensionMethods {
    public static void LoadMarkdown(this IWebBrowser browser, string path, string template) {
        string fileContent = File.ReadAllText(path);
        string markdownAsHTML = string.Format(template, Markdown.ToHtml(fileContent));
        byte[] htmlAsUTF8 = Encoding.UTF8.GetBytes(markdownAsHTML);
        string htmlAsBase64String = Convert.ToBase64String(htmlAsUTF8);
        browser.Load($"data:text/html;base64,{htmlAsBase64String}");
    }
}
