using Microsoft.AspNetCore.Identity;

namespace cAthlet.Services
{
    public class GermanIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DefaultError()
       => new IdentityError { Code = nameof(DefaultError), Description = "Ein unbekannter Fehler ist aufgetreten." };

        public override IdentityError DuplicateUserName(string userName)
            => new IdentityError { Code = nameof(DuplicateUserName), Description = $"Der Benutzername '{userName}' ist bereits vergeben." };

        public override IdentityError DuplicateEmail(string email)
            => new IdentityError { Code = nameof(DuplicateEmail), Description = $"Die E-Mail-Adresse '{email}' wird bereits verwendet." };

        public override IdentityError PasswordTooShort(int length)
            => new IdentityError { Code = nameof(PasswordTooShort), Description = $"Das Passwort muss mindestens {length} Zeichen lang sein." };

        public override IdentityError PasswordRequiresNonAlphanumeric()
            => new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = "Das Passwort muss mindestens ein Sonderzeichen enthalten." };

        public override IdentityError PasswordRequiresDigit()
            => new IdentityError { Code = nameof(PasswordRequiresDigit), Description = "Das Passwort muss mindestens eine Ziffer enthalten." };

        public override IdentityError PasswordRequiresUpper()
            => new IdentityError { Code = nameof(PasswordRequiresUpper), Description = "Das Passwort muss mindestens einen Großbuchstaben enthalten." };

        public override IdentityError PasswordRequiresLower()
            => new IdentityError { Code = nameof(PasswordRequiresLower), Description = "Das Passwort muss mindestens einen Kleinbuchstaben enthalten." };

    }
}
