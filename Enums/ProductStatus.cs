using System.ComponentModel.DataAnnotations;

namespace CaishenManagementAPI.Enums
{
    public enum ProductStatus
    {
        [Display(Name = "Bản nháp")]
        Draft = 0,

        [Display(Name = "Chờ phê duyệt")]
        PendingApproval = 1,

        [Display(Name = "Đang bán")]
        Active = 2,

        [Display(Name = "Tạm ẩn")]
        Inactive = 3,

        [Display(Name = "Đã bán hết")]
        OutOfStock = 4,

        [Display(Name = "Ngừng bán")]
        Discontinued = 5,

        [Display(Name = "Đã lưu trữ")]
        Archived = 6
    }
}
