using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using newvisionsproject.managers.events;

public class nvpLandingEvaluator : MonoBehaviour {

	// +++ public fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++    
	// +++ editor fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	[SerializeField] private float _horizontalDeathThreshold;
	[SerializeField] private float _verticalDeathThreshold;

	// +++ private fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	private Rigidbody _rb;
    
    
    
    
    // +++ unity callbacks ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	void Start () {
		Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    
    
    
    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag != "Plattform") {
			nvpEventManager.INSTANCE.InvokeEvent(GameEvents.OnPlayerDestroyed, this, null);
		}

		// get velocity of player
		var vel = other.relativeVelocity;

		Debug.LogFormat("Velocity X: {0} - Velocity Y: {1}", vel.x, vel.y);

		if(Mathf.Abs(vel.x) > _horizontalDeathThreshold  || Mathf.Abs(vel.y) > _verticalDeathThreshold){
			nvpEventManager.INSTANCE.InvokeEvent(GameEvents.OnPlayerDestroyed, this, vel);
		}
		else {
			nvpEventManager.INSTANCE.InvokeEvent(GameEvents.OnSaveLanding, this, vel);
		}

	}
	// +++ class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	void Init(){
		_rb = this.GetComponent<Rigidbody>();
	}
}
