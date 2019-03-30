namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreToMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Genre",
                    c => new
                    {
                        Id = c.Int(nullable: false),
                        Type = c.String(nullable: false)
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.Movie",
                    c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        GenreId = c.Int(nullable: false)
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Movie", "GenreId");
            AddForeignKey("dbo.Movie", "GenreId", "dbo.Genre", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Movie", "GenreId", "dbo.Genre");
            DropIndex("dbo.Movie", new[] { "GenreId" });
            DropTable("dbo.Movie");
            DropTable("dbo.Genre");
        }
    }
}
