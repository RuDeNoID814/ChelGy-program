#include <iostream>

//Программа должна запросить значения переменных у пользователя. Написать ассемблерную вставку, которая вычислит a+b и запишет в две переменные типа bool наличие переполнения для знаковых/беззнаковых чисел.
//Программа должна вывести на экран:
//Результат сложения для чисел со знаком
//Результат сложения для чисел без знака
//Было ли переполнение для чисел со знаком
//Было ли переполнение для чисел без знака

using namespace std;

int main()
{
    unsigned char a, b, z; // создаем переменные. т.к char символный тип, то далее будем вводить в int, а потом переводить в char
    bool isSignedOverflow = false; // bool для true/false на флагах of
    bool isUnsignedOverflow = false; // true/false на флагах cf


    cout << "Эта программа позволяет вычислить наличие переполнения для знаковых/беззнаковых чисел. \n\n";
    cout << "Введите переменные a и b, чтобы сложить их: \n\n";
    int tmp; // создам временную переменную для чисда, потому что unsigned char считается как символ
    cout << "Переменная a: "; cin >> tmp; a = (unsigned char)tmp; // вводим число в int, а далее переводим его в unsigned char
    cout << "Переменная b: "; cin >> tmp; b = (unsigned char)tmp;
    cout << "\n\n";

    __asm__ (
        "mov %3, %%al \n\t" // перемещаем a в младший регистр
        "add %4, %%al \n\t" // прибавляем b + a
        "mov %%al, %0 \n\t" // выводим al в z
        "jae uns_cf \n\t" // если cf = 0, то прыгаем дальше
        "movb $1, %2 \n\t" // если cf не 0, то присваиваем true(1) и итог cf = 1 - переполнен
        "uns_cf: \n\t" // метка для прыжка
        "jno sig_of \n\t" // если of = 0, то делаем прыжок
        "movb $1, %1 \n\t" // если of не 0, то присваиваем true(1) и итог of =1 - переполнен
        "sig_of: \n\t" // метка для прыжка
        :"=m"(z), "=m"(isSignedOverflow), "=m"(isUnsignedOverflow) //OUTPUT
        :"m"(a), "m"(b) //INPUT
        :"%eax" //Clobbers
        );


    // Блок для вывода знаковых signed
    if(isSignedOverflow)
        cout << "Знаковый(signed) = " << (int)(signed char)z << " - переполнение произошло \n";
    else
        cout << "Знаковый(signed) = " << (int)(signed char)z << " - переполнения не произошло \n";


    //Блок для вывода беззнаковых unsigned
    if(isUnsignedOverflow)
        cout << "Беззнаковый(unsigned) = " << (int)z << " - переполнение произошло \n";
    else
        cout << "Беззнаковый(unsigned) = " << (int)z << " - переполнения не произошло \n";

    }


//#include <stdio.h>
//:OUTPUT
//:INPUT
//:Clobbers
//r - register
//m - memory
//p - address
//= - write
//+ - read and write
//int main()
//{
//	unsigned char a=254,b=1,z;
//	char isOverFlow=0;
//    __asm__ (
//    "mov %2,%%al \n\t"
//    "add %3,%%al \n\t"
//    "mov %%al,%1 \n\t"
//    "jnc isof \n\t"    ЕСЛИ нетпереполнения то 0 и переходим к isof
//    "movb $1,%0 \n\t"      ЕСЛИ переполнение то 1
//    "isof: \n\t"
//    :"=m"(isOverFlow),"=m"(z):"m"(a),"m"(b):"%eax","memory","cc");
//    printf("%d\n",*(signed char*)(&z));
//    printf("%u\n",z);
//    if(isOverFlow) printf("Overflow (unsigned)\n");
//    else printf("Not Overflow (unsigned)\n");
//	return 0;
//}
