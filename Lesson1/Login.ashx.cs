﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson1
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            string path=context.Request.MapPath("Login.html");
            string html=System.IO.File.ReadAllText(path);
            string _vs = context.Request.Form["_viewstate"];
            bool ispostback = !string.IsNullOrEmpty(_vs);
            if (ispostback)
            {
                string name = context.Request.Form["name"];
                string pwd = context.Request.Form["pwd"];
                if (name == "tf" && pwd == "123")
                    context.Response.Write("登录成功");
                else
                {
                    context.Response.Write("登录失败");
                    html = html.Replace("@name", name).Replace("@msg","登录失败");
                    context.Response.Write(html);
                }
            }
            else
            {
                html = html.Replace("@name", "").Replace("@msg", "登录失败");
                context.Response.Write(html);
            }
                
            //context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}