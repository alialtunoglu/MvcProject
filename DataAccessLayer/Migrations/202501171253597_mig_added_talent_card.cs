﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_added_talent_card : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Talents",
                c => new
                    {
                        TalentId = c.Int(nullable: false, identity: true),
                        TalentName = c.String(),
                        Range = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.TalentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Talents");
        }
    }
}
