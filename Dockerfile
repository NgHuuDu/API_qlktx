# 1. Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# --- COPY CÁC FILE PROJECT ---

# 1. API
COPY ["DormitoryManagementSystem.API/DormitoryManagementSystem.API.csproj", "DormitoryManagementSystem.API/"]

# 2. Các thư mục phụ thuộc (DAO, BUS, DTO)
COPY ["DormitoryManagementSystem.BUS/DormitoryManagementSystem.BUS.csproj", "DormitoryManagementSystem.BUS/"]
COPY ["DormitoryManagementSystem.DAO/DormitoryManagementSystem.DAO.csproj", "DormitoryManagementSystem.DAO/"]
COPY ["DormitoryManagementSystem.DTO/DormitoryManagementSystem.DTO.csproj", "DormitoryManagementSystem.DTO/"]

# 3. Entity (SỬA LẠI ĐƯỜNG DẪN Ở ĐÂY)
# Trường hợp 1: Nếu file .csproj KHÔNG có V10 (nhưng thư mục có V10) -> Thử dòng này:
# COPY ["DormitoryManagementSystemV10.Entity/DormitoryManagementSystem.Entities.csproj", "DormitoryManagementSystemV10.Entity/"]

# Trường hợp 2 (Khả năng cao): File .csproj cũng có V10 -> Giữ nguyên dòng này nhưng hãy chắc chắn file tồn tại
COPY ["DormitoryManagementSystemV10.Entity/DormitoryManagementSystemV10.Entity.csproj", "DormitoryManagementSystemV10.Entity/"]

# 4. Mappings
COPY ["DormitoryManagementSystem.Mappings/DormitoryManagementSystem.Mappings.csproj", "DormitoryManagementSystem.Mappings/"]

# --- RESTORE ---
RUN dotnet restore "DormitoryManagementSystem.API/DormitoryManagementSystem.API.csproj"

# --- COPY TOÀN BỘ CODE CÒN LẠI ---
COPY . .
WORKDIR "/src/DormitoryManagementSystem.API"
RUN dotnet build "DormitoryManagementSystem.API.csproj" -c Release -o /app/build

# 2. Publish Stage
FROM build AS publish
RUN dotnet publish "DormitoryManagementSystem.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# 3. Final Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DormitoryManagementSystem.API.dll"]
