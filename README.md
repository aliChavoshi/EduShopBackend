# پروژه EduShopBackend

## معرفی پروژه
پروژه **EduShopBackend** یک API قدرتمند و مقیاس‌پذیر برای فروشگاه اینترنتی است که با استفاده از **ASP.NET Core Web API** توسعه داده شده است. این پروژه به صورت **ماژولار** طراحی شده و از **معماری Clean Architecture** بهره می‌برد. تمامی بخش‌های آن از یکدیگر **مستقل** هستند و می‌توانند به صورت جداگانه توسعه داده شوند.

این پروژه در کنار **EduShopClient** (فرانت‌اند توسعه‌یافته با Angular) یک فروشگاه اینترنتی **کامل و حرفه‌ای** را تشکیل می‌دهد.

## ویژگی‌های کلیدی پروژه
✅ **استفاده از Clean Architecture** برای جداسازی لایه‌ها و افزایش خوانایی کد  
✅ **استفاده از CQRS** برای مدیریت درخواست‌ها و بهینه‌سازی عملکرد  
✅ **استفاده از JWT** برای احراز هویت کاربران  
✅ **پشتیبانی از Repository Pattern و Unit Of Work**  
✅ **بهره‌گیری از Fluent Validation** برای اعتبارسنجی درخواست‌ها  
✅ **استفاده از Redis** برای کش کردن داده‌ها و افزایش سرعت  
✅ **پرداخت آنلاین از طریق زرین پال**  
✅ **پشتیبانی از Docker و Docker-Compose** برای اجرای آسان سرویس‌ها  
✅ **Unit Testing** با استفاده از XUnit و NUnit  
✅ **پشتیبانی از پایگاه‌های داده مختلف (SQL Server, PostgreSQL)**  
✅ **پشتیبانی از GitHub Actions برای CI/CD**  

## پیش‌نیازها
برای اجرای این پروژه، نیاز به نرم‌افزارهای زیر خواهید داشت:
- **Visual Studio 2022** یا جدیدتر
- **.NET 8 SDK**
- **SQL Server / PostgreSQL**
- **Docker & Docker-Compose** (اختیاری)
- **Redis** (اختیاری برای بهبود عملکرد)

## نصب و راه‌اندازی
### 1. دریافت سورس کد
ابتدا سورس کد را از **GitHub** کلون کنید:
```sh
git clone https://github.com/aliChavoshi/EduShopBackend.git
cd EduShopBackend
```

### 2. تنظیم Connection String
فایل **appsettings.json** را باز کنید و تنظیمات دیتابیس را تغییر دهید:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=EduShopDB;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
}
```

### 3. اجرای Migrations
برای راه‌اندازی دیتابیس، دستورات زیر را اجرا کنید:
```sh
dotnet ef database update
```

### 4. اجرای پروژه
```sh
dotnet run
```

## ساختار پروژه
```
EduShopBackend/
│── src/
│   ├── Application/         # لایه‌ی منطقی و پردازش درخواست‌ها
│   ├── Domain/              # مدل‌های اصلی پروژه
│   ├── Infrastructure/      # ارتباط با دیتابیس و سرویس‌های جانبی
│   ├── Presentation/        # کنترلرها و API های پروژه
│── tests/                   # تست‌های واحد
│── docker-compose.yml       # تنظیمات Docker
│── appsettings.json         # تنظیمات پروژه
```

## API های کلیدی
### 1. احراز هویت
**ورود به سیستم**
```http
POST /api/auth/login
```
```json
{
  "email": "user@example.com",
  "password": "password123"
}
```
**ثبت‌نام**
```http
POST /api/auth/register
```
```json
{
  "name": "Ali Chavoshi",
  "email": "ali@example.com",
  "password": "password123"
}
```

### 2. محصولات
**دریافت لیست محصولات**
```http
GET /api/products
```
**افزودن محصول جدید**
```http
POST /api/products
```

### 3. سبد خرید
**دریافت سبد خرید کاربر**
```http
GET /api/basket
```
**افزودن آیتم به سبد خرید**
```http
POST /api/basket/add
```

### 4. سفارشات
**ثبت سفارش جدید**
```http
POST /api/orders
```

## تست و دیباگ پروژه
برای تست پروژه از **XUnit** استفاده شده است. اجرای تست‌ها:
```sh
dotnet test
```

## توسعه و مشارکت
- **Fork** کنید، تغییرات خود را اعمال کنید و **Pull Request** ارسال کنید.
- پیشنهادات و مشکلات را از طریق **GitHub Issues** ثبت کنید.

## لینک‌های مرتبط
- **فرانت‌اند پروژه (EduShopClient):** [EduShopClient GitHub](https://github.com/aliChavoshi/EduShopClient)
- **صفحه آموزش دوره:** [دوره آموزش طراحی فروشگاه اینترنتی](https://www.daneshjooyar.com/وب-سایت-فروشگاهی-مشابه-دیجی-کالا/)

---
**مدرس:** *علی چاوشی* 🚀

