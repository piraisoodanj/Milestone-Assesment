using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Part2CrestionAndModifyingPDF
{
    class CSVToPDFReport
    {
        static void Main(string[] args)
        {
            // Path to the CSV file
            string csvFilePath = @"C:\Users\Administrator\Desktop\C#_Assesment\Milestone-Assesment\MilestoneAssesment6\Part2CrestionAndModifyingPDF\SampleInput.csv";
            string pdfFilePath = "SummaryReport.pdf";

            // 1. Read and parse CSV data
            List<DataRecord> records = ReadCsvFile(csvFilePath);

            if (records != null)
            {
                // 2. Generate the PDF report
                GeneratePdfReport(records, pdfFilePath);
            }
        }

        
        static List<DataRecord> ReadCsvFile(string csvFilePath)
        {
            List<DataRecord> records = new List<DataRecord>();

            try
            {
                using (var reader = new StreamReader(csvFilePath))
                {
                    string line;
                    bool isFirstLine = true;

                    while ((line = reader.ReadLine()) != null)
                    {
                        // Skip header line
                        if (isFirstLine)
                        {
                            isFirstLine = false;
                            continue;
                        }

                        string[] values = line.Split(',');

                        // Ensure we have exactly two values in each line
                        if (values.Length == 2)
                        {
                            string name = values[0].Trim();
                            decimal amount;

                            // Check if the second column is a valid decimal
                            if (decimal.TryParse(values[1].Trim(), out amount))
                            {
                                records.Add(new DataRecord(name, amount));
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount for: " + values[0]);
                            }
                        }
                    }
                }

                Console.WriteLine("CSV file read successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading the CSV file: " + ex.Message);
                return null;
            }

            return records;
        }

        
        static void GeneratePdfReport(List<DataRecord> records, string pdfFilePath)
        {
            try
            {
                // Create the document object
                Document document = new Document();

                // Set up the PDF writer and file stream
                PdfWriter.GetInstance(document, new FileStream(pdfFilePath, FileMode.Create));

                // Open the document to allow writing
                document.Open();

                // Add a title
                Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                Paragraph title = new Paragraph("Monthly Sales Summary", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                // Add some space before the table
                document.Add(new Paragraph("\n"));

                // Create a table with two columns: Name and Amount
                PdfPTable table = new PdfPTable(2); // 2 columns
                table.WidthPercentage = 100;

                // Add table headers
                Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                PdfPCell nameHeader = new PdfPCell(new Phrase("Name", headerFont));
                nameHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(nameHeader);

                PdfPCell amountHeader = new PdfPCell(new Phrase("Amount", headerFont));
                amountHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(amountHeader);

                // Add rows for each record in the CSV
                Font rowFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                foreach (var record in records)
                {
                    // Name cell
                    PdfPCell nameCell = new PdfPCell(new Phrase(record.Name, rowFont));
                    nameCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    table.AddCell(nameCell);

                    // Amount cell
                    PdfPCell amountCell = new PdfPCell(new Phrase(record.Amount.ToString("C"), rowFont)); // Currency format
                    amountCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(amountCell);
                }

                // Add the table to the document
                document.Add(table);

                // Close the document
                document.Close();

                Console.WriteLine("PDF report generated successfully at: " + Path.GetFullPath(pdfFilePath));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while generating the PDF report: " + ex.Message);
            }
        }
    }

    /// <summary>
    /// Represents a single record of data from the CSV file.
    /// </summary>
  

}
