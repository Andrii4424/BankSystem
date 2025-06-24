using ApplicationCore.Domain.Entities.Identity;
using ApplicationCore.Domain.RepositoryContracts;
using BankData.Repository;
using BankServices.BankService;
using BankServices.CardService;
using BankServices.EmployeeService;
using BankServices.UserService;
using BankServicesContracts.RepositoryContracts;
using BankServicesContracts.ServicesContracts;
using BankServicesContracts.ServicesContracts.BankService;
using BankServicesContracts.ServicesContracts.CardServiceContracts;
using BankServicesContracts.ServicesContracts.EmployeeServiceContracts;
using BankServicesContracts.ServicesContracts.UserServiceContracts;
using Entities;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BankProject
{
    public static class AddApplicationServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Swagger 
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //CORS
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policyBuilder =>{
                    policyBuilder.WithOrigins(configuration.GetSection("AllowedOrigins").Get<string[]>());
                    policyBuilder.WithMethods("GET", "POST", "PUT", "DELETE");                      
                });
            });

            //Database 
            services.AddControllersWithViews();
            services.AddDbContext<BankAppContext>(
                options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                }
                );

            //Repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IBankRepository), typeof(BankRepository));
            services.AddScoped(typeof(ICardRepository), typeof(CardRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));

            //Identity
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<BankAppContext>()
                .AddDefaultTokenProviders();

            //Services

            //Bank Services
            services.AddScoped<IBankReadService, BankReadService>();
            services.AddScoped<IBankAddService, BankAddService>();
            services.AddScoped<IBankUpdateService, BankUpdateService>();
            services.AddScoped<IBankDeleteService, BankDeleteService>();

            //Card Services 
            services.AddScoped<ICardReadService, CardReadService>();
            services.AddScoped<ICardAddService, CardAddService>();
            services.AddScoped<ICardUpdateService, CardUpdateService>();
            services.AddScoped<ICardDeleteService, CardDeleteService>();

            //User Services
            services.AddScoped<IUserReadService, UserReadService>();
            services.AddScoped<IUserAddService, UserAddService>();
            services.AddScoped<IUserUpdateService, UserUpdateService>();
            services.AddScoped<IUserDeleteService, UserDeleteService>();

            //Employee Services
            services.AddScoped<IEmployeeReadService, EmployeeReadService>();
            services.AddScoped<IEmployeeAddService, EmployeeAddService>();
            services.AddScoped<IEmployeeUpdateService, EmployeeUpdateService>();
            services.AddScoped<IEmployeeDeleteService, EmployeeDeleteService>();

            return services;
        }
    }
}
