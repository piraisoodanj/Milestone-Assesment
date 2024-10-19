using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace iTextSharpPDFManipulationAssesment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input details
            string pdfPath = "SalesReport.pdf";
            string modifiedPdfPath = "ModifiedSalesReport.pdf";
            string title = "Monthly Sales Report";
            string text = "Total Sales: $10,000";
            string imagePath = @"C:\Users\Administrator\Desktop\sampleImg.png";
            string additionalText = "Additional Information: Sales exceeded expectations.";

            // 1. Generate the PDF
            GeneratePdf(pdfPath, title, text, imagePath);

            // 2. Modify the existing PDF
            ModifyPdf(pdfPath, modifiedPdfPath, additionalText);
        }

               
        static void GeneratePdf(string pdfPath, string title, string text, string imagePath)
        {
            try
            {
                // Create the document object
                Document document = new Document();

                // Set up the PDF writer and file stream
                PdfWriter.GetInstance(document, new FileStream(pdfPath, FileMode.Create));

                // Open the document to allow writing
                document.Open();

                // Add the title with bold formatting and center alignment
                Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                Paragraph titleParagraph = new Paragraph(title, titleFont);
                titleParagraph.Alignment = Element.ALIGN_CENTER;
                document.Add(titleParagraph);

                // Add some space before the next section
                document.Add(new Paragraph("\n"));

                // Add the text content
                Font textFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                Paragraph textParagraph = new Paragraph(text, textFont);
                document.Add(textParagraph);

                // Add some space before the next section
                document.Add(new Paragraph("\n\n"));

                // Check if the image exists and add it to the document
                if (File.Exists(imagePath))
                {
                    Image img = Image.GetInstance(imagePath);
                    img.ScaleToFit(400f, 300f); // Adjust image size
                    img.Alignment = Element.ALIGN_CENTER;
                    document.Add(img);
                }
                else
                {
                    Console.WriteLine("Image file not found: " + imagePath);
                }

                // Close the document
                document.Close();

                Console.WriteLine("PDF generated successfully at: " + Path.GetFullPath(pdfPath));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while generating the PDF: " + ex.Message);
            }
        }

        
        static void ModifyPdf(string originalPdfPath, string modifiedPdfPath, string additionalText)
        {
            try
            {
                // Check if original PDF exists
                if (!File.Exists(originalPdfPath))
                {
                    Console.WriteLine("Original PDF file not found: " + originalPdfPath);
                    return;
                }

                // Open the existing PDF for reading
                PdfReader reader = new PdfReader(originalPdfPath);
                using (FileStream fs = new FileStream(modifiedPdfPath, FileMode.Create))
                {
                    // Create a stamper to apply modifications
                    PdfStamper stamper = new PdfStamper(reader, fs);

                    // Get the first page to add additional text
                    PdfContentByte cb = stamper.GetOverContent(1);

                    // Add additional text to the first page
                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    cb.BeginText();
                    cb.SetFontAndSize(bf, 12);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, additionalText,100, 350, 0); // Position text
                    cb.EndText();

                    stamper.Close();
                }

                Console.WriteLine("PDF modified successfully at: " + Path.GetFullPath(modifiedPdfPath));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while modifying the PDF: " + ex.Message);
            }
        }
    }
}