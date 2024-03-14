using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMBWebReviewer.Code.Data
{
    public enum AMBReviewType
    {
        ContentType = 1
    }

    public enum AMBReviewResult
    {
        Safe_Completed = 0,
        Safe_ReviewLater = 200,
        NotSafe_ReviewLater = 300,
        Illegal_products_and_services = 1,
        Infringe_intellectual_property_rights=2,
        Products_and_services_that_are_unfair_predatory_or_deceptive = 3,
        Adult_content_and_services = 4,
        Certain_legal_services = 5,
        Firearms_explosives_and_dangerous_materials = 6,
        Gambling = 7,
        Marijuana = 8,
        Misuse_of_AllMyBio = 7
    }

    public enum AMBReviewAction
    {
        FirstEmailNotification = 1
    }

    public enum AMBReviewActionResult
    {
        NotDone = 0,
        Sent = 1,
        Pending = 2
    }
}