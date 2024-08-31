using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron1 : MonoBehaviour
{
    [SerializeField] int _speed;
    Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddRelativeForce(0f, _speed * 100f, 0f);
        Destroy(gameObject, ParamGuns.Distance/100f);
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (!other.gameObject.name.Contains("Coin"))
            Destroy(gameObject);*/
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
