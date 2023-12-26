using HanStoriaEntity.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace HanStoria_WebSite.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
             new Category() {Name="Çadır ve Gölgelikler", Description= "Çadır ve Gölgelik Ürünleri" },
             new Category() { Name = "Kamp Eşyaları", Description = "Kamp Eşyaları"},
             new Category() { Name = "Ekipmanlar", Description = "Kamp Ekipmanı Ürünleri"},
             new Category() { Name = "Kamp Mutfağı", Description = "Kamp Mutfağı Ürünleri"},
             new Category() { Name = "İndirimler", Description = "İndirim Ürünleri"},
            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            var urunler = new List<Product>()
            {
             new Product() {Name="3 Kişilik Kamp Çadırı - MH100 Fresh & Black",PhotoName="https://i.ibb.co/crW0Lh6/3-kisilik-kamp-cadiri-fresh.jpg", Description= "Serin ve karanlık bir ortamda uyumanız için daha fazla rahatlık sunar. Kendi kendine ayakta durabilen kubbeli yapısı ile size en uygun kamp alanını seçmek için çadırı taşıyabilirsiniz.\r\n\r\nKamp yaptığınız ilk geceniz mi? Basit ve kolay kurulabilen, Fresh&Black çadır 3 kişilik kamplarınız için tasarlandı.",Price=3250,Stock=410,IsApproved=true,CategoryId=1},
             new Product() {Name="Stanley Termos (0.47L)",PhotoName="https://i.ibb.co/JFF5SY9/stanley-termos0-47.jpg", Description= "DAYANIKLI VE GÜVENLİ: Bu Stanley termos, 18/8 yüksek kaliteli gıda sınıfı paslanmaz çelik yapısıyla sağlam ve paslanmaya dayanacak şekilde üretilmiştir.Ayrıca, BPA içermeyen malzemelerle üretilmiştir, içeceklerinizi güvenle tüketebilirsiniz. SIZDIRMAZ ",Price=900,Stock=101,IsApproved=true,CategoryId=4},
             new Product() {Name="QUECHUA Şişme Mat - 2 Kişilik", PhotoName="https://i.ibb.co/WtV00GH/sisme-mat-2-kisilik.jpg",Description= " Size iki kişilik, 120 cm boyunda, rahat ve en uygun fiyatlı kamp matını sunmak. Doğru yatak basıncı ve ürünün altına köpük mat kullanımı ürün ömrünü uzatır!",Price=900,Stock=202,IsApproved=true,CategoryId=2},
             new Product() {Name="QUECHUA Katlanır Kamp Sandalyesi",PhotoName="https://i.ibb.co/tKV5fHJ/katlanir-kamp-sandalyesi-basic-xl.jpg", Description= "Hızlı ve kolay bir şekilde katlanır. Katlı halde az yer kaplar ve çadırınızın bir köşesine sığabilir. Entegre kayışı sayesinde kolayca taşıyacaksınız.",Price=900,Stock=410,IsApproved=true,CategoryId=3},
             new Product() {Name="FORCLAZ Şarj Edilebilen Kafa Lambası",PhotoName="https://i.ibb.co/F0D1ZLY/sarj-edilebilen-kafa-lambasi-feneri.jpg", Description= "HL500 V3 kafa lambası, 300 lümene sahiptir ve darbelere ve su sıçramalarına karşı sağlamlığını korur. USB ile şarj edilebilen bataryası sayesinde artık yanınızda pil taşımanız gerekmeyecek!",Price=900,Stock=0,IsApproved=false,CategoryId=5},
            };

            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();

            var haftaninUrunleri = new List<ProductOfWeek>()
            {
             new ProductOfWeek() {ProductId=1},
             new ProductOfWeek() {ProductId=2},
             new ProductOfWeek() {ProductId=3},
             new ProductOfWeek() {ProductId=4},
            };

            foreach (var haftaninUrunu in haftaninUrunleri)
            {
                context.ProductsOfWeek.Add(haftaninUrunu);
            }
            context.SaveChanges();


            var slaytitemleri = new List<MainSlider>()
            {
                new MainSlider() {PhotoName="https://i.ibb.co/MD3CJGw/camp.jpg",Title="KAMP MALZEMELERİ VE EKİPMANLARI",Slogan=" En kaliteli ve uygun fiyatlı kamp malzemeleriyle ekipmanlarını HanStoria'da bulabilirsiniz. Çadırdan kamp eşyalarına kadar onlarca ürün sizleri bekliyor!",ButtonContent1="Incele",ButtonContent2="Kamp Ekipmanlarını Incele"},
                new MainSlider() {PhotoName="https://i.ibb.co/ZYyKvCh/camp2.jpg",Title="MACERANIZA BİZİMLE KATILIN",Slogan="Macera Tutkunlarına Özel Kampanya! HanStoria'daki geniş ürün yelpazesi ile maceranın keyfini çıkarın!",ButtonContent1="Ekipmanlar",ButtonContent2="Indirim"},
            };

            foreach (var slaytitemi in slaytitemleri)
            {
                context.MainSliders.Add(slaytitemi);
            };
            context.SaveChanges();

            base.Seed(context); 
        }
    }
}


