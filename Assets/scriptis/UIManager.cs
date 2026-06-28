using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI das Moedas")]
    [SerializeField] private GameObject painelDasEspadas;
    [SerializeField] private GameObject iconeDaEspada;

    [Header("UI do Lucro")]
    [SerializeField] private TextMeshProUGUI textoLucro;

    [Header("UI do Painel Final")]
    [SerializeField] private GameObject painelFinal;
    [SerializeField] private TextMeshProUGUI textoDoResultado;
    [SerializeField] private TextMeshProUGUI textoLucroFinal;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        if (painelFinal != null)
            painelFinal.SetActive(false);
    }

    public void CarregarIconesDasEspadas(int moedasDisponiveis)
    {
        for (int i = 0; i < moedasDisponiveis; i++)
        {
            GameObject icone = Instantiate(iconeDaEspada, painelDasEspadas.transform);
            icone.transform.localPosition = Vector3.zero;
            icone.transform.localScale = Vector3.one;
        }
    }

    public void AtualizarIconeDaEspada(int moedaAtual)
    {
        painelDasEspadas.transform.GetChild(moedaAtual).GetComponent<Image>().color = Color.black;
    }

    public void AtualizarLucro(int lucro)
    {
        if (textoLucro != null)
            textoLucro.text = "R$ " + lucro.ToString();
    }

    public void AtivarPainelFinal(bool venceu, int lucroTotal)
    {
        if (textoDoResultado != null)
            textoDoResultado.text = venceu ? "LUCRO!" : "FALÊNCIA!";

        if (textoLucroFinal != null)
            textoLucroFinal.text = venceu ? "Você lucrou: R$ " + lucroTotal.ToString() : "Você foi à falência!";

        if (painelFinal != null)
            painelFinal.SetActive(true);

        if (venceu)
            AudioManager.Instance.vitoria.Play();
        else
            AudioManager.Instance.derrota.Play();
    }

    public void ReiniciarPartida()
    {
        SceneManager.LoadScene("CenaJogo");
    }

    public void SairDoJogo()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}