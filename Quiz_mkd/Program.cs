using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Quiz.Domain.Identity;
using Quiz.Repository.Data;
using Quiz.Repository.Implementation;
using Quiz.Repository.Interface;
using Quiz.Utility;
using Quiz.Utility.Options;
using Quiz.Web.Domain_Transfer.Implementation;
using Quiz.Web.Domain_Transfer.Interface;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();// if i want to confirm the email for the user 
//builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddRazorPages();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddTransient<IRangListDetailsGeneral, RangListDetailsGeneral>();
builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection("Smtp"));
//builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection(SmtpOptions.Smtp));//this line is added for mail sending to have the options for Smtp options by hand
//builder.Services.AddScoped<UserManager<ApplicationUser>>();

builder.Services.AddScoped<SignInManager<ApplicationUser>>();

builder.Services.AddScoped<RoleManager<IdentityRole>>();
builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    var smtpOptions = app.Services.GetRequiredService<IOptions<SmtpOptions>>().Value;
    Console.WriteLine("USERNAME: " + smtpOptions.SmtpUserName);
    Console.WriteLine("PASSWORD: " + smtpOptions.SmtpPassword);
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); // for login and register
app.UseAuthorization();
app.MapRazorPages(); // for login and register

app.MapControllerRoute(
    name: "default",
    pattern: "{area=User}/{controller=Home}/{action=Index}/{id?}");


using (var scope = app.Services.CreateScope())
{
    var emailSender = scope.ServiceProvider.GetRequiredService<IEmailSender>();
    try
    {
        await emailSender.SendEmailAsync("nina.koceska@students.finki.ukim.mk", "Test Email from Program.cs", "? This is a test email from Program.cs on app start.");
        Console.WriteLine("Test email sent successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error sending test email: {ex.Message}");
    }
}


app.Run();