namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetGenreType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Genre SET Type = 'Action' WHERE Id = 1");
            Sql("UPDATE Genre SET Type = 'Comedy' WHERE Id = 2");
            Sql("UPDATE Genre SET Type = 'Crime' WHERE Id = 3");
            Sql("UPDATE Genre SET Type = 'Fiction' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
