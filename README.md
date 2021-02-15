# GasStation (WinForms, C#)
Владелец автозаправки «BestOil» заказал следующую программу. Когда автозаправка только начинает свою деятельность, владелец обычно хочет получать максимально большой доход, 
который планирует увеличить за счет дополнительных услуг. Поэтому на автозаправке будет действовать небольшое кафе. Но, в то же время он может нанять только одного работника 
на должность кассира, а потому назначение программы – учет продаж бензина и ассортимента товаров в миникафе.
Требования к поставленной задаче:
Для удобства окно разделено на три части: первая для осуществления вычислений, касающихся непосредственно заправки автомобилей топливом; вторая – покупки в мини-кафе; третья 
часть для вычисления суммы оплаты.
Итак, первая группа элементов Автозаправка.
ComboBox – выпадающий список с перечнем имеющегося горючего. По умолчанию, сразу при запуске программы должен быть выбран определенный вид горючего и в TextBox (или например Label) 
должна отображаться цена на данный вид продукта. При каждой смене выбора бензина, цена в данном поле будет соответственно меняться.
Далее, дается возможность выбора: купить горючее, указав необходимое количество литров или указав, на какую сумму клиент будет заправляться. При этом, после выбора одного из двух
вариантов предоставления услуги, ненужное поле становится заблокированным. В случае ввода суммы денег, группа «К оплате» изменит название на «К выдаче»; вместо суммы следует выводить 
количество литров, соответственно изменяются единицы измерения с «грн..» на «л».
Вторая группа Мини-кафе.
Для удобства, все возможные товары выведены сразу в данной части. Для каждого продукта предусмотрены CheckBox с названием товара, рядом выводится цена (неактивный TextBox). При 
получении заказа для возможности ввода количества заказанных единиц товара, следует поставить «галочку» в CheckBox напротив соответствующего товара.
Последняя – «К оплате».
Содержит кнопку, которая отвечает за осуществление вычисления и вывода сумм в соответствующих полях. После того, как выведена сумма, через (например) 10 секунд должен появиться 
запрос на очистку формы, то есть при появлении следующего клиент: да – все поля принимают значения по умолчанию, нет – неизменное состояние остается еще на 10 секунд. При выходе
из программы (закончился рабочий день) должно появиться окно с сообщением, какова общая сумма выручки за данный день. Или эту сумму можно сразу выводить в самой форме и изменять 
после каждого осуществления расчета с клиентом.
Кроме этого, придайте форме эстетический вид (цвета, шрифты, рисунки ...). При обоснованной необходимости и интересном решении функциональности программы разрешается вносить изменения 
во внешний вид формы или набор элементов.
Для мини кафе реализовать разделённый доступ админа и юзера. Админ может редактировать товары и цены, добавлять товары. Юзер формирует чек покупки, котрый накапливается в 
отдельном файле. Реализовать меню (+ кнопки), мультиязячность.

The owner of the BestOil gas station has ordered the following program. When a gas station is just starting out, the owner usually wants to get the most income possible,
which plans to increase through additional services. Therefore, a small cafe will operate at the gas station. But, at the same time, he can only hire one employee.
for the position of a cashier, and therefore the purpose of the program is to keep track of gasoline sales and the range of goods in the mini-cafe
Requirements for the task:
For convenience, the window is divided into three parts: the first for performing calculations related to the direct refueling of vehicles; the second - shopping in a mini-cafe; third
part for calculating the payment amount.
So, the first group of gas station elements.
ComboBox - a drop-down list with a list of available fuel. By default, immediately upon starting the program, a certain type of fuel must be selected and in the TextBox (or for example Label)
the price for this type of product should be displayed. Each time you change the choice of gasoline, the price in this field will change accordingly.
Further, a choice is given: to buy fuel, indicating the required number of liters or indicating how much the customer will refuel. Moreover, after choosing one of the two
service options, the unnecessary field becomes blocked. If you enter the amount of money, the "For payment" group will change the name to "For issue"; instead of the amount should be displayed
the number of liters, respectively, the units of measurement change from "UAH .." to "l".
Second group Mini-cafes.
For convenience, all possible products are displayed immediately in this section. For each product there is a CheckBox with the name of the product, next to it is the price (inactive TextBox). When
When receiving an order, to be able to enter the number of ordered units of goods, you should put a tick in the CheckBox opposite the corresponding item.
The last one is “For payment”.
Contains a button that is responsible for calculating and displaying amounts in the corresponding fields. After the amount is withdrawn, after (for example) 10 seconds, the
a request to clear the form, that is, when the following client appears: yes - all fields take their default values, no - the unchanged state remains for another 10 seconds. When leaving
from the program (the working day has ended) a window should appear with a message, what is the total amount of revenue for this day. Or this amount can be immediately withdrawn in the form itself and changed
after each settlement with the client.
Also, give the form an aesthetic look (colors, fonts, designs ...). If there is a justified need and an interesting solution to the functionality of the program, it is allowed to make changes
the appearance of a form or a set of elements.
For mini-cafes, implement shared access for admin and user. The admin can edit products and prices, add products. The user generates a purchase receipt, which is accumulated in
a separate file. Implement a menu (+ buttons), multilanguage.
