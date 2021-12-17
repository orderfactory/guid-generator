using System;

namespace OrderFactory.GuidGenerator
{
    public interface IGuidGenerator
    {
        Guid NewGuid();
    }
}
