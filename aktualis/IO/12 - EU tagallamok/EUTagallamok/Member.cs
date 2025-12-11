public class Member
{
   public string Country { get; set; }
   public DateTime JoinDate { get; set; }


   public override string ToString()
   {
      return $"{Country};{JoinDate:yyyy.MM.dd}";
   }
}
