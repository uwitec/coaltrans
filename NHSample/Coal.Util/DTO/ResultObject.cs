namespace Coal.Util
{
    public class ResultObject : DTO
    {
        public ResultObject()
            : base("resultObject")
        {
            this.m_content["errorCode"] = 0;
            this.m_content["statusCode"] = 0;
        }

        public int ErrorCode
        {
            get
            {
                return GetInt("errorCode");
            }
            set
            {
                this.m_content["errorCode"] = value;
            }
        }

        public int StatusCode
        {
            get
            {
                return GetInt("statusCode");
            }
            set
            {
                this.m_content["statusCode"] = value;
            }
        }
    }
}
