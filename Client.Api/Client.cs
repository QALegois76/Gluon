using System.ComponentModel.DataAnnotations;

namespace Client.Api
{
    public class Client
    {
        [Key]
        public Guid Guid { get; set; } = Guid.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public byte Age { get; set; } = 0;

        public EGender Gender { get; set; } = EGender.Nonbinary;

        public DateTime Created { get; set; } = DateTime.MinValue;


        public override bool Equals(object? obj)
        {
            if (obj is Client c)
                return this.Guid == c.Guid;
            return false;
        }

        public override string ToString()
        {
            return $"({this.Guid}) -> {this.FirstName} {this.LastName} {this.Age} years";
        }

        public void Copy(Client other)
        {
            this.FirstName = other.FirstName;
            this.LastName = other.LastName;
            this.NickName = other.NickName;
            this.Gender = other.Gender;
            this.Age = other.Age;
        }
    }

    public enum EGender
    {
        Male,
        Female,
        Nonbinary,
        Other
    }
}
