﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MakaleEkle.aspx.cs" Inherits="YemekBlog.Admin.MakaleEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="CKEditor/ckeditor/ckeditor.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form" style="">

        <asp:Label runat="server" CssClass="hata" Visible="true">
            <asp:Label runat="server" ID="lbl_Hata"></asp:Label>
        </asp:Label>

        <div class="form" style="min-height: 400px;">
            <div class="YarimForm" style="margin-right: 50px; margin-top: 50px; float: right; min-height: 500px; width: 40%;">
                <label class="label" style="float: left">Makale Kategorisi:</label>
                <asp:DropDownList CssClass="label" ID="ddl_Kategori" runat="server" DataTextField="KategoriAdi" DataValueField="ID" Style="float: right"></asp:DropDownList>
            </div>
            <%----------------------------------------------------------------------------------------------------%>
            <div class="YarimForm" style="margin-right: 50px; margin-top: 50px; float: right; min-height: 500px; width: 40%;">

                <div style="height: 100px; margin-left: 7px">
                    <label>Liste Görünümü</label>
                    <br />
                    <asp:TextBox ID="tb_list" TextMode="MultiLine" runat="server" MaxLength="256" CssClass="textboxfill" Style="max-width: 98%; max-height: 100%"></asp:TextBox>
                </div>
                <div>
                    <asp:TextBox runat="server" ID="tb_Content" TextMode="MultiLine"></asp:TextBox>

                    <script >
                        CKEDITOR.replace('ctl00$ContentPlaceHolder1$tb_Content');
                    </script>
                </div>

            </div>
        </div>

    </div>
</asp:Content>