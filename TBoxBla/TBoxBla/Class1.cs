using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricentis.Automation.AutomationInstructions.TestActions;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Adapters.Attributes;
using Tricentis.Automation.Engines.Adapters.Html;
using Tricentis.Automation.Engines.Technicals.Html;

namespace TBoxBla
{
    [SupportedTechnical(typeof(IHtmlInputElementTechnical))]
    public class HtmlUpperTextBoxAdapter : HtmlTextBoxAdapter
    {
        protected HtmlUpperTextBoxAdapter(IHtmlInputElementTechnical htmlTechnical,
                                          Validator validator)
            : base(htmlTechnical, validator)
        {
        }

        public override string Text
        {
            get { return base.Text; }
            set { base.Text = "123"; }
        }


    }
}