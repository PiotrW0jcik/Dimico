namespace Dimico.Server.Infrastructure.Services
{
    public class Result
    {
        public bool Succeded { get; private set; }

        public bool Failure => !this.Succeded;

        public string Error { get; private set; }

        public  static  implicit operator Result  (bool succeded)
            => new Result{ Succeded = succeded};

        public static implicit operator Result(string error)
            => new Result
            {
                Succeded = false,
                Error = error
            };
    }
}
