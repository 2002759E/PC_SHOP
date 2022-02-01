using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_SHOP.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string AccountsEndpoint = $"{Prefix}/accounts";
        public static readonly string BrandsEndpoint = $"{Prefix}/brands";
        public static readonly string CategoriesEndpoint = $"{Prefix}/categories";
        public static readonly string ConditionsEndpoint = $"{Prefix}/conditions";
        public static readonly string ItemsEndpoint = $"{Prefix}/items";
        public static readonly string ListItemsEndpoint = $"{Prefix}/listitems";
        public static readonly string PurchaseRequestsEndpoint = $"{Prefix}/purchaserequests";
        public static readonly string PaymentsEndpoint = $"{Prefix}/payments";
        public static readonly string TradeRequestsEndpoint = $"{Prefix}/traderequests";
        public static readonly string ReviewsEndpoint = $"{Prefix}/reviews";
    }
}
