
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

# Yapýlacaklar
- katmanlý mimariyi oluþtur. $
- database baglantýsýný oluþtur.$
- controllerlarý olustur.$
- Data genereter sýnýfýný oluþtur.$
- Validation sýnýfýný oluþtur. &
- metotlarýn içerisindeki error handlenerlarý kontrol et, 
- AccountControllera bakýldý$
- metotlarýn içindeki validation sýnýflarýný kontrol et,
- yorumlarý yaz
- readme.md dosyasý oluþtur.


# auto mapper dosyalarýný , Business katmanýnda tutacagým