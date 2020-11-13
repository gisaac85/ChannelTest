using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLogic.Models.OrderModel
{
    public class Line
    {        
        public string Status;        
        public bool IsFulfillmentByMarketplace;
        public string MerchantProductNo;       
        public string Gtin;        
        public string Description;     
        public double UnitVat;       
        public double LineTotalInclVat;     
        public double LineVat;        
        public double OriginalUnitPriceInclVat;        
        public double OriginalUnitVat;      
        public double OriginalLineTotalInclVat;        
        public double OriginalLineVat;      
        public double OriginalFeeFixed;   
        public object BundleProductMerchantProductNo;  
        public List<object> ExtraData;       
        public string ChannelProductNo;      
        public int Quantity;
        public int CancellationRequestedQuantity;     
        public double UnitPriceInclVat;       
        public double FeeFixed;
        public double FeeRate;
        public string Condition;
        public DateTime ExpectedDeliveryDate;
    }
}
