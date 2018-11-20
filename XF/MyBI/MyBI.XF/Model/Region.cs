namespace MyBI
{
    public class Region
    {
        public int iD { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Region target = (Region)obj;
            return target != null ? this.Name == target.Name : false;
        }
    }
}
