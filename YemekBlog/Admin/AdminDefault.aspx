<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminDefault.aspx.cs" Inherits="YemekBlog.Admin.AdminDefault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView runat="server" ID="lv_Makaleler" OnItemCommand="lv_Makaleler_ItemCommand">
        <LayoutTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th>Kullanıcı Adı</th>
                    <th>Kategori Adı</th>
                    <th>Başlık</th>
                    <th>Özet</th>
                    <th>Yetki Adı</th>
                    <th>Yükleme Tarihi</th>
                    <th>Yayındamı?</th>
                    <th>
                        <img src="../Images/Smile.png" width="30" />
                    </th>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("YetkiAdi") %></td>
                <td><%#Eval("KategoriAdi") %></td>
                <td><%#Eval("Baslik") %></td>
                <td><%#Eval("Adi") %></td>
                <td><%#Eval("Okundu") %></td>
                <td><%#Eval("YuklemeTarihi") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yayında" :"Kapalı"%></td>
                <td>
                    <asp:LinkButton ID="lbtn_AktifEt" CssClass="silbutton" CommandArgument='<%# Eval("ID") %>' CommandName="sil" runat="server">Aktif Et</asp:LinkButton>&nbsp;|&nbsp;
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
                <td><%#Eval("Adi") %></td>
                <td><%#Eval("KategoriAdi") %></td>
                <td><%#Eval("Baslik") %></td>
                <td><%#Eval("Ozet") %></td>
                <td><%#Eval("YetkiAdi") %></td>
                <td><%#Eval("YuklemeTarihi") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yayında" :"Kapalı"%></td>
                <td>
                    <asp:LinkButton ID="lbtn_AktifEt" CssClass="silbutton" CommandArgument='<%# Eval("ID") %>' CommandName="sil" runat="server">Aktif Et</asp:LinkButton>&nbsp;|&nbsp;
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th>Kullanıcı Adı</th>
                    <th>Kategori Adı</th>
                    <th>Başlık</th>
                    <th>Özet</th>
                    <th>Yetki Adı</th>
                    <th>Yükleme Tarihi</th>
                    <th>Yayındamı?</th>
                    <th>
                        <img src="../Images/Smile.png" width="30" /></th>
                </tr>
                <tr>
                    <td colspan="6">Henüz Makale Eklenmedi</td>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server" />
            </table>
        </EmptyDataTemplate>
    </asp:ListView>

    <asp:ListView runat="server" ID="lv_yorumlar" OnItemCommand="lv_yorumlar_ItemCommand">
        <LayoutTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th>Kullanıcı Adi</th>
                    <th>Kullanıcı ID</th>
                    <th>Başlık</th>
                    <th>Yorum Tarihi</th>
                    <th>İçerik</th>
                    <th>Like Sayısı</th>
                    <th></th>
                    <th>
                        <img src="../Images/Smile.png" width="50" /></th>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("KullaniciAdi") %></td>
                <td><%#Eval("KullaniciID") %></td>
                <td><%#Eval("Baslik") %></td>
                <td><%#Eval("YorumTarihi") %></td>
                <td><%#Eval("Icerik") %></td>
                <td><%#Eval("YorumLike") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yayında" :"Kapalı"%></td>
                <td>
                    <asp:LinkButton ID="lbtn_AktifEt" CssClass="silbutton" CommandArgument='<%# Eval("ID") %>' CommandName="Aktif" runat="server">Aktif Et</asp:LinkButton>&nbsp;|&nbsp;
                    <asp:LinkButton ID="lbtn_KaliciSil" CssClass="silbutton" CommandArgument='<%# Eval("ID") %>' CommandName="KaliciSil" runat="server">Kalıcı Sil</asp:LinkButton>&nbsp;|&nbsp;
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
                <td><%#Eval("KullaniciAdi") %></td>
                <td><%#Eval("KullaniciID") %></td>
                <td><%#Eval("Baslik") %></td>
                <td><%#Eval("YorumTarihi") %></td>
                <td><%#Eval("Icerik") %></td>
                <td><%#Eval("YorumLike") %></td>
                <td><%# (bool)Eval("IsDeleted") ==false ? "Yayında" :"Kapalı"%></td>
                <td>
                    <asp:LinkButton ID="lbtn_AktifEt" CssClass="silbutton" CommandArgument='<%# Eval("ID") %>' CommandName="Aktif" runat="server">AktifEt</asp:LinkButton>&nbsp;|&nbsp;
                    <asp:LinkButton ID="lbtn_KaliciSil" CssClass="silbutton" CommandArgument='<%# Eval("ID") %>' CommandName="KaliciSil" runat="server">Kalıcı Sil</asp:LinkButton>&nbsp;|&nbsp;
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EmptyDataTemplate>
            <table class="table" cellspacing="0">
                <tr>
                    <th>Yetkisi</th>
                    <th>Kategori Adı</th>
                    <th>Başlık</th>
                    <th>Kullanıcı Adı</th>
                    <th>Okunma Sayısı</th>
                    <th>
                        <img src="../Images/Smile.png" width="30" /></th>
                </tr>
                <tr>
                    <td colspan="6">Henüz Yorum Eklenmedi</td>
                </tr>
                <asp:PlaceHolder ID="ItemPlaceHolder" runat="server" />
            </table>
        </EmptyDataTemplate>
    </asp:ListView>
    <br>
</asp:Content>
