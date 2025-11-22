using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityUpdateRequest;

namespace Service.Extensions
{
    public static class EvaluationPatchExtensions
    {
        /// <summary>
        /// Aplica los cambios enviados en el request a la evaluación existente
        /// y recalcula el resultado final con base en los nuevos criterios,
        /// siguiendo la misma lógica del EvaluationBuilder.
        /// </summary>
        public static void ApplyPatch(this Evaluation evaluation, EvaluationUpdateRequest request)
        {
            if (evaluation == null || request == null)
                return;

            // 🔹 1️⃣ Actualizar campos base (igual que en el builder)
            if (!string.IsNullOrWhiteSpace(request.TypeEvaluation))
                evaluation.TypeEvaluation = request.TypeEvaluation;

            if (!string.IsNullOrWhiteSpace(request.AccompanimentRole))
                evaluation.AccompanimentRole = request.AccompanimentRole;

            if (!string.IsNullOrWhiteSpace(request.Comments))
                evaluation.Comments = request.Comments;

            if (request.ExperienceId > 0)
                evaluation.ExperienceId = request.ExperienceId;

            if (request.UserId > 0)
                evaluation.UserId = request.UserId;

            

            // 🔹 2️⃣ Limpiar y volver a llenar los criterios
            if (request.EvaluationCriteriaDetailRequest != null && request.EvaluationCriteriaDetailRequest.Any())
            {
                // Reiniciar lista de criterios
                evaluation.EvaluationCriterias ??= new List<EvaluationCriteria>();
                evaluation.EvaluationCriterias.Clear();

                int totalScore = 0;

                // Volver a construir cada criterio igual que el builder
                foreach (var c in request.EvaluationCriteriaDetailRequest)
                {
                    int scoreSum = (c.Scores != null && c.Scores.Any()) ? c.Scores.Sum() : 0;
                    totalScore += scoreSum;

                    var newCriteria = new EvaluationCriteria
                    {
                        EvaluationId = evaluation.Id,
                        CriteriaId = c.CriteriaId,
                        Score = scoreSum,
                        DescriptionContribution = c.DescriptionContribution
                       
                    };



                    evaluation.EvaluationCriterias.Add(newCriteria);
                }

                // 🔹 3️⃣ Recalcular resultado final (igual que en el builder)
                evaluation.EvaluationResult = CalcularResultadoFinal(totalScore);
            }
        }

        /// <summary>
        /// Calcula el resultado final igual que en el EvaluationBuilder.
        /// </summary>
        private static string CalcularResultadoFinal(int totalScore)
        {
            if (totalScore <= 45)
                return "Naciente";
            else if (totalScore <= 79)
                return "Creciente";
            else
                return "Inspiradora";
        }
    }
}



