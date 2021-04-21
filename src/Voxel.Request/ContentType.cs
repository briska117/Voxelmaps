using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IISI.Request
{
    public enum ContentType
    {
        [Description("application/json")]
        Json,
        [Description("application/x-www-form-urlencoded")]
        x_www_form_urlencoded

    }
}
