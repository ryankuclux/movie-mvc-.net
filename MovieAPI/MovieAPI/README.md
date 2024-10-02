# PROJECT API (Backend)

## Struktur Folder
1. Models = Mempresentasikan tabel dalam basis data
2. Data = Menghubungkan model dengan table di database
3. DTO = Membawa data yang hanya diperlukan
4. Controllers = Unuk menangani permintaan HTTP (Logika Kontrol)

5. Connected Services = Mengelola layanan yang terhubung (API, database, dll)
6. Dependencies = Package / Framework yang digunakan di project (Bootstrap, entitiy framework, dll)
7. Properties = Pengaturan untuk project dan menentukan cara aplikasi dijalankan
8. appsettings.json = Pengaturan konfigurasi aplikasi (Koneksi database)
9. movieAPI.http = Menguji endpoint API yang dieksekusi langsung dari editor
10. Program.cs = Titik masuk aplikasi (Mengatur semua aspek yang diperlukan untuk menjalankan aplikasi)

### Data
1. base = Memanggil constructor dari kelas induk (DbContext)
2. options = Parameter konfigurasi untuk menentukan bagaimana MoviesDbContext berinteraksi dengan database
3. Konfigurasi = Proses pengaturan bagaimana suatu aplikasi beroperasi

### Controllers
1. [Route("api/[controller]")] = Jalur URL (Routing)
2. [ApiController] = Menandakan bahwa ini adalah controller untuk API

3. async = Menandakan bahwa metode tersebut berjalan secara asinkron
4. await = Menunggu hasil dari operasi Asynchronus tanpa menghentikan operasi lain
5. Task = Mengembalikan nilai (Jika method asynchronous mengembalikan data, gunakan Task<T>)

6. IActionResult = Memberi tahu ASP.NET Core bahwa sebuah method dalam dapat mengembalikan nilai
7. => = Lambda expression
8. Mapping = Mentransformasi objek dari satu tipe ke tipe lain

# PROJECT MVC (Frontend)

## Struktur Folder
1. Models = Mempresentasikan tabel dalam basis data
2. Services = Komunikasi dengan API (Logika bisnis)
3. Controllers = Penghubung antara pengguna dan aplikasi dan menyiapkan data untuk tampilan
4. Views = Tampilan Razor (.cshtml) yang digunakan untuk merender UI

5. Connected Services = Mengelola layanan yang terhubung (API, database, dll)
6. Dependencies = Package / Framework yang digunakan di project (Bootstrap, entitiy framework, dll)
7. Properties = Pengaturan untuk project dan menentukan cara aplikasi dijalankan
8. wwwroot = File statis (CSS, JavaScript, Images)
9. appsettings.json = Pengaturan konfigurasi aplikasi (Koneksi database)
10. Program.cs = Titik masuk aplikasi (Mengatur semua aspek yang diperlukan untuk menjalankan aplikasi)

### Services
1. response.EnsureSuccessStatusCode = Memastikan bahwa permintaan HTTP berhasil. Jika server mengembalikan 
error, program akan memunculkan error dan tidak melanjutkan eksekusi berikutnya
2. response.Content.ReadFromJsonAsync = Mengambil isi konten dalam format JSON dan konversikan ke dalam objek 
C#

### Controllers
1. ViewBag = Mengirim data dari controller ke view tanpa harus mendefinisikan tipe data
2. ?? = null-coalescing (Memberikan nilai alternatif jika variabel di sebelah kirinya bernilai null)
3. ? = null-conditional (Tipe data dapat memiliki nilai null)
4. ! = null-forgiving = (Yakin bahwa ekspresi yang diberikan tidak akan bernilai null)
5. [ValidateAntiForgeryToken] = Mencegah serangan Cross-Site Request Forgery (CSRF)
6. ModelState.IsValid = Menyimpan status dan informasi tentang model yang diterima dari form, jika semua data 
valid, maka akan bernilai true
7. return RedirectToAction(nameof(Index)) = Setelah film berhasil ditambahkan, controller akan mengarahkan
pengguna kembali ke halaman Index

8. IsNullOrWhiteSpace = Memeriksa apakah null, kosong atau spasi
9. Where = Memfilter koleksi
10. Contains = Memeriksa apakah Title mengandung teks yang ada di SearchBar
11. StringComparison.CurrentCultureIgnoreCase = Tidak memperhatikan huruf besar / kecil

### Views
1. Any = Memeriksa apakah ada item dalam koleksi
2. var isActive = "active"; = Menetapkan kelas active pada item carousel pertama
3. isActive = ""; = Mengosongkan variabel isActive agar item-item berikutnya tidak memiliki kelas active