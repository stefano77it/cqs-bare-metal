using System;

namespace Cqs.SampleApp.Core
{
    public interface IRequest
    {
        Guid CorrelationId { get; set; }
    }
}