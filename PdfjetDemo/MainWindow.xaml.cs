using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using PDFjet.NET;
using System.Windows;
using System.Diagnostics;

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

            Open_Pdf_Button.IsEnabled = false;
        }

        public void DrawComponent()
        {
            #region   initilize the pdf file

            FileStream fos = new FileStream("PdfJet.pdf", FileMode.Create);

            BufferedStream bos = new BufferedStream(fos);

            PDF pdf = new PDF(bos);

            Page page2 = new Page(pdf, A4.PORTRAIT);

            Font Title_Font = new Font(pdf, CoreFont.HELVETICA_BOLD);

            Title_Font.SetSize(14f);

            Font Labels_Font = new Font(pdf, CoreFont.HELVETICA_BOLD);

            Labels_Font.SetSize(10f);

            #endregion

            #region Draw the Logo

            String fileName = @"C:\Users\Fatima\Documents\PdfExport\PdfjetDemo\images\pink_elephant.png";

            FileStream fis1 = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            Image image2 = new Image(pdf, fis1, ImageType.PNG);

            image2.SetPosition(20.0f, 20.0f);

            image2.ScaleBy(0.1f);

            image2.DrawOn(page2);

            #endregion

            #region Draw the title

            TextColumn column = new TextColumn(0);

            column.SetSpaceBetweenLines(5.0f);

            column.SetSpaceBetweenParagraphs(10.0f);

            column.SetSize(300.0f, 20.0f);

            column.SetPosition(150.0f, 30.0f);

            Paragraph p1 = new Paragraph();

            p1.SetAlignment(Align.CENTER);

            p1.Add(new TextLine(Title_Font, "The First Demo Using PDFJET Library"));

            column.AddParagraph(p1);

            column.DrawOn(page2);
            #endregion

            #region Draw the Form

            // Set the Colomn for the labels

            TextColumn Labels_Colomn = new TextColumn(0);

            Labels_Colomn.SetSpaceBetweenLines(5.0f);

            Labels_Colomn.SetSpaceBetweenParagraphs(10.0f);

            Labels_Colomn.SetPosition(10.0f, 80.0f);

            Labels_Colomn.SetSize(150.0f, 20.0f);

            Labels_Colomn.SetSpaceBetweenParagraphs(20);


            //Set The Text for the labels

            Paragraph First_Name = new Paragraph();

            First_Name.Add(new TextLine(Labels_Font, "First Name:"));

            Paragraph Last_Name = new Paragraph();

            Last_Name.Add(new TextLine(Labels_Font, "Last Name:"));

            Paragraph Gender = new Paragraph();

            Gender.Add(new TextLine(Labels_Font, "Gender:"));

            Paragraph Favourite_sport = new Paragraph();

            Favourite_sport.Add(new TextLine(Labels_Font, "sport:"));

            TextBox First_Name_Textbox = new TextBox(Labels_Font);

            First_Name_Textbox.SetText("Mohammad");

            First_Name_Textbox.SetPosition(80.0f, 80.0f);

            TextBox Last_Name_Textbox = new TextBox(Labels_Font);

            Last_Name_Textbox.SetText("Altahan");

            Last_Name_Textbox.SetPosition(80.0f, 110.0f);


            //add Radio buttons to the form

            RadioButton Male_Radiobutton = new RadioButton(Labels_Font, "Male");

            Male_Radiobutton.SetPosition(80.0f, 150.0f);

            Male_Radiobutton.Select(true);

            RadioButton Female_Radiobutton = new RadioButton(Labels_Font, "Female");

            Female_Radiobutton.SetPosition(130.0f, 150.0f);

            //add Radio buttons to the form

            CheckBox Football_checkbox = new CheckBox(Labels_Font, "Football");

            Football_checkbox.SetPosition(80.0f, 180.0f);

            Football_checkbox.Check(Mark.CHECK);

            CheckBox swimming_checkbox = new CheckBox(Labels_Font, "Swimming");

            swimming_checkbox.SetPosition(150.0f, 180.0f);

            swimming_checkbox.Check(Mark.CHECK);

            CheckBox joggen_checkbox = new CheckBox(Labels_Font, "joggen");

            joggen_checkbox.SetPosition(220.0f, 180.0f);

            #endregion

            #region add images to the file

            String montana = @"C:\Users\Fatima\Documents\images\montana_1990.jpg";

            Image image1 = new Image(pdf, new FileStream(montana, FileMode.Open), ImageType.JPG);

            image1.SetLocation(20f, 220f);

            image1.SetAltDescription("montana_1990 image");

            image1.ScaleBy(0.09f);

            image1.DrawOn(page2);

            String europelargesm = @"C:\Users\Fatima\Documents\images\europelargesm.jpg";

            Image europ_image = new Image(pdf, new FileStream(europelargesm, FileMode.Open), ImageType.JPG);

            europ_image.SetLocation(230f, 220f);

            europ_image.SetAltDescription("europelargesm image");            

            europ_image.ScaleBy(0.26f);

            europ_image.DrawOn(page2);

            String fruits = @"C:\Users\Fatima\Documents\images\Culinary_fruits_front_view.jpg";

            Image fruits_image = new Image(pdf, new FileStream(fruits, FileMode.Open), ImageType.JPG);

            fruits_image.SetLocation(390f, 220f);

            fruits_image.SetAltDescription("fruit image");

            fruits_image.ScaleBy(0.047f);

            fruits_image.DrawOn(page2);

            //Description for the first image
            TextColumn Images_Column = new TextColumn(0);

            Images_Column.SetSpaceBetweenLines(5.0f);

            Images_Column.SetSpaceBetweenParagraphs(10.0f);

            Images_Column.SetPosition(60f, 350f);

            Images_Column.SetSize(400f,20f);

            Paragraph Montant_image_Decription = new Paragraph();

            Font f4 = new Font(pdf, CoreFont.HELVETICA_OBLIQUE);

            f4.SetSize(10f);

            Montant_image_Decription.Add(new TextLine(f4, "montana 1990"));

            Images_Column.AddParagraph(Montant_image_Decription);

            Images_Column.DrawOn(page2);


            //Description for the second image
            TextColumn Europe_colomn = new TextColumn(0);

            Europe_colomn.SetSpaceBetweenLines(5.0f);

            Europe_colomn.SetSpaceBetweenParagraphs(10.0f);

            Europe_colomn.SetPosition(240f, 350f);

            Europe_colomn.SetSize(400f, 20f);

            Paragraph Europ_image_Decription = new Paragraph();

            Europ_image_Decription.Add(new TextLine(f4, "europelargesm"));

            Europe_colomn.AddParagraph(Europ_image_Decription);

            Europe_colomn.DrawOn(page2);

            //Description for the third image

            TextColumn Fruit_colomn = new TextColumn(0);

            Fruit_colomn.SetSpaceBetweenLines(5.0f);

            Fruit_colomn.SetSpaceBetweenParagraphs(10.0f);

            Fruit_colomn.SetPosition(400f, 350f);

            Fruit_colomn.SetSize(400f, 20f);

            Paragraph EFruit_image_Decription = new Paragraph();

            EFruit_image_Decription.Add(new TextLine(f4, "Culinary fruits front view"));

            Fruit_colomn.AddParagraph(EFruit_image_Decription);

            Fruit_colomn.DrawOn(page2);

            #endregion

            #region  add component to the page

            //add the labels to the colomn

            Labels_Colomn.AddParagraph(First_Name);

            Labels_Colomn.AddParagraph(Last_Name);

            Labels_Colomn.AddParagraph(Gender);

            Labels_Colomn.AddParagraph(Favourite_sport);


            //add the Textboxes to the page

            First_Name_Textbox.DrawOn(page2);

            Last_Name_Textbox.DrawOn(page2);


            //add the column to the page

            Labels_Colomn.DrawOn(page2);

            //add the Radio buttons to the page

            Male_Radiobutton.DrawOn(page2);

            Female_Radiobutton.DrawOn(page2);

            //add the Checkboxes to the page

            Football_checkbox.DrawOn(page2);

            swimming_checkbox.DrawOn(page2);

            joggen_checkbox.DrawOn(page2);
            #endregion

            //#region  Add a table to the file

            //TextLine Table_text = new TextLine(Title_Font, "Some data about world communications");

            //Table_text.SetPosition(20.0f, 220.0f);

            //Table table = new Table();

            //Font Header_Font = new Font(pdf, CoreFont.HELVETICA_BOLD);

            //Header_Font.SetSize(7.0f);

            //Font Cell_Font = new Font(pdf, CoreFont.HELVETICA);

            //Cell_Font.SetSize(7.0f);

            //List<List<Cell>> tableData = GetData("WorldData.txt", "|", Table.DATA_HAS_2_HEADER_ROWS, Header_Font, Cell_Font);

            //table.SetData(tableData, Table.DATA_HAS_2_HEADER_ROWS);

            //table.SetPosition(20.0f, 240.0f);

            //table.SetTextColorInRow(6, Color.blue);

            //table.SetTextColorInRow(39, Color.red);

            //table.RemoveLineBetweenRows(0, 1);

            //table.AutoAdjustColumnWidths();

            //table.SetColumnWidth(0, 120);

            //table.RightAlignNumbers();

            //int numOfPages = table.GetNumberOfPages(page2);

            //Table_text.DrawOn(page2);

            //while (true)
            //{
            //    table.DrawOn(page2);
            //    // TO DO: Draw "Page 1 of N" here
            //    if (!table.HasMoreData())
            //    {
            //        // Allow the table to be drawn again later:
            //        table.ResetRenderedPagesCount();
            //        break;
            //    }
            //    page2 = new Page(pdf, Letter.PORTRAIT);
            //}

            //#endregion

            #region Write to the pdf file
            pdf.Flush();
            bos.Close();
            #endregion
        }

        public List<List<Cell>> GetData(String fileName, String delimiter, int numOfHeaderRows, Font f1, Font f2)
        {

            List<List<Cell>> tableData = new List<List<Cell>>();

            int currentRow = 0;
            StreamReader reader = new StreamReader(fileName);
            String line = null;
            while ((line = reader.ReadLine()) != null)
            {
                List<Cell> row = new List<Cell>();
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
                for (int i = 0; i < cols.Length; i++)
                {
                    String text = cols[i].Trim();
                    if (currentRow < numOfHeaderRows)
                    {
                        row.Add(new Cell(f1, text));
                    }
                    else
                    {
                        row.Add(new Cell(f2, text));
                    }
                }
                tableData.Add(row);
                currentRow++;
            }
            reader.Close();

            return tableData;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DrawComponent();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.StackTrace);
            }

            Create_Pdf_Button.IsEnabled = false;

            Pdf_File_Ready.Content = "The pdf file is ready click open button to open it";

            Open_Pdf_Button.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start("PdfJet.pdf");
        }
    }
}