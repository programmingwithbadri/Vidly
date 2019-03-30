namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetGenreType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genre (Id, Type) VALUES (1, 'Thriller')");
            Sql("INSERT INTO Genre (Id, Type) VALUES (2, 'Family')");
            Sql("INSERT INTO Genre (Id, Type) VALUES (3, 'Romance')");
            Sql("INSERT INTO Genre (Id, Type) VALUES (4, 'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
