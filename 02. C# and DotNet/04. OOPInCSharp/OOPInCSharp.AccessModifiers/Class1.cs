namespace OOPInCSharp.AccessModifiers
{
    public class PublicSample
    {
        private InternalSample internalSample = new InternalSample();
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class ProtectedSample
    {
        protected void Print() => Console.WriteLine("Sample");
    }

    public class PrivateSample
    {
        private void Print() => Console.WriteLine("Sample");



    }


    internal class InternalSample
    {
        private void Print() => Console.WriteLine("Sample");

    }
}