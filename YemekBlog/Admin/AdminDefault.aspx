<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminDefault.aspx.cs" Inherits="YemekBlog.Admin.AdminDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView runat="server" ID="lv_yorumlar" OnItemCommand="lv_yorumlar_ItemCommand">
        <LayoutTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th>Kullanıcı Adı</th>
                    <th>Makale kategorisi</th>
                    <th>Makale Adı</th>
                    <th>Kullanıcı Adı</th>
                    <img src="../Images/Smile.png" />
                </tr>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server" />
            </table>
        </LayoutTemplate>

        <ItemTemplate>
            <tr>
                <td><%#Eval("KullaniciAdi") %></td>
                <td><%#Eval("KategoriAdi") %></td>
                <td><%#Eval("Baslik") %></td>
                <td><%#Eval("YorumTarihi") %></td>
                <td><%#Eval("YorumIcerik") %></td>
                <td><%#Eval("YorumLike") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yayında" :"Kapalı"%></td>
                <td>
                    <asp:LinkButton ID="lbtn_AktifEt" CssClass="silbutton" CommandArgument='<%# Eval("ID") %>' CommandName="Aktif" runat="server">AktifEt</asp:LinkButton>&nbsp;|&nbsp;
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
                <td><%#Eval("KullaniciAdi") %></td>
                <td><%#Eval("KategoriAdi") %></td>
                <td><%#Eval("Baslik") %></td>
                <td><%#Eval("YorumTarihi") %></td>
                <td><%#Eval("YorumIcerik") %></td>
                <td><%#Eval("YorumLike") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yayında" :"Kapalı"%></td>
                <td>
                    <asp:LinkButton ID="lbtn_AktifEt" CssClass="silbutton" CommandArgument='<%# Eval("ID") %>' CommandName="Aktif" runat="server">AktifEt</asp:LinkButton>&nbsp;|&nbsp;
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th>Kullanıcı Adı</th>
                    <th>Makale kategorisi</th>
                    <th>Makale Adı</th>
                    <th>Kullanıcı Adı</th>
                    <th><a href="../Images/&">../Images/&</a></th>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server" />
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
    <br>
    <asp:ListView runat="server" ID="lv_Makaleler" OnItemCommand="lv_Makaleler_ItemCommand">
        <LayoutTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th>Kullanıcı Adı</th>
                    <th>Makale kategorisi</th>
                    <th>Makale Adı</th>
                    <th>Kullanıcı Adı</th>
                    <img src="../Images/Smile.png" />
                </tr>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server" />
            </table>
        </LayoutTemplate>

        <ItemTemplate>
            <tr>
                <td><%#Eval("YetkiAdi") %></td>
                <td><%#Eval("KategoriAdi") %></td>
                <td><%#Eval("Baslik") %></td>
                <td><%#Eval("YuklemeTarihi") %></td>
                <td><%#Eval("Okundu") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yayında" :"Kapalı"%></td>
                <td>
                    <asp:LinkButton ID="lbtn_AktifEt" CssClass="silbutton" CommandArgument='<%# Eval("ID") %>' CommandName="Aktif" runat="server">AktifEt</asp:LinkButton>&nbsp;|&nbsp;
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
                <td><%#Eval("KullaniciAdi") %></td>
                <td><%#Eval("KategoriAdi") %></td>
                <td><%#Eval("Baslik") %></td>
                <td><%#Eval("YorumTarihi") %></td>
                <td><%#Eval("YorumIcerik") %></td>
                <td><%#Eval("YorumLike") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yayında" :"Kapalı"%></td>
                <td>
                    <asp:LinkButton ID="lbtn_AktifEt" CssClass="silbutton" CommandArgument='<%# Eval("ID") %>' CommandName="Aktif" runat="server">AktifEt</asp:LinkButton>&nbsp;|&nbsp;
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
                <table class="table" cellspacing="0">
                <tr>
                    <th>Makale kategorisi</th>
                    <th>Makale Adı</th>
                    <th>Kullanıcı Adı</th>
                    <th>Yayındamı</th><img src="../Images/TheRock.jpg" />
                    <th><a href="../Images/&">../Images/&</a></th>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server" />
            </table>
        </EmptyDataTemplate>
    </asp:ListView>

</asp:Content>
