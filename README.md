# Medicine API 
- LoginController'ında jwt ile logın işlemi bulunmaktaktadır. 
- Buradan bir token oluşturup bu token ile "ActiveSubstanceController", "MedicineController" ve "StorageController"da bulunan işlemleri gerçekleştirebiliriz.
- Bu controllerda GetAll, GetId, Add, Delete, ve update işlemleri bulunmaktadır. 
- Öncelikle ActiveSubstanceController'dan etken maddeleri ve StarageControllerdan deopları eklememiz gerekiyor.
- MedicineController da ise ilac oluşturmamız gerekiyor.

　

```javascript

"Medicine":{
     "Name":"Ilac8",
     "Code":"fgdsf",
     "Type":"Krem",
     "ExpireDate":"2012-04-23T18:25:43.511Z",
     "StorageId":2
     }, 
"Substance":[1,2]
   
    
  ```


Bu şeklide ekleme işlemini yapıyoruz.(StorageId boş geçilebilir. Fakat Substance boş geçilemez. Aynı Code dan ilaç eklenmez. )

- Bu controllerda aynı zamanda ilacın ismine göre cağırma işlemi de bulunuyor.
- StorageController da bulunan rest/v1/depo/{code} endpoint ile depoda bulunan bütün ilaçlar getirebilir.

`rest/v1/depo/{storageCode}/ilac/{medicineCode}` endpointi ile istenen ilaca ulaşabiliriz.

```javascript
    "kod": "code1",
    "adi": "Ilac2",
    "turu": "Krem",
    "skt": "23.Nisan.2012",
    "etkenler": [
        {
            "etkenadi": "parasetamol"
        },
        {
            "etkenadi": "ksitol"
        }
    ]
 ```
Bu şekilde bir sonuç alıyoruz.

- Guvenlik için Authentication.JwtBearer 3.1.12 kullanıldı.
- ORM aracı olarak EntityFrameworkCore kullandım.
- API ve ClassLibrary için .Net Core 3.1 sürümü kullanıldı.
- Database olarak MSSql kullanıldı.
