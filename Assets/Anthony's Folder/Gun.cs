using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] GameObject projectile;
        [SerializeField] float rateOfFire = 1f;



        private void Start()
        {

        }
        public float GetRateOfFire()
        {
            return rateOfFire;   
        }

        public void Fire()
        {
            Instantiate(projectile, transform.position, transform.rotation);     
                        //you can use transform.position instead of gunPoint.position
                        //if this script is attached directly to a gunpoint
        }
    }
}