using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace AMBWebReviewer.Code.Data
{
    public class AMBReviewData
    {


        public static DataRow GetRowForReview()
        {

            string strSQL = @"select DATEDIFF(now(),links.datetime) as maturity, links.*, users.*  
                              from links inner join users on links.user_id = users.user_id 
                              where  links.type = 'biolink' 
                                 and link_id not in (select link_id from linksreview) 
                                 and users.plan_id = 'free' 
                                 and links.clicks > 10 
                              order by link_id desc limit 1;";

            DataTable dtData = AMBReviewerData.AMBConn.GetData(strSQL);
            DataRow drRow = dtData.NewRow();
            //drRow = dtData.NewRow();

            if (dtData.Rows.Count > 0)
            {
                drRow = dtData.Rows[0];
            }

            return drRow;

        }




        public static void DoReview(int LinkID, 
                                    int review_type_id,
                                    int review_result_id,
                                    int last_action,
                                    int action_result)
        {

            string strCheckSQL = string.Format("select * from linksreview where link_id = {0}", LinkID);

            string strSQL;

          if (AMBReviewerData.AMBConn.GetData(strCheckSQL).Rows.Count > 0)
            {
                //Update
                strSQL = @"UPDATE `allmy_db`.`linksreview`
                                    SET
                                    `review_type_id` = <{review_type_id}>,
                                    `review_result_id` = <{review_result_id}>,
                                    `last_action` = <{last_action}>,
                                    `action_result` = <{action_result}>,
                                    `review_modified_date` = CURRENT_DATE()
                                    WHERE `link_id` = <{link_id}>;"
                                    .Replace("<{review_type_id}>", (review_type_id != 0 ? review_type_id.ToString() : "review_type_id"))
                                    .Replace("<{review_result_id}>", (review_result_id != 0 ? review_result_id.ToString() : "review_result_id"))
                                    .Replace("<{last_action}>", (last_action != 0 ? last_action.ToString() : "last_action"))
                                    .Replace("<{action_result}>", (action_result != 0 ? action_result.ToString() : "action_result"));

            }
            else
            {
                //Insert
                strSQL = @"INSERT INTO `allmy_db`.`linksreview`
                                    (`link_id`,
                                    `review_type_id`,
                                    `review_result_id`,
                                    `review_modified_date`,
                                    `last_action`,
                                    `action_result`)
                                    VALUES
                                    (<{link_id}>,
                                    <{review_type_id}>,
                                    <{review_result_id}>,
                                    CURRENT_DATE(),
                                    <{last_action}>,
                                    <{action_result}>);"
                                    .Replace("<{link_id}>", LinkID.ToString())
                                    .Replace("<{review_type_id}>", (review_type_id != 0 ? review_type_id.ToString() : "0"))
                                    .Replace("<{review_result_id}>", (review_result_id != 0 ? review_result_id.ToString() : "0"))
                                    .Replace("<{last_action}>", (last_action != 0 ? last_action.ToString() : "0"))
                                    .Replace("<{action_result}>", (action_result != 0 ? action_result.ToString() : "0"));





            }


            AMBReviewerData.AMBConn.ExecuteSQL(strSQL);



        }


    }
}