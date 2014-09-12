using ComCon.Contracts.Menu;
using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComCon.Common.Events
{
    public class LoadMenuEvent : CompositePresentationEvent<IComConMenuItem> { }
}
