using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Core.Events
{
    public abstract class Message : IRequest<bool>
    {
        public string MessageTye { get; protected set; }
        protected Message()
        {
            MessageTye = GetType().Name;
        }
    }
}
