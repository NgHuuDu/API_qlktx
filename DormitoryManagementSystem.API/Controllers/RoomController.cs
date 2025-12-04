using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.Rooms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IRoomBUS _roomBUS;
    public RoomController(IRoomBUS roomBUS) => _roomBUS = roomBUS;

    // --- STUDENT API ---
    [HttpGet("student/rooms/{RoomID}")]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> GetRoomDetail(string RoomID)
    {
        var roomDetail = await _roomBUS.GetRoomDetailByIDAsync(RoomID);
        if (roomDetail == null) throw new KeyNotFoundException($"Không tìm thấy phòng: {RoomID}");
        return Ok(roomDetail);
    }

    [HttpGet("student/rooms/cards")]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> SearchRoomInCard(
        [FromQuery] string? buildingId, [FromQuery] int? roomNumber,
        [FromQuery] int? capacity, [FromQuery] decimal? minPrice,
        [FromQuery] decimal? maxPrice, [FromQuery] bool? allowCooking,
        [FromQuery] bool? airConditioner)
    {
        var rooms = await _roomBUS.SearchRoomInCardAsync(buildingId, roomNumber, capacity, minPrice, maxPrice, allowCooking, airConditioner);
        return Ok(rooms ?? new List<RoomDetailDTO>());
    }

    [HttpGet("student/rooms/grid")]
    [Authorize(Roles = "Student")]
    public async Task<IActionResult> SearchRoomInGrid(
        [FromQuery] string? buildingId, [FromQuery] int? roomNumber,
        [FromQuery] int? capacity, [FromQuery] decimal? minPrice,
        [FromQuery] decimal? maxPrice)
    {
        var rooms = await _roomBUS.SearchRoomInGridAsync(buildingId, roomNumber, capacity, minPrice, maxPrice);
        return Ok(rooms ?? new List<RoomGridDTO>());
    }

    // --- COMMON & ADMIN API ---
    [HttpGet("rooms/capacities")]
    public async Task<IActionResult> GetCapacities() => Ok(await _roomBUS.GetRoomCapacitiesAsync());

    [HttpGet("rooms/price-ranges")]
    public IActionResult GetPriceRanges() => Ok(_roomBUS.GetPriceRanges());

    [HttpPost("admin/rooms")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateRoom([FromBody] RoomCreateDTO dto)
    {
        await _roomBUS.AddRoomAsync(dto);
        return Ok(new { message = "Thêm phòng thành công!" });
    }

    [HttpPut("admin/rooms/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateRoom(string id, [FromBody] RoomUpdateDTO dto)
    {
        await _roomBUS.UpdateRoomAsync(id, dto);
        return Ok(new { message = "Cập nhật thông tin phòng thành công!" });
    }

    [HttpDelete("admin/rooms/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteRoom(string id)
    {
        await _roomBUS.DeleteRoomAsync(id);
        return Ok(new { message = "Xóa phòng thành công" });
    }

    [HttpGet("admin/rooms/search")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SearchRooms([FromQuery] string q)
    {
        var result = await _roomBUS.SearchRoomsAsync(q);
        if (result == null || !result.Any())
            throw new KeyNotFoundException($"Không tìm thấy phòng nào với từ khóa '{q}'");
        return Ok(result);
    }
}