
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

# Yap�lacaklar
- katmanl� mimariyi olu�tur. $
- database baglant�s�n� olu�tur.$
- controllerlar� olustur.$
- Data genereter s�n�f�n� olu�tur.$
- Validation s�n�f�n� olu�tur. &
- metotlar�n i�erisindeki error handlenerlar� kontrol et, 
- AccountControllera bak�ld�$
- metotlar�n i�indeki validation s�n�flar�n� kontrol et,
- yorumlar� yaz
- readme.md dosyas� olu�tur.


# auto mapper dosyalar�n� , Business katman�nda tutacag�m