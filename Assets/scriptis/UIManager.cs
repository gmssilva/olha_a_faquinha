using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI das Espadas")]
    [SerializeField] private GameObject painelDasEspadas;
    [SerializeField] private GameObject iconeDaEspada;

    [Header("UI do Painel Final")]
    [SerializeField] private GameObject painelFinal;
    [SerializeField] private TextMeshProUGUI textoDoResultado;

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

    public void CarregarIconesDasEspadas(int espadasDisponiveis)
    {
        for (int i = 0; i < espadasDisponiveis; i++)
        {
            GameObject icone = Instantiate(iconeDaEspada, painelDasEspadas.transform);
            icone.transform.localPosition = Vector3.zero;
            icone.transform.localScale = Vector3.one;
        }
    }

    public void AtualizarIconeDaEspada(int espadaAtual)
    {
        painelDasEspadas.transform.GetChild(espadaAtual).GetComponent<Image>().color = Color.black;
    }

    public void AtivarPainelFinal(bool venceu)
    {
        if (textoDoResultado != null)
            textoDoResultado.text = venceu ? "VITÓRIA" : "GAME OVER";

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