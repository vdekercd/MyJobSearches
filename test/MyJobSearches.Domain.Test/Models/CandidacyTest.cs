namespace MyJobSearches.Domain.Test.Models;

public class CandidacyTest
{
    [Fact]
    public void Candidacy_CreateSuccess()
    {
        var validCandidacy = CandidacyTestUtility.GetValidCandidacy();
        var candidacy = new Candidacy(validCandidacy.Id, validCandidacy.UserId, validCandidacy.CurriculumVitae,
            validCandidacy.Company, validCandidacy.CompanyEmail, validCandidacy.Filename, validCandidacy.CandidacyDate);
        
        CheckCandidacyProperties(candidacy, validCandidacy);
        CheckCompanyProperties(candidacy, validCandidacy);
        CheckCurriculumVitaeProperties(candidacy, validCandidacy);
    }

    [Fact]
    public void Candidacy_ValidateCandidacy()
    {
        var candidacy = CandidacyTestUtility.GetValidCandidacy();
        var isValid = IsCandidacyValid(candidacy);
        isValid.Should().BeTrue();
    }

    [Fact]
    public void Candidacy_ValidateCandidacy_EmailNotValid()
    {
        var candidacy = CandidacyTestUtility.GetEmailNotValidCandidacy();
        var isValid = IsCandidacyValid(candidacy);
        isValid.Should().BeFalse();
    }

    [Fact]
    public void Candidacy_ValidateCandidacy_DateInFuturNotValid()
    {
        var candidacy = CandidacyTestUtility.GetDateInFutureNotValidCandidacy();
        var isValid = IsCandidacyValid(candidacy);
        isValid.Should().BeFalse();
    }

    private static void CheckCandidacyProperties(Candidacy validCandidacy, Candidacy candidacy)
    {
        candidacy.Id.Should().Be(validCandidacy.Id);
        candidacy.UserId.Should().Be(validCandidacy.UserId);
        candidacy.CompanyEmail.Should().Be(validCandidacy.CompanyEmail);
        candidacy.Filename.Should().Be(validCandidacy.Filename);
        candidacy.CandidacyDate.Should().Be(validCandidacy.CandidacyDate);
    }

    private void CheckCompanyProperties(Candidacy candidacy, Candidacy validCandidacy)
    {
        candidacy.Company.Should().NotBeNull();
        candidacy.Company.Id.Should().Be(validCandidacy.Company.Id);
        candidacy.Company.Name.Should().Be(validCandidacy.Company.Name);
    }

    private void CheckCurriculumVitaeProperties(Candidacy validCandidacy, Candidacy candidacy)
    {
        candidacy.CurriculumVitae.Should().NotBeNull();
        candidacy.CurriculumVitae.Id.Should().Be(validCandidacy.CurriculumVitae.Id);
        candidacy.CurriculumVitae.Filename.Should().Be(validCandidacy.CurriculumVitae.Filename);
    }

    private bool IsCandidacyValid(Candidacy candidacy)
    {
        return new DefaultValidatorStrategy<Candidacy>().IsValid(candidacy)
            && new DefaultValidatorStrategy<Company>().IsValid(candidacy.Company)
            && new DefaultValidatorStrategy<CurriculumVitae>().IsValid(candidacy.CurriculumVitae);
    }
}
