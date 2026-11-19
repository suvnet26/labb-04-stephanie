namespace PasswordSystem.Tests;

public class PasswordResetServiceTests
{
    [Fact]
    public void SendResetEmail_SendsTokenToCorrectEmail()
    {
        // Arrange
        var fakeEmailProvider = new FakeEmailProvider();
        var fakeTokenGenerator = new FakeTokenGenerator();
        var sut = new PasswordResetService(fakeEmailProvider, fakeTokenGenerator);
        var testEmail = "test@test.com";

        // Act
        sut.SendResetEmail(testEmail);

        // Assert
        var sentEmail = Assert.Single(fakeEmailProvider.SentEmails);
        Assert.Equal(testEmail, sentEmail.To);
        Assert.Contains(fakeTokenGenerator.Token, sentEmail.Body);
    }

 /*Det ska bara gå att begära en lösenordsåterställning
  om e-postadressen redan är registrerad i systemet.*/
[Fact]
public void IsEmailRegistered_ReturnsFalse_WhenEmailIsNotAdded()
{
    var repository = new FakeUserRepository();

    Assert.False(repository.IsEmailRegistered("test@test.com"));
}

[Fact]
public void IsEmailRegistered_ReturnsTrue_WhenEmailIsAdded()
{
    var repository = new FakeUserRepository();
    repository.AddUser("test@test.com", "password");

    Assert.True(repository.IsEmailRegistered("test@test.com"));
}
}
