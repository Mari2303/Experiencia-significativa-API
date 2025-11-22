using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityCreateRequest;
using Entity.Requests.EntityData.EntityDetailRequest;
using Entity.Requests.ModuleOperation;

/// <summary>
/// Builder para construir una evaluación junto con sus criterios asociados.
/// Permite crear una entidad <see cref="Evaluation"/> y una lista de <see cref="EvaluationCriteria"/>
/// de manera ordenada y acumulando la puntuación total.
/// </summary>
public class EvaluationBuilder
{
    private readonly Evaluation _evaluation;
    private readonly List<EvaluationCriteria> _EvaluationCriteria = new();
    private int _totalScore;

    /// <summary>
    /// Inicializa una nueva instancia de <see cref="EvaluationBuilder"/> a partir del DTO de registro.
    /// </summary>
    /// <param name="dto">
    /// Objeto <see cref="EvaluationRegisterDTO"/> con los datos principales de la evaluación.
    /// </param>
    public EvaluationBuilder(EvaluationCreateRequest request)
    {
        _evaluation = new Evaluation
        {
            TypeEvaluation = request.TypeEvaluation,
            AccompanimentRole = request.AccompanimentRole,
            Comments = request.Comments,
            UserId = request.UserId,
            ExperienceId = request.ExperienceId,
            State = true,
            CreatedAt = DateTime.UtcNow
        };
    }

   

    /// <summary>
    /// Agrega los criterios de evaluación y calcula la suma de sus puntajes.
    /// 
    ///  Importante: En esta etapa los criterios aún no tienen asignado el <c>EvaluationId</c>,
    /// solo se preparan para ser guardados posteriormente junto con la evaluación.
    /// </summary>
    /// <param name="criteriaScores">
    /// Colección de <see cref="EvaluationCriteriaInputDTO"/> que contiene los identificadores de los criterios
    /// y la lista de puntajes seleccionados (3 números por cada criterio).
    /// </param>
    /// <returns>
    /// Instancia de <see cref="EvaluationBuilder"/> para encadenar métodos (patrón Fluent Builder).
    /// </returns>
    public EvaluationBuilder AddCriteriaScores(IEnumerable<EvaluationCriteriaDetailRequest> criteriaScores)
    {
        foreach (var c in criteriaScores)
        {
            int scoreSum = c.Scores.Sum(); // Suma los 3 números de cada criterio
            _totalScore += scoreSum;


            var criterEval = new EvaluationCriteria
            {
                CriteriaId = c.CriteriaId,
                Score = scoreSum,
                DescriptionContribution = c.DescriptionContribution,
               
            };

            _EvaluationCriteria.Add(criterEval);
        }
        return this;
    }

    /// <summary>
    /// Finaliza la construcción de la evaluación y asigna el resultado final en base al puntaje total.
    /// </summary>
    /// <returns>
    /// Una tupla con:
    /// <list type="bullet">
    ///   <item><description><see cref="Evaluation"/>: La entidad de la evaluación construida.</description></item>
    ///   <item><description><see cref="List{EvaluationCriteria}"/>: Lista de criterios asociados.</description></item>
    /// </list>
    /// </returns>
    public (Evaluation Evaluation, List<EvaluationCriteria> Criteria) Build()
    {
        _evaluation.EvaluationResult = CalcularResultadoFinal(_totalScore);
        return (_evaluation, _EvaluationCriteria);
    }

    /// <summary>
    /// Calcula el resultado final de la evaluación según el puntaje total acumulado.
    /// </summary>
    /// <param name="totalScore">Suma total de los puntajes de todos los criterios.</param>
    /// <returns>
    /// <c>"Naciente"</c> si el puntaje es menor o igual a 45.  
    /// <c>"Creciente"</c> si el puntaje es menor o igual a 79.  
    /// <c>"Inspiradora"</c> si el puntaje es mayor a 79.  
    /// </returns>
    private string CalcularResultadoFinal(int totalScore) =>
        totalScore <= 45 ? "Naciente" :
        totalScore <= 79 ? "Creciente" : "Inspiradora";
}



