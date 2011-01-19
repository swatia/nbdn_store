<%@ Page Title="" Language="C#" MasterPageFile="Store.master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="nothinbutdotnetstore.web.ui.views.EditProfile" %>
<asp:Content ID="Content3" ContentPlaceHolderID="childContentPlaceHolder" runat="server">


<table id="editprofile">
    <tr>
        <td>
            <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="txtFirstName" Text="First Name"></asp:Label><br />
            <asp:TextBox ID="txtFirstName" runat="server" Columns="30" CssClass="required"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="lblMiddleInitial" runat="server" AssociatedControlID="txtMiddleInitial"
                Text="Middle Initial"></asp:Label><br />
            <asp:TextBox ID="txtMiddleInitial" runat="server" Columns="1"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName" Text="Last Name"></asp:Label><br />
            <asp:TextBox ID="txtLastName" runat="server" Columns="30" CssClass="required"></asp:TextBox>
        </td>
    </tr>
        <tr>
        <td>
            k<br />
            <asp:TextBox ID="txtUsername" runat="server" Columns="30" CssClass="required"></asp:TextBox>
        </td>
        <td colspan="2">
            <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" Text="Password"></asp:Label> 
            <span class="fielddescription"> (To change your password, provide one below.)</span><br />
            <asp:TextBox ID="txtPassword" runat="server" Columns="30"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblEmailAddress" runat="server" AssociatedControlID="txtEmailAddress"
                Text="Email Address"></asp:Label><br />
            <asp:TextBox ID="txtEmailAddress" runat="server" Columns="30" CssClass="email"></asp:TextBox>
        </td>
        <td colspan="2">
            <asp:Label ID="lblInitials" runat="server" AssociatedControlID="txtInitials" Text="Initials"></asp:Label><br />
            <asp:TextBox ID="txtInitials" runat="server" Columns="3"></asp:TextBox>
        </td>
    </tr>

                    
</table>

<div class="actions">
    <asp:Button runat="server" ID="btnSave" Text="Update Profile" 
        onclick="btnSave_Click" />
</div>
</asp:Content>
