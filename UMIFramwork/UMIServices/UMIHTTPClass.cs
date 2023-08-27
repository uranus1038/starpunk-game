namespace UMI.HTTP
{
    public class UMIHTTPClass
    {
        public string getURL(int result)
        {
            string LK = string.Empty;
            switch (result)
            {
                case 0:
                    LK = "http://localhost:8000/api/user/getPlyerLogin/";
                    break;
                case 1:
                    LK = "http://localhost:8000/api/user/getPlyerData/";
                    break;
            }
            return LK;
        }
    }
}