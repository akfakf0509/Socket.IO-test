using System;
using System.Collections;
using System.Collections.Generic;
using Socket.Newtonsoft.Json;
using Socket.Quobject.SocketIoClientDotNet.Client;
using UnityEngine;

public class TestObject : MonoBehaviour {
  private QSocket socket;

    void Start()
    {
        socket = IO.Socket("http://hellfightsocket.run.goorm.io:80");

        socket.On(QSocket.EVENT_CONNECT, () =>
        {
            Debug.Log("Connected");
        });

        Dictionary<string, string> dict = new Dictionary<string, string>();
        dict.Add("text", "test");
        Debug.Log(JsonConvert.SerializeObject(dict));
    }

  private void OnDestroy () {
    socket.Disconnect ();
  }
}