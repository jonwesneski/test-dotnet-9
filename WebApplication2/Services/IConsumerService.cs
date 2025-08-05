using System;

namespace WebApplication2.Services;

public interface IConsumerService
{
    //public static abstract Task<RecipeConsumerService> CreateAsync();
    public Task StartConsuming();
}
