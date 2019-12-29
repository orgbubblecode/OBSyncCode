﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OBSync.Models.OBDataSources
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OBCRMContainer : DbContext
    {
        public OBCRMContainer()
            : base("name=OBCRMContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<accounts_audit> accounts_audit { get; set; }
        public virtual DbSet<accounts_bugs> accounts_bugs { get; set; }
        public virtual DbSet<accounts_cases> accounts_cases { get; set; }
        public virtual DbSet<accounts_contacts> accounts_contacts { get; set; }
        public virtual DbSet<accounts_cstm> accounts_cstm { get; set; }
        public virtual DbSet<accounts_opportunities> accounts_opportunities { get; set; }
        public virtual DbSet<acl_actions> acl_actions { get; set; }
        public virtual DbSet<acl_roles> acl_roles { get; set; }
        public virtual DbSet<acl_roles_actions> acl_roles_actions { get; set; }
        public virtual DbSet<acl_roles_users> acl_roles_users { get; set; }
        public virtual DbSet<alert> alerts { get; set; }
        public virtual DbSet<am_projecttemplates> am_projecttemplates { get; set; }
        public virtual DbSet<am_projecttemplates_audit> am_projecttemplates_audit { get; set; }
        public virtual DbSet<am_projecttemplates_contacts_1_c> am_projecttemplates_contacts_1_c { get; set; }
        public virtual DbSet<am_projecttemplates_project_1_c> am_projecttemplates_project_1_c { get; set; }
        public virtual DbSet<am_projecttemplates_users_1_c> am_projecttemplates_users_1_c { get; set; }
        public virtual DbSet<am_tasktemplates> am_tasktemplates { get; set; }
        public virtual DbSet<am_tasktemplates_am_projecttemplates_c> am_tasktemplates_am_projecttemplates_c { get; set; }
        public virtual DbSet<am_tasktemplates_audit> am_tasktemplates_audit { get; set; }
        public virtual DbSet<aobh_businesshours> aobh_businesshours { get; set; }
        public virtual DbSet<aod_index> aod_index { get; set; }
        public virtual DbSet<aod_index_audit> aod_index_audit { get; set; }
        public virtual DbSet<aod_indexevent> aod_indexevent { get; set; }
        public virtual DbSet<aod_indexevent_audit> aod_indexevent_audit { get; set; }
        public virtual DbSet<aok_knowledge_base_categories> aok_knowledge_base_categories { get; set; }
        public virtual DbSet<aok_knowledge_base_categories_audit> aok_knowledge_base_categories_audit { get; set; }
        public virtual DbSet<aok_knowledgebase> aok_knowledgebase { get; set; }
        public virtual DbSet<aok_knowledgebase_audit> aok_knowledgebase_audit { get; set; }
        public virtual DbSet<aok_knowledgebase_categories> aok_knowledgebase_categories { get; set; }
        public virtual DbSet<aop_case_events> aop_case_events { get; set; }
        public virtual DbSet<aop_case_events_audit> aop_case_events_audit { get; set; }
        public virtual DbSet<aop_case_updates> aop_case_updates { get; set; }
        public virtual DbSet<aop_case_updates_audit> aop_case_updates_audit { get; set; }
        public virtual DbSet<aor_charts> aor_charts { get; set; }
        public virtual DbSet<aor_conditions> aor_conditions { get; set; }
        public virtual DbSet<aor_fields> aor_fields { get; set; }
        public virtual DbSet<aor_reports> aor_reports { get; set; }
        public virtual DbSet<aor_reports_audit> aor_reports_audit { get; set; }
        public virtual DbSet<aor_scheduled_reports> aor_scheduled_reports { get; set; }
        public virtual DbSet<aos_contracts> aos_contracts { get; set; }
        public virtual DbSet<aos_contracts_audit> aos_contracts_audit { get; set; }
        public virtual DbSet<aos_contracts_documents> aos_contracts_documents { get; set; }
        public virtual DbSet<aos_invoices> aos_invoices { get; set; }
        public virtual DbSet<aos_invoices_audit> aos_invoices_audit { get; set; }
        public virtual DbSet<aos_line_item_groups> aos_line_item_groups { get; set; }
        public virtual DbSet<aos_line_item_groups_audit> aos_line_item_groups_audit { get; set; }
        public virtual DbSet<aos_pdf_templates> aos_pdf_templates { get; set; }
        public virtual DbSet<aos_pdf_templates_audit> aos_pdf_templates_audit { get; set; }
        public virtual DbSet<aos_product_categories> aos_product_categories { get; set; }
        public virtual DbSet<aos_product_categories_audit> aos_product_categories_audit { get; set; }
        public virtual DbSet<aos_products> aos_products { get; set; }
        public virtual DbSet<aos_products_audit> aos_products_audit { get; set; }
        public virtual DbSet<aos_products_quotes> aos_products_quotes { get; set; }
        public virtual DbSet<aos_products_quotes_audit> aos_products_quotes_audit { get; set; }
        public virtual DbSet<aos_quotes> aos_quotes { get; set; }
        public virtual DbSet<aos_quotes_aos_invoices_c> aos_quotes_aos_invoices_c { get; set; }
        public virtual DbSet<aos_quotes_audit> aos_quotes_audit { get; set; }
        public virtual DbSet<aos_quotes_os_contracts_c> aos_quotes_os_contracts_c { get; set; }
        public virtual DbSet<aos_quotes_project_c> aos_quotes_project_c { get; set; }
        public virtual DbSet<aow_actions> aow_actions { get; set; }
        public virtual DbSet<aow_conditions> aow_conditions { get; set; }
        public virtual DbSet<aow_processed> aow_processed { get; set; }
        public virtual DbSet<aow_processed_aow_actions> aow_processed_aow_actions { get; set; }
        public virtual DbSet<aow_workflow> aow_workflow { get; set; }
        public virtual DbSet<aow_workflow_audit> aow_workflow_audit { get; set; }
        public virtual DbSet<bug> bugs { get; set; }
        public virtual DbSet<bugs_audit> bugs_audit { get; set; }
        public virtual DbSet<call> calls { get; set; }
        public virtual DbSet<calls_contacts> calls_contacts { get; set; }
        public virtual DbSet<calls_leads> calls_leads { get; set; }
        public virtual DbSet<calls_reschedule> calls_reschedule { get; set; }
        public virtual DbSet<calls_reschedule_audit> calls_reschedule_audit { get; set; }
        public virtual DbSet<calls_users> calls_users { get; set; }
        public virtual DbSet<campaign_log> campaign_log { get; set; }
        public virtual DbSet<campaign_trkrs> campaign_trkrs { get; set; }
        public virtual DbSet<campaign> campaigns { get; set; }
        public virtual DbSet<campaigns_audit> campaigns_audit { get; set; }
        public virtual DbSet<@case> cases { get; set; }
        public virtual DbSet<cases_audit> cases_audit { get; set; }
        public virtual DbSet<cases_bugs> cases_bugs { get; set; }
        public virtual DbSet<cases_cstm> cases_cstm { get; set; }
        public virtual DbSet<contact> contacts { get; set; }
        public virtual DbSet<contacts_audit> contacts_audit { get; set; }
        public virtual DbSet<contacts_bugs> contacts_bugs { get; set; }
        public virtual DbSet<contacts_cases> contacts_cases { get; set; }
        public virtual DbSet<contacts_cstm> contacts_cstm { get; set; }
        public virtual DbSet<contacts_users> contacts_users { get; set; }
        public virtual DbSet<cron_remove_documents> cron_remove_documents { get; set; }
        public virtual DbSet<currency> currencies { get; set; }
        public virtual DbSet<document_revisions> document_revisions { get; set; }
        public virtual DbSet<document> documents { get; set; }
        public virtual DbSet<documents_accounts> documents_accounts { get; set; }
        public virtual DbSet<documents_bugs> documents_bugs { get; set; }
        public virtual DbSet<documents_cases> documents_cases { get; set; }
        public virtual DbSet<documents_contacts> documents_contacts { get; set; }
        public virtual DbSet<documents_opportunities> documents_opportunities { get; set; }
        public virtual DbSet<eapm> eapms { get; set; }
        public virtual DbSet<email_addr_bean_rel> email_addr_bean_rel { get; set; }
        public virtual DbSet<email_addresses> email_addresses { get; set; }
        public virtual DbSet<email_addresses_audit> email_addresses_audit { get; set; }
        public virtual DbSet<email_marketing> email_marketing { get; set; }
        public virtual DbSet<email_marketing_prospect_lists> email_marketing_prospect_lists { get; set; }
        public virtual DbSet<email_templates> email_templates { get; set; }
        public virtual DbSet<emailman> emailmen { get; set; }
        public virtual DbSet<email> emails { get; set; }
        public virtual DbSet<emails_beans> emails_beans { get; set; }
        public virtual DbSet<emails_email_addr_rel> emails_email_addr_rel { get; set; }
        public virtual DbSet<emails_text> emails_text { get; set; }
        public virtual DbSet<favorite> favorites { get; set; }
        public virtual DbSet<fields_meta_data> fields_meta_data { get; set; }
        public virtual DbSet<folder> folders { get; set; }
        public virtual DbSet<folders_rel> folders_rel { get; set; }
        public virtual DbSet<folders_subscriptions> folders_subscriptions { get; set; }
        public virtual DbSet<fp_event_locations> fp_event_locations { get; set; }
        public virtual DbSet<fp_event_locations_audit> fp_event_locations_audit { get; set; }
        public virtual DbSet<fp_event_locations_fp_events_1_c> fp_event_locations_fp_events_1_c { get; set; }
        public virtual DbSet<fp_events> fp_events { get; set; }
        public virtual DbSet<fp_events_audit> fp_events_audit { get; set; }
        public virtual DbSet<fp_events_contacts_c> fp_events_contacts_c { get; set; }
        public virtual DbSet<fp_events_fp_event_delegates_1_c> fp_events_fp_event_delegates_1_c { get; set; }
        public virtual DbSet<fp_events_fp_event_locations_1_c> fp_events_fp_event_locations_1_c { get; set; }
        public virtual DbSet<fp_events_leads_1_c> fp_events_leads_1_c { get; set; }
        public virtual DbSet<fp_events_prospects_1_c> fp_events_prospects_1_c { get; set; }
        public virtual DbSet<import_maps> import_maps { get; set; }
        public virtual DbSet<inbound_email> inbound_email { get; set; }
        public virtual DbSet<inbound_email_autoreply> inbound_email_autoreply { get; set; }
        public virtual DbSet<inbound_email_cache_ts> inbound_email_cache_ts { get; set; }
        public virtual DbSet<jjwg_address_cache> jjwg_address_cache { get; set; }
        public virtual DbSet<jjwg_address_cache_audit> jjwg_address_cache_audit { get; set; }
        public virtual DbSet<jjwg_areas> jjwg_areas { get; set; }
        public virtual DbSet<jjwg_areas_audit> jjwg_areas_audit { get; set; }
        public virtual DbSet<jjwg_maps> jjwg_maps { get; set; }
        public virtual DbSet<jjwg_maps_audit> jjwg_maps_audit { get; set; }
        public virtual DbSet<jjwg_maps_jjwg_areas_c> jjwg_maps_jjwg_areas_c { get; set; }
        public virtual DbSet<jjwg_maps_jjwg_markers_c> jjwg_maps_jjwg_markers_c { get; set; }
        public virtual DbSet<jjwg_markers> jjwg_markers { get; set; }
        public virtual DbSet<jjwg_markers_audit> jjwg_markers_audit { get; set; }
        public virtual DbSet<job_queue> job_queue { get; set; }
        public virtual DbSet<lead> leads { get; set; }
        public virtual DbSet<leads_audit> leads_audit { get; set; }
        public virtual DbSet<leads_cstm> leads_cstm { get; set; }
        public virtual DbSet<linked_documents> linked_documents { get; set; }
        public virtual DbSet<meeting> meetings { get; set; }
        public virtual DbSet<meetings_contacts> meetings_contacts { get; set; }
        public virtual DbSet<meetings_cstm> meetings_cstm { get; set; }
        public virtual DbSet<meetings_leads> meetings_leads { get; set; }
        public virtual DbSet<meetings_users> meetings_users { get; set; }
        public virtual DbSet<note> notes { get; set; }
        public virtual DbSet<oauth_consumer> oauth_consumer { get; set; }
        public virtual DbSet<oauth_nonce> oauth_nonce { get; set; }
        public virtual DbSet<oauth_tokens> oauth_tokens { get; set; }
        public virtual DbSet<oauth2clients> oauth2clients { get; set; }
        public virtual DbSet<oauth2tokens> oauth2tokens { get; set; }
        public virtual DbSet<opportunity> opportunities { get; set; }
        public virtual DbSet<opportunities_audit> opportunities_audit { get; set; }
        public virtual DbSet<opportunities_contacts> opportunities_contacts { get; set; }
        public virtual DbSet<opportunities_cstm> opportunities_cstm { get; set; }
        public virtual DbSet<outbound_email> outbound_email { get; set; }
        public virtual DbSet<outbound_email_audit> outbound_email_audit { get; set; }
        public virtual DbSet<project> projects { get; set; }
        public virtual DbSet<project_contacts_1_c> project_contacts_1_c { get; set; }
        public virtual DbSet<project_cstm> project_cstm { get; set; }
        public virtual DbSet<project_task> project_task { get; set; }
        public virtual DbSet<project_task_audit> project_task_audit { get; set; }
        public virtual DbSet<project_users_1_c> project_users_1_c { get; set; }
        public virtual DbSet<projects_accounts> projects_accounts { get; set; }
        public virtual DbSet<projects_bugs> projects_bugs { get; set; }
        public virtual DbSet<projects_cases> projects_cases { get; set; }
        public virtual DbSet<projects_contacts> projects_contacts { get; set; }
        public virtual DbSet<projects_opportunities> projects_opportunities { get; set; }
        public virtual DbSet<projects_products> projects_products { get; set; }
        public virtual DbSet<prospect_list_campaigns> prospect_list_campaigns { get; set; }
        public virtual DbSet<prospect_lists> prospect_lists { get; set; }
        public virtual DbSet<prospect_lists_prospects> prospect_lists_prospects { get; set; }
        public virtual DbSet<prospect> prospects { get; set; }
        public virtual DbSet<prospects_cstm> prospects_cstm { get; set; }
        public virtual DbSet<relationship> relationships { get; set; }
        public virtual DbSet<release> releases { get; set; }
        public virtual DbSet<reminder> reminders { get; set; }
        public virtual DbSet<reminders_invitees> reminders_invitees { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<roles_modules> roles_modules { get; set; }
        public virtual DbSet<roles_users> roles_users { get; set; }
        public virtual DbSet<saved_search> saved_search { get; set; }
        public virtual DbSet<scheduler> schedulers { get; set; }
        public virtual DbSet<securitygroup> securitygroups { get; set; }
        public virtual DbSet<securitygroups_acl_roles> securitygroups_acl_roles { get; set; }
        public virtual DbSet<securitygroups_audit> securitygroups_audit { get; set; }
        public virtual DbSet<securitygroups_default> securitygroups_default { get; set; }
        public virtual DbSet<securitygroups_records> securitygroups_records { get; set; }
        public virtual DbSet<securitygroups_users> securitygroups_users { get; set; }
        public virtual DbSet<spot> spots { get; set; }
        public virtual DbSet<sugarfeed> sugarfeeds { get; set; }
        public virtual DbSet<surveyquestionoption> surveyquestionoptions { get; set; }
        public virtual DbSet<surveyquestionoptions_audit> surveyquestionoptions_audit { get; set; }
        public virtual DbSet<surveyquestionoptions_surveyquestionresponses> surveyquestionoptions_surveyquestionresponses { get; set; }
        public virtual DbSet<surveyquestionrespons> surveyquestionresponses { get; set; }
        public virtual DbSet<surveyquestionresponses_audit> surveyquestionresponses_audit { get; set; }
        public virtual DbSet<surveyquestion> surveyquestions { get; set; }
        public virtual DbSet<surveyquestions_audit> surveyquestions_audit { get; set; }
        public virtual DbSet<surveyrespons> surveyresponses { get; set; }
        public virtual DbSet<surveyresponses_audit> surveyresponses_audit { get; set; }
        public virtual DbSet<survey> surveys { get; set; }
        public virtual DbSet<surveys_audit> surveys_audit { get; set; }
        public virtual DbSet<task> tasks { get; set; }
        public virtual DbSet<templatesectionline> templatesectionlines { get; set; }
        public virtual DbSet<tracker> trackers { get; set; }
        public virtual DbSet<upgrade_history> upgrade_history { get; set; }
        public virtual DbSet<user_preferences> user_preferences { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<users_last_import> users_last_import { get; set; }
        public virtual DbSet<users_password_link> users_password_link { get; set; }
        public virtual DbSet<users_signatures> users_signatures { get; set; }
        public virtual DbSet<vcal> vcals { get; set; }
        public virtual DbSet<address_book> address_book { get; set; }
    }
}
