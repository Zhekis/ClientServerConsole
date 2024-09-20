markdown
# TestClienServerApp

Тестовая разработка клиент-серверного приложения.
Серверное приложение отправляет текстовые сообщения в клиентское приложение.
Содержимое сообщения должно варьироваться от следующих условий: если чисел в дате
и времени (с точностью до секунд), установленных на сервере, в момент отправки:
● больше четных, то отправляем сообщение «чет!»;
● больше нечетных — «нечет!»;
● при равном значении четных и нечетных чисел — «равно!».
Клиентское приложение подключается к серверу по сети и начинает отображать
полученные сообщения.
