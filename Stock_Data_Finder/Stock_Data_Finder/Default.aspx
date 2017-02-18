﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Stock_Data_Finder._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    </br>
    Symbol:<asp:TextBox ID="symbol" runat="server" /></br></br>
    Start Date:<asp:Calendar ID="sDate" runat="server"></asp:Calendar></br>
    End Date:<asp:Calendar ID="eDate" runat="server"></asp:Calendar></br>
    <asp:Button runat="server" Text="Submit" onclick="submitUserInput" ID="SubmitButton"  />
    </br></br>


    <asp:Table ID="symbolData" runat="server">
        <asp:TableHeaderRow runat="server" >
                <asp:TableHeaderCell>Date</asp:TableHeaderCell>
                <asp:TableHeaderCell>Closing Price</asp:TableHeaderCell>
            </asp:TableHeaderRow>
    </asp:Table>
           


</asp:Content>
