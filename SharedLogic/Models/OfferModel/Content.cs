using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedLogic.Models.OfferModel
{
    public class Content
    {
        public string MerchantProductNo;
        [Required]
        public int Stock;
        public int StockLocationId;
        public DateTime UpdatedAt;
    }
}
