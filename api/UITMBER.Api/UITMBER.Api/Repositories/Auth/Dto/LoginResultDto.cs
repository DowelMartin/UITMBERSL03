namespace UITMBER.Api.Repositories.Auth
{
    public class LoginResultDto
    {
        public bool Success { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Roles { get; set; }
        public string Photo { get; set; }
        public string Error { get; set; }
    }
}