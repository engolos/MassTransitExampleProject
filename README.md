# MassTransitExampleProject

docker da rabbitmq çalıştırmak için

docker run -d --hostname MassTransitExample --name MassTransitExample -e RABBITMQ_DEFAULT_USER=admin -e R
ABBITMQ_DEFAULT_PASS=123456 -p 5672:5672 -p 15672:15672 rabbitmq:3-management

Daha sonra http://localhost:15672/ adresinden giriş yaparak admin sekmesi altındaki users kısmından projede kullanacağınız user için
username password ve virtualhost'u projede kullanacağınız bilgilere göre ayarlayınız.
