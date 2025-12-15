using UnityEngine;
using UnityEngine.UI; 

public class DynamicCrosshair : MonoBehaviour
{
    public Image ObjetoImagem; 

    [Header(" ")]
    public Sprite Normal;       
    public Sprite Interagiveis;    
    public Sprite bloqueados;      

    [Header(" ")]
    public float Distancia = 5f; 
    public LayerMask Layer;

    void Update()
    {
        UpdateCrosshair();
    }


    void UpdateCrosshair()
    {
        // Cria um raio saindo do centro exato da tela
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Distancia, Layer))
        {
            
            if (hit.collider.CompareTag("Interagiveis"))
            {
                ChangeSprite(Interagiveis);
            }
            
            else if (hit.collider.CompareTag("Bloqueados"))
            {
                ChangeSprite(bloqueados);
            }
            
            else
            {
                ChangeSprite(Normal);
            }
        }
        else
        {
            
            ChangeSprite(Normal);
        }
    }

    void ChangeSprite(Sprite newSprite)
    {
        // Só troca se a imagem for diferente para economizar processamento
        if (ObjetoImagem.sprite != newSprite)
        {
            ObjetoImagem.sprite = newSprite;
        }
    }
}