using API.Data.Account;
using API.Interfaces.Repositories;
using API.Models;
using API.Services;
using API.Validations;
using FluentValidation;
using Moq;
using Test.Utils;

namespace Test.Services
{
    public class AccountServiceTest
    {
        private List<Account> accounts = new List<Account>();

        [Fact]
        public async Task AccountService_Should_Create_Account_When_Input_Is_Valid()
        {
            //arrange
            var input = new UpsertAccountInput(0, RandomString(128), RandomString(255));
            var repository = SetupAccountRepository();
            var validator = new AccountValidation();
            var service = new AccountService(repository, validator);

            //act
            var result = await service.Create(input);

            //assert
            Assert.Equal(input.Name, result.Name);
            Assert.Equal(input.Description, result.Description);
            Assert.NotEqual(0, result.Id);
        }

        [Fact]
        public async Task AccountService_Should_Fail_Account_When_Input_Is_Invalid_Description()
        {
            //arrange
            var input = new UpsertAccountInput(0, RandomString(128), RandomString(285));
            var repository = SetupAccountRepository();
            var validator = new AccountValidation();
            var service = new AccountService(repository, validator);

            //act-assert
            await Assert.ThrowsAsync<ValidationException>(()=> service.Create(input));
        }

        [Fact]
        public async Task AccountService_Should_Fail_Account_When_Input_Is_Invalid_Name()
        {
            //arrange
            var input = new UpsertAccountInput(0, RandomString(300), RandomString(255));
            var repository = SetupAccountRepository();
            var validator = new AccountValidation();
            var service = new AccountService(repository, validator);

            //act-assert
            await Assert.ThrowsAsync<ValidationException>(() => service.Create(input));
        }

        [Fact]
        public async Task AccountService_Should_Update_Success_With_Valid_Args()
        {
            //arrange
            var input = new UpsertAccountInput(0, RandomString(128), RandomString(255));
            var repository = SetupAccountRepository();
            var validator = new AccountValidation();
            var service = new AccountService(repository, validator);
            var result = await service.Create(input);

            var newName = RandomString(128);
            var newDescription = RandomString(255);

            var updateEntity = new UpsertAccountInput(result.Id, newName, newDescription);


            //act
            var resultUpdate = await service.Update(updateEntity);

            //assert
            Assert.Equal(newName, resultUpdate.Name);
            Assert.Equal(newDescription, resultUpdate.Description);
            Assert.NotEqual(0, result.Id);
        }

        //TODO Test Gets and Deletes, using bellow setup.




        public IAccountRepository SetupAccountRepository()
        {
            var repositoryMock = new Mock<IAccountRepository>();
            repositoryMock.Setup(p => p.GetById(It.IsAny<long>())).Returns<long>((id) => Task.FromResult(accounts.FirstOrDefault(p => p.Id == id) ?? throw new Exception("not found")));
            repositoryMock.Setup(p => p.GetAll()).Returns(() => Task.FromResult(accounts as ICollection<Account>));
            repositoryMock.Setup(p => p.Update(It.IsAny<Account>())).Returns<Account>((entity)  => {
                var currentEntity = accounts.First(p => p.Id == entity.Id);
                currentEntity.Name = entity.Name;
                currentEntity.Description = entity.Description;
                return Task.FromResult(currentEntity);
                });
            repositoryMock.Setup(p => p.Add(It.IsAny<Account>())).Returns<Account>((entity) => {
                entity.Id = new Random().NextLong(99999999999);
                accounts.Add(entity);
                return Task.FromResult(entity);
            });
            //repositoryMock.Setup(p => p.Delete(It.IsAny<long>())).Callback<long>((id)=> { accounts = accounts.Where(p => p.Id != id).ToList(); });

            return repositoryMock.Object;
        }

        private static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
             return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
