using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BearBytes.SohoPayDay.DataAccess;
using BearBytes.SohoPayDay.DataAccess.Interfaces;
using StructureMap;

namespace BearBytes.SohoPayDay.Business
{
    public class Business
    {
        public static Container LoadDependencies()
        {
            return new Container(x =>
            {
                x.For<IProductDao>().Use<ProductDao>();
            });
        }
    }
}
