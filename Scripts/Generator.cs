namespace BumpySellotape.Core
{
    public abstract class Generator
    {
        public abstract object Generate();
    }

    public abstract class Generator<T> : Generator
    {
        public override object Generate() => GenerateT();

        public abstract T GenerateT();
    }
}
