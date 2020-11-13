using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLogic.Models.OfferModel
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
