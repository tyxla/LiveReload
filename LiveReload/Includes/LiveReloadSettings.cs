using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LiveReload
{
    class LiveReloadSettings: ApplicationSettingsBase
    {
        [UserScopedSetting()]
        [DefaultSettingValue("")]
        public String UserHost
        {
            get
            {
                return ((String)this["UserHost"]);
            }
            set
            {
                this["UserHost"] = (String)value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("")]
        public String UserDocumentRoot
        {
            get
            {
                return ((String)this["UserDocumentRoot"]);
            }
            set
            {
                this["UserDocumentRoot"] = (String)value;
            }
        }
    }
}
