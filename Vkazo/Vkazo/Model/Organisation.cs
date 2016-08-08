using System.ComponentModel;

namespace Vkazo.Model
{
    public class Organisation : Base
    {
        public string Image { get; set; }
        public string Founder { get; set; }
        public string FoundingYear { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Telephonenumber { get; set; }
    }
}