using UnityEngine;

public class Patron : MonoBehaviour
{
    [SerializeField] GameObject _effectTouch;
    [SerializeField] GameObject _effectTouchEnemy;
    [SerializeField] float _speedGun;
    Rigidbody _rb;
    void Start()
    {

        _rb = GetComponent<Rigidbody>();
        _rb.AddRelativeForce(0f, 0f, _speedGun);
        Destroy(gameObject, 5f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.gameObject.tag != "Enemy")
        {
            Instantiate(_effectTouch, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(_effectTouchEnemy, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
