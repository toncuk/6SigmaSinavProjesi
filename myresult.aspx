﻿<%@ Page Title="" Language="C#" MasterPageFile="~/usermaster.master" AutoEventWireup="true" CodeFile="myresult.aspx.cs" Inherits="myresult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="heardcontentplaceholder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontentplaceholder" Runat="Server">
    <div class="card-header">
        <h2>Sonuçlarım</h2>
    </div>
    <asp:TextBox ID="getemail" runat="server" Visible ="false"></asp:TextBox>
    <asp:GridView ID="gridmyresult" runat="server" GridLines="None" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-bordered" OnPageIndexChanging="gridmyresult_PageIndexChanging" PageSize="8">
        <Columns>
            <asp:BoundField DataField="exam_name" HeaderText="Sınav Ismi" NullDisplayText="no exam name"/>
            <asp:BoundField DataField="exam_date" DataFormatString="{0:d}" HeaderText="Sınav Tarihi" NullDisplayText="Sınav Tarihi Bulunamadı" />
            <asp:BoundField DataField="totalquestion" HeaderText="Toplam Soru" />
            <asp:BoundField DataField="result_status" HeaderText="Sonuç" />
            <asp:BoundField DataField="exam_marks" HeaderText="Tam Puan" />
            <asp:BoundField DataField="result_score" HeaderText="Alınan Puan" />
        </Columns>
    </asp:GridView>
        <div class="col-md-12">
        <div class="card">
            <div class="card-header">
                <asp:Panel ID="panel_myresultshow_warning" runat="server" Visible="false">
                    <br />
                    <div class="alert alert-danger text-center">
                        <asp:Label ID="lbl_myresultshowwarning" runat="server" />
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

