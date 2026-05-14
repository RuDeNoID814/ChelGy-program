#include <iostream>

//unsigned char a,b;
//
//Программа должна запросить значения переменных у пользователя. Написать ассемблерную вставку, которая вычислит a+b и запишет в две переменные типа bool наличие переполнения для знаковых/беззнаковых чисел.
//Программа должна вывести на экран:
//Результат сложения для чисел со знаком
//Результат сложения для чисел без знака
//Было ли переполнение для чисел со знаком
//Было ли переполнение для чисел без знака
//Пример:
//a=255
//b=255
//a+b=-2 (signed)
//a+b=254 (unsigned)
//no overflow (signed)
//overflow (unsigned)
//Необходимо изучить команды: jc, jnc, jo,jno

using namespace std;



int main()
{
    unsigned char a, b, z;
    bool notOverFlow, isOverFlow = 0;


    cout << "Эта программа позволяет вычислить наличие переполнения для знаковых/беззнаковых чисел. \n\n";
    cout << "Введите переменные a и b: \n\n";
    cout << "Переменная a: "; cin >> a;
    cout << "Переменная b: "; cin >> b;



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
//    "jnc isof \n\t"
//    "movb $1,%0 \n\t"
//    "isof: \n\t"
//    :"=m"(isOverFlow),"=m"(z):"m"(a),"m"(b):"%eax","memory","cc");
//    printf("%d\n",*(signed char*)(&z));
//    printf("%u\n",z);
//    if(isOverFlow) printf("Overflow (unsigned)\n");
//    else printf("Not Overflow (unsigned)\n");
//	return 0;
//}
