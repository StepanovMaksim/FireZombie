using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float _healf;
    [SerializeField] float _moveSpeed;
    [SerializeField] GameObject[] _enemyStates;
    [SerializeField] GameObject _deadEffect;
    [SerializeField] GameObject _damageEffect;
    [SerializeField] GameObject _hero;
    [SerializeField] Animator _animator;

    Rigidbody rb;
    float maxHealf;
    int damageStep = 0;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxHealf = _healf;
    }

    private void FixedUpdate()
    {
      //  Vector3 targetMove = (_hero.transform.position - transform.position).normalized;
        transform.LookAt(new Vector3(_hero.transform.position.x, 0, _hero.transform.position.z));
        //rb.MovePosition(rb.transform.position + targetMove*_moveSpeed*Time.deltaTime);
        rb.linearVelocity = transform.TransformVector(new Vector3(0f,0f,_moveSpeed));
    
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Gun")
        {
            if (_healf > 0)
            {
                _healf -= 10f;
                stateEnemy();

                if (_healf/maxHealf < 0.7f && damageStep < 1)
                {
                    Instantiate(_damageEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    damageStep += 1;
                }
                if (_healf / maxHealf < 0.3f && damageStep == 1)
                {
                    Instantiate(_damageEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    damageStep += 1;
                }
            }
            else
            {
                Instantiate(_damageEffect, transform.position, Quaternion.identity);
                Instantiate(_deadEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

        }
    }

    /*private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Hero")
            _animator.SetBool("Hit", true);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Hero")
            _animator.SetBool("Hit", false);
    }*/

    void stateEnemy()
    {
        for (int i = 0; i < _enemyStates.Length; i++)
        {
            if (_healf / maxHealf > 0.7f)
            {
                if (i == 0)
                    _enemyStates[i].SetActive(true);
                else _enemyStates[i].SetActive(false);
            }
            else if (_healf / maxHealf <= 0.7f && _healf / maxHealf > 0.3f)
            {
                if (i == 1)
                    _enemyStates[i].SetActive(true);
                else _enemyStates[i].SetActive(false);
            }
            else
            {
                if (i == 2)
                    _enemyStates[i].SetActive(true);
                else _enemyStates[i].SetActive(false);

            }

        }
    }
}
