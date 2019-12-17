# backend

Kullanilan Teknolojiler
Back-End=>ASP.NET CORE WEB API
Veritabani=>MSSQL Server
Neden ASP.NET CORE WEB API kullanildi?
1)Kullanici arayüzü bağlı olmaksızın yarın öbür gün kullanılan bu veriler bir internet sayfasında olabileceği gibi bir mobil aplikasyona da aktarılabilme imkanı olduğu
için yazılımın arka planındaki mantık yapısını bir REST API oluşturmaya yönelik gerçekleştirmek istenildi.Aynı zamanda Nesne yönelimli tarafı oldukça güçlü olması itibariyle
C# dilini kullanmak için de ve aynı zamanda kullanıcı arayüzüne veri gönderebilmek ya da arayüzden veri alabilmek için bu imkanı sağlayan framework ya da yapı Web API'de
olduğu için kullanılması tercih edildi
2)NET'den sonra da .NET Core da piyasaya çıkılması itibariyle .Net Core ile artık çapraz platform dediğimiz hem Linux ve hem de MacOS'da da artık kod yazabilme imkanı sunduğu için
yine bu altyapı kullanmamız ve geliştirme yapmamız tercihlerimiz arasındaydı.
3)Artık web projelerin büyük oranda bir API oluşturup bu API üzerinden bir front end teknolojisi(React,Vue,Angular...) 
ile haberleştirilmesi itibariyle yazılım dünyasında oldukça popüler bir web yazılım geliştirme süreci olduğu için yine kullanma tercihlerimiz arasında

Nesne Yönelimli tarafı güçlü olan bir dilin kod yazmada önemi neler olabilir?
1)Programlarımıza yaptıracağımız işlemleri birbirine karıştırmadan her işlemin ya da işlem yapılarını kendi sorumluluğunu gerçekleştirebilme imkanı sağlar.Bu sayede
kodun okunabilirliği ve üzerinde kendi işlemi belli olduğu için üzerinde birim testleri ya da fonksiyona yönelik testler yazılması ve test edilmesi oldukça kolaylaştırır
2)Yine dediğimiz gibi işlemlerin kendine aitliği bize yine veritabanı kayıt girişlerinin sonrasında veritabanında gelen verilerin mantıksal süreçlerden süzülmesi ya da
doğrulanması ve ardından kullanıcı arayüzüne bu verilerin aktarılması sürecini modülleştirmemiz ya da bu her işlemleri birbirinden ayrılması açısından Nesnel bir programlama
bakış açısı kullanabilmek oldukça bu modülleştirme ya da bu işlemleri katmanlara ayırmamızı kolaylık sağlar.Günümüzdeki projelerde de zaten bu veritabanı işlemleri,veritabanından
gelen verilerin mantıksal süreçlerinden geçirilmesi ve sonrasında kullanıcı arayüzüne sonrasında bir sonuç döndürülmesi işlemleri her biri ayrılalarak bunlar katmanlaştırılır.
Bu sayede proje içindeki işlemlerin karışmasını ve kodun okunabilirliği ve en önemlisi yarın öbür gün başka bir geliştirici ekibe dahil olduğundan çok da zorlanmadan
projenin için hemen dahil olabiliyor.Bu bahsettiğimiz modülleştirme yapısına Çok Katmanlı Mimari yapısı denir.

Veritabanı olarak neden MSSQL Server kullanildi?
1)ASP.NET projelerinde genelde uyum açısından da olsun MSSQL Server veritabanı kullanılmakta.Aynı zamanda C# dili beraber MSSQL Server veritabanına bağlanılması
,tabloların oluşturulması ve yeni kayıt ekleme gibi işlemleri oldukça yazımları kolay olması itibariyle tercih sebeplerden bir tanesi.Entity Framework denilen bir ORM
tool(aracı)'da bu tabloların MSSQL Server tarafından da oluşmasını kod üzerinden sağlanmasını oldukça kolaylık sağlamakta.Bu araç da MSSQL Server ile de uyumludur.
Zaten ikisi de Microsoft'a ait teknolojilerdir :)
2)Bizim projemizdeki sistemin yapısında muhakak ilişkiler var yani mesela postaci teslimatlarını gördüğünde muhakak teslimat için gerekli bilgiler yanında vatandaşın
bilgilerin görmesi gerekiyor.İşte o zaman teslimatlar ile bir vatandaşa ait tablolar arasında ilişki kurması gerekir.Yani bir vatandaşa ait birden fazla teslimat olabilecektir
ve aynı zamanda bir teslimat da bir vatandaşa ait olacaktır.O zaman bu kurguya da gerçekleştirmek için bir ilişkisel veritabanına ithiyaç olacaktır ki bu ilişkiler kurulduktan
sonra da bu ilişki tablolar arasında kod tarafında da bir İnner Join kodları yazılarak ilişki tablolar arasındaki değerleri web sayfamızda görüntüleyebilelim.Bu ilişkisel
yapı nedeniyle yine MSSQL Server kullanılması bir tercih sebebidir.

Yazılımın ya da projenin arayüz mimarisi=>MVC(Model-View-Controller)
1)Model=>Model dediğimiz yapı aslında veritabanına ait tablolardır ya da veritabanından gelecek olan verilerin arayüz tarafında istenildiği şekilde gelecek olan yapılardır.
Kısacası verilerin arayüze aktarılacak şeklidir.
2)View=>Kısacası arayüz diyebiliriz.Bu arayüz JavaScript tarafında bir framework ya da kütüphane de olabilir(React,Vue...) isterse bir masaüstü form uygulaması da olabilir.Genel
anlamıyla bu proje için arayüz şudur ki biz verimizi nereye gönderip kullanıcıya gösteriyorsak orası arayüzdür.
3)Controller=>Kodun arka tarafındaki back end kodlarından gelen yapıları olan ya da verinin süzgeçlendiği katmandan gelen verinin bir aksiyon ya da bir view gönderecek
şekilde view tarafıyla haberleşecek yapıdır.Projeye göre yaptığı fonksiyon değişebilmektedir.Bu projedeki yapısı mantıksal katmandan gelen datanın view'a iletecek şekilde
çalışma prensibini yapmaktadır.Başka MVC dediğimiz projelerinde Model ile View arasında ara katman gibi modelden aldığı veri süzgeçleyerek view'a direk iletebilmektedir.Yani hiç
arka tarafta bir katmanlı mimarideki bir ayrı mantıksal katmandan da veri gelmeyebilir de.
Neden Çok Katmanlı Mimarisi(Arayüze bağlanacak olan arka taraf mimarisi) kullanıldı
1)Oluşturduğumuz kodları eğer yarın öbür gün bir desktop(masaüstü) uygulamasına ya da bir ASP.NET MVC dediğimiz direk MVC mimarisini sunan bir framework'e de
aktarmak istenilirse kodlar üzerinden radikal olarak değişiklik yapmaya gerek olmadan da bu kodların da başka platformlarda da kullanabilmesi için bir altyapı
kurmak oldukça mantıklı olacaktır.Bu da aynı zamanda zamandan ve maliyetten pozitif yönde bir katkı sağlayacağı için altyapı kurmak ya da kurumsal mimari olarak
katmanlı mimari yapısı kullanmak oldukça mantıklı olacaktır.

2)İşlemleri katmanlaştırmamız katmanlara geçişlerde kodun okunabilirliği olsun kod üzerinden test edilebilirliği olsun oldukça kolaylık sağlayacaktır.Aynı zamanda
projedeki iş akışlarında her bir geliştiricin yapacağı görevleri dağıtılması açısından oldukça güzel bir altyapıdır.

Çok Katmanlı Mimari yapısı nedir?

1-Genel olarak çok katmanlı mimari yapısı,veritabanı ile alakalı ekleme,silme,güncelleme ve kayıtların getirtilmesinin için ayrı bir katman, bu veritabanına ile alakalı
mantıksal yapılarla ile süzgeçlenmesidir(validasyon(doğrulama)...),gelen verilerin her seferinde veritabanında çekmesini önlemek için tampon bellek yapısı kurulması
ya da gelen verilerin görüntülenmesini kişilerin yetkilerine ya da yetkili olabilmesine göre (authentication) bu iş sürecinin kodlanması gibi kısacası veritabanı ile alakalı
işlemleri haricindeki olabilecek diğer iş süreçlerini kodlanması için ayrı bir katman ve en sonunda iş süreçleri ile şekilenen verilerin ya da veri üzerindeki işlemlerin
arayüz katmana bağlanması ve bu verilerin arayüz tarafında gösterilmesi için ayrı bir katman yapısı kurulması ama tabiki birbirinden bağımsız olmayacak şekilde bu katmanların
bütünene biz çok katmanlı mimari yapısı diyebiliriz



                  Data Access Layer(Veri Erişim Katmanı(Veritabanı işlemleri))
                                                           |
                                                           |
                                                           |
                                                           |
                  Business Logic Layer(İş Mantık Katmanı(Veritabanı haricinde diğer kodlamalar ya da iş süreç(Authenticate,Validation,Caching,Logging...) kodları)
                                                           |
                                                           |
                                                           |
                                                           |
                  User Interface Layer(Kullanıcı Arayüz Katmanı(İş süreçleri ile şekilenen verilerin kullanıcıya gösterildiği katman)




Genelde en basit haliyle üç katmanlı görüldüğü gibi fakat bizim projemizde dahil olmak üzere birkaç yazılım projesinde bir de Entity dediğimiz sadece veritabanı
tabloların sınıf şeklinde oluşturulup veri erişim katmanında kullanılıp kod üzerinden  bu veritabanı tabloların oluşturalabilmesi ve veritabanı üzerinde yeni bir
veri eklemek ya da silmek gibi işlemler için veritabanı tablosuna ait bir sınıfın nesnesinin kullanılması için bu Entity dediğimiz Türkçe tabiriyle Varlık katmanı
kullanılmakta.Aynı zamanda bu tüm katmanlarda da kullanılabilecek ve tüm katmanlar için bir altyapı niteliğinde olacak olan yazılım dünyası framework olacak bir katman
olan Core dediğimiz bir katmanda yine bu projede kullanıldı.Core(Çekirdek) dediğimiz katman tüm katmanlarda yazılacak olan kodlar için bir altyapı olduğu için buralarda
kullanılan metotlar ya da fonksiyonlar sadece ilgili katmanda çağrılıp kullanılması ile yeterli olacaktır ki bu da o katmandaki kodlarda okunurluk sağlayacaktır biz geliştiricler
açısından.









