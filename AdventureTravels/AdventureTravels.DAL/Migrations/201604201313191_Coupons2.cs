namespace AdventureTravels.Contracts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Coupons2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.BasketCoupons", "BasketID");
            AddForeignKey("dbo.BasketCoupons", "BasketID", "dbo.Baskets", "BasketID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketCoupons", "BasketID", "dbo.Baskets");
            DropIndex("dbo.BasketCoupons", new[] { "BasketID" });
        }
    }
}
