using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour, IPooledObject
{
    private GameObject target;
   
    

    public void OnSpawnObject()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
    }

    
}
