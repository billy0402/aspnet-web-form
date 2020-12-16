<%@ Page Title="產品列表" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AspnetWebForm.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>產品列表</h2>
    <p>
        <a href="Create.aspx">新增一筆</a>
    </p>
    <asp:GridView ID="GridView1" runat="server" class="table"
        BorderStyle="None" AutoGenerateColumns="False"
        OnRowCommand="GridView1_RowCommand" GridLines="None">
        <columns>
            <asp:BoundField DataField="fId" HeaderText="編號" />
            <asp:BoundField DataField="fName" HeaderText="品名" />
            <asp:BoundField DataField="fPrice" HeaderText="單價" DataFormatString="{0:C}" />
            <asp:ImageField DataImageUrlField="fImg"
				DataImageUrlFormatString="images/{0}"
				HeaderText="圖示" NullDisplayText="無圖示" >
                <ControlStyle Width="130px" />
            </asp:ImageField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEdit" runat="server"
					CommandArgument='<%# Eval("fId", "{0}") %>'
					CommandName="編輯" >編輯</asp:LinkButton> |
 					<asp:LinkButton ID="lnkDelete" runat="server"
					CommandArgument='<%# Eval("fId", "{0}") %>'
					CommandName="刪除"
					OnClientClick="return confirm('確定要刪除嗎');">
                         刪除
 				</asp:LinkButton>
               </ItemTemplate>
            </asp:TemplateField>
        </columns>
    </asp:GridView>
</asp:Content>
