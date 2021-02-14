
# Araba kiralama sistemi.

![cAR](https://user-images.githubusercontent.com/63293055/107887599-3e4c0600-6f18-11eb-81c9-acd5b5b4bf31.jpg)

@ReCapProject projem  benim gelişimimle beraber gelişmekte olan güzel bir proje. :+1:
Bu projede katmanlı mimari yapısını kullanmaya çalıştım ve projeyi oluştururken SOLID prensiplerine uygun kodlar yazmaya çalıştım ve çalışmaya devam edeceğim. :collision:

## İçindekiler
 ### BUSİNESS KATMANI

Bu katmanda iş kodlarımı yazdım.
  + [Abstract:open_file_folder:  :(İlgili soyut Sınıflarımı içerir.)](https://github.com/kadernur/ReCapProject/tree/master/Business/Abstract)
     + ICarService.cs
 + [ Concrete:open_file_folder: : (Somut sınıflarımı içerir.)](https://github.com/kadernur/ReCapProject/tree/master/Business/Concrete)
    + CarManager.cs

### DATA ACCESS KATMANI 
Veriye ulaşmak için yazdığım katman kısacası SQL kodlarımın mevcut olduğu katman

 + [Abstract:open_file_folder:  :(İlgili soyut Sınıflarımı içerir.)](https://github.com/kadernur/ReCapProject/tree/master/DataAccess/Abstract)
     + ICarDal.cs
     + IBrandDal.cs
      + IColorDal.cs
     + IEntityRepository.cs  :point_right:   Bu class'ım  bu klasördeki var olan diğer class'larımın kullanacağı Generic yapısını oluşturur.
     
     
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
    + IEntity.cs
   
 + [ Concrete:open_file_folder:  : (Somut sınıflarımı içerir.)](https://github.com/kadernur/ReCapProject/tree/master/Entities/Concrete)
  :point_right: Bu klasör ise nesnelerimi ve nesnelere ait özelliklerimin tutulduğu klasördür.
    
              + Car.cs
              + Brand.cs
              + Color.cs


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
|NULL|NULL|











