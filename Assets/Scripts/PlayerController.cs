using UnityEngine;
using static UnityEditor.FilePathAttribute;


public class PlayerController : MonoBehaviour
{
    
    [SerializeField] FixedJoystick _joystick;
    [SerializeField] FixedJoystick _joystickFire;
    [SerializeField] Animator _animator;
    [SerializeField] float _moveSpeed;
    [SerializeField] GameObject _spawnFire;
    Rigidbody _rigidbody;
    private Vector3 moveVector;
    Vector3 targetDirection;
    Ray ray;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        AnimationScript();
        // ������
        AimHero();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            _rigidbody.linearVelocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.linearVelocity.y, _joystick.Vertical * _moveSpeed);
            transform.rotation = Quaternion.LookRotation(_rigidbody.linearVelocity);

        }
        else
            MovePlayer();




    }

    void MovePlayer()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.z = Input.GetAxisRaw("Vertical");
        _rigidbody.MovePosition(_rigidbody.position + moveVector * _moveSpeed * Time.deltaTime);

    }

    void AnimationScript()
    {
        float AngleForce = Mathf.Atan2(moveVector.z, moveVector.x) * Mathf.Rad2Deg;
        float AngleMove = Mathf.Atan2(targetDirection.z, targetDirection.x) * Mathf.Rad2Deg;
        float SumTest = AngleForce - AngleMove;
        if (SumTest < 0) SumTest += 360;

        if (moveVector.x != 0 || moveVector.z != 0)
            _animator.SetInteger("Run", 1);
        else
            _animator.SetInteger("Run", 0);

        SumTest = SumTest / 360;

        _animator.SetFloat("Blend", SumTest);
    }

    void AimHero()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, out RaycastHit hitInfo) && _joystickFire.Horizontal == 0 && _joystickFire.Vertical == 0)
             {
                 targetDirection = new Vector3(hitInfo.point.x - transform.position.x, 0, hitInfo.point.z - transform.position.z);
                Quaternion rotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _moveSpeed * Time.deltaTime*100f);
              }
        if (_joystickFire.Horizontal != 0 && _joystickFire.Vertical != 0)
        {
            targetDirection = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);
            Quaternion rotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _moveSpeed * Time.deltaTime * 100f);
        }
        

        if (Input.GetMouseButtonUp(0))
        {
            _spawnFire.transform.rotation = new Quaternion(0,0,0,0);
            _animator.SetBool("Fire", false);
        }
        if (Input.GetMouseButtonDown(0))
            _animator.SetBool("Fire", true);
            
    }

    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
       //     Vector3 targetDirection1 = new Vector3(other.transform.position.x - _spawnFire.transform.position.x, other.transform.position.y - _spawnFire.transform.position.y, other.transform.position.z - _spawnFire.transform.position.z);
       //     Quaternion rotation1 = Quaternion.LookRotation(targetDirection1);
       //     _spawnFire.transform.rotation = Quaternion.Lerp(_spawnFire.transform.rotation, rotation1, _moveSpeed * Time.deltaTime);


            

           /* if (_aimPlayer)
            {
                targetDirection = new Vector3(other.transform.position.x - transform.position.x, 0f, other.transform.position.z - transform.position.z);
                Quaternion rotation = Quaternion.LookRotation(targetDirection);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _moveSpeed * Time.deltaTime * 100f);
            //    _animator.SetBool("Fire", true);
            }*/

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _spawnFire.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
