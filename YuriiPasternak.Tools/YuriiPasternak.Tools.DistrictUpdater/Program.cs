using System.Text;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using YuriiPasternak.Tools.Shared.Enums;
using YuriiPasternak.Tools.Shared.Models;

Console.WriteLine("PRESS ANY KEY FOR IMPORT DISTRICTS");
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

for (var row = 5; row <= end.Row; row++)
{
    var toCodifier = GetSafeString(firstSheet.Cells[row, 2].Text);
    var toRegionCodifier = GetSafeString(firstSheet.Cells[row, 1].Text);
    var toType = GetType(firstSheet.Cells[row, 6].Text);
    var toName = GetSafeString(firstSheet.Cells[row, 7].Text);

    var to = new TerritorialObject();
    if (toType == TerritorialObjectTypeEnum.District)
    {
        var region = await dbContext.TerritorialObjects.FirstOrDefaultAsync(x => x.Katottg == toRegionCodifier, new CancellationToken());
        if (region != null)
        {
            to.Id = Guid.NewGuid();
            to.RegionId = region.Id;
            to.Katottg = toCodifier;
            to.RegionKatottg = region.Katottg;
            to.TypeId = toType;
            to.Name = toName;
        }
        

        dbContext.TerritorialObjects.Add(to);
        Console.WriteLine();
        count++;
        Console.Write($"ADDED: {count}:  ||  {to.Id}  ||  {to.Katottg}  ||  {to.Name}  ||  {to.TypeId}");
        
    }
}
Console.WriteLine();
Console.WriteLine("SAVE CHANGES? Y/N");
Console.WriteLine();
var change = Console.ReadKey().KeyChar;
if (change == 'Y')
{
    await dbContext.SaveChangesAsync(new CancellationToken());
    Console.WriteLine("SAVED");
}
else if (change == 'N')
{
    Console.WriteLine("ABORTED");
}
else
{
    Console.WriteLine("500");
}


string GetSafeString(string text)
{
    return string.IsNullOrEmpty(text) ? string.Empty : text.Trim();
}

TerritorialObjectTypeEnum GetType(string type)
{
    var result = type switch
    {
        "O" => TerritorialObjectTypeEnum.Region,
        "K" => TerritorialObjectTypeEnum.City,
        "P" => TerritorialObjectTypeEnum.District,
        "H" => TerritorialObjectTypeEnum.Community,
        "M" => TerritorialObjectTypeEnum.City,
        "X" => TerritorialObjectTypeEnum.SmallTown,
        "C" => TerritorialObjectTypeEnum.Village,
        "B" => TerritorialObjectTypeEnum.CityDistrict,
        _ => TerritorialObjectTypeEnum.None,
    };

    return result;
}