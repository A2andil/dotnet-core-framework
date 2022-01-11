namespace Common.Helpers.JWT
{
    internal class SymmetricSecurityKey
    {
        private object p;

        public SymmetricSecurityKey(object p)
        {
            this.p = p;
        }
    }
}