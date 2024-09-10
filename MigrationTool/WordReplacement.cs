using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool
{
    public static class WordReplacement
    {

        private static string word1 = "Google";
        private static string wordReplace1 = "Toggle";
        public static string ReplaceWord(this string jsonString)
        {

            try
            {
                if (string.IsNullOrEmpty(jsonString))
                    return "";
                StringBuilder stringBuilder = new StringBuilder(jsonString);
                stringBuilder.Replace(word1, wordReplace1);
                jsonString = stringBuilder.ToString();
            }
            catch (Exception ex) { Logger.WriteException(ex.Message); }
            return jsonString;

        }
    }
}
