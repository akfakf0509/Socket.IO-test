using System;
using System.Collections;
using System.Collections.Generic;
using Quobject.SocketIoClientDotNet.Client;
using UnityEngine;
using SimpleJSON;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Register : MonoBehaviour
{
	public InputField id;
	public InputField password;
	public InputField email;
	public InputField username;

	public void TryRegister_Fun()
	{
		StartCoroutine(TryRegister());
	}

	IEnumerator TryRegister()
	{
		string serverUrl = "https://unitaemin.run.goorm.io/sunrinthon/auth/signup/";

		WWWForm form = new WWWForm();
		form.AddField("id", id.text);
		form.AddField("password", password.text);
		form.AddField("email", email.text);
		form.AddField("username", username.text);

		id.text = "";
		password.text = "";
		email.text = "";
		username.text = "";

		using (UnityWebRequest www = UnityWebRequest.Post(serverUrl, form))
		{
			yield return www.SendWebRequest();

			if (www.isNetworkError || www.isHttpError)
			{
				Debug.Log(www.error);
			}
			else
			{
				Debug.Log(www.downloadHandler.text);
			}
		}
	}
}