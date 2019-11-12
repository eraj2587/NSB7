// © 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.ServiceModel;

namespace ServiceModelEx
{
    [ServiceContract(Name="ILogbookManager")]
   public interface ILogbookManagerService
   {
      [OperationContract(IsOneWay=true)]
      void LogEntry(LogbookEntryService entry);

      [OperationContract(IsOneWay=true)]
      void Clear();

      [OperationContract]
      LogbookEntryService[] GetEntries();
   }
}