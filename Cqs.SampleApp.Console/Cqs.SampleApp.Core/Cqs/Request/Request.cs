using System;
using System.Security.Principal;

namespace Cqs.SampleApp.Core
{
    public abstract class Request : IRequest
    {
        protected Request()
        {
            CorrelationId = Guid.NewGuid();
        }

        public Guid CorrelationId { get; set; }
    }
}