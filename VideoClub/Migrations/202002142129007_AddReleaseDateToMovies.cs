namespace VideoClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReleaseDateToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleasDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "ReleasDate");
        }
    }
}
