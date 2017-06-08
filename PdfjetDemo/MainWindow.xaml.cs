using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using PDFjet.NET;
using System.Windows;

namespace PdfjetDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }

        public class Example_02
        {
           
                public Example_02()
                {
                    
                    FileStream fos = new FileStream(@"c:\\temp\\Example_02.pdf", FileMode.Create);
                    BufferedStream bos = new BufferedStream(fos);

                    PDF pdf = new PDF(bos);
                    Page page = new Page(pdf, Letter.PORTRAIT);

                    Box flag = new Box(85, 85, 64, 32);

                    PDFjet.NET.Path path = new PDFjet.NET.Path();
                    path.Add(new PDFjet.NET.Point(13.0, 0.0));
                    path.Add(new PDFjet.NET.Point(15.5, 4.5));

                    path.Add(new PDFjet.NET.Point(18.0, 3.5));
                    path.Add(new PDFjet.NET.Point(15.5, 13.5, PDFjet.NET.Point.CONTROL_POINT));
                    path.Add(new PDFjet.NET.Point(15.5, 13.5, PDFjet.NET.Point.CONTROL_POINT));
                    path.Add(new PDFjet.NET.Point(20.5, 7.5));

                    path.Add(new PDFjet.NET.Point(21.0, 9.5));
                    path.Add(new PDFjet.NET.Point(25.0, 9.0));
                    path.Add(new PDFjet.NET.Point(24.0, 13.0));
                    path.Add(new PDFjet.NET.Point(25.5, 14.0));
                    path.Add(new PDFjet.NET.Point(19.0, 19.0));
                    path.Add(new PDFjet.NET.Point(20.0, 21.5));
                    path.Add(new PDFjet.NET.Point(13.5, 20.5));
                    path.Add(new PDFjet.NET.Point(13.5, 27.0));
                    path.Add(new PDFjet.NET.Point(12.5, 27.0));
                    path.Add(new PDFjet.NET.Point(12.5, 20.5));
                    path.Add(new PDFjet.NET.Point(6.0, 21.5));
                    path.Add(new PDFjet.NET.Point(7.0, 19.0));
                    path.Add(new PDFjet.NET.Point(0.5, 14.0));
                    path.Add(new PDFjet.NET.Point(2.0, 13.0));
                    path.Add(new PDFjet.NET.Point(1.0, 9.0));
                    path.Add(new PDFjet.NET.Point(5.0, 9.5));

                    path.Add(new PDFjet.NET.Point(5.5, 7.5));
                    path.Add(new PDFjet.NET.Point(10.5, 13.5, PDFjet.NET.Point.CONTROL_POINT));
                    path.Add(new PDFjet.NET.Point(10.5, 13.5, PDFjet.NET.Point.CONTROL_POINT));
                    path.Add(new PDFjet.NET.Point(8.0, 3.5));

                    path.Add(new PDFjet.NET.Point(10.5, 4.5));
                    path.SetClosePath(true);
                    path.SetColor(Color.red);
                    path.SetFillShape(true);
                    path.PlaceIn(flag, 19.0, 3.0);
                    path.DrawOn(page);

                    Box box = new Box();
                    box.SetSize(16, 32);
                    box.SetColor(Color.red);
                    box.SetFillShape(true);
                    box.PlaceIn(flag, 0.0, 0.0);
                    box.DrawOn(page);
                    box.PlaceIn(flag, 48.0, 0.0);
                    box.DrawOn(page);

                    path.ScaleBy(15.0);
                    path.SetFillShape(false);
                    path.DrawOn(page);

                    pdf.Flush();
                    bos.Close();
                }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new Example_02();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.StackTrace);
            }
        }
    }
}