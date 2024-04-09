using DummyClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : Player
{
	NetworkManager _network;

	private void Start()
	{
		StartCoroutine(CoSendPacket());
		_network = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
	}

	private void Update()
	{

	}

	IEnumerator CoSendPacket()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.25f);
			C_Move move = new C_Move();
			move.posX = Random.Range(-50, 50);
			move.posX = 0;
			move.posZ = Random.Range(-50, 50);

			_network.Send(move.Write());
		}
	}
}
