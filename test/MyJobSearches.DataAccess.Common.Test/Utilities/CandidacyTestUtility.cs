namespace MyJobSearches.Common.Test.Utilities;

public class CandidacyTestUtility
{
    public static Candidacy GetValidCandidacy()
    {
        return new Candidacy(
            id: 1,
            userId: Guid.NewGuid(),
            curriculumVitae: CurriculumVitaeTestUtility.GetCurriculumVitae(),
            company: CompanyTestUtility.GetOniryx(),
            companyEmail: "info@damienvdk.com",
            filename: "email.png",
            candidacyDate: new DateOnly(2021, 12, 28));
    }

    public static Candidacy GetEmailNotValidCandidacy()
    {
        return new Candidacy(
            id: 2,
            userId: Guid.NewGuid(),
            curriculumVitae: CurriculumVitaeTestUtility.GetCurriculumVitae(),
            company: CompanyTestUtility.GetOniryx(),
            companyEmail: "info",
            filename: "email.png",
            candidacyDate: new DateOnly(2021, 12, 28));
    }

    public static Candidacy GetDateInFutureNotValidCandidacy()
    {
        return new Candidacy(
            id: 3,
            userId: Guid.NewGuid(),
            curriculumVitae: CurriculumVitaeTestUtility.GetCurriculumVitae(),
            company: CompanyTestUtility.GetOniryx(),
            companyEmail: "info",
            filename: "email.png",
            candidacyDate: new DateOnly(2099, 12, 28));
    }

    public static Candidacy GetWithNullChildrenCandidacy()
    {
        return new Candidacy(
            id: 3,
            userId: Guid.NewGuid(),
            curriculumVitae: null!,
            company: null!,
            companyEmail: "info",
            filename: "email.png",
            candidacyDate: new DateOnly(2099, 12, 28));
    }

}

