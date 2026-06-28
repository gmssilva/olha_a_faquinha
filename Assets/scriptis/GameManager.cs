using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Controle das Moedas")]
    [SerializeField] private int moedasDisponiveis = 7;
    private int moedaAtual = 0;
    private int lucroTotal = 0;
    private const int valorPorMoeda = 100;

    [Header("Spawn das Moedas")]
    [SerializeField] private GameObject espadaParaSpawnar;
    [SerializeField] private Vector2 posicaoInicialDaEspada = new Vector2(0f, -2.5f);

    [Header("Game Over")]
    [SerializeField] private float tempoParaAtivarPainelFinal = 1f;

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
        UIManager.Instance.CarregarIconesDasEspadas(moedasDisponiveis);
        UIManager.Instance.AtualizarLucro(lucroTotal);
        SpawnarNovaEspada();
    }

    public void SpawnarNovaEspada()
    {
        Instantiate(espadaParaSpawnar, posicaoInicialDaEspada, Quaternion.identity);
    }

    public void QuandoAtingirAlvo()
    {
        lucroTotal += valorPorMoeda;
        UIManager.Instance.AtualizarIconeDaEspada(moedaAtual);
        UIManager.Instance.AtualizarLucro(lucroTotal);

        moedasDisponiveis--;
        moedaAtual++;

        if (moedasDisponiveis <= 0)
        {
            StartCoroutine(AtivarPainelFinalCoroutine(true));
        }
        else
        {
            SpawnarNovaEspada();
        }
    }

    public void QuandoAtingirEspada()
    {
        StartCoroutine(AtivarPainelFinalCoroutine(false));
    }

    private IEnumerator AtivarPainelFinalCoroutine(bool venceu)
    {
        yield return new WaitForSeconds(tempoParaAtivarPainelFinal);
        UIManager.Instance.AtivarPainelFinal(venceu, lucroTotal);
    }
}