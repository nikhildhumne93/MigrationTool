﻿// See https://aka.ms/new-console-template for more information
using MigrationTool;
using MigrationTool.DTOs;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading.Tasks;
using SixLabors.Fonts.Unicode;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;

Logger.WriteMassage("Data migration started please wait.......");

#region ===== Read excel file =====
Logger.WriteMassage("Reading Excel file");
var excelDataList = new ReadExceFile().readExcelFile();
if (excelDataList == null || excelDataList.Count == 0)
{
    //Console.WriteLine("No data found in excel sheet for migration. Please check exception log.");
    Console.ReadKey();
    Environment.Exit(0);
}
Logger.WriteMassage("Excel file read commpleted Successfully");
#endregion


#region ===== Generating access token =====
Logger.WriteMassage("Generating Access Token");
GetTokenResponseDataDTO getTokenResponseDataDTO = await new TokenWebClinetHandler().GetAccessToken();
if (getTokenResponseDataDTO == null)
{
    Console.WriteLine("Facing some issue with Generating Access Token. Please check exception log.");
    Console.ReadKey();
    Environment.Exit(0);
}
string _accessToken = getTokenResponseDataDTO.access_token;

Logger.WriteMassage("Access Token generated Successfully Done");
#endregion

#region ===== Proccessing excel row by row

Logger.WriteMassage("Started Excel row processing one by one");
foreach (var excel in excelDataList)
{
    Logger.WriteMassage("Started Excel row processing for file name " + excel.FormFileName);

    #region ===== Get json file form blob =====
    string formJson = new AzureOpp().GetJsonFileFromBlob(excel.FormFileName);
    if (string.IsNullOrEmpty(formJson) || formJson == "invalid_json")
    {
        Logger.WriteMassage(excel.FormFileName + " unable to read file from blob or file not available.");
        continue;
    }
    #endregion


    #region ===== Proccessing for SQL Data =====
    Logger.WriteMassage("Prepare data for proccessing store data in sql for " + excel.FormFileName);
    SqlDataSaveRequestDTO requestDTO = Utility.GetSqlDataRequestObject(excel);
    if (requestDTO == null) continue;
    Logger.WriteMassage("Prepared data for proccessing store data in SQL for " + excel.FormFileName);

    Logger.WriteMassage("Proccessing for store data in SQL for " + excel.FormFileName);
    SqlDataSaveResponsetDTO sqlDataSaveResponsetDTO = await new WebClinetHandler(_accessToken).SaveSqlData(requestDTO, excel.FormFileName);
    #endregion

    #region ===== Proccessing for NO SQL Data =====

    if (sqlDataSaveResponsetDTO != null)
    {
        Logger.WriteMassage("Data stored in SQL successfully done for " + excel.FormFileName);
        Logger.WriteMassage("Proccessing for store data in no SQL for " + excel.FormFileName);
        MongoDBDataSaveDataResponseDTO responseDTO = await new WebClinetHandler(_accessToken).SaveMongoDBData(new MongoDBDataSaveRequestDTO()
        {
            FormId = "3fa85f64-5717-4562-b3fc-2c963f66afa6", //sqlDataSaveResponsetDTO.FormId
            FormJson = formJson,
            PrefillData = ""

        }, excel.FormFileName);
        Logger.WriteMassage("Data stored in no SQL successfully done for " + excel.FormFileName);

    }
    #endregion

    Logger.WriteMassage("Completed Excel row processing for file name " + excel.FormFileName);
}
Logger.WriteMassage("Excel all row processing done.");

#endregion


Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Logger.WriteMassage("Data migration completed successfuly, Thank you for waiting........");
Console.ReadKey();




