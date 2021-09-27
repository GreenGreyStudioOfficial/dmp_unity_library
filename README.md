# com.greengreysoftworks.dmpanalytics
Библиотека для сбора и отправки событий аналитики

# Текущая версия

0.0.2

# Необходимые данные для подключения библиотеки

Токен авторизации для доступа к github репозиторию (далее <github_api_token>).

> Пример:
> 
> ghp_sroeYEp9kOATCW3kQdzIpcs0jS5JTm04vHK

Ключ идентификации проекта в системе аналитики (далее <analytics_project_key>).

> Пример:
>
> 779a42bdbebeccc7099de0aaff8b7298d4c22638a95028c362da50bcc5da9e67

# Добавление библиотеки в проект

Добавление библиотеки возможно из приватного репозитория в пространстве GreenGreyStudioOfficial. 
Адрес состоит из трех частей:
- <github_api_token>
- путь до репозитория Github
- текущая версия библиотеки (ссылка на git tag релизного коммита)

Пример:

> https://<**github_api_token**>@github.com/GreenGreyStudioOfficial/dmp_unity_library.git#v<**current_version**>

Чтобы добавить зависимость в проект, нужно открыть **PROJECT_DIR/Packages/manifest.json** текущего проекта и добавить строчку в раздел "dependencies"

Пример:

```json
  "dependencies": {
    ...,
    "com.greengreysoftworks.dmpanalytics": "https://ghp_sroeYEp9kOATCW3kQdzIpcs0jS5JTm04vHK@github.com/GreenGreyStudioOfficial/dmp_unity_library.git#v0.0.2"
  }
```

# Использование библиотеки

### Добавление ассета на сцену:

Для подключения аналитики в проект, нужно в стартовую сцену проекта добавить GameObject с компонентами `DmpAnalytics` и `DmpConfiguration`.
Для автоматического добавления можно воспользоваться пунктами меню

`[Edit] -> [GreenGray] -> [Create Dmp Prefab]`

![Add asset](/.readme/add_asset.png)

В итоге на сцене должен появиться prefab с компонентами:

![Prefab with components](/.readme/prefab_with_components.png)

### Доступные настройки:

![Settings](/.readme/settings.png)

**Api Uri** - адрес бекенда статистики (не менять)

**Api Key** - ключ идентификации проекта в системе аналитики (<analytics_project_key>)

**Max Events Count To Send** - количество событий, после которых произойдет отправка на сервер.

**Send Events Timeout In Sec** - таймаут, после которого события будут отправлены на сервер, если не достигнуто максимальное количество.

**Debug Mode** - включает логирование Debug.Log

**Register App Pause** - добавлять или нет событие `APP_ENABLE` (при отладке в редакторе)

**Sending settings** - позволяет отключать отсылаемые события по типам

### Интеграция с AppsFlyer:

В библиотеке реализован компонент `DmpAppsFlyerBridge`, который автоматически добавляется к префабу, на котором находится `DmpAnalytics`, находит подключенный модуль AppsFlyer и запрашивает необходимые данные.

# API

### Регистрация и отправка пользовательских событий:

    IDmpCustomEventRegistry RegisterEvent(string _eventName);
    IDmpCustomEventRegistry RegisterEventProperty(string _eventProperty);
    void LogCustomEvent(string _eventName, Dictionary<string, object> _eventParams = null);