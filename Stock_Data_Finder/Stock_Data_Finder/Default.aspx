<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Stock_Data_Finder._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    </br>
    Symbol:<asp:TextBox ID="symbol" runat="server" /></br></br>
    Start Date:<asp:Calendar ID="sDate" runat="server"></asp:Calendar></br>
    End Date:<asp:Calendar ID="eDate" runat="server"></asp:Calendar></br>
    <asp:Button runat="server" Text="Submit" onclick="submitUserInput" ID="SubmitButton"  />
    </br></br>

    @model List<Stock_Data_Finder.Models.StockInfo>
        <table>
            <tr>
                <th>---------SYMBOL-----------------------</th>
                <th>---------AVG VOLUME-------------------</th>
                <th>---------LAST TRADE PRICE-------------</th>
        
            </tr>
        @foreach (var item in Model)
        {
            <tr>
                <td>@Html.DisplayFor(modelItem => item.Symbol)</td>
                <td>@Html.DisplayFor(modelItem => item.AverageVolume)</td>
                <td>@Html.DisplayFor(modelItem => item.LastTradePrice)</td>
            </tr>
        }
    </table>
           


</asp:Content>
