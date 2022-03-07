using demo_WebAPI2.DAL;
using demo_WebAPI2.Sevice;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Dependency Injection (DI)

//          - Thiết kế sao cho các dependency (phụ thuộc) của một đối tượng CÓ THỂ được đưa vào,
//      tiêm vào đối tượng đó (Injection) khi nó cần tới (khi đối tượng khởi tạo).

//          * Xây dựng các lớp (dịch vụ) có sự phụ thuộc nhau một cách lỏng lẻo, và dependency có thể tiêm vào đối tượng (injection)
//     -thường qua phương thức khởi tạo constructor, property, setter.

//          * Xây dựng được một thư viện có thể tự động tạo ra các đối tượng, các dependency tiêm vào đối tượng đó,
//      thường là áp dụng kỹ thuật Reflection của C# có thể sử dụng các thư viện có sẵn như: Microsoft.Extensions.DependencyInjection
//      hoặc thư viện bên thứ ba như Windsor, Unity Ninject ...

//      Scoped	--> Một bản thực thi (instance) của dịch vụ (Class) được tạo ra cho mỗi phạm vi,
//      tức tồn tại cùng với sự tồn tại của một đối tượng kiểu ServiceScope (đối tượng này tạo bằng cách gọi ServiceProvider.CreateScope,
//      đối tượng này hủy thì dịch vụ cũng bị hủy).

//      Singleton -->  Duy nhất một phiên bản thực thi (instance of class) (dịch vụ) được tạo ra cho hết vòng đời của ServiceProvider

//      Transient -->  Một phiên bản của dịch vụ được tạo mỗi khi được yêu cầu

builder.Services.AddScoped<ServiceOfController>(); // đây là Sử dụng Delegate đăng ký

//       --" .Sevices" : Tạo và triển khai ServiceCollection
//       nó có chức năng quản lý các dịch vụ (đăng ký dịch vụ - tạo dịch vụ - tự động inject - và các dependency của địch vụ ...). 

//      -- AddScoped: Đăng ký vào hệ thống dịch vụ kiểu Scoped

//      -- ServiceOfController: dịch vụ cần đăng ký( Kiểu (tên lớp) dịch vụ).


#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
