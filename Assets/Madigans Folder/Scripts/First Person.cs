using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public class FirstPerson : MonoBehaviour
        {
        public float xAxis;
        public float yAxis;
        float xAxisTurnRate = 365f;
        float yaxisTurnRate = 365f;
        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }


        void LateUpdate()
        {
            float xAxisInput = Input.GetAxis("Mouse Y");
            float yAxisInput = Input.GetAxis("Mouse X");
            xAxis -= xAxisInput * xAxisTurnRate * Time.deltaTime;
            xAxis = Mathf.Clamp(xAxis, -90f, 90f);
            yAxis += yAxisInput * yaxisTurnRate * Time.deltaTime;
            Quaternion newRotation = Quaternion.Euler(xAxis, yAxis, 0f);
            Camera.main.transform.rotation = newRotation;
            
            
        }
    }

}

