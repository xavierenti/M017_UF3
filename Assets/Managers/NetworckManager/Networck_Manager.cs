using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Net.Sockets;
using UnityEngine;

public class Networck_Manager : MonoBehaviour
{
    public static Networck_Manager _NETWORCK_MANAGER;

    private TcpClient socket;
    private NetworkStream stream;
    private StreamWriter writer;
    private StreamReader reader;
    private bool connecter = false;

    const string host = "localhost";
    const int port = 1213;


    private void Awake()
    {
        if (_NETWORCK_MANAGER != null && _NETWORCK_MANAGER != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _NETWORCK_MANAGER = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void ManageData(string data)
    {
        if(data == "ping")
        {
            Debug.Log("Recibo ping");
            writer.WriteLine("1");
            writer.Flush();
        }
    }

    private void Update()
    {
        if (connecter)
        {
            if (stream.DataAvailable)
            {
                string data =reader.ReadLine();
                if (data != null)
                {
                    ManageData(data);
                }
            }
        }
    }

    public void ConnectToServer(string nick, string password)
    {
        try
        {
            socket = new TcpClient(host, port);
            stream = socket.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);
            connecter = true;

            writer.WriteLine("0/" + nick + "/" + password);
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
