using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.Rooms;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IRoomBUS _roomBUS;

    public RoomController(IRoomBUS roomBUS)
    {
        _roomBUS = roomBUS;
    }

    //Student
    // API: Lấy danh sách phòng CÒN TRỐNG (Cho sinh viên đăng ký) với hiện ở datagrid á // 
    // GET: api/room/available
    [HttpGet("available")]
    //[Authorize(Roles = "Student")]// Tắt cái này mới test được, mới lên khi chạy chính thức
    public async Task<IActionResult> GetAvailableRoomsCardStudent()
    {
        try
        {
            var rooms = await _roomBUS.GetAllRoomsCardStudentAsync();

            if (rooms == null || !rooms.Any())
            {
                // Trả về danh sách rỗng chứ không lỗi 404, để FE hiện bảng trống
                return Ok(new List<RoomCardDTO>());
            }

            return Ok(rooms);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Lỗi hệ thống: " + ex.Message });
        }
    }

    //Student 
    // Duyệt phòng ở FE Student, cái trang có hiện thị phòng chi tiết á
    [HttpGet("search")]
    // [Authorize(Roles = "Student")] // Tắt cái này mới test được, mới lên khi chạy chính thức
    public async Task<IActionResult> SearchRooms(
    [FromQuery] string? buildingId,
    [FromQuery] int? roomNumber,
    [FromQuery] int? capacity,
    [FromQuery] decimal? minPrice,
    [FromQuery] decimal? maxPrice,
    [FromQuery] bool? allowCooking,    
    [FromQuery] bool? airConditioner)  
    {
        try
        {
            var rooms = await _roomBUS.SearchRoomsAsync(
                buildingId, roomNumber, capacity, minPrice, maxPrice, allowCooking, airConditioner);

            if (rooms == null || !rooms.Any())
            {
                return Ok(new List<RoomReadDTO>());
            }

            return Ok(rooms);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}