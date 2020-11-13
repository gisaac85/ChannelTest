using System.Collections.Generic;

namespace SharedLogic.Models.OrderModel
{
    public class Root
    {       
         public List<Content> Content;        
         public int Count;
         public int TotalCount;
         public int ItemsPerPage;
         public int StatusCode;
         public object LogId;
         public bool Success;
         public object Message;
         public ValidationErrors ValidationErrors;
    }
}
