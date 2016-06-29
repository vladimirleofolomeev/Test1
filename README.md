# Test1
Test Task № 1

Поставленная задача для тестового задания:

1.Индикация завершения длительных фоновых операций. На форме кнопка. При клике на кнопку где-то глубоко внутри модели запускается фоновый поток с длительной операцией (Thread.Sleep).

По завершению операции необходимо вывести на форме (например, в лейбле) сообщение, что операция завершена.
Нюанс в том, что из модели нет api уведомления о завершении операции.

2. На форме расположить несколько контролов, которые имеют скролл бары (желательно, чтобы контролы были вложены друг в друга). На форме находится комбобокс с несколькими элементами описывающие цвета (например: синий, желтый, красный). При выборе элемента в комбобоксе все скроллбары на форме должны принять выбранный цвет.

3. Реализовать нестандартный заголовок окна. Скрыть стандартный заголовок окна и нарисовать свой, как это сделано в Visual Studio

Описание реализации задания:

Задача №1
Индикация завершения длительных фоновых операций. На форме кнопка. При клике на кнопку где-то глубоко внутри модели запускается фоновый поток с длительной операцией (Thread.Sleep). По завершению операции необходимо вывести на форме (например, в лейбле) сообщение, что операция завершена. Нюанс в том, что из модели нет api уведомления о завершении операции.

Решение: Я использовал асинхронный запуск задачи с async/await, задача ссылается на модель, где самоусыпляется поток на случайное значение 1-10 сек. Индикация привязана к окончанию работы потока. Т.е. индикатору (в моём случае - лейблу) присваивается значение об окончании после завершения потока. Ожидание завершения реализовано через await, так что нет никакого обращения к внутренностям самого потока и его api.
Задача запускается с формы по кнопке "Запуск потока в глубинах модели", индикация выводится в лейбл под кнопкой.

Задача №2
На форме расположить несколько контролов, которые имеют скролл бары (желательно, чтобы контролы были вложены друг в друга). На форме находится комбобокс с несколькими элементами описывающие цвета (например: синий, желтый, красный). При выборе элемента в комбобоксе все скроллбары на форме должны принять выбранный цвет.

Решение:
/*
Эта задача вызвала у меня наибольшее затруднение (2 дня). Так как дизайнерскими решениями я особо до этого не занимался - чтение документации и изучение кода заняло основное время работы над задачей. Особенно вертикальный скроллбар... бррр...
*/
В ресурсах окна был размещен код стилей для каждого элемента вертикального скроллбала и создан на их основе шаблон для контрола. Внутри стилей цвет каждого элемента я привязал к коллекции цветов. Эта же коллекция цветов привязана к комбобоксу в шапке приложения. Каждый элемент коллекции имеет имя и значение кисти. Выбранное значение в комбобоксе вызывает изменение свойства цвета и по имени свойства выбирается элемент коллекции. Так как шаблон привязан к контролу - "вертикальный скроллбал" и находится в ресурсах всего окна, то все вертикальные скроллбары в окне будут изменять свои свойства цвета (независимо, вложены они друг в друга или нет - вообще все).

Задача №3
Реализовать нестандартный заголовок окна. Скрыть стандартный заголовок окна и нарисовать свой, как это сделано в Visual Studio

Решение:
В свойствах окна:
- присвоил AllowsTransparency значение true
- WindowStyle - None
- Background - Transparent,
таким образом убрав стандартный вид окна Windows. Далее разместил в окне grid с тремя строками (заголовок, основная часть, статусная строка) и выставил свои цвета, оставив 80% альфу у Border'a.
В заголовке поместил прямоугольник, для того чтобы реализовать возможность перемещать окно по экрану. В шапке разместил иконку, лейбл, две кастомные кнопоки, комбобокс (для задания №2) и три системные кнопки в своём дизайне. Иконки для кнопок, а точнее коды для свойства Path.Data брал с сайта https://icomoon.io, он позволяет сразу получить векторный код фигуры. Т.е. все рисунки на кнопках в шапке - векторные (можно в коде менять размеры, цвета и что угодно) и имеют свои обработчики.
