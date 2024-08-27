using UnityEngine;

public class FireHero : MonoBehaviour
{
    [SerializeField] GameObject _patron;
    [SerializeField] GameObject _gilza;
    [SerializeField] GameObject _spawnEffect;
    [SerializeField] Transform _spawnWeapon;
    [SerializeField] Transform _spawnGilza;
    [SerializeField] float _coolduwn;
    // Start is called before the first frame update
    float Collduwn;
    private void Start()
    {
        Collduwn = _coolduwn;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _coolduwn -= Time.deltaTime;

            if (_coolduwn < 0)
            {
                Instantiate(_patron, _spawnWeapon.position, _spawnWeapon.rotation);
                Instantiate(_spawnEffect, _spawnWeapon.position, _spawnWeapon.rotation);
                Instantiate(_gilza, _spawnGilza.position, _spawnWeapon.rotation);
                _coolduwn = Collduwn;
            }

        }

        
    }

    
}
