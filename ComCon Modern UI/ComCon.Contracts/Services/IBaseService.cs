using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Contracts.Services
{
    public interface IBaseService
    {
        IEventAggregator EventAggregator { get; }
        //todo: Kommunikation mit SQL Datenbank (Wenn nötig)
    }
}
