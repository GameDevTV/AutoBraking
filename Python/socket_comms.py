import socket
import argparse
import time
import CarProto_pb2
from google.protobuf import text_format

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

def connect():
    print("Connecting...")
    HOST = '127.0.0.1'
    PORT = 5555
    s.connect((HOST, PORT))
    print("Connected to " + HOST + ": " + str(PORT))

def bytes_to_int(bytes):
    result = 0
    for b in bytes:
        result = result * 256 + int(b)
    return result

def read_buffer():
        buf = bytearray(1000) # todo make full size? make list?
        s.recv_into(buf)
        messageSize = buf[0] # todo make larger than 256 message possible
        message = buf[1: messageSize + 1]
        car_stats = CarProto_pb2.CarStats()
        car_stats.ParseFromString(message)
        print("Car speed: " + str(car_stats.speed))

def main():
    word = [0,1,2,3,4]
    print(word[1:len(word)])
    connect()
    time.sleep(1)
    while True:
        read_buffer()
        time.sleep(.5)

if __name__ == '__main__':
    main()
