<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.DepartmentBrowser" 
CodeFile="DepartmentBrowser.aspx.cs"
MasterPageFile="Store.master" %>
<%@ Import Namespace="nothinbutdotnetstore.presentation" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
            <table>            
            <% foreach (var department in departments)
               {%>
            <tr class="ListItem">
               		 <td>                     
                     <a href="ProductBrowser.aspx?<%=QueryStrings.DepartmentId %>=<%=department.Id %>"><%=department.Name %></a>
                	</td>
           	 </tr>        
             <%
               }%>
           	
	    </table>            
</asp:Content>
