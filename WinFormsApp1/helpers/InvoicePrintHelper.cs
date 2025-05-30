using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;


namespace DaddysLanka.Printing
{
    public static class InvoicePrintHelper
    {
        public static void PrintInvoice(
            string customerName,
            string paymentMethod,
            decimal totalAmount,
            DataTable invoiceDetails,
            DataTable servicesTable,
            string notes = "")
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

            // Check if any discount is given
            bool hasDiscount = invoiceDetails.AsEnumerable().Any(r => Convert.ToDecimal(r["Discount"]) != 0);

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(612, 396, Unit.Point); // 8.5 x 5.5 inches
                    page.Margin(20);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Content()
                        .Column(col =>
                        {
                            // Header space (2 inches)
                            col.Item().Height(144);

                            // Invoice Info Row
                            col.Item().Row(row =>
                            {
                                row.RelativeItem().AlignLeft().Text($"Invoice To: {customerName}").Bold();
                                row.RelativeItem().AlignRight().Text($"Date: {DateTime.Now:yyyy-MM-dd HH:mm}");
                            });

                            // Table
                            col.Item().PaddingVertical(10).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(3); // Service Description
                                    columns.ConstantColumn(30); // Qty
                                    columns.ConstantColumn(60); // Unit Price
                                    if (hasDiscount)
                                        columns.ConstantColumn(60); // Discount
                                    columns.ConstantColumn(70); // Line Total
                                });

                                // Header
                                table.Header(header =>
                                {
                                    header.Cell().BorderBottom(1).Text("Service");
                                    header.Cell().BorderBottom(1).AlignRight().Text("Qty");
                                    header.Cell().BorderBottom(1).AlignRight().Text("Unit");
                                    if (hasDiscount)
                                        header.Cell().BorderBottom(1).AlignRight().Text("Discount");
                                    header.Cell().BorderBottom(1).AlignRight().Text("Total(LKR)");
                                });

                                // Rows
                                foreach (DataRow dr in invoiceDetails.Rows)
                                {
                                    var serviceDesc = servicesTable.AsEnumerable()
                                        .FirstOrDefault(r => r.Field<int>("ServiceID") == (int)dr["ServiceID"])
                                        ?.Field<string>("ServiceDescription") ?? "Unknown";
                                    table.Cell().Border(1).Text(serviceDesc);
                                    table.Cell().Border(1).AlignRight().Text(dr["Quantity"].ToString());
                                    table.Cell().Border(1).AlignRight().Text($"{dr["UnitPrice"]:N2}");
                                    if (hasDiscount)
                                        table.Cell().Border(1).AlignRight().Text($"{dr["Discount"]:N2}");
                                    table.Cell().Border(1).AlignRight().Text($"{dr["LineTotal"]:N2}");
                                }
                            });

                            // Payment and Total Row
                            col.Item().Row(row =>
                            {
                                row.RelativeItem().AlignLeft().Text($"Payment Method: {paymentMethod}");
                                row.RelativeItem().AlignRight().Text($"Total (LKR): {totalAmount:N2}").FontSize(12).Bold();
                            });

                            // Notes
                            if (!string.IsNullOrWhiteSpace(notes))
                                col.Item().Text($"Notes: {notes}");

                            // Footer space (1 inch)
                            col.Item().Height(72);
                        });
                });
            });

            // Generate PDF to a temporary file
            string tempFile = Path.Combine(Path.GetTempPath(), $"Invoice_{Guid.NewGuid()}.pdf");
            document.GeneratePdf(tempFile);

            // Open the PDF with the default viewer (user can print from there)
            Process.Start(new ProcessStartInfo
            {
                FileName = tempFile,
                UseShellExecute = true
            });

        }
    }
}
