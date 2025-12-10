using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Tooltip("Transform da câmera (Main Camera child)")]
    public Transform cameraplayer;
    
    [Tooltip("Sensibilidade")]
    public float mouseSensitivity = 2f;
    
    [Tooltip("Ângulo máximo")]
    public float maxLookAngle = 80f;
    
    // Controle de rotação
    private float xRotation = 0f;
    
    void Start()
    {
        // Travar e esconder o cursor no centro da tela
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
    
    void Update()
    {
        HandleCameraRotation();
    }
    
    void HandleCameraRotation()
    {
        if (cameraplayer == null) return;
        
        // Capturar movimento do mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        // ROTAÇÃO VERTICAL (câmera para cima/baixo)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxLookAngle, maxLookAngle);
        cameraplayer.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        // ROTAÇÃO HORIZONTAL (corpo do jogador esquerda/direita)
        transform.Rotate(Vector3.up * mouseX);
    }
}
