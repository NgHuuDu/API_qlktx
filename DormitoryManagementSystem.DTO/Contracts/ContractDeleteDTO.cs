using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.DTO.Contracts
{
    public class ContractDeleteDTO
    {
        [Required(ErrorMessage = "Contract ID is required")]
        [StringLength(10, ErrorMessage = "Contract ID cannot exceed 10 chars")]
        public string ContractID { get; set; } = string.Empty;
    }
}