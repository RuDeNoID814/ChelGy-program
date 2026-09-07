# ChelGy-program

<div align="center">

[![ЧелГУ](https://img.shields.io/badge/университет-ЧелГУ-1E4E9F?style=flat-square)](https://www.csu.ru)
![Тип](https://img.shields.io/badge/репозиторий-учебные_практики-EA580C?style=flat-square)

![C#](https://img.shields.io/badge/-C%23-239120?style=flat-square&logo=csharp&logoColor=white)
![C++](https://img.shields.io/badge/-C%2B%2B-00599C?style=flat-square&logo=cplusplus&logoColor=white)
![Java](https://img.shields.io/badge/-Java-ED8B00?style=flat-square&logo=openjdk&logoColor=white)

</div>

Репозиторий с практиками по **C#**, **ABC** и **Java**.

---

## 📗 1 курс

<details open>
<summary><img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/csharp/csharp-original.svg" width="18" align="top"> <b>C#</b> — 6 практик</summary>
<br>

<details>
<summary><a href="./CSharp/Practice-2">Практика 2</a></summary>

[*Перейти к практике*](https://seadox.ru/docs/7e)

</details>

<details>
<summary><a href="./CSharp/Practice-10">Практика 10</a></summary>

Написать Unit тесты на фреймворке xUnit для файла `CheckerBoardPosition` из лабы 3.

[*Перейти к практике*](https://seadox.ru/docs/avb)

</details>

<details>
<summary><a href="./CSharp/Practice-11">Практика 11</a></summary>

**Практика 11** — Реализовать CRUD-функционал для сущности `Note` (Id, Text, CreatedAt) по аналогии с примером Student из [репозитория учителя](https://github.com/MindHardt/arch-example/tree/efcore). Написать тесты на все CRUD-операции.

[*Перейти к практике*](https://seadox.ru/docs/ulc)

</details>

<details>
<summary><a href="./CSharp/Practice-12">Практика 12</a></summary>

**Практика 12** — Дополнить практику 11, добавив сущность `User`. У одного пользователя может быть много заметок, заметка не может существовать без пользователя. Реализовать CRUD для пользователей и метод получения всех заметок конкретного пользователя.

</details>

<details>
<summary><a href="./CSharp/Practice-13">Практика 13</a></summary>

**Практика 13** E2E тесты для REST API на ASP.NET Core. Реализовать CRUD эндпоинты для сущности Book (Id(int), Name(string), Author(string), ReleaseDate(DateOnly(Nullable))) и написаны E2E тесты через Microsoft.AspNetCore.Mvc.Testing с in-memory SQLite.

[*Перейти к практике*](https://seadox.ru/docs/x3y)

</details>

<details>
<summary><a href="https://github.com/RuDeNoID814/MathEx_Blazor">Практика 14</a> <sup>необязательная</sup></summary>

**Практика 14** — веб-приложение на Blazor SSR. Сделан сборник вопросов/ответов по математическому анализу (MathEx) с карточками: добавление, редактирование, удаление, поиск в реальном времени. Формулы рендерятся через MathJax. Стек: Blazor Web App (SSR + InteractiveServer), EFCore + SQLite, Bootstrap 5.

Основан на проекте [MathEx](https://github.com/RuDeNoID814/MathEx).

[*Перейти к практике*](https://seadox.ru/docs/f57)

</details>

</details>

<details>
<summary><img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/cplusplus/cplusplus-original.svg" width="18" align="top"> <b>ABC</b> — 5 практик <sup>C++ + Assembly</sup></summary>
<br>

<details>
<summary><a href="./ABC/Practice-1">Практика 1</a></summary>

Визуализация представления типов данных на C++. Для введённого числа вывести представление в типах `int`, `float`, `double` в форматах Big-Endian и Little-Endian. Использовать побитовые операции и операции с указателями.

</details>

<details>
<summary><a href="./ABC/Practice-2">Практика 2</a></summary>

Ассемблерная вставка в C++, вычисляет `x=(((a+b)*c)-d)/e`.

- Значения переменных лежат в диапазоне [1, 100]
- Деление целочисленное, остаток отбрасывается

</details>

<details>
<summary><a href="./ABC/Practice-3">Практика 3</a></summary>

`unsigned char a, b;`

Написать ассемблерную вставку, которая вычислит `a+b` и запишет в две переменные типа `bool` наличие переполнения для знаковых/беззнаковых чисел.

Программа должна вывести:
- Результат сложения для чисел со знаком
- Результат сложения для чисел без знака
- Было ли переполнение для чисел со знаком
- Было ли переполнение для чисел без знака

</details>

<details>
<summary><a href="./ABC/Practice-4">Практика 4</a></summary>

Написать ассемблерную вставку, которая перевернёт строку. Например `"Madam, I'm Adam"` → `"madA m'I ,madaM"`. Для решения использовать стек.

</details>

<details>
<summary><a href="./ABC/Practice-5">Практика 5</a></summary>

Написать ассемблерную вставку, которая посчитает факториал числа. Функция должна вызываться рекурсивно с использованием стека.

</details>

</details>

---

## 📘 2 курс

<details open>
<summary><img src="https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/java/java-original.svg" width="18" align="top"> <b>Java</b> — 1 практика</summary>
<br>

<details>
<summary><a href="./Java/lab1">Практика 1</a> <img src="https://img.shields.io/badge/выполнено-8%2F8-brightgreen?style=flat-square" alt="done"></summary>

**Практика 1** — Работа с консольными утилитами JDK (`javac`, `java`, `jar`) без IDE. Все 8 шагов: hello world, разделение на `src/` и `bin/`, два связанных класса, подключение внешнего `.class` через classpath, подключение jar-библиотеки, командный файл, упаковка своего проекта в jar, executable jar с манифестом.

[*Перейти к практике*](https://github.com/ulearn-me-csu-java/javac/blob/master/Prakticheskoe_zadanie_1_Konsolnye_utility_JDK.pdf)

</details>

</details>
