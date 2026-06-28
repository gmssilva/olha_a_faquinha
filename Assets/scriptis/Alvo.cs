using UnityEngine;

public class Alvo : MonoBehaviour
{
    [Header("Rotação do Alvo")]
    [SerializeField] private int[] velocidadesDeRotacao = { 90, 180, -90, -180 };
    private int velocidadeDeRotacaoAtual;

    [Header("Cronômetro da Troca de Velocidade")]
    [SerializeField] private float tempoMaximoParaTrocarVelocidade = 2f;
    private float tempoAtualParaTrocarVelocidade;

    private void Update()
    {
        RodarCronometroDaTrocaDeVelocidade();
        RotacionarAlvo();
    }

    private void RodarCronometroDaTrocaDeVelocidade()
    {
        tempoAtualParaTrocarVelocidade -= Time.deltaTime;
        if (tempoAtualParaTrocarVelocidade <= 0)
        {
            EscolherNovaVelocidadeDeRotacao();
            tempoAtualParaTrocarVelocidade = tempoMaximoParaTrocarVelocidade;
        }
    }

    private void EscolherNovaVelocidadeDeRotacao()
    {
        if (velocidadesDeRotacao == null || velocidadesDeRotacao.Length == 0)
        {
            Debug.LogWarning("Array 'velocidadesDeRotacao' está vazio! Adicione valores no Inspector.");
            return;
        }

        velocidadeDeRotacaoAtual = velocidadesDeRotacao[Random.Range(0, velocidadesDeRotacao.Length)];
    }

    private void RotacionarAlvo()
    {
        transform.Rotate(0f, 0f, velocidadeDeRotacaoAtual * Time.deltaTime);
    }
}