[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/GfoSvSyx)

# Akbank .Net Bootcamp Ödevi
Akbank ve patikadev tarafından gerçekleştirilen Asp.Net eğitimi sürecinde verilen ikinci ödevde, canlı dersimiz esnasında oluşturulan modeller için Controller'ların GET, GETbyId, PUT, POST, DELETE method'larının hazırlanması istendi.

[Akbank .Net Bootcamp Ödev 1](https://github.com/300-Akbank-Net-Bootcamp/aw-1-ysfArslan1)

## Controller oluşturulması :
Canlı ders sırasında oluşturulan sınıfların controller'ları başarıyla oluşturuldu ve istenilen metotlar eklendi.

![Resim Açıklaması](images/c1.jpeg)
![Resim Açıklaması](images/c2.jpeg)
![Resim Açıklaması](images/s1.jpeg)

## Proje Yapısı ve Kod Blokları:
- Proje, farklı katmanlardan oluşmaktadır: 
Api katmanı web API dosyalarını içerir, Base katmanı temel dosyaları barındırır, Business katmanı ise şu an kullanılmıyor olsa da validasyon ve automapping işlemlerinin gerçekleşeceği katmandır. Veritabanı bağlantısının yapıldığı ve ilgili dosyaların bulunduğu katman ise Data katmanıdır.

- Projede veri tabanı olarak Microsoft SQL Server kullanıldı. Migration eklemek için kullanılan komut:
    ```
        dotnet ef migrations add mig1 --project Vb.Data --startup-project Vb.Api
    ```
-  Eklenen Migration'ların uygulanması için kullanılan komut ise şu şekildedir:
    ```
           dotnet ef database update --project "./Vb.Data" --startup-project "./Vb.Api"
    ```

    ![Resim Açıklaması](images/k1.jpeg)