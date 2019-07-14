namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ContractId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Lead_LeadId = c.Int(),
                    })
                .PrimaryKey(t => t.ContractId)
                .ForeignKey("dbo.Leads", t => t.Lead_LeadId)
                .Index(t => t.Lead_LeadId);
            
            CreateTable(
                "dbo.Leads",
                c => new
                    {
                        LeadId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.LeadId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "Lead_LeadId", "dbo.Leads");
            DropIndex("dbo.Contracts", new[] { "Lead_LeadId" });
            DropTable("dbo.Leads");
            DropTable("dbo.Contracts");
        }
    }
}
