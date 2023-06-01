namespace MendiGames.Utils.Http
{
    public class Response
    {
        public string status;
        public string message;

        public Response()
        {

        }

        public Response(string status, string message)
        {
            this.status = status;
            this.message = message;
        }
    }
}