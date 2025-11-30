using System.Drawing;

namespace DormitoryManagementSystem.GUI.Utils
{
    public static class Theme
    {
        // Primary Colors - #6676EF
        public static Color Primary = Color.FromArgb(102, 118, 239);
        public static Color PrimaryDark = Color.FromArgb(82, 94, 191);
        public static Color PrimaryLight = Color.FromArgb(122, 138, 255);

        // Secondary Colors
        public static Color Success = Color.FromArgb(26, 188, 156);
        public static Color Danger = Color.FromArgb(231, 76, 60);
        public static Color Warning = Color.FromArgb(241, 196, 15);
        public static Color Info = Color.FromArgb(52, 152, 219);

        // Neutral Colors
        public static Color Background = Color.FromArgb(248, 249, 253);
        public static Color Surface = Color.White;
        public static Color Border = Color.FromArgb(230, 230, 230);
        public static Color TextPrimary = Color.FromArgb(33, 33, 33);
        public static Color TextSecondary = Color.FromArgb(120, 120, 120);
        public static Color TextDisabled = Color.FromArgb(180, 180, 180);

        // Sidebar Colors - #6676EF
        public static Color SidebarBackground = Color.FromArgb(102, 118, 239); // #6676EF
        public static Color SidebarHover = Color.FromArgb(122, 138, 255); // Nhạt hơn khi hover
        public static Color SidebarActive = Color.FromArgb(82, 94, 191); // Đậm hơn khi active
        public static Color SidebarText = Color.White;

        // Fonts - Microsoft Sans Serif
        public static Font FontTitle = new Font("Microsoft Sans Serif", 20F, FontStyle.Bold);
        public static Font FontHeading = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
        public static Font FontBody = new Font("Microsoft Sans Serif", 10F);
        public static Font FontBodyBold = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
        public static Font FontSmall = new Font("Microsoft Sans Serif", 9F);
        public static Font FontButton = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
        public static Font FontSidebar = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);

        // Spacing
        public const int PaddingSmall = 5;
        public const int PaddingMedium = 10;
        public const int PaddingLarge = 20;
        public const int BorderRadius = 8;
    }
}

