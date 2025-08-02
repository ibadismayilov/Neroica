# Neorica

Neorica, istifadəçilərə yüklədikləri şəkillərin internetdəki oxşarlarını linkləri ilə birlikdə tapmaq imkanı verən, eyni zamanda təhlükəsiz üz tanıma əsaslı giriş təmin edən qabaqcıl bir masaüstü tətbiqidir.

---

## 🚀 Layihənin Məqsədi

"Neorica"nın əsas məqsədi vizual məlumat axtarışını asanlaşdırmaq və təhlükəsiz istifadəçi təcrübəsi yaratmaqdır. Bu platforma, istifadəçilərin məlumatlarının təhlükəsizliyini artırarkən, qeydiyyat və giriş prosesini innovativ üsullarla təmin edir.

---

## ✨ Əsas Xüsusiyyətlər

- **Qabaqcıl Şəkil Axtarışı:** Yüklənmiş şəkillərin internetdəki oxşarlarını sürətli şəkildə tapır və nəticələri müvafiq linklərlə təqdim edir.  
- **Üz Tanıma ilə Giriş/Qeydiyyat:** İstifadəçilər üz tanıma texnologiyasından istifadə edərək tətbiqə təhlükəsiz və sürətli şəkildə daxil ola və ya qeydiyyatdan keçə bilərlər.  
- **Təhlükəsiz Email Doğrulama (OTP):** Qeydiyyat və email dəyişikliyi zamanı istifadəçinin email ünvanına birdəfəlik şifrə (OTP) göndərilir.  
- **Hesab Məlumatlarının İdarə Edilməsi:** İstifadəçilər öz istifadəçi adlarını, email ünvanlarını və şifrələrini asanlıqla yeniləyə bilərlər.  
- **Şifrə Hashing:** İstifadəçi şifrələri verilənlər bazasında təhlükəsiz şəkildə hash edilmiş formada saxlanılır.  
- **Axtarış Tarixçəsi:** İstifadəçilərin əvvəlki şəkil axtarışları saxlanılır.

---

## 🛠️ İstifadə Olunan Texnologiyalar

- **C#:** Tətbiqin əsas proqramlaşdırma dili.  
- **Windows Forms:** Masaüstü qrafik istifadəçi interfeysi (GUI) üçün.  
- **Entity Framework:** Verilənlər bazası ilə obyekt-obyekt əlaqəsi (ORM) üçün.  
- **Emgu CV:** OpenCV kitabxanasının .NET üçün sargısı, üz aşkar etmə və kamera ilə işləmək üçün.  
- **AWS Rekognition:** Bulud əsaslı üz tanıma və indeksləmə xidməti.  
- **SerpAPI:** Google Reverse Image Search API-yə çıxış üçün.  
- **ImgBB:** Şəkilləri müvəqqəti olaraq yükləmək və axtarış API-lərinə ötürmək üçün şəkil hosting xidməti.  
- **SMTP:** Email vasitəsilə OTP kodları göndərmək üçün.

---

## ⚙️ Quraşdırma və Başlatma

1. **Repo-nu Klonlayın:**

   ```bash
   git clone https://github.com/ibadismayilov/Neroica.git
   cd Neorica
Visual Studio-da Açın:

Layihəni Visual Studio (2019 və ya daha yeni versiya) ilə açın.

Verilənlər Bazasını Konfiqurasiya Edin:

AppDbContext sinfinizdə verilənlər bazası bağlantı sətrini düzgün quraşdırın.

Migrations (Miqrasiyalar) Tətbiq Edin:

Visual Studio-da "Tools" → "NuGet Package Manager" → "Package Manager Console" açın və:

Add-Migration InitialCreate
Update-Database
API Açarlarını və SMTP Məlumatlarını Konfiqurasiya Edin:

App.config faylını açın və aşağıdakı appSettings dəyərlərini öz açar və məlumatlarınızla doldurun:

xml
Kopyala
Düzenle
<appSettings>
    <!-- AWS Rekognition üçün -->
    <add key="AwsAccessKeyId" value="SİZİN_AWS_ACCESS_KEY_ID" />
    <add key="AwsSecretAccessKey" value="SİZİN_AWS_SECRET_ACCESS_KEY" />
    <add key="AwsRegion" value="us-east-1" />

    <!-- SerpAPI üçün -->
    <add key="SerpApiKey" value="SİZİN_SERPAPI_KEY" />

    <!-- ImgBB üçün -->
    <add key="ImgbbApiKey" value="SİZİN_IMGBB_KEY" />

    <!-- Email göndərmək üçün -->
    <add key="SmtpHost" value="smtp.gmail.com" />
    <add key="SmtpPort" value="587" />
    <add key="SmtpUsername" value="sizin_email@example.com" />
    <add key="SmtpPassword" value="sizin_email_tətbiq_parolunuz" />
    <add key="EnableSsl" value="true" />
</appSettings>

🚀 İstifadə
Tətbiqi başladın: Visual Studioda yer alan işə sal düyməsinə click edərək tətbiqi işə salın.

Qeydiyyat və giriş üçün üz tanıma və ya ənənəvi metodlardan istifadə edin.

Şəkil axtarışı edin və nəticələri görün.

Hesab məlumatlarını istəyə uyğun yeniləyin.

🔮 Gələcək İnkişaflar
Daha Ətraflı Şəkil Analizi

İki Faktorlu Autentifikasiya (2FA)

Şifrə Sıfırlama Funksiyası

Admin Paneli

Buludda Profil Şəkillərinin Saxlanılması

🤝 Qatqı
Layihəyə qatqı vermək istəyirsinizsə, zəhmət olmasa repozitoriyanı fork edin, dəyişikliklərinizi edin və pull request göndərin.

📄 Lisenziya
...

📧 Əlaqə
Email: ibadismayil635@gmail.com

LinkedIn: https://www.linkedin.com/in/ibad-ismayılov-90a669317/

GitHub: https://github.com/ibadismayilov
