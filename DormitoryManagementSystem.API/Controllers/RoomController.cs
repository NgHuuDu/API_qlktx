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
    [HttpGet("student/available-grid")]
    //[Authorize(Roles = "Student")]// Tắt cái này mới test được, mới lên khi chạy chính thức
    public async Task<IActionResult> GetAllActiveRoomsStudentInDataGrid()
    {
        try
        {
            var rooms = await _roomBUS.GetAllActiveRoomsForGridAsync();

            if (rooms == null || !rooms.Any())
            {
                // Trả về danh sách rỗng chứ không lỗi 404, để FE hiện bảng trống
                return Ok(new List<RoomGridDTO>());
            }

            return Ok(rooms);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Lỗi hệ thống: " + ex.Message });
        }
    }

    [HttpGet("student/available-card")]
    //[Authorize(Roles = "Student")]// Tắt cái này mới test được, mới lên khi chạy chính thức
    public async Task<IActionResult> GetAllActiveRoomsStudentInCard()
    {
        try
        {
            var rooms = await _roomBUS.GetAllActiveRoomsForCardAsync();

            if (rooms == null || !rooms.Any())
            {
                // Trả về danh sách rỗng chứ không lỗi 404, để FE hiện bảng trống
                return Ok(new List<RoomDetailDTO>());
            }

            return Ok(rooms);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Lỗi hệ thống: " + ex.Message });
        }
    }


    [HttpGet("student/Room/{RoomID}")]
    //[Authorize(Roles = "Student")]// Tắt cái này mới test được, mới lên khi chạy chính thức
    public async Task<IActionResult> GetRoomDetail(string RoomID)
    {
        try
        {
            var roomDetail = await _roomBUS.GetRoomDetailByIDAsync(RoomID);

            if (roomDetail == null)
            {
                return NotFound(new { message = $"Không tìm thấy phòng với ID: {RoomID}" });
            }

            return Ok(roomDetail);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Lỗi hệ thống: " + ex.Message });
        }
    }


    //Student 
    // Duyệt phòng ở FE Student, cái trang có hiện thị phòng chi tiết á
    [HttpGet("student/SearchInCard")]
    // [Authorize(Roles = "Student")] // Tắt cái này mới test được, mới lên khi chạy chính thức
    public async Task<IActionResult> SearchRoomInCard(
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
            var rooms = await _roomBUS.SearchRoomInCardAsync(
                buildingId, roomNumber, capacity, minPrice,maxPrice, allowCooking, airConditioner);

            if (rooms == null || !rooms.Any())
            {
                return Ok(new List<RoomDetailDTO>());
            }

            return Ok(rooms);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet("student/SearchInGrid")]
    // [Authorize(Roles = "Student")] // Tắt cái này mới test được, mới lên khi chạy chính thức
    public async Task<IActionResult> SearchRoomInGrid(
    [FromQuery] string? buildingId,
    [FromQuery] int? roomNumber,
    [FromQuery] int? capacity,
    [FromQuery] decimal? minPrice,
    [FromQuery] decimal? maxPrice


    )
    {
        try
        {
            var rooms = await _roomBUS.SearchRoomInGridAsync(
                buildingId, roomNumber, capacity, minPrice,maxPrice);

            if (rooms == null || !rooms.Any())
            {
                return Ok(new List<RoomGridDTO>());
            }

            return Ok(rooms);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }


    [HttpGet("Load/CapacitiesInComboBox")]
    public async Task<IActionResult> GetCapacities()
    {
        try
        {
            var result = await _roomBUS.GetRoomCapacitiesAsync();
            return Ok(result); // Trả về mảng: [2, 4, 6, 8]
        }
        catch (Exception ex) { return StatusCode(500, ex.Message); }
    }

    // URL: api/room/price-ranges
    [HttpGet("Load/Price-ranges")]
    public IActionResult GetPriceRanges()
    {
        var result = _roomBUS.GetPriceRanges();
        return Ok(result);
    }


}