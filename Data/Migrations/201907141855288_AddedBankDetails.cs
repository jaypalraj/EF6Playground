namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBankDetails : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LeadCompanies", newName: "CompanyLeads");
            DropPrimaryKey("dbo.CompanyLeads");
            CreateTable(
                "dbo.BankDetails",
                c => new
                    {
                        BankDetailId = c.Int(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.BankDetailId)
                .ForeignKey("dbo.Contracts", t => t.BankDetailId)
                .Index(t => t.BankDetailId);
            
            AddPrimaryKey("dbo.CompanyLeads", new[] { "Company_CompanyId", "Lead_LeadId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankDetails", "BankDetailId", "dbo.Contracts");
            DropIndex("dbo.BankDetails", new[] { "BankDetailId" });
            DropPrimaryKey("dbo.CompanyLeads");
            DropTable("dbo.BankDetails");
            AddPrimaryKey("dbo.CompanyLeads", new[] { "Lead_LeadId", "Company_CompanyId" });
            RenameTable(name: "dbo.CompanyLeads", newName: "LeadCompanies");
        }
    }
}
