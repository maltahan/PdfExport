using PDFjet.NET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

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
                DrawComponent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }


        public void DrawComponent()
        {
            //initilize the pdf file
            FileStream fos = new FileStream("Example_03.pdf", FileMode.Create);

            BufferedStream bos = new BufferedStream(fos);

            PDF pdf = new PDF(bos);

            Page page2 = new Page(pdf, A4.PORTRAIT);

            Font Title_Font = new Font(pdf, CoreFont.HELVETICA_BOLD);

            Title_Font.SetSize(14f);

            Font Labels_Font = new Font(pdf, CoreFont.HELVETICA_BOLD);

            Labels_Font.SetSize(10f);

            // Draw the Logo
            String fileName = @"C:\Users\Fatima\Documents\PdfExport\PdfjetDemo\images\pink_elephant.png";

            FileStream fis1 = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            Image image2 = new Image(pdf, fis1, ImageType.PNG);

            image2.SetPosition(20.0f, 20.0f);

            image2.ScaleBy(0.1f);

            image2.DrawOn(page2);

            //Draw the title

            TextColumn column = new TextColumn(0);

            column.SetSpaceBetweenLines(5.0f);

            column.SetSpaceBetweenParagraphs(10.0f);

            column.SetSize(300.0f,20.0f);

            column.SetPosition(150.0f,30.0f);

            Paragraph p1 = new Paragraph();

            p1.SetAlignment(Align.CENTER);

            p1.Add(new TextLine(Title_Font, "The First Demo Using PDFJET Library"));

            column.AddParagraph(p1);

            column.DrawOn(page2);

            //Draw the Form

            TextColumn Labels_Colomn = new TextColumn(0);

            Labels_Colomn.SetSpaceBetweenLines(5.0f);

            Labels_Colomn.SetSpaceBetweenParagraphs(10.0f);

            Labels_Colomn.SetPosition(10.0f, 50.0f);

            //Labels_Colomn.SetAlignment(Align.LEFT);

            column.SetSize(150.0f, 20.0f);

            Paragraph p2 = new Paragraph();

            p2.SetAlignment(Align.CENTER);

            p2.Add(new TextLine(Labels_Font, "First Name:"));
           
            Labels_Colomn.AddParagraph(p2);

            Labels_Colomn.DrawOn(page2);

            //Write to the pdf file
            pdf.Flush();
            bos.Close();
        }
    }
}