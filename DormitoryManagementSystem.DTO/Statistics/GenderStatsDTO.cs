using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryManagementSystem.DTO.Statistics
{
    public class GenderStatsDTO
    {
        public int MaleCount { get; set; }
        public int FemaleCount { get; set; }

        public int TotalStudents => MaleCount + FemaleCount;

        // Tính phần trăm (làm tròn 2 chữ số thập phân)
        public double MalePercentage => TotalStudents == 0 ? 0 : Math.Round((double)MaleCount / TotalStudents * 100, 2);
        public double FemalePercentage => TotalStudents == 0 ? 0 : Math.Round((double)FemaleCount / TotalStudents * 100, 2);
    }
}
