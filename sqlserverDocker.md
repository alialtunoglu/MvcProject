Tabii! İşte Docker üzerinde SQL Server'ı çalıştırma ve Azure Data Studio veya SSMS ile bağlanma işleminin adım adım notları:

---

### SQL Server Docker Konteyneri Oluşturma ve Başlatma

1. **Docker Komutu ile SQL Server Konteynerini Başlatma:**
   SQL Server Docker imajını indirip bir konteyner oluşturmak için aşağıdaki komutu çalıştırın:

   ```bash
   docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=password' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
   ```

   Bu komutun açıklamaları:
   - `-e 'ACCEPT_EULA=Y'`: SQL Server'ın son kullanıcı lisans sözleşmesini kabul eder.
   - `-e 'SA_PASSWORD=password'`: `sa` kullanıcısı için belirlenen paroladır.
   - `-p 1433:1433`: SQL Server için 1433 portunu açar (SQL Server'ın varsayılan portu).
   - `--name sqlserver`: Konteynerin adını `sqlserver` olarak belirler.
   - `-d`: Konteyneri arka planda çalıştırır.
   - `mcr.microsoft.com/mssql/server:2022-latest`: SQL Server 2022 Docker imajını kullanır.

2. **Konteynerin Çalışıp Çalışmadığını Kontrol Etme:**
   Konteynerin düzgün çalışıp çalışmadığını kontrol etmek için aşağıdaki komutu kullanabilirsiniz:

   ```bash
   docker ps
   ```

   Bu komut aktif konteynerleri listeleyecektir.

---

### Azure Data Studio veya SSMS ile Bağlantı Kurma

1. **Azure Data Studio veya SSMS'i Başlatın.**
   
2. **Bağlantı Ekranına Aşağıdaki Bilgileri Girin:**

   - **Server (Sunucu Adı):** `localhost`
   - **Username (Kullanıcı Adı):** `sa`
   - **Password (Parola):** `password`
   - **Certification:** `True` (SSL sertifikası doğrulama gereklidir)

   **Not:** Eğer bağlantı sırasında güvenlik uyarısı alırsanız, `Certification: True` olarak ayarlandığı takdirde SSL sertifikası doğrulaması yapılır.

---

Bu adımları takip ederek, SQL Server Docker konteynerini başarıyla çalıştırabilir ve Azure Data Studio veya SSMS üzerinden bağlantı kurabilirsiniz.