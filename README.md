# E-Commerce Microservices

Bu proje, **.NET 8** kullanılarak mikroservis mimarisi ile geliştirilmiştir. [Frontend](https://github.com/sametkayik/ecommerce-frontend) projesiyle entegre çalışacak şekilde tasarlanmıştır. Aşağıdaki servisler bulunmaktadır:

## Mikroservisler

- **Product API** - Ürün yönetimi servisi 
- **Identity Server** - Kimlik doğrulama servisi 
- **Coupon API** - Kupon yönetimi servisi 
- **API Gateway** - Tüm servisleri yönlendiren ağ geçidi
- **Chat Service** - Gerçek zamanlı mesajlaşma servisi 
- **Cart API** - Sepet yönetim servisi
- **Web Service** - MVC arayüzü 

## Kullanılan Teknolojiler

- **.NET 8**
- **MSSQL** (Veritabanı)
- **Ocelot API Gateway** (Mikroservis yönlendirme)
- **SignalR** (Gerçek zamanlı mesajlaşma)

## Özellikler

- **Kullanıcı Girişi** (Identity Server ile kimlik doğrulama)
- **Ürün Yönetimi** (Ekleme, silme, güncelleme)
- **Kupon Kodu Uygulama** (İndirim kuponları ekleyebilme)
- **Sepete Ürün Ekleme** (Ürünleri sepete ekleme ve yönetme)
- **Gerçek Zamanlı Chat** (SignalR ile anlık mesajlaşma)

## Kurulum ve Çalıştırma

Projeyi çalıştırmak için aşağıdaki adımları takip edebilirsiniz:

### 1. Depoyu Klonlayın

```sh
git clone https://github.com/sametkayik/ecommerce-microservices
cd ecommerce-microservices
```

### 2. Servisleri Docker ile Çalıştırın

```sh
docker-compose up -d
```

Bu işlem tamamlandıktan sonra servisler çalıştırılarak tüm veritabanları oluşturulacak ve örnek veriler tablolara kaydedilecektir. Ekstra bir işlem yapmanıza gerek yoktur. Kullanılan portlara Docker üzerinden erişebilirsiniz.

---

## Teşekkür

Bu proje, **Coderspace & Definex .NET Bootcampi** kapsamında üretilmiştir. 

Bu süreçte bilgi ve tecrübelerini bizlerle paylaşan **İbrahim Gökyar** hocamıza ve bootcampi hazırlayarak bizlere fırsat tanıyan **Coderspace & DefineX** ekiplerine teşekkür ederim.

---

Herhangi bir sorunla karşılaşırsanız **sametkayik@gmail.com** adresinden iletişime geçebilirsiniz.

