namespace EpamSqlTask5EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Order_id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Order_id");
            DropTable("dbo.Orders");
        }
    }
}
