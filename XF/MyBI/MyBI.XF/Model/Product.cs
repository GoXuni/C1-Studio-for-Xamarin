namespace MyBI
{
    public class Product
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
            Product target = (Product)obj;
            return target != null ? this.Name == target.Name : false;
        }
    }
}
