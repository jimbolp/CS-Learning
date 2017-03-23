// Cpp Shift.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "iostream";


int main()
{
	int n = 0;
	int repeat = 0;
	std::cin >> n >> repeat;
	for (int i = 0; i < repeat; ++i) {
		std::cout << (n<<1) << "\n";
	}
	system("pause");
    return 0;
}

