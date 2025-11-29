using BidaStore.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

// CÁC USING CẦN THIẾT
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using BidaStore.Client.Auth;
using BidaStore.Client.Services;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using DataShared.Library.Services;
using DataShared.Library.Models;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// 1. Thêm Blazored.LocalStorage
builder.Services.AddBlazoredLocalStorage();

// 2. Thêm các dịch vụ Authentication
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();

// 3. Đăng ký AuthHeaderHandler (Để gửi token trong mọi request)
builder.Services.AddScoped<AuthHeaderHandler>();

// 4. Cấu hình HttpClient để sử dụng AuthHeaderHandler
builder.Services.AddHttpClient("BidaStore.API", client =>
{
    // Địa chỉ API của bạn
    client.BaseAddress = new Uri("https://localhost:7232");
})
    .AddHttpMessageHandler<AuthHeaderHandler>();

// 5. Đăng ký HttpClient mặc định cho các components
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("BidaStore.API"));

// Client-side service registrations
builder.Services.AddScoped<IService<Product>, ProductService>();
builder.Services.AddScoped<IService<Category>, CategoryService>();
builder.Services.AddScoped<IService<Brand>, BrandService>();
builder.Services.AddScoped<IService<Cart>, CartService>();
builder.Services.AddScoped<IService<Contact>, ContactService>();
builder.Services.AddScoped<IService<Customer>, CustomerService>();
builder.Services.AddScoped<IService<Feedback>, FeedbackService>();
builder.Services.AddScoped<IService<Order>, OrderService>();
builder.Services.AddScoped<IService<OrderDetail>, OrderDetailService>();
builder.Services.AddScoped<IService<Post>, PostService>();

await builder.Build().RunAsync();