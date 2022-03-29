<%@ Page Language="C#" AutoEventWireup="True" CodeFile="Test.aspx.cs" MasterPageFile="~/MainBoard.master" Inherits="Test_Test" %>

<asp:Content ID="cDefault" ContentPlaceHolderID="cphMain" runat="Server">

    <div id="divgvSdpms" runat="server" class="FormBox mt-2">
        <div class="HeaderBox">
            <asp:Label ID="Label17" runat="server" Text="نمايش اطلاعات"></asp:Label>
        </div>
        <div id="divdeclare" class="ContentBox DTGridContainer">
            
            <asp:GridView ID="gvMain" gridHeight="200" runat="server" AllowSorting="true" AutoGenerateColumns="false"
                CssClass="Grid" GridLines="Both" DataKeyNames="ccSystem,NameSystem" >
                <AlternatingRowStyle CssClass="GridAlternateRow" />
                <HeaderStyle CssClass="GridRowHeader" />
                <RowStyle CssClass="GridRow" />
                <PagerStyle CssClass="GridPager" />
                <Columns>
                    <asp:TemplateField HeaderText=" شماره ثبت  ">
                        <ItemTemplate>
                            <asp:Label ID="lblTarikh" Text='<%# Eval("ccSystem") %>'
                                runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" نام ">
                        <ItemTemplate>
                            <asp:Label ID="lblTozihat" Text='<%# Eval("NameSystem") %>'
                                runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="مبلغ ">
                        <ItemTemplate>
                            <asp:TextBox ID="txtTest" Text="0" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
        <asp:Button runat="server" ID="btnTest" Text="Sum" />
    </div>
</asp:Content>
