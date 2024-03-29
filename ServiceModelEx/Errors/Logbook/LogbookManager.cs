// � 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using ServiceModelEx.Errors.Logbook;
using ServiceModelEx.Errors.Logbook.WCFLogbookDataSetTableAdapters;
using System;
using System.ServiceModel;

namespace ServiceModelEx
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,UseSynchronizationContext = false)]
   public class LogbookManager : ILogbookManagerService
   {
      [OperationBehavior(TransactionScopeRequired=true)]
      public void LogEntry(LogbookEntryService entry)
      {
         EntriesTableAdapter adapter = new EntriesTableAdapter();
         adapter.Insert(entry.MachineName,entry.HostName,entry.AssemblyName,entry.FileName,entry.LineNumber,entry.TypeName,entry.MemberAccessed,entry.Date,entry.Time,entry.ExceptionName,entry.ExceptionMessage,entry.ProvidedFault,entry.ProvidedMessage,entry.Event);
      }
      [OperationBehavior(TransactionScopeRequired=true)]
      public void Clear()
      {
         EntriesTableAdapter adapter = new EntriesTableAdapter();
         adapter.Clear();
      }
      [OperationBehavior(TransactionScopeRequired=true)]
      public LogbookEntryService[] GetEntries()
      {
         EntriesTableAdapter adapter = new EntriesTableAdapter();

         WCFLogbookDataSet.EntriesDataTable table = new WCFLogbookDataSet.EntriesDataTable();
         adapter.Fill(table);

         Func<WCFLogbookDataSet.EntriesRow,LogbookEntryService> convert = (row) =>
                                                                          {
                                                                             return new LogbookEntryService(row.MachineName,row.HostName,row.EntryDate,row.EntryTime,row.AssemblyName,row.FileName,row.LineNumber,row.TypeName,row.MemberAccessed,row.ExceptionName,row.ExceptionMessage,row.ProvidedFault,row.ProvidedMessage,row.Event);
                                                                          };
         return table.ToArray(convert);
      }
   }
}