namespace EmailTemplateApi.Models
{
    public class EmailRequest
    {
        public string Purpose { get; set; }
        public string RecipientName { get; set; }
        public string Tone { get; set; }
    }
}
