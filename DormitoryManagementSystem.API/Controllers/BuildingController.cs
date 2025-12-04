using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.Buildings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormitoryManagementSystem.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingBUS _buildingBUS;
        public BuildingController(IBuildingBUS buildingBUS) => _buildingBUS = buildingBUS;

        [HttpGet("buildings/lookup/combobox")]
        public async Task<IActionResult> GetBuildingLookup()
        {
            var result = await _buildingBUS.GetBuildingLookupAsync();
            return Ok(result);
        }

        [HttpPost("buildings")]
        [Authorize(Roles = "Admin")] // Bảo mật: Chỉ Admin được tạo
        public async Task<IActionResult> CreateBuilding([FromBody] BuildingCreateDTO dto)
        {
            var result = await _buildingBUS.AddBuildingAsync(dto);
            return Ok(new { message = "Thêm tòa nhà thành công!", buildingId = result });
        }

        [HttpPut("buildings/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBuilding(string id, [FromBody] BuildingUpdateDTO dto)
        {
            await _buildingBUS.UpdateBuildingAsync(id, dto);
            return Ok(new { message = "Cập nhật thông tin tòa nhà thành công!" });
        }

        [HttpDelete("buildings/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBuilding(string id)
        {
            await _buildingBUS.DeleteBuildingAsync(id);
            return Ok(new { message = "Xóa tòa nhà thành công!" });
        }
    }
}