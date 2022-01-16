using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Camera GameCamera;
    public float PanSpeed = 10.0f;

    private Unit selectedUnit;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        GameCamera.transform.position = GameCamera.transform.position + new Vector3(move.y, 0, -move.x) * PanSpeed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            // left click to select unit
            HandleSelection();
        }
        else if (selectedUnit != null && Input.GetMouseButtonDown(1))
        {
            //right click give order to the unit
            HandleAction();
        }

    }

    private void HandleSelection()
    {
        var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //the collider could be children of the unit, so we make sure to check in the parent
            var unit = hit.collider.GetComponentInParent<Unit>();
            selectedUnit = unit;

            Debug.Log("hit on " + hit.collider.gameObject.name + ", Select = " + unit);
        }
    }

    public void HandleAction()
    {
        var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.name.Equals("Ground"))
            {
                Debug.Log("GOTO: " + hit.point);
                selectedUnit.GoTo(hit.point);
            }
        }
    }
}
