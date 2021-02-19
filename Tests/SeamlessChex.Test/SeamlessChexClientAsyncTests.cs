namespace SeamlessChex.Test
{
    using System;
    using System.Threading.Tasks;
    using FluentAssertions;
    using SeamlessChex.Models;
    using Xunit;

    public class SeamlessChexClientAsyncTests
    {
        private readonly SeamlessChexClient client;

        private readonly CreateCheckRequest checkRequest = new CreateCheckRequest()
        {
            Amount = 100m,
            Memo = Guid.NewGuid().ToString(),
            Label = Guid.NewGuid().ToString(),
            Number = "12345",
            Name = "John Doe",
            Email = "john.doe@example.com",
            BankAccount = "1234567890",
            BankRouting = "123456789",
            Address = "123 Main St.",
            City = "Smallville",
            Zip = "12345",
            Phone = "+1 (555) 555 5555",
            State = "KS",
        };

        private string checkId;

        public SeamlessChexClientAsyncTests() =>
            this.client = new SeamlessChexClient("sk_test_01en8e264mt148md2f8xkx6afs");

        [Fact]
        public async Task CreateCheckTestAsync()
        {
            var check = await this.client.CreateCheckAsync(this.checkRequest).ConfigureAwait(false);

            _ = check.CheckId.Should().HaveLength(36);
            _ = check.Amount.Should().Be(this.checkRequest.Amount);
            _ = check.Memo.Should().Be(this.checkRequest.Memo);
            _ = check.Label.Should().Be(this.checkRequest.Label);
            _ = check.Number.Should().Be(this.checkRequest.Number);
            _ = check.Name.Should().Be(this.checkRequest.Name);
            _ = check.Email.Should().Be(this.checkRequest.Email);
            _ = check.BankAccount.Should().Be("1......890");
            _ = check.BankRouting.Should().Be(this.checkRequest.BankRouting);
            _ = check.Address.Should().Be(this.checkRequest.Address);
            _ = check.City.Should().Be(this.checkRequest.City);
            _ = check.Zip.Should().Be(this.checkRequest.Zip);
            _ = check.Phone.Should().Be(this.checkRequest.Phone);
            _ = check.State.Should().Be(this.checkRequest.State);

            this.checkId = check.CheckId;
        }
    }
}
