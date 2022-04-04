using Test.Infraestructure.Entities;

namespace Test.Infraestructure.Specifications
{
    public class AuthSpecification : Specification<User>
    {
        public AuthSpecification(string username, string password)
        : base(x => (x.Username == username || x.Email == username) && x.Password == password) { }
    }
}