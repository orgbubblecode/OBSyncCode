using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using DescriptionLibrary;

namespace OBSync.Models
{
    public enum OBAPIEnumEntityType
    {
        [Description("It can go for days without eating a single morsel. In the bulb on its back, it stores energy.")]
        OBUserInformation = 1001,

        OBUserLogin = 1002,

        AMBUserInformation = 2001,
        AMBUserLogin = 2002



        

    }


    public enum OBAPISuiteCRMModuleTypes
    {

        Accounts,
        ACLRoles,
        AM_ProjectTemplates,
        AOK_KnowledgeBase,
        AOP_Case_Updates,
        AOR_Reports,
        AOS_Contracts,
        AOS_Invoices,
        AOS_Line_Item_Groups,
        AOS_Products,
        AOS_Product_Categories,
        AOS_Quotes,
        AOW_Processed,
        AOW_WorkFlow,
        Bugs,
        Calls,
        CampaignLog,
        Campaigns,
        Cases,
        Contacts,
        Documents,
        EmailMarketing,
        Emails,
        EmailTemplates,
        FP_events,
        FP_Event_Locations,
        jjwg_Maps,
        Leads,
        Meetings,
        OAuth2Clients,
        OAuthKeys,
        Opportunities,
        Project,
        ProjectTask,
        ProspectLists,
        Prospects,
        Releases,
        Roles,
        Schedulers,
        SecurityGroups,
        SurveyQuestionOptions,
        SurveyQuestions,
        SurveyResponses,
        Surveys,
        Tasks,
        Users

    }


}