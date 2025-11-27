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



    // ---------------------------------------------------------
    // KHU VỰC API CHO STUDENT
    // ---------------------------------------------------------


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


    // Duyệt phòng ở FE Student, cái trang có hiện thị lưới á

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











    // ---------------------------------------------------------
    // KHU VỰC API CHUNG CHO ADMIN VÀ STUDENT
    // ---------------------------------------------------------


    [HttpGet("Load/CapacitiesInComboBox")]
    public async Task<IActionResult> GetCapacities()
    {
        try
        {
            var result = await _roomBUS.GetRoomCapacitiesAsync();
            return Ok(result); 
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