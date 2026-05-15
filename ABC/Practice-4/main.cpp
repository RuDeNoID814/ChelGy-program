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
    __asm__ (
        "mov $0, %%rax" // перемещаем наш message в регистр
        "more_chars:" // цикл для проверки закончилось у нас индекс или нет и дальнейшего пуша
        "cmpb $0, (%0, %%rax, 1)" // cmp делаем для фантомного вычитания и выставления флагов у регистра
        "je end_chars" // если zf=0(а это значит, что ничего не осталось), то прыгаем дальше. Если нет, то делаем пуш в стек
        "push %%rax
        "jmp more_chars"

        "end_chars:"



        :
        :"p"(szMessage)
        :"%rax"
             )
}
