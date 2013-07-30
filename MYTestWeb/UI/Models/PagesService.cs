using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using Util;
using UI.Models.WebModels;
using System.CodeDom;

namespace UI.Models
{
    public class PagesService
    {
        public IList<Template> GetTemplates()
        {
            IList<Template> list = new List<Template>();
            Directory.GetDirectories(WebPathManager.TemplateUrl).ToList().ForEach(s =>
            {
                string dir = string.Format("{0}{1}\\", WebPathManager.TemplateUrl, s);
                var xml = new System.Xml.XmlDocument();
                xml.LoadXml(string.Format("{0}config.xml", dir));
                var node = xml.GetElementsByTagName("template")[0];
                list.Add(new Template { Name = node.Attributes["name"].Value, Url = dir, ContentUrl = node.Attributes["contentfolder"].Value, TempImage = this.GetTempImage(dir, s) });
            });

            return list;
        }

        private string GetTempImage(string dir, string folderName)
        {
            return Directory.GetFiles(dir).Where(s => Regex.IsMatch(s.ToLower(), string.Format("{0}.(jpg|png|gif|bmp)", folderName))).First();
        }

        public void CreateHtml(Template tmp)
        {
            Directory.GetFiles(tmp.Url).Where(s => Regex.IsMatch(s.ToLower(), ".+?.(txt|html|htm|asp|aspx|php|jsp)")).ToList().ForEach(p =>
            {
                //todo:读取内容 后 render




                CodeNamespace ns = new CodeNamespace("UI.Controllers");
                ns.Imports.Add(new CodeNamespaceImport("System.Web"));
                ns.Imports.Add(new CodeNamespaceImport("System.Web.Mvc"));
                var ccu = new CodeCompileUnit();
                ccu.Namespaces.Add(ns);
                var prvdr = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("CSharp");
                
            });
        }
    }
}