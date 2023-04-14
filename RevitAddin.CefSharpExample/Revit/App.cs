using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using ricaun.Revit.UI;
using System;

namespace RevitAddin.CefSharpExample.Revit
{
    [AppLoader]
    public class App : IExternalApplication
    {
        private static RibbonPanel ribbonPanel;
        private static TextBox ribbomTextBox;

        public static string GetTextBoxValue()
        {
            return ribbomTextBox?.Value.ToString();
        }

        public Result OnStartup(UIControlledApplication application)
        {
            ribbonPanel = application.CreatePanel("CefSharpExample");


            //ribbonPanel.CreatePushButton<Commands.Command>()
            //    .SetText(typeof(CefSharp.AssemblyInfo).Assembly.GetName().Name)
            //    .SetLargeImage(Properties.Resources.Revit.GetBitmapSource());

            ribbomTextBox = ribbonPanel.CreateTextBox("TextBox")
                .SetPromptText("Address")
                .SetValue("http://ricaun.com")
                .SetShowImageAsButton();

            ribbomTextBox.Width = 100;
            ribbomTextBox.EnterPressed += (s, e) =>
            {
                Commands.Command.OpenWebView(GetTextBoxValue());
            };

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            ribbonPanel?.Remove();
            return Result.Succeeded;
        }
    }

}