using System.ComponentModel.DataAnnotations;

namespace CaishenManagementAPI.Enums
{
    public enum ProductType
    {
        [Display(Name = "Nhan")]
        NHA = 0,

        [Display(Name = "Vong")]
        VON = 1,

    }
}
