namespace ConsoleApp
{
    public class DataBase
    {
        public DataBase()
        {
            Chaine = "Ma chaine";
        }
        public string Chaine {  get;  set; } 

    }

    public class SpecialDatabase :DataBase
    {
        public SpecialDatabase()
        {
            Chaine = "Ma chaine";
        }
    }
   

}
