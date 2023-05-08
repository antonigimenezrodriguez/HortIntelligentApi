namespace HortIntelligentApi.Application.Dtos
{
    public class ResultDto<T>
    {
        public IList<string> Errors { get; set; } = new List<string>();
        public T Data { get; set; } = default;
        public int StatusCode { get; set; } = StatusCodes.Status200OK;
        public bool Error
        {
            get
            {
                if ((Errors != null && Errors.Count > 0) || StatusCode != StatusCodes.Status200OK)
                    return true;
                else
                    return false;
            }

        }

        public override string ToString()
        {
            string resultat = string.Empty;

            foreach (var error in Errors)
            {
                resultat += $"{error}\r\n";
            }

            return resultat.Substring(0, resultat.Length - 2);
        }
    }
}
