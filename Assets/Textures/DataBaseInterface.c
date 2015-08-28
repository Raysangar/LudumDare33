#include <sys/types.h>
#include <stdio.h>
#include <string.h>
#include <unistd.h>
#include <sys/stat.h>
#include <fcntl.h>
#include "DataBaseInterface.h"

void getLine(int fd, char *line);

int getSignals(Signal *signals) {
	int fd = open("/fs/sd0/dbfile/devicesignal.txt", O_RDONLY);
	int number, isAnalog, gpio, inOut;
	char line[80], brand[30], model[60];
	int i = 0;

	getLine(fd, line);
	while (line[0] != '\0') {
		sscanf(line, "%s %s %d %d %d %d", brand, model, &number,
				&isAnalog, &gpio, &inOut);
		if (inOut) {
			signals[i].number = number;
			signals[i].isAnalog = isAnalog;
			signals[i].gpio = gpio;
			signals[i].inOut = inOut;
			signals[i].brand = strdup(brand);
			signals[i].model = strdup(model);
			i++;
		}
		getLine(fd, line);
	}
	close(fd);
	return i;
}

void saveRecord(SignalRecord signalRecord) {
	char path[60];
	sprintf(path, "/fs/sd0/dbfile/signalrecord/%s&%s&%d&%d&%d.txt", signalRecord.signal.brand,
			signalRecord.signal.model, signalRecord.signal.number, signalRecord.signal.isAnalog,
			signalRecord.signal.gpio);
	char record[30];
	if (signalRecord.signal.isAnalog)
		sprintf(record, "\n%s %04d", signalRecord.date, signalRecord.value);
	else
		sprintf(record, "\n%s %d", signalRecord.date, signalRecord.value);
	int fd = open(path, O_WRONLY);
	lseek(fd, 0L, SEEK_END);
	write(fd, record, strlen(record));
	close(fd);
}

void getDeviceAddresses(int* addresses, Signal *signals, int signalsCount) {
	int fd = open("/fs/sd0/dbfile/device.txt", O_RDONLY), number, address, i;
	char line[80], brand[40], model[20];
	for (i = 0; i < signalsCount; i++) {
		lseek(fd, 0L, SEEK_SET);
		getLine(fd, line);
		while (line[0] != '\0') {
			sscanf(line, "%s %s %d %x", brand, model, &number, &address);
			if (!strcmp(signals[i].brand, brand)
					&& !strcmp(signals[i].model, model)
					&& signals[i].number == number) {
				addresses[i] = address;
				break;
			}
			getLine(fd, line);
		}
	}
	close(fd);
}

void getRefreshRate(int* refreshRate) {
	int fd = open("/fs/sd0/dbfile/refreshrate.txt", O_RDONLY);
	char line[5];
	getLine(fd, line);
	close(fd);
	sscanf(line, "%d", refreshRate);
}

void getLine(int fd, char *line) {
	char character;
	int i = 0;
	while (read(fd, &character, 1)) {
		if (character == '\n' || character == EOF) break;
		line[i] = character;
		i++;
	}
	line[i] = '\0';
}
