import socket
import argparse
import time

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

def connect():
    print("Connect")
    HOST = '127.0.0.1'
    PORT = 5555
    s.connect((HOST, PORT))

def jump():
    command = "jump" #param
    b = bytearray()
    b.extend(map(ord, command))
    s.sendall(b)

def send_command(command):
    b = bytearray()
    b.extend(map(ord, command))
    s.sendall(b)

def get_speed():
    try:
        command = "getSpeed"
        b = bytearray()
        b.extend(map(ord, command))
        s.sendall(b)
        time.sleep(.1) # hack
        buf = bytearray(100)
        size = s.recv_into(buf)
    except:
        size = 0
    return size

def main():
    connect()
    time.sleep(1)
    send_command("pedal1")
    time.sleep(1)
    while True:
        print(get_speed())
        time.sleep(.5)
        # if (float(currentSpeed) < 15.0):
        #     send_command("pedal.5")
        #     print("faster")
        # else:
        #     send_command("pedal-.2")
        #     print("slower")
        # time.sleep(.5)


if __name__ == '__main__':
    main()
