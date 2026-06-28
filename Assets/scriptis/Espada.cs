using UnityEngine;
using UnityEngine.InputSystem;

public class Espada : MonoBehaviour
{
    [Header("Referências Gerais")]
    private Rigidbody2D oRigidbody2D;

    [Header("Lançamento da Espada")]
    [SerializeField] private float forcaDoLancamento = 20f;
    private bool foiLancada = false;

    private void Start()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ReceberInput();
    }

    private void ReceberInput()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && !foiLancada)
        {
            LancarEspada();
        }
    }

    private void LancarEspada()
    {
        oRigidbody2D.AddForce(new Vector2(0f, forcaDoLancamento), ForceMode2D.Impulse);
        oRigidbody2D.gravityScale = 1f;
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (!foiLancada)
        {
            if (collisionInfo.gameObject.GetComponent<Alvo>() != null)
            {
                oRigidbody2D.linearVelocity = Vector2.zero;
                oRigidbody2D.gravityScale = 0f;
                oRigidbody2D.bodyType = RigidbodyType2D.Static;
                transform.SetParent(collisionInfo.gameObject.transform);

                GameManager.Instance.QuandoAtingirAlvo();
                AudioManager.Instance.impactoAlvo.Play();
            }
            else if (collisionInfo.gameObject.GetComponent<Espada>() != null)
            {
                oRigidbody2D.linearVelocity = Vector2.zero;
                Destroy(this.gameObject, 3f);

                GameManager.Instance.QuandoAtingirEspada();
                AudioManager.Instance.impactoEspada.Play();
            }

            foiLancada = true;
        }
    }
}