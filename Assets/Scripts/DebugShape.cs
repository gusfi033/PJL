using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugShape : MonoBehaviour
{
    [ColorUsage(true)]
    public Color color;
    private void OnDrawGizmos()
    {
        Gizmos.color = color;

        //Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        //Gizmos.matrix = rotationMatrix;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);

        Gizmos.DrawCube(Vector3.zero,Vector3.one);
    }
}
