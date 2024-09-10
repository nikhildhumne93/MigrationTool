using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronXL;
using MigrationTool.DTOs;

namespace MigrationTool
{
    public class ReadExceFile
    {
        #region ====== Constant properties ============
        private const string column1Name = "Column1";
        private const string column2Name = "Column2";
        private const string column3Name = "Column3";
        private const string column4Name = "Column4";
        private const string column5Name = "Column5";
        private const string column6Name = "Column6";
        private const string column7Name = "Column7";
        private const string column8Name = "Column8";
        private const string column9Name = "Column9";
        private const string column10Name = "Column10";
        private const string column11Name = "Column11";
        private const string column12Name = "Column12";


        public const string OrganizationId = "OrganizationId";
        public const string ProductId = "ProductId";
        public const string FormId = "formid";
        public const string Title = "Title";
        public const string FormJsonUrl = "Formjsonurl";
        public const string Parents = "Parents";
        public const string IsActive = "IsActive";
        public const string formFileName = "form_file_name";
        public const string AreaOfOperation = "Area of Operation";
        public const string FormType = "Form Type";
        public const string FormSubTypeCategory = "Form Sub Type / Category";
        public const string Description = "Description";
        #endregion

        string path = ConfigurationManager.AppSettings["ExcelFilePath"].ToString();
        public List<InputExcelColumnDTO> readExcelFile()
        {
            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("File not found, Please enter valid file location");
                Console.ReadKey();
                Environment.Exit(0);
            }

            List<InputExcelColumnDTO> dataList = new List<InputExcelColumnDTO>();
            try
            {
                dataList = new List<InputExcelColumnDTO>();
                DataTable dt = new DataTable();
                WorkBook workBook = WorkBook.Load(path);
                DataSet dataSet = workBook.ToDataSet();
                dt = dataSet.Tables[0];
                bool HeaderReadStatus = false;
                InputExcelColumnDTO inputExcelColumnDTO;
                foreach (DataRow dr in dt.Rows)
                {
                    if (HeaderReadStatus == false)
                    {
                        if (dr.Field<string>(column1Name) == OrganizationId &&
                           dr.Field<string>(column2Name) == ProductId &&
                           dr.Field<string>(column3Name) == FormId &&
                           dr.Field<string>(column4Name) == Title &&
                           dr.Field<string>(column5Name) == FormJsonUrl &&
                           dr.Field<string>(column6Name) == Parents &&
                           dr.Field<string>(column7Name) == IsActive &&
                           dr.Field<string>(column8Name) == formFileName &&
                           dr.Field<string>(column9Name) == AreaOfOperation &&
                           dr.Field<string>(column10Name) == FormType &&
                           dr.Field<string>(column11Name) == FormSubTypeCategory &&
                           dr.Field<string>(column12Name) == Description)
                        {
                            HeaderReadStatus = true; continue;
                        }
                        else
                        {
                             
                            Console.WriteLine("Excel file is not proper format");
                            Console.ReadKey();
                            Environment.Exit(0);
                            
                        }

                    }

                    inputExcelColumnDTO = new InputExcelColumnDTO();

                    try { inputExcelColumnDTO.OrganizationId = dr.Field<double>(column1Name); } catch { }
                    try { inputExcelColumnDTO.ProductId = dr.Field<double>(column2Name); } catch { }
                    try { inputExcelColumnDTO.FormId = dr.Field<double>(column3Name); } catch { }
                    try { inputExcelColumnDTO.Title = dr.Field<string>(column4Name); } catch { }
                    inputExcelColumnDTO.FormJsonUrl = !string.IsNullOrEmpty(dr.Field<string>(column5Name)) ? dr.Field<string>(column5Name) : "";
                    inputExcelColumnDTO.Parents = !string.IsNullOrEmpty(dr.Field<string>(column6Name)) ? dr.Field<string>(column6Name) : "";
                    try { inputExcelColumnDTO.IsActive = dr.Field<double>(column7Name); } catch { }
                    inputExcelColumnDTO.FormFileName = !string.IsNullOrEmpty(dr.Field<string>(column8Name)) ? dr.Field<string>(column8Name) : "";
                    try { inputExcelColumnDTO.AreaOfOperation = dr.Field<double>(column9Name); } catch { }
                    try { inputExcelColumnDTO.FormType = dr.Field<double>(column10Name); } catch { }
                    try { inputExcelColumnDTO.FormSubTypeCategory = dr.Field<double>(column11Name); } catch { }
                    inputExcelColumnDTO.Description = !string.IsNullOrEmpty(dr.Field<string>(column12Name)) ? dr.Field<string>(column12Name) : "";

                    dataList.Add(inputExcelColumnDTO);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteException(ex.Message);
            }
            return dataList;
        }
    }
}
