//:OUTPUT
//:INPUT
//:Clobbers
//r - register
//m - memory
//p - address
//= - write
//+ - read and write

#include <iostream>

using namespace std;

int main()
{
    char szMessage[100] = "Madam, I\'m Adam";
    inc

    __asm__ (
        "mov $0, %%rax \n\t" // обнуляем регистр
        "more_chars: \n\t" // цикл для проверки закончилось у нас индекс или нет и дальнейшего пуша
        "cmpb $0, (%0, %%rax, 1) \n\t" // cmp делаем для фантомного вычитания и выставления флагов у регистра
        "je end_chars \n\t" // если zf=1(а это значит, что ничего не осталось), то прыгаем дальше. Если нет, то делаем пуш в стек и инкримирование на следующий байт
        "movb (%0, %%rax, 1), %%al \n\t" // перемещаем как итог наш байт в младший регистр
        "push %%rax \n\t" // пушим этот байт в стек
        "inc %%rcx" // введем так называемый счетчик в другом регистре, потому что в стеке 0 нету
        "inc %%rax \n\t" // переходим к следующему байту
        "jmp more_chars \n\t"

        "end_chars: \n\t"



        :
        :"p"(szMessage)
        :"%rax", "%rcx"
             )
}
