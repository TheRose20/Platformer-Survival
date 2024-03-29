# Данный проект был создан как пример написания кода по ТЗ
[Ознакомиться с Техническим заданием](https://docs.google.com/document/d/1ZUS6sHHvmQcrcTfE9a0TabNFE93YMRpWvUfZ-7E98rE/edit?usp=sharing)

## Пояснялка
В данном проекте я хотел реализовать [систему дронов](https://github.com/TheRose20/Platformer-Survival/blob/master/README.md#%D1%81%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D0%B0-%D0%B4%D1%80%D0%BE%D0%BD%D0%BE%D0%B2), [систему волн](https://github.com/TheRose20/Platformer-Survival/blob/master/README.md#%D1%81%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D0%B0-%D0%B4%D1%80%D0%BE%D0%BD%D0%BE%D0%B2). И все это завернуть в ООП и солянку SOLID'а. Да в основном мне нужно было сделать ТЗ, но в какой-то момент я понял, что задание простое. Поэтому я забил на некоторые аспекты ТЗ и сконцентрировался на других, таких как [система дронов](https://github.com/TheRose20/Platformer-Survival/blob/master/README.md#%D1%81%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D0%B0-%D0%B4%D1%80%D0%BE%D0%BD%D0%BE%D0%B2), [система волн](https://github.com/TheRose20/Platformer-Survival/blob/master/README.md#%D1%81%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D0%B0-%D0%B4%D1%80%D0%BE%D0%BD%D0%BE%D0%B2)

Как я уже сказал некоторый аспекты ТЗ реализовывать мне было не очень интересно (Я на них просто забил). Но поработал над другими, которые получились достаточно неплохо! Было проделанно не мало работы над архетиктурой проекта, но даже так я считаю его не идеальным.

## Система дронов
Итак, моя задача была - сделать систему с которой можно было гибко работать и отчасти у меня получилось это сделать.

Изначально я сделал [базовый класс врага](https://github.com/TheRose20/Platformer-Survival/blob/master/Assets/Platformer/Architecture/Scripts/Enemy/Enemy.cs), который сразу унаследовал в классе [дрона](https://github.com/TheRose20/Platformer-Survival/blob/master/Assets/Platformer/Architecture/Scripts/Enemy/Drone/Drone.cs), в начале я хотел, чтобы дроны были умными и умели обходить препятствия, даже отдельную [папку](https://github.com/TheRose20/Platformer-Survival/tree/master/Assets/Platformer/Architecture/Scripts/AI/Drone) для этого создал в которой начал писать код, но позже отказался от этой затеи в связи с большими потерями времени и начал реализовывать простое передвижение дрона, которое хоть и работало достаточно просто, но выглядело вполне массивно
https://github.com/TheRose20/Platformer-Survival/blob/7af97ad5818c038e16c2d6c43c2df6a539daa712/Assets/Platformer/Architecture/Scripts/Enemy/Drone/Drone.cs#L69-L104

### Дрон

Дрон, это класс который хранит в себе некий DroneSO[^1].

[^1]: DroneSO расшифровывается как Drone Scriptable Object

https://github.com/TheRose20/Platformer-Survival/blob/7af97ad5818c038e16c2d6c43c2df6a539daa712/Assets/Platformer/Architecture/Scripts/Enemy/Drone/Drone.cs#L11
DroneSO это наследник класса [Scriptable Object](https://docs.unity3d.com/Manual/class-ScriptableObject.html), работающий как флешка. В дрон нужно закинуть *флешку* (DroneSO), чтобы дрон "осознал себя". В этой *флешке* нужные для дрона [параметры](https://github.com/TheRose20/Platformer-Survival/blob/master/Assets/Platformer/Architecture/Scripts/SO/Enemy/Drone/DroneSO.cs), такие как:
- Минимальная дистанция
- Макскимальная дистанция
- Глаза
- Цвет глаз
- Время отключки
- Скорость
- Ускорение
- Замедление <br>

*Флешка* эта нужна для удобства использования, место того, чтобы каждый раз делать из дрона новый префаб с параметрами, мы делаем флешку и передаем дрону во внутрь, он уже сам разбирается, что с ней делать.<br>
В моем случае он ее использует при инициализации:
https://github.com/TheRose20/Platformer-Survival/blob/ff14a9b59c27a731f1243ab913079fd018532df7/Assets/Platformer/Architecture/Scripts/Enemy/Drone/Drone.cs#L25-L34
а так-же дрон использует в своих расчетах, для экономии памяти, да и в целом это правильный подход:
https://github.com/TheRose20/Platformer-Survival/blob/ff14a9b59c27a731f1243ab913079fd018532df7/Assets/Platformer/Architecture/Scripts/Enemy/Drone/Drone.cs#L77-L92


### Оружие
Теперь мне нужно было сделать оружие для дрона, да так, чтобы его можно было легко поменять. Для этого были созданны несколько классов оружия:
- [Наводчик](https://github.com/TheRose20/Platformer-Survival/blob/master/Assets/Platformer/Architecture/Scripts/Enemy/Drone/Guns/AimGunToPlayer.cs) (Который просто наводится на игрока)
- [Базовый класс](https://github.com/TheRose20/Platformer-Survival/blob/master/Assets/Platformer/Architecture/Scripts/Enemy/Drone/Guns/DroneWeapons/DroneGun.cs)
  - [Оружие с пулями](https://github.com/TheRose20/Platformer-Survival/blob/master/Assets/Platformer/Architecture/Scripts/Enemy/Drone/Guns/DroneWeapons/DroneGunBullet.cs) (Оружие которое стреляет пулями)
      - [Пуля](https://github.com/TheRose20/Platformer-Survival/blob/master/Assets/Platformer/Architecture/Scripts/Enemy/Drone/Guns/DroneBullets/DroneBullet.cs)
  - [Лазерная пушка](https://github.com/TheRose20/Platformer-Survival/blob/master/Assets/Platformer/Architecture/Scripts/Enemy/Drone/Guns/DroneWeapons/DroneGunLaser.cs) (Оружие которое стреляет лазером, моментально нанося урон)<br>
  
В целом ничего сложножного, всего 2 производных класса с разной реализацией стрельбы. <br>
Наводчик реализован достаточно просто: он берет позицию игрока через [Singleton](https://metanit.com/sharp/patterns/2.3.php), я подумал, что использовать [Zenject](https://github.com/modesttree/Zenject) будет лишним.
Префаб пушки имеет в себе один из классов пушки и Наводчик.

### _Грузчик_ дрона
Дрон - есть, пушка - есть, осталось собрать все в одну массу, именно эту задачу выполняет - [_Грузчик_ дрона](https://github.com/TheRose20/Platformer-Survival/blob/master/Assets/Platformer/Architecture/Scripts/SO/Enemy/Drone/DroneData.cs)

_Грузчик_ *собирает* дрона из [DroneSO](https://github.com/TheRose20/Platformer-Survival/blob/master/Assets/Platformer/Architecture/Scripts/SO/Enemy/Drone/DroneSO.cs) и [DroneGunSO](https://github.com/TheRose20/Platformer-Survival/blob/master/Assets/Platformer/Architecture/Scripts/SO/Enemy/Drone/DroneGun/DroneGunSO.cs). Сборшик хоть и берет DroneGunSO, но использует только его производные классы (наверное лучше было использовать [интерфейс](https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/keywords/interface) для этого). В любом случае я и там проверку не добавил... Блин... Ладно позже добавлю или в интерфейс переделаю.<br>

Я сказал, что _Грузчик_ **собирает** дрона из его частей, но это вообще не так, он просто хранит в себе параметры **будущего** дрона. Он как грузовик перевозит части, но не собирает их, собирает эти части - Сборщик дронов.

### Сборщик дронов

Сборшик дронов - собирает дроны беря детали из [грузовичка](https://github.com/TheRose20/Platformer-Survival/blob/master/Assets/Platformer/Architecture/Scripts/SO/Enemy/Drone/DroneData.cs). Сборщик дронов это Singleton, чтобы к нему могли обращаться из любого класса, для создания дрона. Для создания дрона ему потребуется некоторые параметры:
- Грузчик дрона
- Позиция создания
https://github.com/TheRose20/Platformer-Survival/blob/73abe6fb102696935750bf1176caf4c86439acc6/Assets/Platformer/Architecture/Scripts/Factory/Drone/DroneFactory.cs#L34
Внутри класса происходит настоящия магия, которую я не хочу коментировать, просто скажу - "Создать этот класс было - непросто"

## Система волн

Теперь переходим к достаточно интересной теме - Волны. Моей задачей было сделать класс с которым можно гибко настраивать волны врагов.
WaveManager, а именно так я назвал класс, должен создавать врагов.
![WaveManager](https://github.com/TheRose20/Platformer-Survival/blob/master/WaveManager.png)
Вот так он выглядит в Unity, хранит в себе точки спавна для врагов, и сами волны в которых можно настраивать:
- Количество врагов
- Время до следуйщей волны
> [!WARNING]
> Работает только в случае отключенной галочки One Time
- Самих врагов
> [!TIP]
> В случае если количество врагов больше, чем есть в WaveManager'е, то будут повторно использоватся враги


Как использовать все это добро можно [почитать тут](https://github.com/TheRose20/Platformer-Survival/blob/master/Use.md)
