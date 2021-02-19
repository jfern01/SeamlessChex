namespace SeamlessChex.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using SeamlessChex.Models;
    using Xunit;

    public class SeamlessChexClientTests
    {
        private readonly SeamlessChexClient client;

        public SeamlessChexClientTests() =>
            this.client = new SeamlessChexClient("sk_test_01en8e264mt148md2f8xkx6afs", false);

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[]
            {
                new CreateCheckRequest()
                {
                    Amount = 100m,
                    Memo = Guid.NewGuid().ToString(),
                    Label = Guid.NewGuid().ToString(),
                    Number = "12345",
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    BankAccount = "12345678909876",
                    BankRouting = "123456789",
                    Address = "123 Main St.",
                    City = "Smallville",
                    Zip = "12345",
                    Phone = "+1 (555) 555 5555",
                    State = "KS",
                },
                new UpdateCheckRequest()
                {
                    Amount = 200m,
                    Memo = Guid.NewGuid().ToString(),
                    Label = Guid.NewGuid().ToString(),
                    Number = "54321",
                    Name = "John Shepard",
                    Email = "john.shepard@example.com",
                    BankAccount = "12345678909876",
                    BankRouting = "123456789",
                    Address = "1234 Main St.",
                    City = "Lexington",
                    Zip = "23456",
                    State = "KY",

                    // Phone = "(556) 555 5555", Apparently the API ignores this.
                },
            },
        };

        public static string MaskBankAccount(string bankAccount)
        {
            var masked = bankAccount[1..^3];

            return bankAccount.Replace(masked, new string('.', masked.Length));
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void CreateAndGetCheckTest(CreateCheckRequest createCheckRequest, UpdateCheckRequest updateCheckRequest)
        {
            var check = this.client.CreateCheck(createCheckRequest);

            var checkId = check.CheckId;

            _ = check.CheckId.Should().HaveLength(36);
            _ = check.Amount.Should().Be(createCheckRequest.Amount);
            _ = check.Memo.Should().Be(createCheckRequest.Memo);
            _ = check.Label.Should().Be(createCheckRequest.Label);
            _ = check.Number.Should().Be(createCheckRequest.Number);
            _ = check.Name.Should().Be(createCheckRequest.Name);
            _ = check.Email.Should().Be(createCheckRequest.Email);
            _ = check.BankAccount.Should().Be(MaskBankAccount(createCheckRequest.BankAccount));
            _ = check.BankRouting.Should().Be(createCheckRequest.BankRouting);
            _ = check.Address.Should().Be(createCheckRequest.Address);
            _ = check.City.Should().Be(createCheckRequest.City);
            _ = check.Zip.Should().Be(createCheckRequest.Zip);
            _ = check.Phone.Should().Be(createCheckRequest.Phone);
            _ = check.State.Should().Be(createCheckRequest.State);

            check = this.client.GetCheck(checkId);

            _ = check.CheckId.Should().Be(checkId);
            _ = check.Amount.Should().Be(createCheckRequest.Amount);
            _ = check.Memo.Should().Be(createCheckRequest.Memo);
            _ = check.Label.Should().Be(createCheckRequest.Label);
            _ = check.Number.Should().Be(createCheckRequest.Number);
            _ = check.Name.Should().Be(createCheckRequest.Name);
            _ = check.Email.Should().Be(createCheckRequest.Email);
            _ = check.BankAccount.Should().Be(MaskBankAccount(createCheckRequest.BankAccount));
            _ = check.BankRouting.Should().Be(createCheckRequest.BankRouting);
            _ = check.Address.Should().Be(createCheckRequest.Address);
            _ = check.City.Should().Be(createCheckRequest.City);
            _ = check.Zip.Should().Be(createCheckRequest.Zip);
            _ = check.Phone.Should().Be(createCheckRequest.Phone);
            _ = check.State.Should().Be(createCheckRequest.State);

            updateCheckRequest.CheckId = checkId;

            check = this.client.UpdateCheck(updateCheckRequest);

            _ = check.CheckId.Should().Be(checkId);
            _ = check.Amount.Should().Be(updateCheckRequest.Amount);
            _ = check.Memo.Should().Be(updateCheckRequest.Memo);
            _ = check.Label.Should().Be(updateCheckRequest.Label);
            _ = check.Number.Should().Be(updateCheckRequest.Number);
            _ = check.Name.Should().Be(updateCheckRequest.Name);
            _ = check.Email.Should().Be(updateCheckRequest.Email);
            _ = check.BankAccount.Should().Be(MaskBankAccount(updateCheckRequest.BankAccount));
            _ = check.BankRouting.Should().Be(updateCheckRequest.BankRouting);
            _ = check.Address.Should().Be(updateCheckRequest.Address);
            _ = check.City.Should().Be(updateCheckRequest.City);
            _ = check.Zip.Should().Be(updateCheckRequest.Zip);
            _ = check.Phone.Should().Be(createCheckRequest.Phone);
            _ = check.State.Should().Be(updateCheckRequest.State);

            var parameters = new GetChecksParameters()
            {
                Limit = 1,
                Label = updateCheckRequest.Label,
            };

            var collection = this.client.GetChecks(parameters);

            _ = collection.Data.Should().HaveCount(1);
            _ = collection.Data.First().CheckId.Should().Be(checkId);
            _ = collection.Data.First().Amount.Should().Be(updateCheckRequest.Amount);
            _ = collection.Data.First().Memo.Should().Be(updateCheckRequest.Memo);
            _ = collection.Data.First().Label.Should().Be(updateCheckRequest.Label);
            _ = collection.Data.First().Number.Should().Be(updateCheckRequest.Number);
            _ = collection.Data.First().Name.Should().Be(updateCheckRequest.Name);
            _ = collection.Data.First().Email.Should().Be(updateCheckRequest.Email);
            _ = collection.Data.First().BankAccount.Should().Be(MaskBankAccount(updateCheckRequest.BankAccount));
            _ = collection.Data.First().BankRouting.Should().Be(updateCheckRequest.BankRouting);
            _ = collection.Data.First().Address.Should().Be(updateCheckRequest.Address);
            _ = collection.Data.First().City.Should().Be(updateCheckRequest.City);
            _ = collection.Data.First().Zip.Should().Be(updateCheckRequest.Zip);
            _ = collection.Data.First().Phone.Should().Be(createCheckRequest.Phone);
            _ = collection.Data.First().State.Should().Be(updateCheckRequest.State);

            var voided = this.client.VoidCheck(checkId);

            _ = voided.Should().BeTrue();
        }
    }
}
