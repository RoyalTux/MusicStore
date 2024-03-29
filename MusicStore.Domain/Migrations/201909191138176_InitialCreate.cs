namespace MusicStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MusicTracks",
                c => new
                    {
                        MusicTrackId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Genre = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MusicTrackId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MusicTracks");
        }
    }
}
