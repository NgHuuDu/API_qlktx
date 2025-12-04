using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.News;
using DormitoryManagementSystem.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/news")]
[ApiController]
public class NewsController : ControllerBase
{
    private readonly INewsBUS _newsBUS;
    public NewsController(INewsBUS newsBUS) => _newsBUS = newsBUS;

    [HttpGet("summary")]
    public async Task<IActionResult> GetNewsList()
    {
        var news = await _newsBUS.GetNewsSummariesAsync();
        return Ok(news);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNewsByID(string id)
    {
        var news = await _newsBUS.GetNewsByIDAsync(id);
        if (news == null) throw new KeyNotFoundException("Tin tức không tồn tại.");
        return Ok(news);
    }

    [HttpPost]
    [Authorize(Roles = AppConstants.Role.Admin)]
    public async Task<IActionResult> CreateNews([FromBody] NewsCreateDTO dto)
    {
        var newNewsId = await _newsBUS.AddNewsAsync(dto);
        return StatusCode(201, new { message = "Đăng tin thành công!", newsId = newNewsId });
    }

    [HttpPut("{id}")]
    [Authorize(Roles = AppConstants.Role.Admin)]
    public async Task<IActionResult> UpdateNews(string id, [FromBody] NewsUpdateDTO dto)
    {
        await _newsBUS.UpdateNewsAsync(id, dto);
        return Ok(new { message = "Cập nhật bài viết thành công!" });
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = AppConstants.Role.Admin)]
    public async Task<IActionResult> DeleteNews(string id)
    {
        await _newsBUS.DeleteNewsAsync(id);
        return Ok(new { message = "Xóa bài viết thành công!" });
    }
}