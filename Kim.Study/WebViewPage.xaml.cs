using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xam.Plugin.WebView.Abstractions;
using Xam.Plugin.WebView.Abstractions.Enumerations;
using Xamarin.Forms;

namespace Kim.Study
{
    public partial class WebViewPage : ContentPage
    {
        public WebViewPage()
        {
            InitializeComponent();

            //FormsWebView WebView = new FormsWebView();

            //WebView.RemoveLocalCallback("test");

            this.Appearing += (s, e) =>
            {
                string html = @"<!DOCTYPE html>
<html>
    <head>
        <meta charset=""utf-8"">
        <title>test</title>
        <script src=""https://cdn.bootcss.com/jquery/3.3.1/jquery.min.js""></script>

    </head>
    <body style=""background-color: red;"">
        <h1>测试</h1>
        <button>点击我</button>
        <script type=""text/javascript"">
            function H5Calc() {
                alert(""I'm H5"");
            }

            $(function() {
                $(""button"").click(function() {
                    test(""abc"");
                });
            });
        </script>
    </body>
</html>
";
                this.myWebView.Source = html;
                this.myWebView.AddLocalCallback("test", (str) => this.myWebView.InjectJavascriptAsync("alert('" + str + "');"));

                this.lblText.Text = "new value";
            };


            //FormsWebView WebView2 = new FormsWebView()
            //{
            //    ContentType = WebViewContentType.Internet,
            //    Source = "http://www.somewebsite.com"
            //};

        }

        void Handle_OnContentLoaded(object sender, System.EventArgs e)
        {
            this.myWebView.InjectJavascriptAsync("H5Calc();").ConfigureAwait(true);
        }

        void Handle_OnNavigationCompleted(object sender, string e)
        {
            this.myWebView.InjectJavascriptAsync("H5Calc();").ConfigureAwait(true);
        }
    }
}
