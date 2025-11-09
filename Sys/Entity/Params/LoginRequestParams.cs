using System;
using System.Collections.Generic;
using System.Text;

namespace Sys.Entity.Params
{
    //登录请求参数
    public class LoginRequestParams
    {

        //用户名
        public string? Username { get; set; }

        //密码
        public string? Password { get; set; }

        //设备
        public string? Device { get; set; }

        //验证码
        public string? Captcha { get; set; }
    }
}
