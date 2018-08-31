using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using newvisionsproject.managers.events;

public class nvpPlayerThruster : MonoBehaviour
{

    // +++ public fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++    
    public bool isLocal;




    // +++ editor fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private Vector2 _forceFactor;
    [SerializeField] private Vector3 _forceVector;
    // +++ private fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private Rigidbody _rb;
    private IVelocityDisplay _velocityDisplay;



    // +++ unity callbacks ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Start()
    {
        Init();

        StartCoroutine(InformSubscriber());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLocal)
        {
            _forceVector.x = Input.GetAxis("Horizontal") * _forceFactor.x;
            _forceVector.y = Input.GetAxis("Vertical") * _forceFactor.y;
        }
		else 
		{
			_forceVector.x = Input.GetAxis("Horizontal_Remote") * _forceFactor.x;
            _forceVector.y = Input.GetAxis("Vertical_Remote") * _forceFactor.y;
		}

        _rb.AddForce(_forceVector, ForceMode.Force);
    }



    // +++ coroutines +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    IEnumerator InformSubscriber()
    {
        while (true)
        {
            _velocityDisplay.UpdateVelocity(_rb.velocity);
            yield return new WaitForSeconds(0.3f);
        }
    }
    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    // +++ class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Init()
    {
        _rb = this.GetComponent<Rigidbody>();
        _velocityDisplay = this.GetComponentInChildren<IVelocityDisplay>();
    }
}
