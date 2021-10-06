namespace CargoServices_Kunal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        FromAddress = c.String(),
                        ToAddress = c.String(),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VehicleNo = c.String(),
                        VehicleTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeID, cascadeDelete: true)
                .Index(t => t.VehicleTypeID);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "VehicleTypeID", "dbo.VehicleTypes");
            DropForeignKey("dbo.Bookings", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Vehicles", new[] { "VehicleTypeID" });
            DropIndex("dbo.Bookings", new[] { "CustomerID" });
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Drivers");
            DropTable("dbo.Customers");
            DropTable("dbo.Bookings");
        }
    }
}
