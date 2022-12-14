using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnitActionSystem : MonoBehaviour
{

    public static UnitActionSystem Instance { get; private set;}

    [SerializeField ]private Unit selectedUnit;
    [SerializeField] private LayerMask unitsLayerMask;
    public event EventHandler OnSelectedUnitChanged;


    private void Awake()
    {
        if( Instance != null)
        {
            Debug.Log("Multiple Instances of the Singleton Onject Detected:"+transform+ "-" + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


    private void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            if (TryHandleUnitSelection()) return;
            selectedUnit.Move(MouseWorld.GetPosition());
        }
    }


    private bool  TryHandleUnitSelection()
    {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitsLayerMask))
        {
            if (raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                SetSelectedUnit(unit);
                return true;
            }
            


        }
        return false;


    }
  

    private void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;
        OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
      
    }

    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }











}
