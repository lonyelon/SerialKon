# SerialKon
Terminal app for writting information to serial.

## Commands
### serial
Edits serial configuration, like the serial port or rate.
```
serial set name COM3
serial set rate 9600
```
It also can be used to connect/disconnect from the serial.
```
serial connect
serial close
```
There is an specific serial command for help too.
```
serial help
```

### write
Writes a value to the serial. The value must be betwen 0 and 255 (both included).
```
serial write 4
```

### help
Shows the help _/(*_*)\_
```
help
```

### clear
Clears the console
```
clear
```
