// See https://aka.ms/new-console-template for more information
using MigrationTool;
using MigrationTool.DTOs;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading.Tasks;
using SixLabors.Fonts.Unicode;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;

Logger.WriteMassage("Data migration started please wait.....");

#region ===== Read excel file =====
Logger.WriteMassage("Reading Excel file.");
var excelDataList = new ReadExceFile().readExcelFile();
if (excelDataList == null || excelDataList.Count == 0)
{
    //Console.WriteLine("No data found in excel sheet for migration. Please check exception log.");
    Console.ReadKey();
    Environment.Exit(0);
}
Logger.WriteMassage("Excel file read commpleted Successfully.");
#endregion


#region ===== Generating access token =====
Logger.WriteMassage("Generating access token.");
GetTokenResponseDataDTO getTokenResponseDataDTO = await new TokenWebClinetHandler().GetAccessToken();
if (getTokenResponseDataDTO == null)
{
    Console.WriteLine("Facing some issue with generating access token. Please check exception log.");
    Console.ReadKey();
    Environment.Exit(0);
}
string _accessToken = getTokenResponseDataDTO.access_token;

Logger.WriteMassage("Access token generated successfully done.");
#endregion

#region ===== Proccessing excel row by row =====

int rowprocessed = 0;
int rowProcessedFailed = 0;
int rowCompleted = 0;
int intitiateInsetedToSQL = 0;
int rowInsetedToSQL = 0;
int rowSQLFailed = 0;
int intitiateInsetedToMongo = 0;
int rowInseredToMongo = 0;
int rowMongoFailed = 0;

Logger.WriteMassage("Started Excel row processing one by one.");
foreach (var excel in excelDataList)
{
    rowprocessed++;
    Logger.WriteMassage("Started Excel row processing for file name " + excel.FormFileName);

    #region ===== Get json file form blob =====
    string formJson = new AzureOpp().GetJsonFileFromBlob(excel.FormFileName);
    if (string.IsNullOrEmpty(formJson) || formJson == "invalid_json")
    {
        Logger.WriteMassage(excel.FormFileName + " unable to read file from blob or file not available.");
        rowProcessedFailed++;
        continue;
    }
    #endregion


    #region ===== Proccessing for SQL Data =====
    intitiateInsetedToSQL++;
    Logger.WriteMassage("Prepare data for proccessing store data in sql for " + excel.FormFileName);
    SqlDataSaveRequestDTO requestDTO = Utility.GetSqlDataRequestObject(excel);
    if (requestDTO == null) { rowProcessedFailed++; continue; }
    Logger.WriteMassage("Prepared data for proccessing store data in SQL for " + excel.FormFileName);

    Logger.WriteMassage("Proccessing for store data in SQL for " + excel.FormFileName);
    SqlDataSaveResponsetDTO sqlDataSaveResponsetDTO = await new WebClinetHandler(_accessToken).SaveSqlData(requestDTO, excel.FormFileName);
    if (sqlDataSaveResponsetDTO == null)
    {
        rowSQLFailed++; rowProcessedFailed++; continue;
    }
    rowInsetedToSQL++;

    #endregion

    #region ===== Proccessing for NO SQL Data =====


    Logger.WriteMassage("Data stored in SQL successfully done for " + excel.FormFileName);
    Logger.WriteMassage("Proccessing for store data in no SQL for " + excel.FormFileName);
    MongoDBDataSaveDataResponseDTO responseDTO = await new WebClinetHandler(_accessToken).SaveMongoDBData(new MongoDBDataSaveRequestDTO()
    {
        FormId = sqlDataSaveResponsetDTO.id, //"3fa85f64-5717-4562-b3fc-2c963f66afa6"
        FormJson = formJson,
        PrefillData = ""

    }, excel.FormFileName);

    if (responseDTO == null) { rowMongoFailed++; rowProcessedFailed++; continue; }
    rowInseredToMongo++;
    Logger.WriteMassage("Data stored in no SQL successfully done for " + excel.FormFileName);


    #endregion

    rowCompleted++;
    Logger.WriteMassage("Completed Excel row processing for file name " + excel.FormFileName);
}
Logger.WriteMassage("Excel all row processing done.");

#endregion


Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Logger.WriteMassage("Excel file proccessed count :- " + rowprocessed);
Logger.WriteMassage("Excel file Failed count :- " + rowProcessedFailed);
Logger.WriteMassage("Excel file Completed successfuly count :- " + rowCompleted);
Logger.WriteMassage("Initiate to insert data in SQL " + intitiateInsetedToSQL);
Logger.WriteMassage("Failed to insert data in SQL " + rowSQLFailed);
Logger.WriteMassage("insert data in SQL completed successfuly " + rowInsetedToSQL);
Logger.WriteMassage("Initiate to insert data in MongoDB " + intitiateInsetedToMongo);
Logger.WriteMassage("Failed to insert data in MongoDB " + rowMongoFailed);
Logger.WriteMassage("insert data in MongoDB completed successfuly " + rowInseredToMongo);


Console.WriteLine();
Logger.WriteMassage("Data migration completed successfuly, Thank you for waiting........");
Console.ReadKey();




