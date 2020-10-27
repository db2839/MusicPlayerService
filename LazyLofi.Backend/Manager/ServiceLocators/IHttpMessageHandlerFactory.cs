using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LazyLofi.Backend.Manager.ServiceLocators
{
    internal interface IHttpMessageHandlerFactory
    {
        HttpMessageHandler CreateHttpMessageHandler();
    }
}