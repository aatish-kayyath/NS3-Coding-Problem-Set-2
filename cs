import socket


def server_program():
    # get the hostname
    host = socket.gethostname()
    port = 5000  # initiate port no above 1024

    server_socket = socket.socket()  # get instance
    # look closely. The bind() function takes tuple as argument
    server_socket.bind((host, port))  # bind host address and port together

    # configure how many client the server can listen simultaneously
    server_socket.listen(2)
    conn, address = server_socket.accept()  # accept new connection
    print("Connection from: " + str(address))
    data = conn.recv(1024).decode()
    print("from connected user: " + str(data))
    f=open(data)
    l=f.read()
    #data = input(' -> ')
    conn.send(l.encode())  # send data to the client

    conn.close()  # close the connection


if __name__ == '__main__':
    server_program()
    
    
    import socket


def client_program():
    host = socket.gethostname()  # as both code is running on same pc
    port = 5000  # socket server port number

    client_socket = socket.socket()  # instantiate
    client_socket.connect((host, port))  # connect to the server

    message = input("enter file name")  # take input

    client_socket.send(message.encode())  # send message
    data = client_socket.recv(1024).decode()  # receive response

    print('Received from server: ' + data)  # show in terminal


    client_socket.close()  # close the connection


if __name__ == '__main__':
    client_program()
