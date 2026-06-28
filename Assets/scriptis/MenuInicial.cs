using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    [Header("Painéis")]
    [SerializeField] private GameObject painelMenu;
    [SerializeField] private GameObject painelCreditos;

    private void Start()
    {
        painelMenu.SetActive(true);
        painelCreditos.SetActive(false);
    }

    public void IniciarJogo()
    {
        SceneManager.LoadScene("CenaJogo");
    }

    public void AbrirCreditos()
    {
        painelMenu.SetActive(false);
        painelCreditos.SetActive(true);
    }

    public void FecharCreditos()
    {
        painelCreditos.SetActive(false);
        painelMenu.SetActive(true);
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}