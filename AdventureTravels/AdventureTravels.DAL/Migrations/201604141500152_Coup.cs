namespace AdventureTravels.Contracts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Coup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketCoupons",
                c => new
                    {
                        BasketCouponID = c.Int(nullable: false, identity: true),
                        CouponId = c.Int(nullable: false),
                        BasketID = c.Guid(nullable: false),
                        CouponCode = c.String(maxLength: 10),
                        CouponType = c.String(maxLength: 100),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CouponDescription = c.String(maxLength: 150),
                        AppliesToProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BasketCouponID);

            //CreateTable(
            //    "dbo.BasketItems",
            //    c => new
            //        {
            //            BasketItemID = c.Int(nullable: false, identity: true),
            //            BasketID = c.Guid(nullable: false),
            //            ProductID = c.Int(nullable: false),
            //            Quantity = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.BasketItemID)
            //    .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
            //    .ForeignKey("dbo.Baskets", t => t.BasketID, cascadeDelete: true)
            //    .Index(t => t.BasketID)
            //    .Index(t => t.ProductID);
            
            //CreateTable(
            //    "dbo.Baskets",
            //    c => new
            //        {
            //            BasketID = c.Guid(nullable: false),
            //            OrderDate = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.BasketID);
            
            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        CouponId = c.Int(nullable: false, identity: true),
                        CouponCode = c.String(maxLength: 10),
                        CouponTypeId = c.Int(nullable: false),
                        CouponDescription = c.String(maxLength: 150),
                        AppliesToProductId = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinSpend = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MultipleUse = c.Boolean(nullable: false),
                        AssignedTo = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.CouponId);
            
            CreateTable(
                "dbo.CouponTypes",
                c => new
                    {
                        CouponTypeId = c.Int(nullable: false, identity: true),
                        CouponModule = c.String(),
                        Type = c.String(maxLength: 30),
                        Description = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.CouponTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketItems", "BasketID", "dbo.Baskets");
            DropForeignKey("dbo.BasketItems", "ProductID", "dbo.Products");
            DropIndex("dbo.BasketItems", new[] { "ProductID" });
            DropIndex("dbo.BasketItems", new[] { "BasketID" });
            DropTable("dbo.CouponTypes");
            DropTable("dbo.Coupons");
            DropTable("dbo.Baskets");
            DropTable("dbo.BasketItems");
            DropTable("dbo.BasketCoupons");
        }
    }
}
