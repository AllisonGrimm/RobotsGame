using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Transform aimTransform;
    private bool isRight = true;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");//finds the aim game object attached to the player
    }

    private void Update()
    {
        Vector3 mousePosition = GetWorldMousePosition();//Gets current position of the mouse
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;//Gets the correct angle for the object to look at
        aimTransform.eulerAngles = new Vector3(0, 0, angle);//Makes the object point at the mouse
    }

    public static Vector3 GetWorldMousePosition()
    {
        Vector3 vec = GetWorldMousePositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetWorldMousePositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
