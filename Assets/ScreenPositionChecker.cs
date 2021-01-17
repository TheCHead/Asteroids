using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPositionChecker : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] float teleportProximityOut = 0.1f;
    [SerializeField] float teleportProximityIn = 0.01f;

    // Update is called once per frame
    void Update()
    {
        CheckScreenPosition();
    }

    private void CheckScreenPosition()
    {
        if (Mathf.Abs(transform.position.x) > GetScreenSize().x * (1 + teleportProximityOut))
        {
            transform.position = new Vector3(-(transform.position.x * (1 - teleportProximityIn)), transform.position.y, 0f);
        }

        if (Mathf.Abs(transform.position.y) > GetScreenSize().y + teleportProximityOut)
        {
            transform.position = new Vector3(transform.position.x, -(transform.position.y * (1 - teleportProximityIn)), 0f);
        }
    }

    public static Vector2 GetScreenSize()
    {
        return Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
}
