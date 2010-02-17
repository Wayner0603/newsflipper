<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BugFeatureRequestUc.ascx.cs" Inherits="newsflippers.uc.BugFeatureRequestUc" %>
 
   <script language="javascript">
       function submit_issue() {
           jQuery.get("submit-issue.aspx?request=test", function(response) {
               if (response == '1') {
                   closePanel('#userlogin_div');
               } else {
                   alert(response);
               }
           });
           return false;
       }
       
    </script>
 <div id="overlay" class="overlay_div" style="display: none; background-color: #000">
        </div>
        
        <div id="userlogin_div">
        <div class="popup_outer">
            <div class="popup_container">
                <div class="popup_header">
                   Submit Bug or a New Feature<div onclick="closePanel('#userlogin_div');" class="popup_close">
                        <img src="../images/close.gif" /></div>
                </div>
                <div class="popup_content">
                Suggest a new feature or report a bug. We appriciate your feedback very much.<br /><br />
                    <asp:TextBox CssClass="textbox" ID="TextBox1" runat="server" Height="71px" TextMode="MultiLine"
                        Width="558px"></asp:TextBox></div>
                <div class="popup_footer">
                   <asp:LinkButton OnClientClick="return submit_issue();" OnClick="Button1_Click" ID="LinkButton1"
                        CssClass="btn" runat="server"><span><span>Submit</span></span></asp:LinkButton>
                    &nbsp;<asp:Label ID="lblMsg" runat="server"></asp:Label></div>
            </div>
        </div>
    </div>