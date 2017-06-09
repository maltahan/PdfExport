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

            //Write to the pdf file
            pdf.Flush();
            bos.Close();
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