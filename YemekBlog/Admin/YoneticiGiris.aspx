<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YoneticiGiris.aspx.cs" Inherits="YemekBlog.Admin.YoneticiGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Giriş</title>
    <link href="../CSS/AdminLoginCSS.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="Tasiyici">
            <div class="panel">   
                <img src="../Images/barış%20abi.jpg" />
                <h3>Giriş</h3>
                <asp:Panel ID="pnl_mesaj" runat="server"  Visible="false">
                    <asp:Label ID="lbl_Hata" Text="" runat="server" />
                </asp:Panel>
                <div>
                    <asp:TextBox ID="tb_KullaniciAdi" runat="server" CssClass="textbox" PlaceHolder="E-posta adresi" />
                </div>
                <div>
                    <asp:TextBox ID="tb_Sifre" runat="server" CssClass="textbox" TextMode="Password" PlaceHolder="Şifreniz" />
                </div>
                <div>
                    <asp:LinkButton ID="lbtn_Giris" Text="Giriş" CssClass="buton" OnClick="lbtn_Giris_Click" runat="server" />
                    
                </div>
            </div>
        </div>
    </form>
</body>
</html>
