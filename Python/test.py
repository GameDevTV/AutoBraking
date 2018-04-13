import socket
import argparse

class SocketConnector:

    s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    
    def __init__(self):
        self.s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

    def connect(self):
        print("Connect")
        
        HOST = '127.0.0.1'
        PORT = 5555
        self.s.connect((HOST, PORT))

    def print_status(self):
        data = self.s.recv(1024)
        print (repr(data))

def main():
    # parser = argparse.ArgumentParser(description='Interacts with the running simulator')
    # parser.add_argument('command', type=str, nargs="*", help='The command to send immediately connected')
    # args = parser.parse_args()

    print("boo")
    sc = SocketConnector()
    sc.connect()

    while True:
        sc.print_status()

    s.close()

if __name__ == '__main__':
    main()