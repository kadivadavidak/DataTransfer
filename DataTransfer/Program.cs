using System;

namespace DataTransfer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                throw new Exception($"Expected 2 arguments. Received {args.Length}.\n\t1. Name of table to retrieve data from. \n\t2. Name of table to store data to.");
            }
#if DEBUG
            var fromTableName = "dwbuild.TEMP_CashAuditToRdsDw";
            var toTableName = "CashAudit";
#else
            var fromTableName = args[0];
            var ToTableName = args[1];
#endif

            try
            {
                DatabaseConnection.ReadDataToDatabase(DataHandler.GetData(fromTableName),toTableName);
            }
            catch (Exception e)
            {
                SmtpHandler.SendMessage($"Error processing date transfer from {fromTableName} to {toTableName}.", $"Error processing date transfer from {fromTableName} to {toTableName}.\n\nEXCEPTION: {e}\n\nINNER EXCEPTION: {e.InnerException}");
            }
        }
    }
}
