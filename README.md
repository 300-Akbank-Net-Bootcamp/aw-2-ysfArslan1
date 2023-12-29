[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/GfoSvSyx)

1- migration olusturma 
Dbcontext in oldugu projede
    dotnet ef migrations add UniqueMigrationName -s Vb.Api/
    dotnet ef migrations add mig1 --project Vb.Data --startup-project Vb.Api

2- migration degisikliklerini db ye gecme yansitma guncelle migrate etme
Olusan migrationlarin calistirilmasi 
sln dizininde 
    dotnet ef database update --project "./Vb.Data" --startup-project "./Vb.Api"


--ortak proje yapisinda 
dotnet ef migrations add UniqueMigrationName
dotnet ef database update

# Yapılacaklar
- katmanlı mimariyi oluştur. $
- database baglantısını oluştur.$
- controllerları olustur.$
- Data genereter sınıfını oluştur.$
- Validation sınıfını oluştur. &
- metotların içerisindeki error handlenerları kontrol et, 
- AccountControllera bakıldı$
- metotların içindeki validation sınıflarını kontrol et,
- yorumları yaz
- readme.md dosyası oluştur.


# auto mapper dosyalarını , Business katmanında tutacagım