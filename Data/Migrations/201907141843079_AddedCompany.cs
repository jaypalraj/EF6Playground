namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCompany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.LeadCompanies",
                c => new
                    {
                        Lead_LeadId = c.Int(nullable: false),
                        Company_CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Lead_LeadId, t.Company_CompanyId })
                .ForeignKey("dbo.Leads", t => t.Lead_LeadId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyId, cascadeDelete: true)
                .Index(t => t.Lead_LeadId)
                .Index(t => t.Company_CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeadCompanies", "Company_CompanyId", "dbo.Companies");
            DropForeignKey("dbo.LeadCompanies", "Lead_LeadId", "dbo.Leads");
            DropIndex("dbo.LeadCompanies", new[] { "Company_CompanyId" });
            DropIndex("dbo.LeadCompanies", new[] { "Lead_LeadId" });
            DropTable("dbo.LeadCompanies");
            DropTable("dbo.Companies");
        }
    }
}
