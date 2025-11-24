using DormitoryManagementSystem.BUS.Interfaces;
using DormitoryManagementSystem.DTO.Buildings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DormitoryManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingBUS _buildingBUS;

        public BuildingsController(IBuildingBUS buildingBUS)
        {
            _buildingBUS = buildingBUS;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingReadDTO>>> GetAllBuildings()
        {
            var buildings = await _buildingBUS.GetAllBuildingAsync();
            return Ok(buildings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingReadDTO>> GetBuildingById(string id)
        {
            var building = await _buildingBUS.GetByIDAsync(id);
            if (building == null)
                return NotFound(new { message = $"Building with ID {id} not found" });
            return Ok(building);
        }
    }
}

