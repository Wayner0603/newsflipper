using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using NF.Engine.Feedback;

namespace newsflippers.services {
    /// <summary>
    /// Summary description for SettingsService
    /// </summary>
     [System.Web.Script.Services.ScriptService]
    public class SettingsService : System.Web.Services.WebService {

        [WebMethod]
        public bool SendEmail(string email, string subject, string body) {
            return true;
        }

        [WebMethod]
        public bool SubmitIssue(string issue) {
            try {
                FeedbackLogic logic = new FeedbackLogic();
                logic.InsertFeedback(issue);
                return true;
            } catch (Exception ex) {
                return false;
            }
            return false;
        }
    }
}
