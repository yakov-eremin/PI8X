#include "Tester.h"
#include "locale.h"

int main()
{
	srand(time(0));
	setlocale(LC_ALL, "rus");
	Tester* test = new Tester();
	test->main_menu();
}