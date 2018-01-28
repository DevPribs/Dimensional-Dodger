using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UserSpawnNetworkManager : NetworkManager {

    public GameObject cpPrefab;
    public GameObject mpPrefab;
    private bool topPlayerSelected;
    public int connections;

	// Use this for initialization
	void Start () {
        topPlayerSelected = false;
        connections = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        //if(SystemInfo.deviceType == DeviceType.Handheld)
        //{
        //    var player = (GameObject)GameObject.Instantiate(mpPrefab, mpPrefab.transform.position, mpPrefab.transform.rotation);
        //    NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        //}
        if(!topPlayerSelected && SystemInfo.deviceType == DeviceType.Desktop)
        {
            var player = (GameObject)GameObject.Instantiate(cpPrefab, cpPrefab.transform.position, cpPrefab.transform.rotation);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
            topPlayerSelected = true;
        }
        else
        {
            var player = (GameObject)GameObject.Instantiate(mpPrefab, mpPrefab.transform.position, mpPrefab.transform.rotation);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        
    }

    // 	called on the server when a new client connects
    public override void OnServerConnect(NetworkConnection conn)
    {
        connections += 1;
    }

    // caled on the server when a client disconnects.
    public override void OnServerDisconnect(NetworkConnection conn)
    {
        connections -= 1;
        if( connections == 0 )
        {
            topPlayerSelected = false;
        }
        NetworkServer.DestroyPlayersForConnection(conn);
    }
}
