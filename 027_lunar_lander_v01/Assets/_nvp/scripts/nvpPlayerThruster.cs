using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using newvisionsproject.managers.events;

public class nvpPlayerThruster : MonoBehaviour {

	// +++ public fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++    
	// +++ editor fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	[SerializeField] private Vector2 _forceFactor;
	[SerializeField] private Vector3 _forceVector;
	// +++ private fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private Rigidbody _rb;
    
    
    
    // +++ unity callbacks ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	void Start () {
		Init();

		StartCoroutine(InformSubscriber());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		_forceVector.x = Input.GetAxis("Horizontal") * _forceFactor.x;
		_forceVector.y = Input.GetAxis("Vertical") * _forceFactor.y;
		_rb.AddForce(_forceVector, ForceMode.Force);
	}
    
    
    
    // +++ coroutines +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	IEnumerator InformSubscriber(){
		while(true){
			nvpEventManager.INSTANCE.InvokeEvent(GameEvents.OnVelocityChanged, this, _rb.velocity);
			yield return new WaitForSeconds(0.3f);
		}
	}
    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	// +++ class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	void Init(){
		_rb = this.GetComponent<Rigidbody>();
	}
}
