namespace VideoClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddedDateToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AddedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AddedDate");
        }
    }
}
