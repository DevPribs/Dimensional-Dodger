using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UserSpawnNetworkManager : NetworkManager {

    public GameObject cpPrefab;
    public GameObject mpPrefab;
    public int topPlayerSelected;

	// Use this for initialization
	void Start () {
        topPlayerSelected = -1;
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
        if(topPlayerSelected == -1 && SystemInfo.deviceType == DeviceType.Desktop)
        {
            var player = (GameObject)GameObject.Instantiate(cpPrefab, cpPrefab.transform.position, cpPrefab.transform.rotation);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
            topPlayerSelected = conn.connectionId;
        }
        else
        {
            var player = (GameObject)GameObject.Instantiate(mpPrefab, mpPrefab.transform.position, mpPrefab.transform.rotation);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
        
    }

    // caled on the server when a client disconnects.
    public override void OnServerDisconnect(NetworkConnection conn)
    {
        if( conn.connectionId == topPlayerSelected )
        {
            topPlayerSelected = -1;
        }
        NetworkServer.DestroyPlayersForConnection(conn);
    }
}
