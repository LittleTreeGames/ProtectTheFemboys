using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*

Basically this prevents the camera from rotating
beyond a set angle to prevent clipping through
the character model.

*/


public class CameraRestriction : MonoBehaviour
{
    public float restrictionAngle = -68f;
    
    void Update(){
        // Get current rotation
        var rotation = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform);

        // Make sure camera can't clip into player
        if (rotation.x < restrictionAngle)
        {
            // Set x rotation to max rotation and leave rest as is
            UnityEditor.TransformUtils.SetInspectorRotation(gameObject.transform, new Vector3(restrictionAngle, rotation.y, rotation.z));
        }
    }
}
