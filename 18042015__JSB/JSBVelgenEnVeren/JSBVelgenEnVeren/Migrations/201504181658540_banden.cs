namespace JSBVelgenEnVeren.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banden : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Merk = c.String(),
                        Type = c.String(),
                        CategorieId = c.Int(nullable: false),
                        Prijs = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Omschrijving = c.String(),
                        Unit = c.Int(nullable: false),
                        Url = c.String(),
                        BandenId = c.Int(),
                        Hoogte = c.String(),
                        Breedte = c.String(),
                        LaadIndex = c.String(),
                        Diameter = c.Int(),
                        SnelheidsCode = c.Int(),
                        AutoId = c.Int(),
                        VelgId = c.Int(),
                        Grootte = c.String(),
                        Breedte1 = c.String(),
                        Steekmaat = c.String(),
                        Offset = c.String(),
                        Naafgat = c.String(),
                        AutoId1 = c.Int(),
                        VerenId = c.Int(),
                        AutoId2 = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.Autoes",
                c => new
                    {
                        AutoId = c.Int(nullable: false, identity: true),
                        AutoMerk = c.String(),
                        AutoModel = c.String(),
                        Bouwjaar = c.Int(nullable: false),
                        Banden_ProductId = c.Int(),
                        Velgen_ProductId = c.Int(),
                        Veren_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.AutoId)
                .ForeignKey("dbo.Products", t => t.Banden_ProductId)
                .ForeignKey("dbo.Products", t => t.Velgen_ProductId)
                .ForeignKey("dbo.Products", t => t.Veren_ProductId)
                .Index(t => t.Banden_ProductId)
                .Index(t => t.Velgen_ProductId)
                .Index(t => t.Veren_ProductId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Username = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Client_ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Clients", t => t.Client_ClientId)
                .Index(t => t.Client_ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Voornaam = c.String(nullable: false, maxLength: 100),
                        Naam = c.String(nullable: false, maxLength: 100),
                        Adres = c.String(nullable: false, maxLength: 250),
                        Huisnummer = c.String(nullable: false, maxLength: 4),
                        Postbus = c.String(maxLength: 2),
                        Stad = c.String(nullable: false, maxLength: 100),
                        PostCode = c.String(nullable: false, maxLength: 10),
                        Land = c.String(nullable: false, maxLength: 50),
                        Telefoonnummer = c.String(maxLength: 30),
                        Email = c.String(nullable: false),
                        BTW = c.String(maxLength: 20),
                        Commentaar = c.String(maxLength: 1000),
                        Particulier = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Facturaties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rapports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SiteBeheers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Autoes", "Veren_ProductId", "dbo.Products");
            DropForeignKey("dbo.Autoes", "Velgen_ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Client_ClientId", "dbo.Clients");
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Autoes", "Banden_ProductId", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "Client_ClientId" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Autoes", new[] { "Veren_ProductId" });
            DropIndex("dbo.Autoes", new[] { "Velgen_ProductId" });
            DropIndex("dbo.Autoes", new[] { "Banden_ProductId" });
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            DropTable("dbo.Stocks");
            DropTable("dbo.SiteBeheers");
            DropTable("dbo.Rapports");
            DropTable("dbo.Facturaties");
            DropTable("dbo.Carts");
            DropTable("dbo.Clients");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Categories");
            DropTable("dbo.Autoes");
            DropTable("dbo.Products");
        }
    }
}
