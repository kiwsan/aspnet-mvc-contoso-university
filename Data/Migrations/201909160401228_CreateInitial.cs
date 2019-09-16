namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_person",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        first_name = c.String(maxLength: 50),
                        last_name = c.String(maxLength: 50),
                        birth_date = c.DateTime(nullable: false),
                        created_date = c.DateTime(nullable: false),
                        row_version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tb_person");
        }
    }
}
