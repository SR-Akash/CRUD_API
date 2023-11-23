using System;
using System.Collections.Generic;

#nullable disable

namespace CRUD_API.Models
{
    public partial class Item
    {
        public long ItemId { get; set; }
        public long? ItemGlobalId { get; set; }
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public string Barcode { get; set; }
        public long ItemTypeId { get; set; }
        public string ItemTypeName { get; set; }
        public long ItemCategoryId { get; set; }
        public string ItemCategoryName { get; set; }
        public long ItemSubCategoryId { get; set; }
        public string ItemSubCategoryName { get; set; }
        public long AccountId { get; set; }
        public string AccountName { get; set; }
        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public long UomId { get; set; }
        public string UomName { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public DateTime ActionTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public decimal Price { get; set; }
        public decimal Vat { get; set; }
        public decimal Sd { get; set; }
        public decimal? AvgRate { get; set; }
        public decimal? TotalValue { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal? VatPercentage { get; set; }
        public decimal CurrentSellingPrice { get; set; }
        public bool? IsActive { get; set; }
        public decimal? StockLimitQuantity { get; set; }
        public long? TaxRateId { get; set; }
        public string Brand { get; set; }
        public string PartNumber { get; set; }
        public string ItemDescription { get; set; }
        public long? OriginId { get; set; }
        public string OriginName { get; set; }
        public decimal? StdPurchasePrice { get; set; }
        public long? AltUomId { get; set; }
        public string AltUomName { get; set; }
        public decimal? ConversionUnit { get; set; }
        public bool IsSerial { get; set; }
        public decimal MaximumDiscountPercent { get; set; }
        public decimal? MaximumDiscountAmount { get; set; }
        public bool IsBatchManage { get; set; }
        public string Hscode { get; set; }
        public string ImageString { get; set; }
        public string ManufacturerName { get; set; }
        public long SupplierId { get; set; }
        public long MinorCategoryId { get; set; }
        public string MinorCategoryName { get; set; }
        public bool IsVariant { get; set; }
        public decimal LastPurchasePrice { get; set; }
        public long BarCodeSerial { get; set; }
        public bool IsNegativeSales { get; set; }
        public bool IsMultipleSalesPrice { get; set; }
        public bool IsSaleAble { get; set; }
        public bool IsForeign { get; set; }
        public bool IsProducible { get; set; }
        public decimal MinSalesQty { get; set; }
        public bool IsPurchase { get; set; }
        public bool IsRent { get; set; }
        public bool? IsAutoBarcode { get; set; }
        public long LastActionById { get; set; }
        public DateTime LastActionTime { get; set; }
        public string ItemImage { get; set; }
    }
}
