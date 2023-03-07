using BLL.Services;
using BLL.Services.Dto;
using DAL.Models;
using DAL.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extensions;

public static class AddExtensions
{
    public static void AddApplicationDataTransients(this IServiceCollection services)
    {
        services.AddScoped<IService<Chat,ChatDto>, ChatService>();
        services.AddScoped<ChatService, ChatService>();
        services.AddScoped<IRepository<Chat>, ChatRepository>();

    }
}