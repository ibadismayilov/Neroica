Neorica
Neorica, istifadəçilərə yüklədikləri şəkillərin internetdəki oxşarlarını linkləri ilə birlikdə tapmaq imkanı verən, eyni zamanda təhlükəsiz üz tanıma əsaslı giriş təmin edən qabaqcıl bir masaüstü tətbiqidir.

🚀 Layihənin Məqsədi
"Neorica"nın əsas məqsədi vizual məlumat axtarışını asanlaşdırmaq və təhlükəsiz istifadəçi təcrübəsi yaratmaqdır. Bu platforma, istifadəçilərin məlumatlarının təhlükəsizliyini artırarkən, qeydiyyat və giriş prosesini innovativ üsullarla təmin edir.

✨ Əsas Xüsusiyyətlər
Qabaqcıl Şəkil Axtarışı: Yüklənmiş şəkillərin internetdəki oxşarlarını sürətli şəkildə tapır və nəticələri müvafiq linklərlə təqdim edir.

Üz Tanıma ilə Giriş/Qeydiyyat: İstifadəçilər üz tanıma texnologiyasından istifadə edərək tətbiqə təhlükəsiz və sürətli şəkildə daxil ola və ya qeydiyyatdan keçə bilərlər.

Təhlükəsiz Email Doğrulama (OTP): Qeydiyyat və email dəyişikliyi zamanı istifadəçinin email ünvanına birdəfəlik şifrə (OTP) göndərilir.

Hesab Məlumatlarının İdarə Edilməsi: İstifadəçilər öz istifadəçi adlarını, email ünvanlarını və şifrələrini asanlıqla yeniləyə bilərlər.

Şifrə Hashing: İstifadəçi şifrələri verilənlər bazasında təhlükəsiz şəkildə hash edilmiş formada saxlanılır.

Axtarış Tarixçəsi: İstifadəçilərin əvvəlki şəkil axtarışları saxlanılır.

🛠️ İstifadə Olunan Texnologiyalar
C#: Tətbiqin əsas proqramlaşdırma dili.

Windows Forms: Masaüstü qrafik istifadəçi interfeysi (GUI) üçün.

Entity Framework: Verilənlər bazası ilə obyekt-obyekt əlaqəsi (ORM) üçün.

Emgu CV: OpenCV kitabxanasının .NET üçün sargısı, üz aşkar etmə və kamera ilə işləmək üçün.

AWS Rekognition: Bulud əsaslı üz tanıma və indeksləmə xidməti.

SerpAPI: Google Reverse Image Search API-yə çıxış üçün.

ImgBB: Şəkilləri müvəqqəti olaraq yükləmək və axtarış API-lərinə ötürmək üçün şəkil hosting xidməti.

SMTP: Email vasitəsilə OTP kodları göndərmək üçün.

⚙️ Quraşdırma və Başlatma
Layihəni yerli sisteminizdə işə salmaq üçün aşağıdakı addımları izləyin:

Repo-nu Klonlayın:

git clone https://github.com/SizinGitHubHesabınız/Neorica.git
cd Neorica

Visual Studio-da Açın:

Layihəni Visual Studio (2019 və ya daha yeni versiya) ilə açın.

NuGet Paketlərini Bərpa Edin:

Visual Studio-da Solution Explorer-də Solution-a sağ klik edin və "Restore NuGet Packages" seçin.

Verilənlər Bazasını Konfiqurasiya Edin:

AppDbContext sinfinizdə verilənlər bazası bağlantı sətrini düzgün quraşdırın.

Migrations (Miqrasiyalar) Tətbiq Edin:

Visual Studio-da "Tools" -> "NuGet Package Manager" -> "Package Manager Console" açın.

Aşağıdakı əmrləri ardıcıl icra edin:

Add-Migration InitialCreate # (və ya sonuncu miqrasiya adınız)
Update-Database

API Açarlarını və SMTP Məlumatlarını Konfiqurasiya Edin:

App.config faylını açın.

Aşağıdakı appSettings dəyərlərini öz API açarlarınız və SMTP məlumatlarınızla doldurun:

<appSettings>
    <!-- AWS Rekognition üçün -->
    <add key="AwsAccessKeyId" value="SİZİN_AWS_ACCESS_KEY_ID" />
    <add key="AwsSecretAccessKey" value="SİZİN_AWS_SECRET_ACCESS_KEY" />
    <add key="AwsRegion" value="us-east-1" /> <!-- İstifadə etdiyiniz region -->

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

Qeyd: SmtpPassword üçün Gmail istifadə edirsinizsə, "Tətbiq Parolu" (App Password) yaratmalısınız.

Emgu CV Native DLL-lərini Əlavə Edin:

Proyektinizin "Platform target"i x86 olduğu üçün, Emgu CV quraşdırma qovluğunuzdan (C:\Emgu\emgucv-XXX\bin\x86) bütün opencv_*.dll və cvextern.dll fayllarını proyektinizin bin\Debug (və ya bin\Release) qovluğuna kopyalayın.

Həmçinin, haarcascade_frontalface_default.xml faylının da bin\Debug (və ya bin\Release) qovluğunda olduğundan əmin olun.

Tətbiqi Build Edin:

Visual Studio-da "Build" -> "Build Solution" seçin.

İcra edilə bilən fayl (.exe) proyekt qovluğunuzun bin\Debug (və ya bin\Release) qovluğunda yerləşəcək.

🚀 İstifadə
Tətbiqi Başlatın: Neorica.exe faylını işə salın.

Qeydiyyat:

Üz tanıma ilə qeydiyyatdan keçin və ya ənənəvi məlumatları daxil edin.

Email doğrulama kodunu daxil edərək qeydiyyatı tamamlayın.

Giriş:

Qeydiyyatdan keçdiyiniz üzünüzlə daxil olun və ya istifadəçi adı/email və şifrə ilə giriş edin.

Şəkil Axtarışı:

Tətbiqin əsas interfeysində şəkil yükləyin və oxşar şəkilləri axtarın.

Hesab Məlumatlarını Yeniləyin:

Hesab səhifənizdə istifadəçi adınızı, emailinizi və ya şifrənizi dəyişdirə bilərsiniz. Email dəyişikliyi zamanı OTP doğrulama tələb olunacaq.

🔮 Gələcək İnkişaflar
Daha Ətraflı Şəkil Analizi: Şəkildəki obyektlərin, səhnələrin və ya mətnin tanınması.

İki Faktorlu Autentifikasiya (2FA): SMS və ya autentifikator proqramları vasitəsilə əlavə 2FA seçimləri.

Şifrə Sıfırlama Funksiyası: Unudulmuş şifrələri təhlükəsiz şəkildə sıfırlamaq imkanı.

Admin Paneli: İstifadəçi hesablarını idarə etmək üçün veb əsaslı və ya masaüstü admin paneli.

Buludda Profil Şəkillərinin Saxlanılması: İstifadəçilərin üz şəkillərini AWS S3 kimi bulud xidmətlərində saxlamaq.

🤝 Qatqı
Layihəyə qatqı vermək istəyirsinizsə, zəhmət olmasa repozitoriyanı fork edin, dəyişikliklərinizi edin və pull request göndərin.

📄 Lisenziya
[Layihənizin lisenziyası burada qeyd oluna bilər, məsələn MIT Lisenziyası]

📧 Əlaqə
Hər hansı bir sualınız və ya təklifiniz varsa, zəhmət olmasa əlaqə saxlayın:

Email: [Sizin Email Ünvanınız]

LinkedIn: [Sizin LinkedIn Profiliniz]

GitHub: [Sizin GitHub Profiliniz]
