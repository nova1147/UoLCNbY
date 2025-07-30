// 代码生成时间: 2025-07-31 07:29:17
using System;
using System.IO;
using System.Data;
using System.Text;
using ClosedXML.Excel;

// 定义一个ExcelGenerator类，用于生成Excel文件
public class ExcelGenerator
{
    // 生成Excel文件的方法
    public static void GenerateExcel(string filePath, string sheetName, DataTable dataTable)
    {
        try
        {
            // 使用ClosedXML库来创建Excel文件
            using (var workbook = new XLWorkbook())
            {
                // 添加一个工作表
                var worksheet = workbook.Worksheets.Add(sheetName);

                // 将DataTable写入工作表
                worksheet.Cell(1, 1).InsertTable(dataTable.CreateDataReader(), true);

                // 保存Excel文件
                workbook.SaveAs(filePath);
            }
        }
        catch (Exception ex)
        {
            // 错误处理：打印异常信息
            Console.WriteLine($"Error generating Excel file: {ex.Message}");
        }
    }
}

// 使用示例
// 假设有一个DataTable，需要生成Excel文件
DataTable dataTable = new DataTable();
dataTable.Columns.Add("Name", typeof(string));
dataTable.Columns.Add("Age", typeof(int));
dataTable.Rows.Add("John Doe", 30);
dataTable.Rows.Add("Jane Doe", 25);

// 生成Excel文件
ExcelGenerator.GenerateExcel("example.xlsx", "Sheet1", dataTable);