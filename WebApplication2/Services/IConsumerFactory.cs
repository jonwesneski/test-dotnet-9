using System;

namespace WebApplication2.Services;

public interface IConsumerFactory
{
    public IConsumerService Create();
}
