namespace web_api.Entities
{
    public class appUser
    {
        public int Id { get; set; }
        public string userName { get; set; }

        public byte[] PasswordHash {get; set;}
        public byte[] PasswordSalt {get; set;}
    }
}