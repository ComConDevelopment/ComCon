using Microsoft.Practices.Prism.Events;
using ComConAPI;

namespace ComCon.Client.Contracts.Services
{
    public interface IBaseService
    {
        IEventAggregator EventAggregator { get; set; }
        APIBase Api { get; set; }

    }
}
