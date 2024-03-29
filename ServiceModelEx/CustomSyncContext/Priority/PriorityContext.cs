// � 2016 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.Runtime.Serialization;

namespace ServiceModelEx
{
    //If using GenericContext<T> is too raw, can encapsulate: 
    [DataContract]
   public class PriorityContext 
   {
      public static CallPriority Current
      {
         get
         {
            return GenericContext<CallPriority>.Current.Value;
         }
         set
         {
            GenericContext<CallPriority>.Current = new GenericContext<CallPriority>(value);
         }
      }      
   }
}

