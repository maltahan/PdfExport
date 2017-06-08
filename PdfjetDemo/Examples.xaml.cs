using PDFjet.NET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PdfjetDemo
{
    /// <summary>
    /// Interaction logic for Examples.xaml
    /// </summary>
    public partial class Examples : Window
    {
        public Examples()
        {

            InitializeComponent();

            try
            {
                new Example_03();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }


        public class Example_09
        {
            public Example_09()
            {

                FileStream fos = new FileStream("Example_09.pdf", FileMode.Create);
                BufferedStream bos = new BufferedStream(fos);

                PDF pdf = new PDF(bos);
                PDFjet.NET.Page page = new PDFjet.NET.Page(pdf, Letter.PORTRAIT);

                Font f1 = new Font(pdf, CoreFont.HELVETICA_BOLD);
                Font f2 = new Font(pdf, CoreFont.HELVETICA_BOLD);
                Font f3 = new Font(pdf, CoreFont.HELVETICA_BOLD);
                Font f4 = new Font(pdf, CoreFont.HELVETICA);

                f1.SetSize(10);
                f2.SetSize(8);
                f3.SetSize(7);
                f4.SetSize(7);

                Chart chart = new Chart(f1, f2);
                chart.SetTitle("World View - Communications");
                chart.SetXAxisTitle("Cell phones per capita");
                chart.SetYAxisTitle("Internet users % of the population");

                chart.SetData(GetData("data/world-communications.txt", "|"));
                addTrendLine(chart);

                chart.SetPosition(70, 50);
                chart.SetSize(500, 300);
                chart.DrawOn(page);

                addTableToChart(page, chart, f3, f4);

                pdf.Flush();
                bos.Close();
            }


            public void addTrendLine(Chart chart)
            {
                List<PDFjet.NET.Point> Points = chart.GetData()[0];

                double m = chart.Slope(Points);
                double b = chart.Intercept(Points, m);

                List<PDFjet.NET.Point> trendline = new List<PDFjet.NET.Point>();
                double x = 0.0;
                double y = m * x + b;
                PDFjet.NET.Point p1 = new PDFjet.NET.Point(x, y);
                //p1.SetDrawLineTo(true);
                p1.SetColor(PDFjet.NET.Color.blue);
                p1.SetShape(PDFjet.NET.Point.INVISIBLE);

                x = 1.5;
                y = m * x + b;
                PDFjet.NET.Point p2 = new PDFjet.NET.Point(x, y);
                //p2.SetDrawLineTo(true);
                p2.SetColor(PDFjet.NET.Color.blue);
                p2.SetShape(PDFjet.NET.Point.INVISIBLE);
                trendline.Add(p1);
                trendline.Add(p2);

                chart.GetData().Add(trendline);
            }


            public void addTableToChart(PDFjet.NET.Page page, Chart chart, Font f3, Font f4)
            {
                PDFjet.NET.Table table = new PDFjet.NET.Table();
                List<List<Cell>> tableData = new List<List<Cell>>();
                List<PDFjet.NET.Point> Points = chart.GetData()[0];
                for (int i = 0; i < Points.Count; i++)
                {
                    PDFjet.NET.Point Point = Points[i];
                    if (Point.GetShape() != PDFjet.NET.Point.CIRCLE)
                    {
                        List<Cell> tableRow = new List<Cell>();

                        Cell cell = new Cell(f4);
                        cell.SetPoint(Point);
                        tableRow.Add(cell);

                        cell = new Cell(f4);
                        cell.SetText(Point.GetText());
                        tableRow.Add(cell);

                        cell = new Cell(f4);
                        cell.SetText(Point.GetURIAction());
                        tableRow.Add(cell);

                        tableData.Add(tableRow);
                    }
                }
                table.SetData(tableData);
                table.AutoAdjustColumnWidths();
                table.SetPosition(70.0, 360.0);
                table.SetColumnWidth(0, 9.0);
                table.DrawOn(page);
            }

            public List<List<PDFjet.NET.Point>> GetData(String fileName, String delimiter)
            {
                List<List<PDFjet.NET.Point>> chartData = new List<List<PDFjet.NET.Point>>();

                StreamReader reader =
                        new StreamReader(fileName);
                List<PDFjet.NET.Point> Points = new List<PDFjet.NET.Point>();
                String line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    String[] cols = null;
                    if (delimiter.Equals("|"))
                    {
                        cols = line.Split(new Char[] { '|' });
                    }
                    else if (delimiter.Equals("\t"))
                    {
                        cols = line.Split(new Char[] { '\t' });
                    }
                    else
                    {
                        throw new Exception("Only pipes and tabs can be used as delimiters");
                    }

                    PDFjet.NET.Point Point = new PDFjet.NET.Point();
                    try
                    {
                        double population = Double.Parse(cols[1].Replace(",", ""));
                        Point.SetText(cols[0].Trim());
                        String country_name = Point.GetText();
                        country_name = country_name.Replace(" ", "_");
                        country_name = country_name.Replace("'", "_");
                        country_name = country_name.Replace(",", "_");
                        country_name = country_name.Replace("(", "_");
                        country_name = country_name.Replace(")", "_");
                        Point.SetURIAction("http://pdfjet.com/country/" + country_name + ".txt");
                        Point.SetX(Double.Parse(cols[5].Replace(",", "")) / population);
                        Point.SetY(Double.Parse(cols[7].Replace(",", "")) / population * 100);
                        Point.SetRadius(2.0);

                        if (Point.GetX() > 1.25)
                        {
                            Point.SetShape(PDFjet.NET.Point.RIGHT_ARROW);
                        }
                        if (Point.GetY() > 80)
                        {
                            Point.SetShape(PDFjet.NET.Point.UP_ARROW);
                            // PDFjet.NET.Point.SetFillShape(true);
                            Point.SetColor(PDFjet.NET.Color.blue);
                        }
                        if (Point.GetText().Equals("France"))
                        {
                            Point.SetShape(PDFjet.NET.Point.MULTIPLY);
                            // PDFjet.NET.Point.SetDrawLineTo(true);
                        }
                        if (Point.GetText().Equals("Canada"))
                        {
                            Point.SetShape(PDFjet.NET.Point.BOX);
                            // PDFjet.NET.Point.SetDrawLineTo(true);
                        }
                        if (Point.GetText().Equals("United States"))
                        {
                            Point.SetShape(PDFjet.NET.Point.STAR);
                            // PDFjet.NET.Point.SetDrawLineTo(true);
                        }

                        Points.Add(Point);
                    }
                    catch (Exception exp)
                    {
                        // Don't print or log the exceptions and
                        // prevent csc from generating warnings

                    }
                }
                reader.Close();
                chartData.Add(Points);

                return chartData;
            }


        }

        public class Example_03
            {

                public Example_03()
                {

                    FileStream fos = new FileStream("Example_03.pdf", FileMode.Create);
                    BufferedStream bos = new BufferedStream(fos);

                    PDF pdf = new PDF(bos);

                Font f1 = new Font(pdf, CoreFont.HELVETICA);

                //String fileName = "images/eu-map.jpg";
                //FileStream fis1 = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                //PDFjet.NET.Image image1 = new PDFjet.NET.Image(pdf, fis1, ImageType.JPG);

                //fileName = "images/fruit.jpg";
                //FileStream fis2 = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                //PDFjet.NET.Image image2 = new PDFjet.NET.Image(pdf, fis2, ImageType.JPG);

                //fileName = "images/mt-map.jpg";
                //FileStream fis3 = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                //PDFjet.NET.Image image3 = new PDFjet.NET.Image(pdf, fis3, ImageType.JPG);

                //PDFjet.NET.Page page = new PDFjet.NET.Page(pdf, A4.PORTRAIT);

                //TextLine text = new TextLine(f1,"The map below is an embedded PNG image");
                //text.SetPosition(90.0f, 30.0f);
                //text.DrawOn(page);

                //image1.SetPosition(90.0f, 40.0f);
                //image1.DrawOn(page);

                //text.SetText("JPG image file embedded once and drawn 3 times");
                //text.SetPosition(90.0f, 550.0f);
                //text.DrawOn(page);

                //image2.SetPosition(90.0f, 560.0f);
                //image2.ScaleBy(0.5f);
                //image2.DrawOn(page);

                //image2.SetPosition(260.0f, 560.0f);
                //image2.SetRotateCW90(true);
                //image2.ScaleBy(0.5f);
                //image2.DrawOn(page);

                //image2.SetPosition(350.0f, 560.0f);
                //image2.SetRotateCW90(false);
                //image2.ScaleBy(0.5f);
                //image2.DrawOn(page);

                //text.SetText("The map on the right is an embedded BMP image");
                //text.SetUnderline(true);
                ////text.SetStrikeLine(true);
                //text.SetTextDirection(15);
                //text.SetPosition(90.0f, 800.0f);
                //text.DrawOn(page);

                //image3.SetPosition(390.0f, 630.0f);
                //image3.ScaleBy(0.5f);
                //image3.DrawOn(page);

                TextLine t1 = new TextLine(f1, "The map below is an embedded PNG image");
                t1.SetPosition(90.0f, 30.0f);
                String fileName = @"C:\temp\fruit.jpg";
                //String fileName = System.IO.Path.Combine(Environment.CurrentDirectory, @"images\", "fruit.jpg");
                FileStream fis1 = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                PDFjet.NET.Image image2 = new PDFjet.NET.Image(pdf, fis1, ImageType.JPG);
                image2.SetPosition(260.0f, 560.0f);
                image2.SetRotateCW90(true);
                image2.ScaleBy(0.5f);

                PDFjet.NET.Page page2 = new PDFjet.NET.Page(pdf, A4.PORTRAIT);
                image2.DrawOn(page2);
                t1.DrawOn(page2);
                pdf.Flush();
                    bos.Close();
                }

            }
       
    }
}