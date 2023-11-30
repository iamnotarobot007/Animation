
using UnityEngine;

public class DoorFun : MonoBehaviour
{
    public float distanceRaycast= 3f;
  
    public Transform door; 
    public float openAngle = 90f; 
    public float closeAngle = 0f;
    private bool isOpen = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceRaycast))
        {
          if (hit.collider.gameObject == gameObject)
          {
            Door();
          }
        }
        }
    }

    private void Door()
    {
        isOpen = !isOpen;
        if (isOpen) Open();
        else Close();
    }

    private void Open()
    {
        door.rotation = Quaternion.Euler(0f, openAngle, 0f);
    }

    private void Close()
    {
        door.rotation = Quaternion.Euler(0f, closeAngle, 0f);
    }
}
