namespace VideoClub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE  MembershipTypes Set Name = 'Pay As You Go' where Id = 1");
            Sql("UPDATE  MembershipTypes Set Name = 'Monthly' where Id = 2");
            Sql("UPDATE  MembershipTypes Set Name = 'Trimestrial' where Id = 3");
            Sql("UPDATE  MembershipTypes Set Name = 'Yearly' where Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
