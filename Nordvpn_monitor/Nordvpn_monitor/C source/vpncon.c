#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <string.h>

int main()
{
	srand(time(0));
	const char *a[6];
	/*a[0] = "de";
	a[1] = "es";
	a[2] = "it";
	a[3] = "fr";
	a[4] = "fi";*/
	a[0] = "cz";
	a[1] = "lv";
	a[2] = "bg";
	a[3] = "al";
	a[4] = "ch";
	a[5] = "gb";

	unsigned int random = rand()%5;

	char command[19];
	strcpy(command, "nordvpn connect ");
	strcat(command, a[random]);
	strcat(command, "\0");
	printf("Executing: %s", command);
	system(command);

	char message[100];
	strcpy(message, "notify-send NORDVPN 'Attempted VPN in [");
	strcat(message, a[random]);
	strcat(message, "]'\0");
	if(system(message) == 0)
        exit(0);
    else
        system("notify-send NORDVPN 'Something went wrong'");
	return 0;
}
