namespace NamiMetal.Enums
{
    public class Status : Enumeration
    {
        public static Status ACTIVE = new(1, nameof(ACTIVE));
        public static Status DEACTIVE = new(1, nameof(DEACTIVE));

        public Status(int id, string name) : base(id, name)
        {
        }
    }
}
