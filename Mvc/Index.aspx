<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body style="background-color:#e7e7e7">
    <form id="form1" runat="server">
        <h3>Category List</h3>
        <hr/>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource3" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="CategorryName" HeaderText="CategorryName" SortExpression="CategorryName"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <br />
        <hr/>
        <h3>Expense List</h3>
        <asp:GridView runat="server" DataSourceID="SqlDataSource4" ID="Gri" AutoGenerateColumns="False" DataKeyNames="ExpenseId">
            <Columns>
                <asp:BoundField DataField="ExpenseId" HeaderText="ExpenseId" ReadOnly="True" InsertVisible="False" SortExpression="ExpenseId"></asp:BoundField>
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <br />
        <hr/>

        <asp:SqlDataSource runat="server" ID="SqlDataSource4" ConnectionString="<%$ ConnectionStrings:Expense_TrackerConnectionString %>" SelectCommand="SELECT [ExpenseId], [Title], [Amount] FROM [Expense]"></asp:SqlDataSource>
        <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:Expense_TrackerConnectionString %>" SelectCommand="SELECT [CategorryName] FROM [Category]"></asp:SqlDataSource>

        <br />
        <div>
            <asp:DropDownList runat="server" DataTextField="CategorryName" DataValueField="CategoryId" DataSourceID="SqlDataSource1" ID="CategoryList" AutoPostBack="True" ToolTip="You can Select Category And particlar Expense Show">
                <asp:ListItem Value="0">Select category </asp:ListItem>
            </asp:DropDownList><asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:Expense_TrackerConnectionString %>" SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>
        </div>
        <br />
        <asp:GridView runat="server" DataSourceID="SqlDataSource2" ID="ExpList" AllowSorting="True" AllowPaging="True" PageSize="5" ToolTip="For Sorting Click On Particlar Fields"></asp:GridView>
        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:Expense_TrackerConnectionString %>" SelectCommand="SELECT [ExpenseId], [Title], [Amount] FROM [Expense] WHERE ([CategoryId] = @CategoryId)">
            <SelectParameters>
                <asp:ControlParameter ControlID="CategoryList" PropertyName="SelectedValue" Name="CategoryId" Type="Int32"></asp:ControlParameter>
            </SelectParameters>
        </asp:SqlDataSource>
        <hr/>
    </form>
</body>
</html>
