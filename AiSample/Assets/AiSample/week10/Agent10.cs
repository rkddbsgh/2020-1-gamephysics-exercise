using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent10 : MonoBehaviour
{
    private Vector3 _pickPos = Vector3.zero;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mouse_pos = Input.mousePosition;

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenToWorldPoint(mouse_pos), -Vector3.up, out hit, 1000))
            {
                _pickPos = hit.point;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_pickPos, 1.0f);
    }
}
