using System;
using System.Collections;
using System.Collections.Generic;
using Quobject.SocketIoClientDotNet.Client;
using UnityEngine;
using SimpleJSON;
using Newtonsoft.Json;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
	private Socket socket;

	public InputField id;
	public InputField password;
	public InputField email;
	public InputField username;

	void Start()
	{
		socket = IO.Socket("https://sunrinthonsocket.run.goorm.io");

		socket.On(Socket.EVENT_CONNECT, () =>
		{
			Debug.Log("Connected");
		});

		socket.On("SendClient", (data) =>
		{
			Debug.Log(JSON.Parse(data.ToString()));
		});
	}

	public void TryRegister()
	{
		var send_data = new Dictionary<string, string>
		{
			{"id",id.text },
			{"password",password.text },
			{"email",email.text },
			{"username",username.text }
		};

		socket.Emit("SendServer", JsonConvert.SerializeObject(send_data));
		Debug.Log("Sended");
	}

	private void OnDestroy()
	{
		socket.Disconnect();
	}
}