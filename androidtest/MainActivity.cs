using Android.App;
using Android.Widget;
using Android.OS;

namespace androidtest
{
    [Activity(Label = "androidtest", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate { button.Text = $"{count++} clicks!"; };

            Android.Webkit.WebView webView = FindViewById<Android.Webkit.WebView>(Resource.Id.webView1);
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
            webView.LoadData(html, "text/html", "utf-8");
        }
    }
}

