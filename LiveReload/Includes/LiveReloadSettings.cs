using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LiveReload
{
    // Class for managing application user settings.
    class LiveReloadSettings: ApplicationSettingsBase
    {
        // Setting for the "Host" of the user.
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

        // Setting for the "Document Root" of the user.
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
