namespace MyJobSearches.Domain.Adapters
{
    public class CandidacyAdapter
    {
        public Candidacy AdaptToCandidacy(CandidacyEntity candidacyEntity)
        {
            if(candidacyEntity == null) return null!;

            return new Candidacy(
                id: candidacyEntity.Id,
                userId: candidacyEntity.UserId,
                curriculumVitae: new CurriculumVitaeAdapter().AdaptToCurriculumVitae(candidacyEntity.CurriculumVitaeEntity),
                company: AdaptCompany(candidacyEntity),
                companyEmail: candidacyEntity.EmailTo,
                filename: candidacyEntity.Filename,
                candidacyDate: DateOnly.FromDateTime(candidacyEntity.CandidacyDate)
                );
        }

        public CandidacyEntity AdaptToCandidacyEntity(Candidacy candidacy)
        {
            if (candidacy == null) return null!;

            return new CandidacyEntity()
            {
                Id = candidacy.Id,
                UserId = candidacy.UserId,
                EmailTo = candidacy.CompanyEmail,
                Filename = candidacy.Filename,
                CandidacyDate = candidacy.CandidacyDate.ToDateTime(TimeOnly.MinValue),
                CompanyEntity = AdaptCompanyEntity(candidacy),
                CurriculumVitaeEntity = new CurriculumVitaeAdapter().AdaptToCurriculumVitaeEntity(candidacy.CurriculumVitae)
            };
        }

        private Company AdaptCompany(CandidacyEntity candidacyEntity)
        {
            if (candidacyEntity?.CompanyEntity == null) return null!;

            return new Company(
                id: candidacyEntity.CompanyEntity.Id,
                name: candidacyEntity.CompanyEntity.Name);
        }

        private CompanyEntity AdaptCompanyEntity(Candidacy candidacy)
        {
            if (candidacy?.Company == null) return null!;

            return new CompanyEntity()
            {
                Id = candidacy.Company.Id,
                Name = candidacy.Company.Name
            };
        }

        private CurriculumVitaeEntity AdaptCurriculumVitaeEntity(Candidacy candidacy)
        {
            if (candidacy?.CurriculumVitae == null) return null!;

            return new CurriculumVitaeEntity()
            {
                Id = candidacy.CurriculumVitae.Id,
                Filename = candidacy.CurriculumVitae.Filename
            };
        }
    }
}
