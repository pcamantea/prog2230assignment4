namespace AdventureTravels.Contracts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Customers",
            //    c => new
            //        {
            //            CustomerId = c.Int(nullable: false, identity: true),
            //            CustomerName = c.String(),
            //            PictureUrl = c.String(),
            //            Address1 = c.String(),
            //            Address2 = c.String(),
            //            Town = c.String(),
            //            PostalCode = c.String(),
            //            HomePhone = c.String(),
            //            BusinessPhone = c.String(),
            //            EmailAddress = c.String(),
            //        })
            //    .PrimaryKey(t => t.CustomerId);
            
            //CreateTable(
            //    "dbo.OrderItems",
            //    c => new
            //        {
            //            OrderItemId = c.Int(nullable: false, identity: true),
            //            ProductId = c.Int(nullable: false),
            //            Quantity = c.Int(nullable: false),
            //            Price = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Order_OrderId = c.Int(),
            //        })
            //    .PrimaryKey(t => t.OrderItemId)
            //    .ForeignKey("dbo.Orders", t => t.Order_OrderId)
            //    .Index(t => t.Order_OrderId);
            
            //CreateTable(
            //    "dbo.Orders",
            //    c => new
            //        {
            //            OrderId = c.Int(nullable: false, identity: true),
            //            OrderDate = c.DateTime(nullable: false),
            //            CustomerId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.OrderId);
            
            //CreateTable(
            //    "dbo.Products",
            //    c => new
            //        {
            //            ProductId = c.Int(nullable: false, identity: true),
            //            Description = c.String(),
            //            ImageUrl = c.String(),
            //            Price = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
            //        })
            //    .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.OrderItems", "Order_OrderId", "dbo.Orders");
            //DropIndex("dbo.OrderItems", new[] { "Order_OrderId" });
            //DropTable("dbo.Products");
            //DropTable("dbo.Orders");
            //DropTable("dbo.OrderItems");
            //DropTable("dbo.Customers");
        }
    }
}
