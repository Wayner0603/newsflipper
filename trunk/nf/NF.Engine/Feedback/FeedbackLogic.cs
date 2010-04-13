using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NF.Engine.Common;

namespace NF.Engine.Feedback {
    public class FeedbackLogic : LogicBase<FeedbackData> {
        public void InsertFeedback(string feedback) {
            DataModel.InsertIssue(feedback);
        }
    }
}
