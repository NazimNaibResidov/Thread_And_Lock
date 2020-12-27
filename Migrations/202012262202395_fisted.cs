namespace MonyTansfer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class fisted : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    AccoundNumber = c.String(),
                    Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    IsActive = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Logs",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FromAcound = c.String(),
                    ToAcound = c.String(),
                    TransferAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    TransferDate = c.DateTime(nullable: false),
                    isSuccessFul = c.Boolean(nullable: false),
                    FailedReason = c.String(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Logs");
            DropTable("dbo.Accounts");
        }
    }
}
