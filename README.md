# CRUD_entity_framework
>> bài tập ví dụ về cách sử dụng entity framework trong việc
- tạo csdl và tương tác với nó bằng code first
- app simple console CRUD Student



# Step by Step

>> create console app in visual studio 

>> Chạy lệnh sau để cài đặt Entity Framework Core 

	Install-Package Microsoft.EntityFrameworkCore
	Install-Package Microsoft.EntityFrameworkCore.SqlServer
	Install-Package Microsoft.EntityFrameworkCore.Tools


>> Creat Model class Student

	public class Student
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Score { get; set; }
	}

>> Tạo lớp SchoolContext
- Thêm lớp SchoolContext kế thừa từ DbContext
- để quản lý kết nối với cơ sở dữ liệu và các bảng dữ liệu.

		using Microsoft.EntityFrameworkCore;				
	    public class SchoolContext : DbContext							
	    {
			 public DbSet<Student> Students { get; set; }
			 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			{
				optionsBuilder.UseSqlServer("YourConnectionStringHere");
			}
		}
	 
>> lệnh tạo migration và update database

	Add-Migration InitialCreate
	Update-Database

>> các hàm xử lý thêm, xoá sử sinh viên, trong program