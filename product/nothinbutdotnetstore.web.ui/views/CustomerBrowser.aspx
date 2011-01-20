<%@ MasterType VirtualPath="Store.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="nothinbutdotnetstore.web.ui.views.CustomerBrowser"
CodeFile="CustomerBrowser.aspx.cs" MasterPageFile="Store.master" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
            <table>            
            <%--each customer should go here--%>
            <tr class="ListItem">
               		 <td> FirstName
                	</td>
               		 <td> LastName
                	</td>
               		 <td> Address
                	</td>
           	 </tr>        

             <% foreach (var customer in details) {%>
              <tr>
                <td><%= customer.FirstName %></td>
                <td><%= customer.LastName %></td>
                <td><%= customer.Address %></td>
                <td><%= customer.Age %></td>
              </tr>
             <% }%>
           	
	    </table>            
</asp:Content>
