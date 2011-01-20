<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.CustomerBrowser"
CodeFile="CustomerBrowser.aspx.cs" MasterPageFile="Store.master" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
            <table>            
            <%--each customer should go here--%>
            <tr class="ListItem">
               		 <td>                     
                   FirstName
                	</td>
               		 <td>                     
                   LastName
                	</td>
               		 <td>                     
                   Address
                	</td>
           	 </tr>        
           	
	    </table>            
</asp:Content>
