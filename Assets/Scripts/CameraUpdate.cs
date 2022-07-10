using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUpdate : MonoBehaviour
{
    public GameObject tank;
    public float _camVeloc = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(tank.transform.position.x, this.transform.position.y, tank.transform.position.z);

        float _camY = Input.GetAxis("Mouse X");
        float _camX = Input.GetAxis("Mouse Y");

        Vector3 _rotacaoPlayer = transform.localEulerAngles;
        _rotacaoPlayer.y += _camY * _camVeloc;
        this.transform.localEulerAngles = _rotacaoPlayer;
    }
}
