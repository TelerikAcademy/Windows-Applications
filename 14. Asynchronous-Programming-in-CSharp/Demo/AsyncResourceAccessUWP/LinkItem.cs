namespace AsyncResourceAccessUWP
{
    public struct LinkItem
    {
        public string Href;
        public string Text;

        public override string ToString()
        {
            return this.Href + "\n\t" + this.Text;
        }
    }
}
