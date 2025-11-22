using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models.ModuleGeographic;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityCreateRequest;
using Entity.Requests.EntityData.EntityDataRequest;
using Entity.Requests.ModuleGeographic;
using Entity.Requests.ModuleOperation;

namespace Builders
{
    public class InstitutionBuilder
    {
        private readonly Institution _institution;

        public InstitutionBuilder()
        {
            _institution = new Institution
            {
                CreatedAt = DateTime.UtcNow,
                State = true
            };
        }

        public InstitutionBuilder WithBasicInfo(InstitutionCreateRequest request)
        {
            _institution.Name = request.Name;
            _institution.Address = request.Address;
            _institution.Phone = request.Phone;
            _institution.CodeDane = request.CodeDane;
            _institution.EmailInstitucional = request.EmailInstitucional;
            _institution.NameRector = request.NameRector;
            _institution.Caracteristic = request.Caracteristic;
            _institution.TerritorialEntity = request.TerritorialEntity;
            _institution.TestsKnow = request.TestsKnow;
            return this;
        }



        public InstitutionBuilder WithAddress(IEnumerable<AddressInfoRequest> request)
        {
            _institution.Addresss = request.Select(R => new Address

            {
                Name = R.Name,
                CreatedAt = DateTime.UtcNow,
                State = true


            }).ToList();
            return this;
        }

        public InstitutionBuilder WithCommune(IEnumerable<CommuneInfoRequest> request)
        {
            _institution.Communes = request.Select(R => new Commune

            {
                Name = R.Name,
                CreatedAt = DateTime.UtcNow,
                State = true


            }).ToList();
            return this;
        }

        public InstitutionBuilder WithDepartament(IEnumerable<DepartamentInfoRequest> request)
        {
            _institution.Departaments = request.Select(R => new Departament

            {
                Name = R.Name,
                CreatedAt = DateTime.UtcNow,
                State = true


            }).ToList();
            return this;
        }

        public InstitutionBuilder WithEEZone(IEnumerable<EEZoneInfoRequest> request)
        {
            _institution.EEZones = request.Select(R => new EEZone

            {
                Name = R.Name,
                CreatedAt = DateTime.UtcNow,
                State = true


            }).ToList();
            return this;
        }



        public InstitutionBuilder WithMunicipality(IEnumerable<MunicipalityInfoRequest> request)
        {
            _institution.Municipalitis= request.Select(R => new Municipality

            {
                Name = R.Name,
                CreatedAt = DateTime.UtcNow,
                State = true


            }).ToList();
            return this;
        }

        public Institution Build() => _institution;

    }
}
