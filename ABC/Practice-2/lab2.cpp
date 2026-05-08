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
    cout << "x=(((a+b)*c)-d)/e - подставь числа в переменные от 1 до 100, чтобы сложить их \n\n" ;
    // Принимаем числа в переменные
    cout << "a = "; cin >> a;
    cout << "b = "; cin >> b;
    cout << "c = "; cin >> c;
    cout << "d = "; cin >> d;
    cout << "e = "; cin >> e;

    __asm__ (
        "mov %1, %%eax \n\t"                                        // 1(a) input add in register eax
        "add %2, %%eax \n\t"                                        // 2(b) addition with register eax(a) = a + b
        "imul %3, %%eax \n\t"                                       // eax = eax * 3(c)
        "sub %4, %%eax \n\t"                                        // eax = eax - 4(d)
        "cdq \n\t"                                                  // расширяем регистр eax, потому что idiv делит edx:eax . Так как мы не используем edx, то там хранится мусор. Мы его расширяем и покрываем нулями
        "mov %5, %%ecx \n\t"                                        // add (5) in register ecx
        "idiv %%ecx \n\t"                                           // делим edx:eax на делитель в ecx

        "mov %%eax, %0 \n\t"                                        // вытаскиваем результат из eax в output (0)

        :"=m"(x)                                                    // OUTPUT
        :"m"(a),"m"(b),"m"(c),"m"(d),"m"(e)                         // INPUT
        :"%eax", "%ecx"                                             // Clobbers

);


    // Выводим x
    cout << "x = " << x << endl;
}
