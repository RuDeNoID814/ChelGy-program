#include <iostream>

using namespace std;

void ShowLeByte (unsigned char* byte, int size)
{
    for (int i = 0 ; i < size ; i++)
    {
        for (int j = 7 ; j >= 0 ; j--)
        {
            if (*(byte + i) & (1 << j))
                cout << "1";
            else
                cout << "0";
        }
    }
}

void ShowBeByte (unsigned char* byte, int size)
{
    for (int i = size - 1 ; i >= 0 ; i--)
    {
        for (int j = 7 ; j >= 0 ; j--)
        {
            if (*(byte + i) & (1 << j))
                cout << "1";
            else
                cout << "0";
        }
    }
}

int main()
{
    cout << "Input your number: ";
    int x;
    cin >> x;

    int it = x;
    float ft = x;
    double de = x;


    cout << "int: \n" << "Little-Endian: "; ShowLeByte((unsigned char*)&it, sizeof(int)); cout <<
     "\n" << "Big-Endian: "; ShowBeByte((unsigned char*)&it, sizeof(int)); cout << "\n";

    cout << "float: \n" << "Little-Endian: "; ShowLeByte((unsigned char*)&ft, sizeof(float)); cout <<
     "\n" << "Big-Endian: "; ShowBeByte((unsigned char*)&ft, sizeof(float)); cout << "\n";

     cout << "double: \n" << "Little-Endian: "; ShowLeByte((unsigned char*)&de, sizeof(double)); cout <<
     "\n" << "Big-Endian: "; ShowBeByte((unsigned char*)&de, sizeof(double)); cout << "\n";
}

