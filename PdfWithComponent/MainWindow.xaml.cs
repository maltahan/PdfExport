using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PdfWithComponent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static Font titleFont = FontFactory.GetFont("Courier", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        string path = @"c:\\temp\\Sample-PDF-File.pdf";
        //string path = "c:\\temp\\Sample-PDF-File" + DateTime.Now.ToString("yyyyMMdd_hhmmss");
        public MainWindow()
        {
            InitializeComponent();           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            //Create document
            Document doc = new Document();
            //Create PDF Table
            PdfPTable tableLayout = new PdfPTable(4);

            //Create a PDF file in specific path
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));

            //Open the PDF document
            doc.Open();

            //Add Content to PDF
            doc.Add(Add_Content_To_PDF(tableLayout));

            // Closing the document
            doc.Close();

            btnOpenPDFFile.IsEnabled = true;
            btnGeneratePDFFile.IsEnabled = false;
        }

        private PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)
        {
            
            float[] headers = { 20, 20, 30, 30 };  //Header Widths
            tableLayout.SetWidths(headers);        //Set the pdf headers
            tableLayout.WidthPercentage = 80;       //Set the PDF File witdh percentage

            //Add Title to the PDF file at the top
            tableLayout.AddCell(new PdfPCell(new Phrase("Creating PDF file using iTextsharp", new Font(titleFont.Family, 13, 1, new iTextSharp.text.BaseColor(153, 51, 0)))) { Colspan = 4, Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_CENTER });

            //Add header
            AddCellToHeader(tableLayout, "Cricketer Name");
            AddCellToHeader(tableLayout, "Height");
            AddCellToHeader(tableLayout, "Born On");
            AddCellToHeader(tableLayout, "Parents");

            //Add body
            AddCellToBody(tableLayout, "Sachin Tendulkar");
            AddCellToBody(tableLayout, "1.65 m");
            AddCellToBody(tableLayout, "April 24, 1973");
            AddCellToBody(tableLayout, "Ramesh Tendulkar, Rajni Tendulkar");

            AddCellToBody(tableLayout, "Mahendra Singh Dhoni");
            AddCellToBody(tableLayout, "1.75 m");
            AddCellToBody(tableLayout, "July 7, 1981");
            AddCellToBody(tableLayout, "Devki Devi, Pan Singh");

            AddCellToBody(tableLayout, "Virender Sehwag");
            AddCellToBody(tableLayout, "1.70 m");
            AddCellToBody(tableLayout, "October 20, 1978");
            AddCellToBody(tableLayout, "Aryavir Sehwag, Vedant Sehwag");

            AddCellToBody(tableLayout, "Virat Kohli");
            AddCellToBody(tableLayout, "1.75 m");
            AddCellToBody(tableLayout, "November 5, 1988");
            AddCellToBody(tableLayout, "Saroj Kohli, Prem Kohli");

            return tableLayout;
        }

        // Method to add single cell to the header
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(titleFont.Family, 8, 1, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5, BackgroundColor = new BaseColor(0, 51, 102) });
        }

        // Method to add single cell to the body
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(titleFont.Family, 8, 1, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5, BackgroundColor = BaseColor.WHITE });
        }

        private void btnOpenPDFFile_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(path);
            btnGeneratePDFFile.IsEnabled = true;
            btnOpenPDFFile.IsEnabled = false;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
