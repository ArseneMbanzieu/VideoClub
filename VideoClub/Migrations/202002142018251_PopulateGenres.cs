namespace VideoClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES (Id, Name) Values (1, 'Comedy')");
            Sql("INSERT INTO GENRES (Id, Name) Values (2, 'Family')");
            Sql("INSERT INTO GENRES (Id, Name) Values (3, 'Romance')");
            Sql("INSERT INTO GENRES (Id, Name) Values (4, 'Action')");
        }
        
        public override void Down()
        {
        }
    }
}
