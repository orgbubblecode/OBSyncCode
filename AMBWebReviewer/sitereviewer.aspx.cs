using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AMBWebReviewer.Code.Data;

namespace AMBWebReviewer
{


//    INSERT INTO `allmy_db`.`linksreview` (`link_id`,
//                                    `review_type_id`,
//                                    `review_result_id`,
//                                    `review_modified_date`,
//                                    `last_action`,
//                                    `action_result`)
//     select DISTINCT link_id, 1, 7, now(),0,0 from biolinks_blocks where settings LIKE '%daftar%' and link_id not in (select link_id from  linksreview)          



    public partial class sitereviewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            LoadNext();


            if (!IsPostBack)
            {




            }






        }

     


        private void LoadNext()
        {

            DataRow oData = AMBWebReviewer.Code.Data.AMBReviewData.GetRowForReview();

            string URL = string.Concat("https://allmy.bio/", oData["url"].ToString());


            myIframe.Attributes.Remove("src");
            myIframe.Attributes.Add("src", URL);


            hdnLinkID.Value = oData["link_id"].ToString();


            var resultSet = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Page URL", URL),
                new KeyValuePair<string, string>("User Name", oData["name"].ToString()),
                new KeyValuePair<string, string>("User Email", oData["email"].ToString()),
                new KeyValuePair<string, string>("Plan", oData["plan_id"].ToString()),
                new KeyValuePair<string, string>("Clicks", oData["clicks"].ToString()),
                new KeyValuePair<string, string>("Maturity", oData["maturity"].ToString())
            };


            string strItems = "";

            foreach (KeyValuePair<string, string> item in resultSet)
            {
                strItems += string.Format("<li class='list-group-item'>{0}</li>", string.Concat(item.Key, ": ","<b>" , item.Value, "</b>"));
            }

            string strList = string.Concat("<ul class='list-group'>", strItems, "</ul>");

            ltDtls.Text = strList;

        }

        protected void btnSensitiveGambling_Click(object sender, EventArgs e)
        {
            int linkID = int.Parse(hdnLinkID.Value);

            AMBWebReviewer.Code.Data.AMBReviewData.DoReview(linkID,
                                                             (int)AMBReviewType.ContentType,
                                                             (int)AMBReviewResult.Gambling,
                                                             0,
                                                             0);
            LoadNext();

        }

        protected void btnSensitiveAdult_Click(object sender, EventArgs e)
        {
            int linkID = int.Parse(hdnLinkID.Value);

            AMBWebReviewer.Code.Data.AMBReviewData.DoReview(linkID,
                                                            (int)AMBReviewType.ContentType,
                                                            (int)AMBReviewResult.Adult_content_and_services,
                                                            0,
                                                            0);
            LoadNext();

        }

        protected void btnThisSiteIsSafeFla_Click(object sender, EventArgs e)
        {
            int linkID = int.Parse(hdnLinkID.Value);
            AMBWebReviewer.Code.Data.AMBReviewData.DoReview(linkID,
                                                           (int)AMBReviewType.ContentType,
                                                           (int)AMBReviewResult.Safe_Completed,
                                                           0,
                                                           0);
            LoadNext();

        }

        protected void btnSafeEvaluateLater_Click(object sender, EventArgs e)
        {
            int linkID = int.Parse(hdnLinkID.Value);

            AMBWebReviewer.Code.Data.AMBReviewData.DoReview(linkID,
                                                           (int)AMBReviewType.ContentType,
                                                           (int)AMBReviewResult.Safe_ReviewLater,
                                                           0,
                                                           0);
            LoadNext();

        }

        protected void btnNotSafeEvaluateLater_Click(object sender, EventArgs e)
        {
            int linkID = int.Parse(hdnLinkID.Value);

            AMBWebReviewer.Code.Data.AMBReviewData.DoReview(linkID,
                                                      (int)AMBReviewType.ContentType,
                                                      (int)AMBReviewResult.NotSafe_ReviewLater,
                                                      0,
                                                      0);
            LoadNext();

        }
    }
}