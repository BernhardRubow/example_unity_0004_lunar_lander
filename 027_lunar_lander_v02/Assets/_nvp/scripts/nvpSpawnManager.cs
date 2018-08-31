using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nvpSpawnManager : MonoBehaviour
{

    // +++ public fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++    
    // +++ editor fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _playerPrefab;




    // +++ private fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++




    // +++ unity callbacks ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Start()
    {
        SpawnPlayer(System.Guid.NewGuid().ToString(), true);
		SpawnPlayer(System.Guid.NewGuid().ToString(), false);
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // +++ class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void SpawnPlayer(string id, bool isLocal)
    {
        if(isLocal){
			var player = Instantiate(
				_playerPrefab,
				_spawnPoints[0].position,
				_spawnPoints[0].rotation
			);
			player.GetComponent<nvpPlayerThruster>().isLocal = true;
		}
		else {
			var player = Instantiate(
				_playerPrefab,
				_spawnPoints[1].position,
				_spawnPoints[1].rotation
			);
			player.GetComponent<nvpPlayerThruster>().isLocal = false;
		}
    }

}