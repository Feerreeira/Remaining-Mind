using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Velocidade de movimento")]
    public float moveSpeed = 5f;
    
    [Tooltip("Gravidade da Idosa")]
    public float gravity = -9.81f;
    
    private CharacterController controller;
    private Vector3 velocity;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        Movement();
        Gravity();
    }
 
    void Movement()
    {
        if (controller == null) return;
        
        // Capturar input WSAD
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");    
        
        // Calcular direção de movimento relativa à rotação do jogador
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        
        controller.Move(move * moveSpeed * Time.deltaTime);
    }
    
    void Gravity()
    {
        if (controller == null) return;
        
        // Se está no chão, reseta a velocidade vertical
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }
        
        // Aplicar gravidade
        velocity.y += gravity * Time.deltaTime;
        
        // Aplicar velocidade vertical
        controller.Move(velocity * Time.deltaTime);
    }
}
