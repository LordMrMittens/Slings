using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [SerializeField] LineRenderer lineRendererLeft;
    [SerializeField] LineRenderer lineRendererRight;
    [field: SerializeField] public Transform ShootingAxis { get; private set; }
    public void DeactivateLineRenderers()
    {
        lineRendererLeft.enabled = false;
        lineRendererRight.enabled = false;
    }
    public void ActivateLineRenderers()
    {
        UpdateSourcePosition();
        lineRendererLeft.enabled = true;
        lineRendererRight.enabled = true;
    }
    public void UpdatePullingPosition(Vector3 position)
    {
        lineRendererLeft.SetPosition(1, position);
        lineRendererRight.SetPosition(1, position);
    }
    public void UpdateSourcePosition()
    {
        lineRendererLeft.SetPosition(0, lineRendererLeft.transform.position);
        lineRendererRight.SetPosition(0, lineRendererRight.transform.position);
    }
}
