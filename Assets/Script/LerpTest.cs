using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{

    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;
    public Transform pointABCD;

    private float interpolateAmount;
    void Update()
    {
        interpolateAmount = (interpolateAmount + Time.deltaTime/2) % 1f;


        pointABCD.position = CubicLerp(pointA.position, pointB.position, pointC.position, pointD.position, interpolateAmount);
    }

    private Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 ab = Vector3.Lerp(a, b, t);
        Vector3 bc = Vector3.Lerp(a, c, t);

        return Vector3.Lerp(ab, bc, interpolateAmount);
    }

    private Vector3 CubicLerp(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        Vector3 ab_bc = QuadraticLerp(a, b, c, t);
        Vector3 bc_cd = QuadraticLerp(b, c, d, t);

        return Vector3.Lerp(ab_bc, bc_cd, interpolateAmount);
    }
}
