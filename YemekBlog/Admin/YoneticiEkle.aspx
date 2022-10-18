<%@ Page Title="Yönetici ekle" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="YoneticiEkle.aspx.cs" Inherits="YemekBlog.Admin.YoneticiEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form">
        <table class="table" style="text-decoration:none; width: 500px; opacity: 0.9;">
            <tr>
                <td>
                    <asp:TextBox ID="tb_Adi" runat="server" CssClass="textbox" PlaceHolder="Yonetici Adı"></asp:TextBox>
                    <asp:TextBox ID="tb_Soyad" runat="server" CssClass="textbox" PlaceHolder="Soyadı"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tb_KullaniciAdi" runat="server" CssClass="textbox" PlaceHolder="Kullanıcı Adı"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tb_Eposta" runat="server" CssClass="textbox" PlaceHolder="Eposta"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tb_Sifre" runat="server" CssClass="textbox" PlaceHolder="Şifre"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton Text="Yönetici" runat="server" ID="rbtn_Admin"></asp:RadioButton>


                    <asp:RadioButton Text="Yazar" runat="server" ID="rbtn_Yazar"></asp:RadioButton>
                    <asp:Button ID="btn_Add" OnClick="btn_Add_Click" CssClass="buton" Text="Yonetici Ekle" runat="server" ></asp:Button>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel runat="server" ID="Pnl_hata" Visible="false" CssClass="hata">
                        <asp:Label runat="server" ID="lbl_message"></asp:Label>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
