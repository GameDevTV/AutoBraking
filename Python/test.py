import socket
import argparse

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

def connect():
    print("Connect")

    HOST = '127.0.0.1'
    PORT = 5555
    s.connect((HOST, PORT))

def print_status():
    data = s.recv(1024)
    print (repr(data))

def jump():
    command = "jump" #param
    b = bytearray()
    b.extend(map(ord, command))
    s.sendall(b)

def get_speed():
    command = "getSpeed"
    b = bytearray()
    b.extend(map(ord, command))
    s.sendall(b)
    data = s.recv(1024)
    print (data)

def main():
    connect()

if __name__ == '__main__':
    main()
