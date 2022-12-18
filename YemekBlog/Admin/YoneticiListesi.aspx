<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="YoneticiListesi.aspx.cs" Inherits="YemekBlog.Admin.YoneticiListesi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ListView runat="server" ID="lv_yoneticiler" OnItemCommand="lv_yoneticiler_ItemCommand">

        <LayoutTemplate>

            <table>
                <tr>
                    <td>Yetki Adı</td>
                    <td>Adı</td>
                    <td>SoyAdı</td>
                    <td>Kullanıcı Adı</td>
                    <td>E-Posta</td>
                    <th>
                        <img src="../Images/Smile.png" width="30" />
                    </th>
                    <asp:PlaceHolder runat="server" ID="ItemPlaceHolder" />
                </tr>
            </table>

        </LayoutTemplate>

        <ItemTemplate>
            <tr>
                <td><%#Eval("YetkiAdi") %></td>
                <td><%#Eval("Adi") %></td>
                <td><%#Eval("Soyadi") %></td>
                <td><%#Eval("KullaniciAdi") %></td>
                <td><%#Eval("Eposta") %></td>
            </tr>
        </ItemTemplate>

    </asp:ListView>

</asp:Content>
