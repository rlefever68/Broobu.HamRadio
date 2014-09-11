// <copyright file="AgentClassTemplate.partial.cs" company="Microsoft">
//  Copyright © Microsoft. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using Iris.Contract.Generation.Common;

namespace Iris.Contract.Generation.Templates
{
    public partial class ErrorTemplate
    {
        public IrisToStringHelper ToStringHelper = new IrisToStringHelper();

        public static List<Exception> Exceptions { get; set; }

        public ErrorTemplate()
            : base()
        {

        }

        protected override void Validate()
        {
            if (this.Errors != null && this.Errors.Count > 0)
                this.Error("Errors have been generated.");
        }

        protected static String GetExceptionInformation()
        {
            StringBuilder sb = new StringBuilder();
            byte ErrorCount = 0;
            foreach (var ex in Exceptions)
            {
                ErrorCount++;

                sb.AppendLine("==========");
                sb.AppendLine(String.Format("Error {0}:", ErrorCount));
                sb.AppendLine("==========");
                sb.AppendLine(ex.Message);
                sb.AppendLine(ex.StackTrace);

                if (ex.InnerException != null)
                {
                    sb.AppendLine("InnerException: ");
                    sb.AppendLine(GetExceptionInformation(ex.InnerException));
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
        protected static String GetExceptionInformation(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            byte ErrorCount = 0;
           
                ErrorCount++;

                sb.AppendLine(ex.Message);
                sb.AppendLine(ex.StackTrace);

                if (ex.InnerException != null)
                {
                    sb.AppendLine("InnerException: ");
                    sb.AppendLine(GetExceptionInformation(ex.InnerException));
                }
                sb.AppendLine();
           
            return sb.ToString();
        }
    }
}
