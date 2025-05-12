using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject range;
    void Awake()
    {
        range.SetActive(false);
    }
    void OnMouseOver()
        {
            range.SetActive(true);
        }
        void OnMouseExit()
        {
            range.SetActive(false);
        }
}
