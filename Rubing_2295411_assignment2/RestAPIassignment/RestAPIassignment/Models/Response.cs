namespace RestAPIassignment.Models
{
    public class Response
    {
        public int statusCode { get; set; }
        public string messageCode { get; set; }
        public Farmer farmer { get; set; }
        public List<Farmer> farmers { get; set; }
    }
}
