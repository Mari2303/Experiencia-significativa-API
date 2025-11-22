

using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityCreateRequest;
using Entity.Requests.ModuleOperation;

namespace Builders
{
    public class ObjectiveBuilder
    {
        private readonly Objective _objective;

        public ObjectiveBuilder()
        {
            _objective = new Objective
            {
                CreatedAt = DateTime.UtcNow,
                State = true
            };
        }


        /// <summary>
        /// Agrega objetivos relacionados con la experiencia.
        /// </summary>
        public ObjectiveBuilder WithBaseInfo(ObjectiveCreateRequest request)
        {
            _objective.DescriptionProblem = request.DescriptionProblem;
            _objective.ObjectiveExperience = request.ObjectiveExperience;
            _objective.EnfoqueExperience = request.EnfoqueExperience;
            _objective.Methodologias = request.Methodologias;
            _objective.InnovationExperience = request.InnovationExperience;
            _objective.Pmi = request.Pmi; 
            _objective.Nnaj = request.Nnaj;
            
            return this;
        }


        public ObjectiveBuilder WithMonitoring(IEnumerable<MonitoringCreateRequest> request)
        {
            _objective.Monitorings = request.Select(R => new Monitoring

            {
                MonitoringEvaluation = R.MonitoringEvaluation,
                Result = R.Result,
                Sustainability = R.Sustainability,
                Tranfer = R.Tranfer,
                 CreatedAt = DateTime.UtcNow,
                State = true

            }).ToList();
            return this;
        }

        public ObjectiveBuilder WithSupportInfo(IEnumerable<SupportInformationCreateRequest> request)
        {
            _objective.SupportInformations = request.Select(R => new SupportInformation

            {
                Summary = R.Summary,
                MetaphoricalPhrase = R.MetaphoricalPhrase,
                Testimony = R.Testimony,
                FollowEvaluation = R.FollowEvaluation,
                CreatedAt = DateTime.UtcNow,
                State = true


            }).ToList();
            return this;
        }

    

        public Objective Build() => _objective;

    }
}