namespace BLL.Models
{
    public class BasicResource
    {
        public int Total { get; set; }
        public int Max { get; set; } = 10;
        public int PerClick { get; set; } = 1;
    }
}