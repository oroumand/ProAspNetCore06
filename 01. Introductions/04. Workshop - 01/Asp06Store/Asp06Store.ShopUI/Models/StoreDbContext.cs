using Microsoft.EntityFrameworkCore;

namespace Asp06Store.ShopUI.Models
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public StoreDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id=1,
                    Category="Mobile",
                    Name= "Apple iPhone 13",
                    Description= "One small reduction of the notch, one giant leap for the iPhone! That's the best description for the most minor iPhone upgrade yet - the Apple iPhone 13.",
                    Price = 30_000_000
                },
                new Product
                {
                    Id = 2,
                    Category = "Mobile",
                    Name = "Samsung Galaxy F42 5G",
                    Description = "Glass front, plastic frame, plastic back 1080 x 2408 pixels, 20:9 ratio (~400 ppi density)",
                    Price = 25_000_000
                },
                new Product
                {
                    Id = 3,
                    Category = "Mobile",
                    Name = "Xiaomi Poco C31",
                    Description = "2021, September 30 6.53 inches, 102.9 cm2 (~81.0% screen-to-body ratio) Octa-core (4x2.3 GHz Cortex-A53 & 4x1.8 GHz Cortex-A53)",
                    Price = 8_000_000
                },
                new Product
                {
                        Id = 4,
                        Category = "Mobile",
                        Name = "Xiaomi Redmi Note 10 Lite",
                        Description = "Qualcomm SM7125 Snapdragon 720G (8 nm)  Wi-Fi 802.11 a/b/g/n/ac, dual-band, Wi-Fi Direct, hotspot",
                        Price =10_000_000
                },
                  new Product
                  {
                      Id = 5,
                      Category = "Laptop",
                      Name = "ASUS Zenbook 14X OLED",
                      Description = "Life is brighter and clearer with Zenbook 14X OLED, the slim, light and compact laptop with a gorgeous 16:10 4K OLED HDR NanoEdge touchscreen that gives you the deepest blacks and the most vivid colours.",
                      Price = 45_000_000
                  },
                new Product
                {
                    Id = 6,
                    Category = "Laptop",
                    Name = "ASUS ExpertBook B7",
                    Description = "ASUS ExpertBook B7 Flip is an enterprise-level, 5G-enabled premium laptop that’s designed to accelerate your business1. Working on the go is easier than ever with a lightning-fast data",
                    Price = 33_000_000
                },
                new Product
                {
                    Id = 7,
                    Category = "Laptop",
                    Name = "ProArt Studiobook 16",
                    Description = "Turn your creative vision into reality with the ProArt Studiobook 16 studio laptop: it pushes every boundary to give you the effortless creative experience you’ve always wanted, but never thought possible. With a certified color-accurate 16-inch 120 Hz 2.5K IPS",
                    Price = 53_000_000
                },
                new Product
                {
                    Id = 8,
                    Category = "PC",
                    Name = "ASUS ProArt Display PA278CV",
                    Description = "Professional Monitor – 27-inch, IPS, WQHD (2560 x 1440), 100% sRGB, 100% Rec. 709, Color Accuracy ΔE < 2, Calman Verified, USB-C, DisplayPort Daisy-chaining, ProArt Preset, ProArt Palette, Ergonomic Stand",
                    Price = 38_000_000
                },
                new Product
                {
                    Id = 9,
                    Category = "PC",
                    Name = "Sleek and ultra-portable with a Zen-inspired design",
                    Description = "With a slim 8.5 mm (0.3-inch) profile and tipping the scales at just 800g (1.76 pounds), the MB169B+ is the world’s slimmest and lightest companion display, ideal for a simple on-the-go dual-monitor setup and mobile presentations.",
                    Price = 19_000_000
                },
                new Product
                {
                    Id = 10,
                    Category = "PC",
                    Name = "Ultracompact mini PC ",
                    Description = "ASUS Mini PC PN62 is an ultracompact computer that delivers powerful performance for a wide variety of home and business applications. Featuring the latest 10th Generation Intel® Core™ processors and support for high-speed 2666 MHz DDR4 memory, Mini PC PN62 is ready to take on demanding workloads, yet its diminutive size takes up",
                    Price = 12_000_000
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
