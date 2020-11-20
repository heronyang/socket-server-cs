# Socket Server in C#

This is simple socket server example written in C#, developed on MacOS.

## Install

```
$ brew cask install mono-mdk
```

## Build

```
$ csc server.cs
```

## Run

```
$ mono server.exe
```

You can test with `telnet` like the following ('@' signals the end of the
connection):

```
$ telnet localhost 12345

Trying ::1...
telnet: connect to address ::1: Connection refused
Trying 127.0.0.1...
Connected to localhost.
Escape character is '^]'.
hello
how are you?
@
Bye bye from server.
Connection closed by foreign host.
```

You can find the server prints out:

```
$ mono server.exe
Waiting connection ...
Connection accepted!
Received (size=7): hello

Received (size=14): how are you?

Waiting connection ...
```

## Reference

- https://www.mono-project.com/docs/about-mono/supported-platforms/macos/
- https://www.geeksforgeeks.org/socket-programming-in-c-sharp/
- https://docs.microsoft.com/en-us/dotnet/api/system.net.sockets.socket.listen?view=net-5.0
