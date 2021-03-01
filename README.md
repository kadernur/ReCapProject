
# Araba kiralama sistemi.

![cAR](https://user-images.githubusercontent.com/63293055/107887599-3e4c0600-6f18-11eb-81c9-acd5b5b4bf31.jpg)

@ReCapProject projem  benim gelişimimle beraber gelişmekte olan güzel bir proje. :+1:
Bu projede katmanlı mimari yapısını kullanmaya çalıştım ve projeyi oluştururken SOLID prensiplerine uygun kodlar yazmaya çalıştım ve çalışmaya devam edeceğim. Bu projede "CODE RAFACTORİNG (Kodları iyileştirme) " yaparak ilerleme sağlayacağım. :collision:

### :loud_sound::boom: GÜNCELLEME(20.02.2021)
:purple_circle: Projeye Core katmanı eklendi.  
:purple_circle: DTOs klasörü eklendi.  
:purple_circle: Code refactoring yaparak IEntitiyRepository,IEntity classları Core katmanına yerleştirildi.  
:purple_circle: IEntityRepositoryBase class'ı oluşturuldu.  
:purple_circle: Car,Color ve Brand nesnelerinin Crud operasyonları eklendi.program.cs 'de test edildi.  

### :loud_sound::boom: GÜNCELLEME(22.02.2021)
:brown_circle: Projeye Result yaoıları eklendi.  
:brown_circle: Magic strings yapısı kullanıldı.  
:brown_circle: Business classında code refactoring  yapıldı. Abstract ve Concrete sınıflarındaki class'lar generic yapısıyla değiştirildi.

### :loud_sound::boom: GÜNCELLEME(01.03.2021)
:large_blue_circle: Projeye WebAPI katmanı eklendi.Bu katmanda Business katmanındaki tüm servislerin API karşılğı yazılıp postman test aracında test edildi.




## İçindekiler
 ### BUSİNESS KATMANI

Bu katmanda iş kodlarımı yazdım.
  + [Abstract:open_file_folder:  :(İlgili soyut Sınıflarımı içerir.)](https://github.com/kadernur/ReCapProject/tree/master/Business/Abstract)
     + ICarService.cs
     + :purple_circle:IColorService.cs
     + :purple_circle:IBrandService.cs
 + [ Concrete:open_file_folder: : (Somut sınıflarımı içerir.)](https://github.com/kadernur/ReCapProject/tree/master/Business/Concrete)
    + CarManager.cs
    + :purple_circle:ColorManager.cs
    + :purple_circle:BrandManager.cs

+ [:brown_circle: Constants :open_file_folder:(sabitlerimizi içeren klasör](https://github.com/kadernur/ReCapProject/tree/master/Business/Constants)    
          + Messages.cs :brown_circle: :point_right:magic string ifadelerimizi içeren classtır. Yani projede kullandığımız sabit mesajları içerir.
    
    
### :purple_circle: CORE KATMANI
Evrensel kodlarımızı kullandığımız  katmanımızdır.  
Core katmanı diğer katmanları referans almaz.
+ [ DataAceess :open_file_folder:](https://github.com/kadernur/ReCapProject/tree/master/Core/DataAccess)
     + [EntityFramework :open_file_folder:](https://github.com/kadernur/ReCapProject/tree/master/Core/DataAccess/EntityFramework)
         + EfEntityRepository.cs :point_right: Burda kodları evrensel hale getirip farklı sistemler'e implemente etmemi sağlar.
     + IEntityRepository :point_right: Data Access katmanındaki bu class'ı evrensel olabilmesi için Core katmanına taşıdım.
 + [Entities :open_file_folder:](https://github.com/kadernur/ReCapProject/tree/master/Core/Entities)  
          + IDto.cs   
          + IEntity.cs :point_right:  Entites katmanından buraya taşıdım.  
                     
 + [:brown_circle:Utilities :open_file_folder:](https://github.com/kadernur/ReCapProject/tree/master/Core/Utilities/Results) Restful(JSON) sürecinin gereksinimlerini içerir. Yani Request(istek) ve Response(yanıt) sürecini yönetebilmek için ortam hazırlar.
    + :brown_circle: Results :open_file_folder:  
      + :brown_circle:Abstract  
          + IDataResult.cs :point_right: bu interface message ,success yanında data da içermesini istenen işlemlerde kullanılır.  
          + IResult.cs :point_right: void tipinde olan veriler için success ve message bilgilerini içerir

   + :brown_circle:Concrete :poin_right:Result türleri için işlemin  başarılı ve başarısız olma durumuna göre geçerli classları içeirir.  
      + DataResult.cs
      + ErrorDataResult.cs
      + SuccessDataResult.cs
      + Result.cs
      + SuccessResult.cs
      + ErrorResult.cs
     

### DATA ACCESS KATMANI 
Veriye ulaşmak için yazdığım katman kısacası SQL kodlarımın mevcut olduğu katman

 + [Abstract:open_file_folder:  :(İlgili soyut Sınıflarımı içerir.)](https://github.com/kadernur/ReCapProject/tree/master/DataAccess/Abstract)
     + ICarDal.cs
     + IBrandDal.cs
     + IColorDal.cs
     + IEntityRepository.cs :x: :point_right:   Bu class'ım  bu klasördeki var olan diğer class'larımın kullanacağı Generic yapısını oluşturur.
     
     
 + [ Concrete  :open_file_folder: : (Somut sınıflarımı içerir.)](https://github.com/kadernur/ReCapProject/tree/master/DataAccess/Concrete)
 
     + EntityFrameWork:open_file_folder:  :point_right:  Bu klasör çalışmak istediğim veri tabanına bağlantı kurduğum ve istediğim verileri çekmemi sağlayan yapıları içeren bir klasördür. yani veri tabanı ile kendi class'larımı ilişkilendiğim classtır.
     + EfCarDal.cs
     + EfBrandDal.cs
     + EfColorDal.cs
     + ReCapDatabeseContext.cs  :point_right:  Bu class'ım veri tabanına bağlanmamı sağlayan kodları içerir ve bu klasördeki diğer class'larımın  veri tabanına erişimin sağlar.
   
+ InMemoryDal :point_right:  bu klasör veri tabanı kullanmadan bellekte olan verileri kullandığım klasördür.
   + InMemoryCarDal.cs

### ENTİTİES
 Bu katman yardımcı katmanımdır.
  + [Abstract :open_file_folder: :(İlgili soyut Sınıflarımı içerir.](https://github.com/kadernur/ReCapProject/tree/master/Entities/Abstract)
    + IEntity.cs :x:
   
 + [ Concrete:open_file_folder:  : (Somut sınıflarımı içerir.)](https://github.com/kadernur/ReCapProject/tree/master/Entities/Concrete)
  :point_right: Bu klasör ise nesnelerimi ve nesnelere ait özelliklerimin tutulduğu klasördür.
    
              + Car.cs
              + Brand.cs
              + Color.cs
              
+ [DTOs :purple_circle::open_file_folder: (Veri tabanını ilişkisel tablolarını içerir. Join işlemleri burda yapılır.)](https://github.com/kadernur/ReCapProject/tree/master/Entities/DTOs)  
      + :purple_circle: CarDetailDto.cs 
      
      
      
      
### :large_blue_circle: WebAPI  
[Sadece veri transferi için kullanılır.RestFull mimarisini destekleyen katmandır. bu katmandaki Controller gelen bütün istekleri karşılar.(RESFUL: Http protokolü:Bir kaynağa ulaşmak için izlediğimiz yol diyebiliriz.)](https://github.com/kadernur/ReCapProject/tree/master/WebAPI)

### [SQL TABLO İÇERİKLERİ](https://github.com/kadernur/ReCapProject/blob/master/SQLQuery2Recap.sql)

#### CAR TABLOSU

|CarId | BrandId | ColorId | ModelYear | DailyPrice | Description |
|------ |--------|---------|-----------|------------|------------------|
|1|1|2|2012|100|ManuelBenzin|
|2|1|3|2015|150|Otomotik Dizel|
|3|2|1|2017|200|Otomotik Hybrid|
|4|3|3|2014|125|Manuel Dizel|
|NULL|NULL|NULL|NULL|NULL|NULL|


#### BRAND TABLOSU
|BranId|BrandName|
|-------|---------|
|1|Tesla|
|2|BMw|
|3|Renault|
|NULL|NULL|


#### COLOR TABLOSU

|ColorId|ColorName|
|-------|---------|
|1|Beyaz|
|2|Siyah|
|3|Mavi|
|4|Gri|
|5||Turuncu|
|NULL|NULL|











