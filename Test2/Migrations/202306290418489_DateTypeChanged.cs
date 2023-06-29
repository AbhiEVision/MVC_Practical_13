namespace Test2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTypeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "DOB", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "DOB", c => c.DateTime(nullable: false));
        }
    }
}
