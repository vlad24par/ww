using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var sell = GetElement();
            if(sell != null)
                sell.Select();
        }
        
    }
    
    private Sell GetElement()
    {
        var raycast = RaycastPosition(Input.mousePosition);
        var mousePos = Input.mousePosition;
        mousePos.z = 50f;
        var origin = _camera.ScreenToWorldPoint(mousePos);
        var raycastPhysics = Physics2D.RaycastAll(origin + Vector3.back, 
            Vector3.forward, 100f);
        var isPieceTouched = false;
            
        foreach (var hit in raycastPhysics)
        {
            var sell = hit.transform.GetComponent<Sell>();

            if (sell != null)
                return sell;
        }

        return null;
    }
    
    private static List<RaycastResult> RaycastPosition(Vector3 position)
    {
        PointerEventData pointerData = new PointerEventData (EventSystem.current)
        {
            pointerId = -1,
        };
         
        pointerData.position = position;
 
        List<RaycastResult> results = new List<RaycastResult>();
            
        var eventSystem = EventSystem.current;
        if (eventSystem != null)
        {
            eventSystem.RaycastAll(pointerData, results);
        }

        return results;
    }
}