# C# dili ve selenium kullanarak console uygulamasında takipçi kazıma, kullanıcıyı takip etmeyenleri bulma

Bu console uygulaması C# dilinde yazılmıştır. Sizden alınan kullanıcı adı ve şifre ile sisteme giriş yapılmaktadır. Ardından takipçileri kazımak istenen kişinin kullanıcı adı yazılmalıdır. Bu console uygulaması ile 200 - 250 kişi arasında az sayıda takipçi kazımasında hiçbir eksik veri olmadan takip etmeyen kişiler görüntülenebilmektedir.

Eğer takipçi, takip edilen sayısı 200 - 250 kişiden fazlaysa Instagram için "Cross-Origin Read Blocking (CORB)" devreye girmektedir. CORB politikası nedeniyle web sayfası tarafından sağlanan bazı veriler JavaScript tarafından doğrudan erişilemez hale getirilir. Bu nedenle, Selenium gibi araçlarla veri çekerken eksik veya hatalı veriler alınabilir. Örneğin 300 kişi için 285 kişi gibi daha az sayıda kişi kazınacak anlamına gelmektedir. Daha fazla takipçi kazımak istiyorsanız CORB'u engellemeniz gerekmektedir. 

Ancak, belirtmek gerekir ki, Instagram'ın kullanım şartları botlar ve otomatik araçlar tarafından veri çekmeyi yasaklar ve hesabınızın askıya alınmasına neden olabilir. Bu nedenle, Instagram'dan veri çekerken bu kurallara uymak ve saygılı olmak önemlidir.
