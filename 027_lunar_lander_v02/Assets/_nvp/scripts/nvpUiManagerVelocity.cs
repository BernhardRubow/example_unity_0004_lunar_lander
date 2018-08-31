using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using newvisionsproject.managers.events;

public class nvpUiManagerVelocity : MonoBehaviour, IVelocityDisplay {

	// +++ public fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++    
	// +++ editor fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	[SerializeField] private Text _verticalValue;
	[SerializeField] private Text _horizontalValue;





	// +++ private fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // +++ unity callbacks ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	void Start () {
	}

    void Update () {
		
	}
    
    
    
    
    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	void OnDestroy(){
	}




    // +++ public class methods +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public void UpdateVelocity(Vector3 vel)
    {
		_verticalValue.text = vel.x.ToString("0.00");
		_horizontalValue.text = vel.y.ToString("0.00");
    }




    // +++ private class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
}

public interface IVelocityDisplay{
    void UpdateVelocity(Vector3 vel);
}
