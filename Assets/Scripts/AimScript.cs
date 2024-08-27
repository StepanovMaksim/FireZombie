using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Vector3 targetDirection1 = new Vector3(other.transform.position.x - transform.position.x, other.transform.position.y - transform.position.y, other.transform.position.z - transform.position.z);
            Quaternion rotation1 = Quaternion.LookRotation(targetDirection1);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation1, 50f * Time.deltaTime);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            transform.Rotate(0, 0, 0);
        }
    }
}
