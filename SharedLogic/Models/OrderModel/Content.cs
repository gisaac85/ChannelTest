using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLogic.Models.OrderModel
{   
    public class Content
    {
        public int Id;
        public string ChannelName;
        public int ChannelId;
        public string GlobalChannelName;
        public int GlobalChannelId;
        public string ChannelOrderSupport;
        public string ChannelOrderNo;
        public string Status;
        public bool IsBusinessOrder;
        public DateTime CreatedAt;
        public DateTime UpdatedAt;
        public BillingAddress BillingAddress;
        public ShippingAddress ShippingAddress;
        public List<Line> Lines;
        public ExtraData Extra_Data;
        public object MerchantComment;
        public double SubTotalInclVat;
        public double SubTotalVat;
        public double ShippingCostsVat;
        public double TotalInclVat;
        public double TotalVat;
        public double OriginalSubTotalInclVat;
        public double OriginalSubTotalVat;
        public double OriginalShippingCostsInclVat;
        public double OriginalShippingCostsVat;
        public double OriginalTotalInclVat;
        public double OriginalTotalVat;
        public string Phone;
        public string Email;
        public object CompanyRegistrationNo;
        public object VatNo;
        public string PaymentMethod;
        public double ShippingCostsInclVat;
        public string CurrencyCode;
        public DateTime OrderDate;
        public object ChannelCustomerNo;
        public string MerchantProductNo;
        public int Stock;
        public int StockLocationId;
        
    }
}
