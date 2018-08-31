using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using newvisionsproject.managers.events;
using System;

public class nvpUiManagerLanding : MonoBehaviour {

	// +++ public fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++    
	// +++ editor fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	[SerializeField] private Text _successText;
	[SerializeField] private Text _failureText;




	// +++ private fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    
    
    
    
    // +++ unity callbacks ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	void Start () {
		SubscribeToEvents();
	}
    
    
    
    
    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	void OnDestroy()
	{
		UnsubscribeFromEvents();
	}

    private void OnPlayerDestroyed(object s, object e)
    {
		_failureText.gameObject.SetActive(true);
    }

    private void OnSaveLanding(object s, object e)
    {
		_successText.gameObject.SetActive(true);
    }




	// +++ class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	void SubscribeToEvents(){
		nvpEventManager.INSTANCE.Subscribe(GameEvents.OnSaveLanding, OnSaveLanding);
		nvpEventManager.INSTANCE.Subscribe(GameEvents.OnPlayerDestroyed, OnPlayerDestroyed);
	}

    void UnsubscribeFromEvents(){
		nvpEventManager.INSTANCE.Unsubscribe(GameEvents.OnSaveLanding, OnSaveLanding);
		nvpEventManager.INSTANCE.Unsubscribe(GameEvents.OnPlayerDestroyed, OnPlayerDestroyed);
	}
}
