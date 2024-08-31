using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{

    [SerializeField] GameObject _patron;
    [SerializeField] GameObject[] _spawnPos;
    [SerializeField] GameObject _effectFire;
    [SerializeField] float _kofSpeed;
    [SerializeField] float _kofStrenght;
    [SerializeField] float _kofDistance;
    public static List<int> ParamGun;
    public static event Action StateParamGun;
    bool _startFire = false;
    void Fire()
    {
        if (ParamGun[2] == 0)
        {
            Instantiate(_patron, _spawnPos[0].transform.position, _spawnPos[0].transform.rotation);
            Instantiate(_effectFire, _spawnPos[0].transform.position, _spawnPos[0].transform.rotation, gameObject.transform);
        }
        else
        {
            Instantiate(_patron, _spawnPos[1].transform.position, _spawnPos[0].transform.rotation);
            Instantiate(_effectFire, _spawnPos[1].transform.position, _spawnPos[0].transform.rotation, gameObject.transform);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartGame();

    }

    public void BonusWeapon()
    {
        if (gameObject.name == "Gun")
            ParamGun = PlayerResurs1.Gun0;
        else if (gameObject.name == "Gun1")
            ParamGun = PlayerResurs1.Gun1;
        else if (gameObject.name == "Gun2")
            ParamGun = PlayerResurs1.Gun2;
        else if (gameObject.name == "Gun3")
            ParamGun = PlayerResurs1.Gun3;
        else if (gameObject.name == "Gun4")
            ParamGun = PlayerResurs1.Gun4;
        else if (gameObject.name == "Gun5")
            ParamGun = PlayerResurs1.Gun5;
        else if (gameObject.name == "Gun6")
            ParamGun = PlayerResurs1.Gun6;
        ParamGuns.Speed = ParamGuns.Speed * _kofSpeed + ParamGun[0] * 10;
        ParamGuns.Strength = ParamGuns.Strength * _kofStrenght + ParamGun[1] * 10;
        ParamGuns.Distance = ParamGuns.Distance * _kofDistance + ParamGun[2] * 10;
    }



    private void OnEnable()
    {
        BonusWeapon();
        StateParamGun?.Invoke();
    }

    private void OnDisable()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    void StartGame()
    {
        BonusWeapon();
        StartCoroutine(DoCheck());
    }

    IEnumerator DoCheck()
    {
        while (ParamGuns.Speed > 0)
        {
            if (!_startFire)
            {
                yield return new WaitForSeconds(1f);
                _startFire = true;
            }

            yield return new WaitForSeconds(60f / ParamGuns.Speed);
            Fire();

        }
    }


}
