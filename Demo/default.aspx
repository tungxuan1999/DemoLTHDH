<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Demo._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DEMO LTHDH</title>
    <style type="text/css">
        .hide {
             position: absolute;
             top: -9999px;
             left: -9999px;
        }
        .div1{
            border:1px solid black;
            margin-top:20px;
            margin-left:50px;
            margin-bottom:30px;
            margin-right:150px;
        }
        .div2{
            margin-left: inherit;
            margin-right: inherit;
            margin-bottom: inherit;
        }
        .div3{
            border:1px solid blue;
            width:300px;
            margin-left:auto;
        }
        .div4{
            border:1px solid green;
            width:300px;
            margin:auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div1">
            <div class="div2"><h1>DEMO FIFO, LRU, OPTIMAL, CLOCK</h1>
            <h2>Nhập chuỗi: <asp:TextBox ID="InputArray" runat="server"/></h2>
            <h2>Nhập frame: <asp:TextBox ID="InputFrame" runat="server"/></h2>
            <asp:Button ID="ButtonDEMO" runat="server" Text="OK" OnClick="ButtonDEMO_Click"/><br />
                </div>
            <div class="div2"><a margin-left="InputArray">Ví dụ nhập</a><br />
                <a margin-left="InputArray">Nhập chuỗi: 2 3 4 1 2 5 6 7 8 6</a><br />
                <a margin-left="InputFrame">Nhập frame: 3</a><br />
                Lưu ý<br />
                Chuỗi và frame phải là số nguyên dương</div>
            <div class="div3" align="left">
                <a>Học kỳ 19.2A</a><br />
                <a>Demo: https://www.facebook.com/Linning154 </a><br />
                <a>GV hướng dẫn: TS. Phan Đình Thế Huân</a>
            </div>
            </div>
        <div class="div1" id="divFINAL">
            <div class="div2">
                <h1>FIFO</h1>
                <asp:GridView ID="GridViewFIFO" runat="server" OnRowDataBound="GridViewFIFO_RowDataBound"
                    ></asp:GridView>
                <br />
                <asp:GridView ID="GridViewNextFIRO" runat="server"
                    ></asp:GridView>
                <h1>LRU</h1>
                <asp:GridView ID="GridViewLRU" runat="server" OnRowDataBound="GridViewLRU_RowDataBound"
                    ></asp:GridView>
                <br />
                <asp:GridView ID="GridViewLOCALRU" runat="server"
                    ></asp:GridView>
                <h1>OPT</h1>
                <asp:GridView ID="GridViewOPT" runat="server" OnRowDataBound="GridViewOPT_RowDataBound"
                    ></asp:GridView>
                <br />
                <asp:GridView ID="GridViewLOCAOPT" runat="server"
                    ></asp:GridView>
                <h1>CLOCK</h1>
                <asp:GridView ID="GridViewCLOCK" runat="server" OnRowDataBound="GridViewCLOCK_RowDataBound" 
                    ></asp:GridView>
                <br />
                <asp:GridView ID="GridViewStatusNextCLOCK" runat="server"
                    ></asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
