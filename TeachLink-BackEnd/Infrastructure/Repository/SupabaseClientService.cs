namespace TeachLink_BackEnd.Infrastructure.Services
{
    public class SupabaseClientFactory
    {
        private readonly string _supabaseUrl;
        private readonly string _supabaseKey;

        public SupabaseClientFactory(IConfiguration configuration)
        {
            _supabaseUrl = configuration["Supabase:SupabaseUrl"];
            _supabaseKey = configuration["Supabase:SupabaseKey"];
        }

        public Supabase.Client CreateClient()
        {
            return new Supabase.Client(
                _supabaseUrl,
                _supabaseKey,
                new Supabase.SupabaseOptions { AutoConnectRealtime = true }
            );
        }

        public Supabase.Client CreateClient(string token)
        {
            var headers = new Dictionary<string, string> { { "Authorization", "Bearer " + token } };

            return new Supabase.Client(
                _supabaseUrl,
                _supabaseKey,
                new Supabase.SupabaseOptions { Headers = headers, AutoConnectRealtime = true }
            );
        }
    }
}
