namespace CargoServices_Kunal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        DriverID = c.Int(nullable: false),
                        VehicleID = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverID, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.DriverID)
                .Index(t => t.VehicleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "VehicleID", "dbo.Vehicles");
            DropForeignKey("dbo.Jobs", "DriverID", "dbo.Drivers");
            DropForeignKey("dbo.Jobs", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Jobs", new[] { "VehicleID" });
            DropIndex("dbo.Jobs", new[] { "DriverID" });
            DropIndex("dbo.Jobs", new[] { "CustomerID" });
            DropTable("dbo.Jobs");
        }
    }
}
