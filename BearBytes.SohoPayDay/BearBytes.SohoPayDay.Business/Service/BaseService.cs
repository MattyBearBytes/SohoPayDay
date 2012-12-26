using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BearBytes.SohoPayDay.Business.Service.Interface;
using NLog;

namespace BearBytes.SohoPayDay.Business.Service
{
    public class BaseService : IBaseService
    {
        protected readonly Logger Logger;

        public BaseService()
        {
            Logger = LogManager.GetLogger("ButcherManagerLog");
        }
    }
}
