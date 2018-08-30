using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using newvisionsproject.managers.events;

public class nvpUiManagerVelocity : MonoBehaviour {

	// +++ public fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++    
	// +++ editor fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	[SerializeField] private Text _verticalValue;
	[SerializeField] private Text _horizontalValue;




	// +++ private fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    
    
    
    
    // +++ unity callbacks ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	void Start () {
		SubscribeToEvents();
	}


    // Update is called once per frame
    void Update () {
		
	}
    
    
    
    
    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	void OnDestroy(){
		UnsubscribeFromEvents();
	}

    private void OnVelocityChanged(object s, object e)
    {
        Vector3 vel = (Vector3)e;
		_verticalValue.text = vel.x.ToString();
		_horizontalValue.text = vel.y.ToString();
    }


    // +++ class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void SubscribeToEvents()
    {
        nvpEventManager.INSTANCE.Subscribe(GameEvents.OnVelocityChanged, OnVelocityChanged);
    }

    private void UnsubscribeFromEvents()
    {
        nvpEventManager.INSTANCE.Subscribe(GameEvents.OnVelocityChanged, OnVelocityChanged);
    }

}
