using System.Text;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using YuriiPasternak.Tools.RegionUpdater.Models;

Console.WriteLine("PRESS ANY KEY FOR IMPORT REGIONS");
Console.ReadKey();

Console.WriteLine();

string writePath = $"Log_{DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy--HH-mm-ss")}.txt";

using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.Default))
{

}

const string filePath = "TOCodifier_1901.xlsx";

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
Console.OutputEncoding = Encoding.UTF8;

using var dbContext = new YuriiPasternakSimpleRealEstateDbContext();
using var package = new ExcelPackage(new FileInfo(filePath));

var count = 0;
var firstSheet = package.Workbook.Worksheets[0];
//var start = firstSheet.Dimension.Start;
var end = firstSheet.Dimension.End;

for (var row = 2; row <= end.Row; row++)
{
    var toCodifier = GetSafeString(firstSheet.Cells[row, 3].Text);
    var toType = GetSafeString(firstSheet.Cells[row, 6].Text);
}


string GetSafeString(string text)
{
    return string.IsNullOrEmpty(text) ? string.Empty : text.Trim();
}