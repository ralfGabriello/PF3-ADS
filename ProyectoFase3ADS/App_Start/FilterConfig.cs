﻿using System.Web;
using System.Web.Mvc;

namespace ProyectoFase2ADS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
