# BirdMissions

## Russian
**BirdMission** - это крошечный прототип игровой системы миссий и героев.

Запустив проект в Unity, вы увидите карту с иконками миссий и панель с иконками героев.

### Игровой процесс
![Gameplay gif](https://github.com/Ninellie/BirdMissions/blob/master/Assets/GameplayGifs/BirdMission.gif)

### Игровой цикл
1. Выбор миссии. Игрок может кликнуть по иконке миссии, чтобы выбрать её в качестве активной.
2. Запуск миссии. Если одна из миссия выбрана - показывается панель миссии с описанием и кнопки запуска. Кнопка запуска миссии запускает миссию и показывает экран активной миссии.
3. Прохождение миссии. Экран активной миссии содержит описание того что происходило в миссии, а также название команды игрока и команды противника.
4. Завершение миссии. Чтобы завершить миссиию, достаточно кликнуть по кннопку "Завершить миссию". После этого игрок возвращается на карту, а пройденная миссия становится заблокированной.

### Возможности расширения
Непрограммист может с удобством редактировать все данные миссий с помощью ScriptableObjects файлов.

Можно настраивать следующие данные миссий:
- Название
- Описание перед миссией
- Описание во время миссии
- Название команды союзника
- Название команды противника
- Расположение на карте
- Связи между миссиями
- Парные миссии, которые блокируют друг друга при прохождении
- Разблокируемые герои после прохождения миссии
- Очки, которые будут даны герою проходящему миссию
- Очки, которые будут даны определённым героям

А также данные героев:
- Имя
- Картинка с портретом героя
___
## English
BirdMission is a tiny prototype of the game's mission and hero system.

When you launch a project in Unity, you will see a map with mission icons and a panel with hero icons.
### Game process
![Gameplay gif](https://github.com/Ninellie/BirdMissions/blob/master/Assets/GameplayGifs/BirdMission.gif)

### Game loop
1. Choosing a mission. The player can click on the mission icon to select it as active.
2. Launch the mission. If one of the missions is selected, the mission panel with a description and launch buttons are shown. The mission launch button starts the mission and shows the active mission screen.
3. Passing the mission. The active mission screen contains a description of what happened in the mission, as well as the name of the player's team and the enemy team.
4. Completing the mission. To complete the mission, just click on the "Complete Mission" button. After this, the player returns to the map, and the completed mission becomes blocked.

### Expansion options
A non-programmer can conveniently edit all mission data using ScriptableObjects files.

The following mission data can be configured:
- Name
- Description before the mission
- Description during the mission
- Ally's team name
- Name of the enemy team
- Location on the map
- Links between missions
- Paired missions that block each other during passage
- Unlockable heroes after completing the mission
- Points that will be given to the hero completing the mission
- Points that will be given to certain heroes

And also the characters' data:
- Name
- Picture with a portrait of the hero