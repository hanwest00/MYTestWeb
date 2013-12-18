using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Controls
{
    public abstract class HXControl
    {
        protected const string HEADER = "HX:{0}";

        public string Label
        {
            get { return string.Format(HEADER, this.GetType().Name); }
        }

        public string Id
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }

        public abstract void RenderHtml();


//System.Text.RegularExpressions.Regex.Matches(context, string.Format("(?<=\\[{0})\\s\\S*?(?=\\[/{0}])", Label), System.Text.RegularExpressions.RegexOptions.Compiled);
           
    }
}