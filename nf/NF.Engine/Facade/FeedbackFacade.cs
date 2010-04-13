using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NF.Engine.Feedback;

namespace NF.Engine.Facade {
    public class FeedbackFacade {
        public static void InsertFeedback(string feedback) {
            FeedbackLogic logic = new FeedbackLogic();
            logic.InsertFeedback(feedback);
        }
    }
}
