namespace UMI.HTTP
{
    public class UMIHTTPClass
    {
        public string getURL(string result)
        {
            string LK = string.Empty;
            switch (result)
            {
                case "getLogin":
                    LK = "http://localhost:8000/api/user/getPlyerLogin/";
                    break;
            }
            return LK;
        }
    }
}