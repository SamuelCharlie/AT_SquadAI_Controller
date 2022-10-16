using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_To_Cover : MonoBehaviour
{
    public bool x_cover = false;
    public bool y_cover = false;
    public bool in_cover_x = false;
    public bool in_cover_y = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("In Cover");
        if (x_cover)
        {
            in_cover_x = true;
        }

        if (y_cover)
        {
            in_cover_y = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Not In Cover");
        in_cover_x = false;
        in_cover_y = false;

    }
}
