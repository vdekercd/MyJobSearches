using System.Collections.Immutable;
using MyJobSearches.Domain.Services;

namespace MyJobSearches.Domain.Test.Services
{
    public class CurriculumVitaeServiceTest
    {
        private IRepository<CurriculumVitaeEntity> _curriculumVitaeEntityRepository =
            new InMemoryRepository<CurriculumVitaeEntity>();
        
        private IRepository<CandidacyEntity> _candidacyEntityRepository =
            new InMemoryRepository<CandidacyEntity>();

        [Fact]
        public async Task CurriculumVitaeService_AddNew()
        {
            // Arrange
            var curriculumVitaeService = new CurriculumVitaeService(_curriculumVitaeEntityRepository, _candidacyEntityRepository);
            
            // Act
            var newId = await curriculumVitaeService.AddNewCurriculumVitaeAsync(CurriculumVitaeTestUtility.GetCurriculumVitae());
            
            // Assert
            var result = await _curriculumVitaeEntityRepository.FindAsync(newId);
            result.Should().NotBeNull();
        }
        
        [Fact]
        public async Task CurriculumVitaeService_Update()
        {
            // Arrange
            var curriculumVitaeService = new CurriculumVitaeService(_curriculumVitaeEntityRepository, _candidacyEntityRepository);
            var newFileName = "newFile.pdf";
            
            // Act
            var newId = await curriculumVitaeService.AddNewCurriculumVitaeAsync(CurriculumVitaeTestUtility.GetCurriculumVitae());
            var result = await _curriculumVitaeEntityRepository.FindAsync(newId);
            result.Filename = newFileName;
            await curriculumVitaeService.UpdateCurricilumVitaeAsync(new CurriculumVitaeAdapter().AdaptToCurriculumVitae(result));
            result = await _curriculumVitaeEntityRepository.FindAsync(newId);
            
            // Assert
            result.Filename.Should().Be(newFileName);
        }
        
        [Fact]
        public async Task CurriculumVitaeService_Delete()
        {
            // Arrange
            var curriculumVitaeService = new CurriculumVitaeService(_curriculumVitaeEntityRepository, _candidacyEntityRepository);

            // Act
            var newId = await curriculumVitaeService.AddNewCurriculumVitaeAsync(CurriculumVitaeTestUtility.GetCurriculumVitae());
            var result = await _curriculumVitaeEntityRepository.FindAsync(newId);
            await curriculumVitaeService.DeleteCurriculumVitaeByIdAsync(result.Id);
            Func<Task> action = async () => await _curriculumVitaeEntityRepository.FindAsync(newId);
            
            // Assert
            await Assert.ThrowsAsync<Exception>(action);

        }
    }
}
