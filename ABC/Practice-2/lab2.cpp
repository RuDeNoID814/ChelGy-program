#include <iostream>
#include <stdio.h>

using namespace std;

//:OUTPUT
//:INPUT
//:Clobbers
//r - register
//m - memory
//p - address
//= - write
//+ - read and write

int main()
{
    int a, b, c, d, e, x;
    // Показываем вставку, по которой делать вычисление
    cout << "x=(((a+b)*c)-d):e - подставь числа в переменные от 1 до 100, чтобы сложить их";
    // Принимаем числа в переменные
    cout << "a = "; cin >> a;
    cout << "b = "; cin >> b;
    cout << "c = "; cin >> c;
    cout << "d = "; cin >> d;
    cout << "e = "; cin >> e;

    __asm__ ()


    // Выводим x
    cout << "x = " << x << endl;
}
