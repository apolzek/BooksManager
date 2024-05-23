﻿using Bogus;
using BooksManager.Application.Commands.Users;
using BooksManager.Application.Queries.Users;
using BooksManager.Core.Entities;
using BooksManager.Core.Enums;

namespace BooksManager.Tests.Mocks
{
    public static class UserMock
    {
        public static Faker<User> UserFaker => new Faker<User>()
            .CustomInstantiator(f => (
                new User(
                    f.Person.FirstName,
                    f.Person.Email,
                    f.Random.Word(),
                    f.PickRandom<Roles>())
            ));

        public static Faker<CreateUserCommand> CreateUserCommandFaker =>
            new Faker<CreateUserCommand>()
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.Name, f => f.Person.FirstName)
                .RuleFor(x => x.Password, f => f.Random.Word())
                .RuleFor(x => x.Role, f => f.PickRandom<Roles>());

        public static Faker<LoginUserCommand> LoginUserCommandFaker =>
            new Faker<LoginUserCommand>()
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.Password, f => f.Random.Word());

        public static Faker<GetUserByIdQuery> GetUserByIdQueryFaker =>
            new Faker<GetUserByIdQuery>()
                .RuleFor(x => x.Id, f => f.Random.Guid());
    }
}