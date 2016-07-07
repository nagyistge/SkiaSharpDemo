using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using SkiaSharp;

namespace SkiaSharpDemo
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        }
        
        void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SkiaCreatePdf();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                Debug.Print(ex.StackTrace);
            }
        }
        
        private void SkiaCreatePdf()
        {
            float width = 800f;
            float height = 600f;
            using (var stream = new SKFileWStream ("document.pdf"))
            {
                using (var document = SKDocument.CreatePdf (stream)) 
                {
                    // the first page
                    using (var canvas = document.BeginPage (width, height)) 
                    {
                        using (var paint = new SKPaint ()) 
                        {
                            canvas.DrawText ("...PDF...", 10f, 100f, paint); 
                            document.EndPage ();
                        }
                    }
                
                    // the second page
                    using (var canvas = document.BeginPage (width, height)) 
                    {
                        using (var paint = new SKPaint ()) 
                        {
                            canvas.DrawText ("...PDF...", 10f, 100f, paint); 
                            document.EndPage ();
                        }
                    }
                
                    // all done
                    document.Close ();
                }
            }
        }
    }
}
