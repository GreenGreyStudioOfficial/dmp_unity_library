# Green Grey Analytics Library for Unity
Библиотека для сбора и отправки событий игровой аналитики в системе DMP.

## Текущая версия
1.0.0

## 0. Что понадобится для интеграции?
**analytics_project_key** - ключ идентификации проекта в системе аналитики

Его вы можете получить у менеджера Green Grey


## 1. Добавление в проект
1.1 В панели Package Manager выберите Add package from git URL

![Add package to project](/.readme/add_package_from_git.png)

1.2 В открывшемся окне вставьте ссылку https://github.com/GreenGreyStudioOfficial/dmp_unity_library.git#v0.0.9

1.3 Выберите пункт меню Edit → GreenGrey → Create Dmp Prefab.

![Add asset](/.readme/add_asset.png)

Это создаст в текущей сцене объект DmpAnalytics, управляющий отправкой аналитики на сервер. 

1.4 В свойствах объекта DmpAnalytics укажите свой **analytics_project_key** - ключ идентификации проекта в системе аналитики.

Также здесь можно поменять управлять настройками библиотеки аналитики:

![Settings](/.readme/properties.png)

**Api Uri** - адрес бэкенда статистики (не менять)

**Api Key** - ключ идентификации проекта в системе аналитики

**Max Events Count To Send** - количество событий, после которых произойдет отправка на сервер статистики.

**Send Events Timeout In Sec** - таймаут, после которого события будут отправлены на сервер, даже если не достигнуто максимальное количество.

**Debug Mode** - включает отладочное логирование

**Register App Pause** - добавлять или нет событие APP_ENABLE (при отладке в редакторе)


## 2. Использование

Чтобы трекать события используйте методы глобального объекта DmpAnalytics.Instance


### Трекинг покупок

Для трекинга покупок используйте методы LogPurchase:

```
void LogPurchase(string _currency, float _value, Dictionary<string, object> _eventParams);
void LogPurchase(string _currency, float _value);
```

где

_currency - трехбуквенный код валюты покупки по [ISO_4217](https://en.wikipedia.org/wiki/ISO_4217#Active_codes)

_value - сумма покупки

_eventParams - произвольные дополнительные параметры


Пример:

```
DmpAnalytics.Instance.LogPurchase("USD", 0.99f, new Dictionary<string, object>
{
   ["lot"] = "big_coins_pack",
   ["from"] = "fullscreen_offer",
   ["show_count"] = 2
});
```

### Трекинг произвольных событий

Для трекинга событий используйте метод LogEvent:

```
void LogCustomEvent(string _eventName, Dictionary<string, object> _eventParams = null);
```

где:

_eventName - имя события

_eventParams  - произвольные дополнительные параметры

Пример:
```
DmpAnalytics.Instance.LogCustomEvent("SCENE_OPEN", new Dictionary<string, object>
{
   {"scene_index", currentSceneIndex},
   {"scene_name", SceneManager.GetActiveScene().name}
});
```

## 3. Проверка интеграции

При вызове методов DmpAnalytics.Instance в консоли должны отображаться сообщения об отправке событий (убедитесь, что флаг Debug Mode установлен  в настройках аналитики - см. п. 1.4):

![Log](/.readme/log.png)

Проверить валидность отправленных событий вы сможете в персональном дашборде в Tableau, доступ к которому вы получите от менеджера Green Grey вместе с ключами приложения.
