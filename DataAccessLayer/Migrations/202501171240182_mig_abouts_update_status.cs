﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_abouts_update_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "AboutStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "AboutStatus");
        }
    }
}
