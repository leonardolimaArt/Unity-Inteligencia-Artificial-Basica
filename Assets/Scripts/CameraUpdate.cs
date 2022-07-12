using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUpdate : MonoBehaviour
{
    public GameObject tank;
    public float _camVeloc = 0.7f;
    public bool mouseCam = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (mouseCam)
        {

            if (Input.GetMouseButton(0))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                
                Vector3 CamPos = this.transform.position;
                float _camY = Input.GetAxis("Mouse X");
                float _camX = Input.GetAxis("Mouse Y");

                CamPos.x += -_camY * _camVeloc;
                CamPos.z += -_camX * _camVeloc;
                this.transform.position = CamPos;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            

            //Vector3 _rotacaoPlayer = transform.localEulerAngles;
            //_rotacaoPlayer.y += _camY * _camVeloc;
            //this.transform.localEulerAngles = _rotacaoPlayer;
        }
        else
        {
            this.transform.position = new Vector3(tank.transform.position.x, this.transform.position.y, tank.transform.position.z);

            float _camY = Input.GetAxis("Mouse X");
            float _camX = Input.GetAxis("Mouse Y");

            Vector3 _rotacaoPlayer = transform.localEulerAngles;
            _rotacaoPlayer.y += _camY * _camVeloc;
            this.transform.localEulerAngles = _rotacaoPlayer;
        }
    }
}
