using UnityEngine;
using UnityEngine.InputSystem;

public class XRTouchInputController : MonoBehaviour
{
    [Header("Linterna")]
    public Light flashlight;

    [Header("Disparo")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootForce = 10f;

    [Header("Objeto Color")]
    public Renderer targetRenderer;

    private bool flashlightOn = false;

    void Update()
    {
        var rightController =
            UnityEngine.XR.InputDevices.GetDeviceAtXRNode(
                UnityEngine.XR.XRNode.RightHand);

        if (rightController.TryGetFeatureValue(
            UnityEngine.XR.CommonUsages.triggerButton,
            out bool triggerPressed) && triggerPressed)
        {
            ShootProjectile();
        }

        if (rightController.TryGetFeatureValue(
            UnityEngine.XR.CommonUsages.gripButton,
            out bool gripPressed) && gripPressed)
        {
            ChangeColor();
        }

        if (rightController.TryGetFeatureValue(
            UnityEngine.XR.CommonUsages.primaryButton,
            out bool aPressed) && aPressed)
        {
            ToggleFlashlight();
        }

        if (rightController.TryGetFeatureValue(
            UnityEngine.XR.CommonUsages.secondaryButton,
            out bool bPressed) && bPressed)
        {
            Debug.Log("Botón B presionado");
        }
    }

    void ToggleFlashlight()
    {
        flashlightOn = !flashlightOn;
        flashlight.enabled = flashlightOn;
    }

    void ShootProjectile()
    {
        if (projectilePrefab == null || firePoint == null)
            return;

        GameObject bullet = Instantiate(
            projectilePrefab,
            firePoint.position,
            firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity =
                firePoint.forward * shootForce;
        }
    }

    void ChangeColor()
    {
        if (targetRenderer == null)
            return;

        targetRenderer.material.color =
            Random.ColorHSV();
    }
}