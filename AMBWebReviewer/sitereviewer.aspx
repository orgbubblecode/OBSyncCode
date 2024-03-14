<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sitereviewer.aspx.cs" Inherits="AMBWebReviewer.sitereviewer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



     <div class="container">



     <div class="modal-body row">
  <div class="col-md-6">
    
      <div  class="row">

          <asp:Literal ID="ltDtls" runat="server"></asp:Literal>
          <asp:HiddenField ID="hdnLinkID" runat="server" />
      </div>

      <div  class="row">

      <asp:Button ID="btnSensitiveGambling" onclick="btnSensitiveGambling_Click"  runat="server" CssClass="btn btn-danger btn-lg btn-block" Text="Sensitive - Gambling" />

      <asp:Button ID="btnSensitiveAdult" onclick="btnSensitiveAdult_Click"  runat="server" CssClass="btn btn-danger btn-lg btn-block" Text="Sensitive - Adult Content" />

      <asp:Button ID="btnThisSiteIsSafeFla" onclick="btnThisSiteIsSafeFla_Click" runat="server" CssClass="btn btn-success btn-lg btn-block" Text="This Site Is SAFE" />

      <asp:Button ID="btnSafeEvaluateLater" onclick="btnSafeEvaluateLater_Click"  runat="server" CssClass="btn btn-info btn-lg btn-block" Text="SAFE Evaluate Later!" />

      <asp:Button ID="btnNotSafeEvaluateLater" onclick="btnNotSafeEvaluateLater_Click" runat="server" CssClass="btn btn-info btn-lg btn-block" Text="Not SAFE Evaluate Later!" />
          </div>
         

  </div>
  <div class="col-md-6">
     <iframe name="myIframe" id="myIframe" width="400px" height="900px" runat="server"></iframe>
  </div>
</div>

  
</div>



</asp:Content>
