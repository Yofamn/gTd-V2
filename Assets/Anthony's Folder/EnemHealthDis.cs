using System.Collections;
using System.Collections.Generic;
using TMPro;
using TowerDefense;
using UnityEngine;

public class EnemHealthDis : MonoBehaviour
{
public Camera mainCamera;
    public TextMeshProUGUI hoverHealthText;
    private Health lastHoveredHealth;

    void Awake()
    {
        mainCamera = Camera.main;
        //hoverHealthText = GameObject.FindWithTag("EnemDis")?.GetComponent<TextMeshProUGUI>();
        
    }
    void Update()
    {
        if (hoverHealthText == null)
        {
            GameObject textObject = GameObject.FindWithTag("EnemDis");
            if (textObject != null)
            {
                hoverHealthText = textObject.GetComponent<TextMeshProUGUI>();
            }
        }
        ShowHealthOnHover();
    }

    void ShowHealthOnHover()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Health health = hit.collider.GetComponent<Health>();

            if (health != null && hoverHealthText != null)
            {
                lastHoveredHealth = health;
                hoverHealthText.text = $"Health: {health.getHealth()}";
                hoverHealthText.transform.position = Input.mousePosition;
                hoverHealthText.gameObject.SetActive(true);
                return;
            }
        }

        // Hide text if nothing is hovered or hoverHealthText is null
        if (hoverHealthText != null)
        {
            hoverHealthText.text = $"";
        }
        lastHoveredHealth = null;
    }
}
