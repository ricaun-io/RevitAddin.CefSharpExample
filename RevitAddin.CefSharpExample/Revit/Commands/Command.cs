using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAddin.CefSharpExample.Views;
using System;

namespace RevitAddin.CefSharpExample.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        static WebView WebView { get; set; }
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            OpenWebView(App.GetTextBoxValue());

            return Result.Succeeded;
        }

        public static void OpenWebView(string address)
        {
            WebView?.SetAddress(address);
            if (WebView is null)
            {
                WebView = new WebView(address);
                WebView.Closed += (s, e) => { WebView = null; };
                WebView.Show();
            }
            WebView?.Activate();
        }
    }
}
