using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace Itc.Am.UI.App_Start
{
    public class WebSecurityConfig
    {
        public static void RegisterWebSec()
        {
            WebSecurity.InitializeDatabaseConnection("StoreEntities", "UserModel",
                "UserId", "Email", autoCreateTables: true);
        }
    }
}