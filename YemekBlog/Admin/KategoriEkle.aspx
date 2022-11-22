<%@ Page Title="Kategori Ekle" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="YemekBlog.Admin.KategoriEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formtablediv">
        <table class="kategoriekletable">
            <tr>
                <td>
                        <asp:Label ID="lbl_message" Text="Text" CssClass="hata" runat="server" Visible="false" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tb_KategoriAdi" runat="server" CssClass="textbox" placeholder="Kategori Adı Giriniz"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="lbtn_kategoriEkle" runat="server" OnClick="lbtn_Kategori_Ekle_Click" Text="Kategori Ekle" CssClass="formButton" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
