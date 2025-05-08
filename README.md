# Employee Management System

Bu proje, bir şirketin çalışan ve departman yönetimini sağlamak için geliştirilmiş web tabanlı bir uygulamadır.  
Frontend kısmı jQuery + Bootstrap ile, backend kısmı .NET Core + Entity Framework ile geliştirilmiştir.  
JWT tabanlı kimlik doğrulama içerir.

---

## Özellikler

- JWT ile login sistemi
- Departmanlar: listeleme, ekleme, düzenleme, silme
- Çalışanlar: listeleme, ekleme, düzenleme, silme
- Bootstrap modal üzerinden form yönetimi
- localStorage ile token saklama
- API isteklerinde `Authorization: Bearer <token>` header'ı gönderilir
- Giriş yapılmadan sayfalara erişim engellenir
- Navbar ile sayfalar arası geçiş ve çıkış (logout) işlemi yapılabilir

---

## Teknolojiler

| Katman     | Teknoloji                         |
|------------|-----------------------------------|
| Frontend   | HTML, CSS, jQuery, Bootstrap      |
| Backend    | ASP.NET Core Web API     |
| ORM        | Entity Framework Core             |
| Veritabanı | MSSQL (Docker ile yerel kurulum)  |
| Auth       | JSON Web Token (JWT)              |

---

## Test Kullanıcısı

- **Kullanıcı adı:** `admin`
- **Şifre:** `1234`

Başarılı giriş sonrası JWT token alınır ve localStorage’a kaydedilir.

---

## Proje Yapısı

employee-management-system/
├── EmployeeManagementApi/ → .NET Web API
│ ├── Controllers/
│ ├── Models/
│ ├── Requests/
│ ├── Responses/
│ ├── Program.cs
│ └── ...
├── web/ → jQuery + Bootstrap frontend
│ ├── login.html
│ ├── employees.html
│ ├── departments.html
│ ├── navbar.html
├── README.md


---

## Kurulum Talimatları

### Backend (.NET Core)

1. Terminal veya Rider/VS Code terminalini aç

2. Proje dizinine gir: cd EmployeeManagementApi

3. NuGet bağımlılıklarını yükle: dotnet restore

4. Veritabanını oluştur (migration sonrası): dotnet ef database update

5. Uygulamayı çalıştır: dotnet run

6. Swagger arayüzüne git: http://localhost:5079/swagger

appsettings.json içindeki bağlantı bilgileri MSSQL Docker container'ına göre ayarlanmıştır. İçindeki MSSQL bağlantı adresi sizin ortamınıza göre düzenlenmelidir.

Frontend (HTML)
1. web/ klasörüne gir

2. login.html dosyasını tarayıcıda aç

3. Giriş yaptıktan sonra token alınır ve employees.html ile departments.html ekranlarına erişim sağlanır. Token tarayıcıda localStorage'da saklanır ve tüm isteklerde Authorization: Bearer ... header’ı olarak gönderilir.