// -----------------------------------------------------------------------
// <copyright file="DebriefingExtensions.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------
namespace WebUI.Models.ExtensionMethods
{
    /*
     * This file is part of TUBS.
     *
     * TUBS is free software: you can redistribute it and/or modify
     * it under the terms of the GNU Affero General Public License as published by
     * the Free Software Foundation, either version 3 of the License, or
     * (at your option) any later version.
     *  
     * TUBS is distributed in the hope that it will be useful,
     * but WITHOUT ANY WARRANTY; without even the implied warranty of
     * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
     * GNU Affero General Public License for more details.
     *  
     * You should have received a copy of the GNU Affero General Public License
     * along with TUBS.  If not, see <http://www.gnu.org/licenses/>.
     */
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Web.Mvc;
    using Spc.Ofp.Debriefer.Dal.Common;
    using Spc.Ofp.Debriefer.Dal.Entities;

    public static class EvaluationQuestionExtensions
    {
        private static string[] DEFAULT_OPTIONS = {
            "Cc",
            "Inc",
            "InR",
            "Er",
            "ErR",
            "X"
        };

        private static string[] DEFAULT_WITH_DNE_OPTIONS = {
            "Cc",
            "Inc",
            "InR",
            "Er",
            "ErR",
            "X",
            "DnE"
        };

        private static string[] YESNO_OPTIONS = {
            "Y",
            "N"
        };

        private static string[] CORRECT_OR_ERROR_OPTIONS = {
            "Cc",
            "Er"
        };

        private static string[] WRITTEN_REPORT_OPTIONS = {
            "Wk",
            "Gd",
            "Vg",
            "Exc"
        };

        private static MvcHtmlString DebrieferTextBox(string inputId, string value)
        {
            TagBuilder textBox = new TagBuilder("input");
            textBox.MergeAttribute("type", "text");
            textBox.MergeAttribute("id", inputId);
            textBox.MergeAttribute("name", inputId);
            if (!String.IsNullOrEmpty(value))
            {
                textBox.MergeAttribute("value", value);
            }
            return MvcHtmlString.Create(textBox.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString NotesTextBox(this EvaluationQuestionViewModel eqvm)
        {
            if (null == eqvm)
            {
                return MvcHtmlString.Create(String.Empty);
            }
            return DebrieferTextBox(String.Format("Questions[{0}].Notes", eqvm.Number), eqvm.Notes);
        }

        public static MvcHtmlString AnswerTextBox(this EvaluationQuestionViewModel eqvm)
        {
            if (null == eqvm)
            {
                return MvcHtmlString.Create(String.Empty);
            }
            return DebrieferTextBox(String.Format("Questions[{0}].Answer", eqvm.Number), eqvm.Answer);
        }

        public static MvcHtmlString RadioButton(this EvaluationQuestionViewModel eqvm, bool disabled = true)
        {
            if (null == eqvm || Constraint.FreeText == eqvm.AnswerConstraints)
            {
                return MvcHtmlString.Create(String.Empty);
            }

            string[] options = DEFAULT_OPTIONS;
            switch (eqvm.AnswerConstraints)
            {
                case Constraint.CorrectOrError:
                    options = CORRECT_OR_ERROR_OPTIONS;
                    break;
                case Constraint.YesNo:
                    options = YESNO_OPTIONS;
                    break;
                case Constraint.WrittenReport:
                    options = WRITTEN_REPORT_OPTIONS;
                    break;
                case Constraint.DefaultWithDne:
                    options = DEFAULT_WITH_DNE_OPTIONS;
                    break;
                default:
                    break;
            }

            StringBuilder outputBuffer = new StringBuilder(512); // Start at 512 characters
            foreach (string option in options)
            {
                // Come up with Id for input (needed for label)
                string inputId = String.Format("Questions[{0}].Answer_{1}", eqvm.Number, option);
                //string inputId = String.Format("question{0}_{1}", eqvm.Number, option);
                //string inputId = String.Format("{0}_{1}_{2}", ViewData.TemplateInfo.HtmlFieldPrefix, 

                TagBuilder labelBuilder = new TagBuilder("label");
                labelBuilder.MergeAttribute("for", inputId);
                labelBuilder.InnerHtml = option;

                TagBuilder inputBuilder = new TagBuilder("input");
                inputBuilder.MergeAttribute("id", inputId);
                inputBuilder.MergeAttribute("name", String.Format("Questions[{0}].Answer", eqvm.Number)); // Double check this!
                inputBuilder.MergeAttribute("type", "radio");
                inputBuilder.MergeAttribute("value", option);
                // disabled is true when we're using this radio button for display purposes
                if (disabled)
                {
                    inputBuilder.MergeAttribute("disabled", "disabled");
                }
                else
                {
                    if (!String.IsNullOrEmpty(eqvm.DefaultAnswer) && String.IsNullOrEmpty(eqvm.Answer) && option.Equals(eqvm.DefaultAnswer))
                    {
                        inputBuilder.MergeAttribute("checked", "checked");
                    }
                }
                if (option.Equals(eqvm.Answer, StringComparison.InvariantCulture))
                {
                    inputBuilder.MergeAttribute("checked", "checked");
                }
                
                outputBuffer.Append(labelBuilder.ToString());
                outputBuffer.Append(inputBuilder.ToString(TagRenderMode.SelfClosing));
            }
           
            return MvcHtmlString.Create(outputBuffer.ToString());
        }
    }
}