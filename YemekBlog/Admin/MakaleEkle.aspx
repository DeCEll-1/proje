<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MakaleEkle.aspx.cs" Inherits="YemekBlog.Admin.MakaleEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="CKEditor/ckeditor/ckeditor.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form" style="">

        <asp:Label runat="server" CssClass="hata" Visible="true">
            <asp:Label runat="server" ID="lbl_Hata"></asp:Label>
        </asp:Label>

        <div class="form" style="min-height: 400px;">
            <div class="YarimForm" style="display:grid;margin-right: 50px; margin-top: 50px; float: right; min-height: 500px; width: 40%; text-align: center;">

                <div>
                    <asp:TextBox ID="tb_baslik" runat="server" CssClass="textbox" Style="font-size: 13pt; text-align: center;" placeholder="Makale Başlığı"></asp:TextBox>
                </div>
                <br />
                <%--a--%>
                <div style="height: 20px;">
                    <label style="float: left">Makale Kategorisi:</label>
                    <asp:DropDownList ID="ddl_Kategori" runat="server" DataTextField="KategoriAdi" DataValueField="ID" Style="float: right"></asp:DropDownList>
                </div>
                <br />
                <%--a--%>
                <div style="height: 23px;">
                    <label style="float: left;">Listle Görseli</label>
                    <asp:FileUpload ID="fu_min" runat="server" Style="float: right" />
                </div>
                <br />
                <%--a--%>
                <div style="height: 20px;">
                    <label style="float: left;">İçerik Görseli</label>
                    <asp:FileUpload ID="fu_max" runat="server" Style="float: right" />
                </div>
                <br />
                <%--a--%>
                <div style="height: 20px;">
                    <label style="float: left;">Makale Yayına Alınsınmı</label>
                    <asp:CheckBox ID="cb_confirm" runat="server" Text="Onaylıyorum" Checked="false" Style="float: right;" />
                </div>
                <br />
                    <div style="height: 36px;align-self:center;">
                        <asp:LinkButton CssClass="formButton" ID="lbtn_submit" runat="server" Text="Makale Ekle"></asp:LinkButton>
                    </div>
                    
            </div>


            <%----------------------------------------------------------------------------------------------------%>
            <div class="YarimForm" style="margin-right: 50px; margin-top: 50px; float: right; min-height: 500px; width: 40%;">

                <div style="height: 100px; margin-left: 7px">
                    <label>Liste Görünümü</label>
                    <br />
                    <asp:TextBox ID="tb_list" TextMode="MultiLine" runat="server" MaxLength="256" CssClass="textboxfill" Style="resize: none; width: 98%; height: 72%;"></asp:TextBox>
                </div>
                <div>
                    <asp:TextBox runat="server" ID="tb_Content" TextMode="MultiLine"></asp:TextBox>

                    <script>
                        CKEDITOR.replace('ctl00$ContentPlaceHolder1$tb_Content');
                        CKEDITOR.config.height = 252;
                    </script>
                </div>

            </div>
        </div>

    </div>
</asp:Content>
